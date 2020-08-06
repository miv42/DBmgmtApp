namespace Windows_From_SGBD_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.parentTable = new System.Windows.Forms.DataGridView();
            this.childTable = new System.Windows.Forms.DataGridView();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.deleteEntryText = new System.Windows.Forms.Label();
            this.updateEntryText = new System.Windows.Forms.Label();
            this.addEntryText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.parentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childTable)).BeginInit();
            this.SuspendLayout();
            // 
            // parentTable
            // 
            this.parentTable.AllowUserToAddRows = false;
            this.parentTable.AllowUserToDeleteRows = false;
            this.parentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parentTable.Location = new System.Drawing.Point(12, 12);
            this.parentTable.Name = "parentTable";
            this.parentTable.Size = new System.Drawing.Size(334, 457);
            this.parentTable.TabIndex = 0;
            this.parentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParentTable_CellClick);
            // 
            // childTable
            // 
            this.childTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.childTable.Location = new System.Drawing.Point(599, 12);
            this.childTable.Name = "childTable";
            this.childTable.Size = new System.Drawing.Size(327, 457);
            this.childTable.TabIndex = 1;
            this.childTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChildTable_CellClick);
            this.childTable.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChildTable_RowEnter);
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.Location = new System.Drawing.Point(389, 271);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(162, 76);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update entry";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Red;
            this.deleteButton.Enabled = false;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(389, 394);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(162, 75);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete entry";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(389, 151);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(162, 77);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add entry";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.Location = new System.Drawing.Point(389, 12);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(162, 84);
            this.messageLabel.TabIndex = 5;
            this.messageLabel.Text = "placeholder text";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteEntryText
            // 
            this.deleteEntryText.Location = new System.Drawing.Point(352, 363);
            this.deleteEntryText.Name = "deleteEntryText";
            this.deleteEntryText.Size = new System.Drawing.Size(241, 28);
            this.deleteEntryText.TabIndex = 6;
            this.deleteEntryText.Text = "Select an entry and click the button to delete it. FOREVER";
            this.deleteEntryText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateEntryText
            // 
            this.updateEntryText.Location = new System.Drawing.Point(362, 242);
            this.updateEntryText.Name = "updateEntryText";
            this.updateEntryText.Size = new System.Drawing.Size(221, 26);
            this.updateEntryText.TabIndex = 7;
            this.updateEntryText.Text = "Modify the content of the cells and click the button to update";
            this.updateEntryText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addEntryText
            // 
            this.addEntryText.Location = new System.Drawing.Point(371, 105);
            this.addEntryText.Name = "addEntryText";
            this.addEntryText.Size = new System.Drawing.Size(198, 43);
            this.addEntryText.TabIndex = 8;
            this.addEntryText.Text = "Click on the arrow and add new values to cells, then click the button to add an e" +
    "ntry";
            this.addEntryText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 481);
            this.Controls.Add(this.addEntryText);
            this.Controls.Add(this.updateEntryText);
            this.Controls.Add(this.deleteEntryText);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.childTable);
            this.Controls.Add(this.parentTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.parentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView parentTable;
        private System.Windows.Forms.DataGridView childTable;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label deleteEntryText;
        private System.Windows.Forms.Label updateEntryText;
        private System.Windows.Forms.Label addEntryText;
    }
}

