using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Windows_From_SGBD_2
{
    public partial class Form1 : Form
    {
        private string conString = "Data Source=DESKTOP-FK8H31S\\SQLEXPRESS;Initial Catalog=Sateliten;Integrated Security=True";
        DataTable parentDataTable, childDataTable;
        string parentTableName, childTableName;
        string PK_column_name, FK_column_name, PK_childTable;
        string current_selected_child, current_selected_parent;

        /// <summary>
        /// Salveaza valoarea pk a randului selectat momentan
        /// Activeaza butoanele de comanda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow clickedRow = childTable.Rows[e.RowIndex];
            current_selected_child = clickedRow.Cells[PK_childTable].Value.ToString();
            deleteButton.Enabled = true;
            updateButton.Enabled = true;
            addButton.Enabled = true;
        }


        /*
         Folosind functia Update() de la SqlDataAdapter, salvam modificarile facute la DataSet
         Calls the respective INSERT, UPDATE, or DELETE statements for each inserted, updated, or deleted row in the specified DataSet from a DataTable - docs.Microsoft.com
             */
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    // salveaza randul modificat
                    DataRowView drv = childTable.CurrentRow.DataBoundItem as DataRowView;
                    DataRow[] rowsToUpdate = new DataRow[] { drv.Row };

                    string sqlString = "SELECT * FROM " + childTableName + " WHERE " + FK_column_name + " = @parentPK_Col;";

                    SqlCommand sqlCom = new SqlCommand(sqlString, con);
                    sqlCom.Parameters.AddWithValue("@parentPK_Col", current_selected_parent);

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCom);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(rowsToUpdate);
                    messageLabel.Text = ":D";

                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    messageLabel.Text = "Hmmm try valid input? maybe that way it works idk";
                }
            }

        }

        /*
         Cand este pus focus-ul pe un rand din tabel se executa urmatoarea functie
         In cazul un care este un rand nou, completeaza automat PK-ul si Fk-ul catre parinte (aceastea fiind readOnly pt user)
         Daca sunt FK-ul aditionale la tabelul copil... ghinion, ce sa zic, crapa daca nu sunt valori preexistente
             */
        private void ChildTable_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    DataGridViewRow clickedRow = childTable.Rows[e.RowIndex];
                    //string childTable_PK_value = clickedRow.Cells[PK_childTable].Value.ToString();

                    // daca e rand nou, completeaza cu urmatorul ID (tabelele mele nu au auto increment, sadly) update: acum au, da tot imi trb aia
                    if(clickedRow.Cells[PK_childTable].Value == null)
                    {
                        string queryString = "SELECT MAX(" + PK_childTable + ") FROM " + childTableName;
                        SqlCommand getID = new SqlCommand(queryString, con);
                        SqlDataReader reader = getID.ExecuteReader();
                        reader.Read();
                        int id = reader.GetInt32(0);
                        reader.Close();
                        id++;

                        // seteaza valorile coloanelor readOnly
                        clickedRow.Cells[PK_childTable].Value = id;
                        clickedRow.Cells[FK_column_name].Value = current_selected_parent;

                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /*
         Fnctioneaza pe acelasi principiu ca si UpdateButton_Click. Legit. Same sh..stuff.
         Dar mi-am dat seama prea tarziu de asta asa ca am 2 butoane care fac acelasi lucru. 
         Macar au nume diferite si contribuie la look-ul general.
         
         User: so they're the same?
         Me: Yes, but actually no
             */
        private void AddButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    DataRowView drv = childTable.CurrentRow.DataBoundItem as DataRowView;
                    DataRow[] rowsToUpdate = new DataRow[] { drv.Row };

                    string sqlString = "SELECT * FROM " + childTableName + " WHERE " + FK_column_name + " = @parentPK_Col;";

                    SqlCommand sqlCom = new SqlCommand(sqlString, con);
                    sqlCom.Parameters.AddWithValue("@parentPK_Col", current_selected_parent);

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCom);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(rowsToUpdate);
                    messageLabel.Text = ":D";

                    ChildTable_UpdateContent(current_selected_parent);

                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    messageLabel.Text = "Hmmm try valid input? maybe that way it works idk";
                }
            }
        }



        /// <summary>
        /// Se apeleaza cand este selectat un rand din tabelul parinte
        /// Updateaza continutul din tabelul copil
        /// Salveaza valoarea Pk a randului selectat momentan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteButton.Enabled = false;
            updateButton.Enabled = false;
            addButton.Enabled = false;

           
            if (e.RowIndex < 0)
            {   //why you click header
                return;
            }
            DataGridViewRow clickedRow = parentTable.Rows[e.RowIndex];
            
            // extragem FK din tabelul parinte
            string parentTable_PK = clickedRow.Cells[PK_column_name].Value.ToString();
            current_selected_parent = parentTable_PK;

            // updatatam tabelul copil cu datele corespunzatoare FK-ului [parentTable_FK]
            ChildTable_UpdateContent(parentTable_PK);
        }


        /*
         Avem numele tabelelor salvate, avem Pk-urile salvate
         Tot ce mai trebuie e sa fie apasat butonul ala mare, rosu si amenintator si gata, apocalipsa.
             */
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string sqlString = "DELETE FROM " + childTableName + " WHERE " + PK_childTable + "= @pk_kid;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();

                    // adauga parametrii la comanda sql
                    SqlCommand sqlDeleteCom = new SqlCommand(sqlString, con);
                    sqlDeleteCom.Parameters.AddWithValue("@pk_kid", current_selected_child);
                    int rowsDeleted = sqlDeleteCom.ExecuteNonQuery();
                    
                    if (rowsDeleted > 0)
                        MessageBox.Show("Row Deleted!! Let's delete another one!");
                    else
                        MessageBox.Show("No row Deleted :(");

                    ChildTable_UpdateContent(current_selected_parent);

                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }


        /// <summary>
        /// Updateaza continutul tabelului copil dupa o valoare data
        /// </summary>
        /// <param name="parentPK">valoarea FK dupa care se umple tabelul copil</param>
        private void ChildTable_UpdateContent(string parentPK)
        {
            // stringul comenzi sql
            string sqlString = "SELECT * FROM " + childTableName + " WHERE " + FK_column_name + " = @parentPK_Col;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                // adaugam parametrii la comanda sql
                SqlCommand sqlCom = new SqlCommand(sqlString, con);
                sqlCom.Parameters.AddWithValue("@parentPK_Col", parentPK);

                // umple tabelul copil cu valorile gasite de [sqlCom]
                try
                {
                    con.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCom);
                    childDataTable = new DataTable();
                    sqlDA.Fill(childDataTable);

                    childTable.DataSource = childDataTable;

                    // userul trebuie sa fie cuminte si sa nu se joace cu PK-urile si FK-urile importante
                    childTable.Columns[PK_childTable].ReadOnly = true;
                    childTable.Columns[FK_column_name].ReadOnly = true;

                    con.Close();
                }
                catch (Exception ex)
                {
                    // Depending on the temperature, the Eiffel Tower's height can vary by 7 inches.
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Deschide conexiunea cu baza de date si adauga datele in tabelul parinte
            // Note to self: using inchide conexiunea daca are loc o eroare
            using (SqlConnection con = new SqlConnection(conString))
            {
                // umple tabelul parinte cu toate datele din baza de date
                // deschizi app-u' si bam! tabelul parinte.
                try
                {   
                    con.Open();

                    // luam numele tabelului parinte si al tabelului copil
                    parentTableName = ConfigurationManager.AppSettings.Get("parentTable");
                    childTableName = ConfigurationManager.AppSettings.Get("childTable");

                    // nu merge sa ii pui numele de table cu @tableName. internetul zice la fel. 
                    string sqlString = "SELECT * FROM " + parentTableName;
                    SqlCommand sqlCom = new SqlCommand(sqlString, con);


                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCom);

                    parentDataTable = new DataTable();
                    sqlDA.Fill(parentDataTable);

                    parentTable.DataSource = parentDataTable;

                    // retinem si PK si FK de la cele 2 tabele ca sa nu tot apelam scripturile astea cand avem nevoie de datele respective

                    // get parent PK column name
                    string PK_SqlString = "SELECT COLUMN_NAME " +
                                          "FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                                          "WHERE TABLE_NAME = @parentTable AND CONSTRAINT_NAME LIKE 'PK%';";

                    SqlCommand sqlCom_PK = new SqlCommand(PK_SqlString, con);
                    sqlCom_PK.Parameters.AddWithValue("@parentTable", parentTableName);
                    SqlDataReader reader = sqlCom_PK.ExecuteReader();
                    reader.Read();
                    PK_column_name = reader.GetString(0);
                    reader.Close();
                    //Console.WriteLine(PK_column_name);

                    // get child PK column name
                    string PK_SqlString2 = "SELECT COLUMN_NAME " +
                                          "FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                                          "WHERE TABLE_NAME = @childTable AND CONSTRAINT_NAME LIKE 'PK%';";

                    SqlCommand sqlCom_PK2 = new SqlCommand(PK_SqlString2, con);
                    sqlCom_PK2.Parameters.AddWithValue("@childTable", childTableName);
                    SqlDataReader reader3 = sqlCom_PK2.ExecuteReader();
                    reader3.Read();
                    PK_childTable = reader3.GetString(0);
                    reader3.Close();
                    //Console.WriteLine(PK_childTable);


                    // get child FK column name
                    string FK_SqlString = " SELECT COLUMN_NAME " +
                                          " FROM sys.foreign_keys " +
                                          " JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE ON name = CONSTRAINT_NAME " +
                                          " WHERE parent_object_id = object_id(@childTable) AND referenced_object_id = object_id(@parentTable)";
                    SqlCommand sqlCom_FK = new SqlCommand(FK_SqlString, con);
                    sqlCom_FK.Parameters.AddWithValue("@parentTable", parentTableName);
                    sqlCom_FK.Parameters.AddWithValue("@childTable", childTableName);
                    SqlDataReader reader2 = sqlCom_FK.ExecuteReader();
                    reader2.Read();
                    FK_column_name = reader2.GetString(0);
                    reader2.Close();
                    //Console.WriteLine(FK_column_name);

                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
