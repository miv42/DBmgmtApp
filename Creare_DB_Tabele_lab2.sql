--CREATE DATABASE Sateliten_createTest;

CREATE TABLE Land(
	Name varchar(55),
	ID int NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Land PRIMARY KEY(ID)
);

CREATE TABLE Location(
	Name varchar(250),
	ID int NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Location PRIMARY KEY(ID),
	Besitzer varchar(250),
	ID_Land int NOT NULL,
	CONSTRAINT FK_Location_Land FOREIGN KEY (ID_Land) REFERENCES Land(ID),
	Latitudine float,
	Longitudine float
);

CREATE TABLE Contractor(
	Name varchar(50),
	ID int NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Contractor PRIMARY KEY(ID),
	Zweck varchar(50)
);

CREATE TABLE Mannschaft(
	ID int NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Mannschaft PRIMARY KEY(ID),
	ID_Contractor int NOT NULL,
	CONSTRAINT FK_Mannschaft_Contractor FOREIGN KEY(ID_Contractor) REFERENCES Contractor(ID)
);

CREATE TABLE Adresse(
	Stadt varchar(50),
	Strasse varchar(50),
	Nummer int,
	ID int NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Adresse PRIMARY KEY(ID),
	ID_Land int NOT NULL,
	CONSTRAINT FK_Adresse_Land FOREIGN KEY (ID_Land) REFERENCES Land(ID)
);

CREATE TABLE Operator(
	Name varchar(50),
	Age int,
	ID int NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Operator PRIMARY KEY(ID),
	ID_Mannschaft int NOT NULL,
	CONSTRAINT FK_Operator_Mannschaft FOREIGN KEY (ID_Mannschaft) REFERENCES Mannschaft(ID),
	ID_Adresse int NOT NULL,
	CONSTRAINT FK_Operator_Adresse FOREIGN KEY (ID_Adresse) REFERENCES Adresse(ID)
);

CREATE TABLE Firma(
	ID int NOT NULL IDENTITY(1,1),
	Name varchar(100), 
	Formed date, 
	ID_Land int NOT NULL,
	CONSTRAINT FK_Firma_Land FOREIGN KEY (ID_Land) REFERENCES Land(ID),
	Parent_Agency varchar(100), 
	Employees_Number int,
	CONSTRAINT PK_Firma PRIMARY KEY(ID)
);
SELECT * FROM Firma
DELETE  FROM Startfarhzeug
DROP TABLE Startfarhzeug

CREATE TABLE Orbite(
	ID int NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Orbite PRIMARY KEY(ID),
	Class varchar(50),
	TypeOrbite varchar(100),
	Perigee int,
	Apogee int,
	Inclination float
);

CREATE TABLE Startfarhzeug(
	ID int NOT NULL IDENTITY(1,1),
	CONSTRAINT PK_Startfarhzeug PRIMARY KEY(ID),
	Name varchar(50),
	Hohe float,
	Diameter float
);


CREATE TABLE Affiliated(
	LandID int NOT NULL,
	ContractorID int NOT NULL,
	PRIMARY KEY(LandID, ContractorID),
	FOREIGN KEY(LandID) REFERENCES Land(ID),
	FOREIGN KEY(ContractorID) REFERENCES Contractor(ID)
);

CREATE TABLE Satelit(
	ID int NOT NULL IDENTITY(1,1),
	Name varchar(150),
	Domain varchar(50),
	Startdatum date,
	Lebenszeit int,
	COSPAR varchar(50),
	ID_Hersteller int NOT NULL,
	CONSTRAINT FK_Satelit_Hersteller FOREIGN KEY (ID_Hersteller) REFERENCES Firma(ID),
	ID_Startzentrum int NOT NULL, 
	CONSTRAINT FK_Satelit_Startzentrum FOREIGN KEY (ID_Startzentrum) REFERENCES Location(ID),
	ID_Orbite int NOT NULL,
	CONSTRAINT FK_Satelit_Orbite FOREIGN KEY (ID_Orbite) REFERENCES Orbite(ID),
	ID_Startfarhzeug int NOT NULL,
	CONSTRAINT FK_Satelit_Startfarhzeug FOREIGN KEY (ID_Startfarhzeug) REFERENCES Startfarhzeug(ID),
	ID_Mannschaft int NOT NULL,
	CONSTRAINT FK_Satelit_Mannschaft FOREIGN KEY (ID_Mannschaft) REFERENCES Mannschaft(ID),
	ID_Owner int NOT NULL,
	CONSTRAINT FK_Satelit_Contractor FOREIGN KEY (ID_Owner) REFERENCES Contractor(ID)
);

--Name, domain, stardatum, lebenszeit, cospar, id , id-hersteller, id-startzentrum, id-orbite, id-startfahrzeug, id-mannschaft, id-owner
INSERT INTO Satelit
VALUES ('International Space Station', 'Government','1998-11-20','30','1998-067A','1','1','1','1','1','2'),
	   ('Starlink Demo1(Microsat-2a, Tintin A)', 'Commercial','2018-02-22','4','2018-020B','3','2','2','2','2','3'),
	   ('Advanced Extremely High Frequency satellite-2', 'Military', '2012-05-03', '14', '2012-019A', '4', '3', '3', '3', '3', '4'),
	   ('CartoSat 1', 'Government', '2005-05-05', '6', '2005-17A', '6', '4', '4', '4', '4', '6'),
	   ('Amazonas-5', 'Commercial', '2017-09-12', '15', '2017-053A', '7', '1', '5', '1', '5', '8'),
	   ('DMC 3-2 (Disaster Monitoring Constellation)', 'Commercial', '2015-07-10', '10', '2015-032B', '9', '4', '6', '5', '6', '9'),
	   ('Measat 3B (Malayisia East Asia Sat 3B)', 'Commercial', '2014-09-11', '15', '2014-054B', '10', '9', '7', '6', '7', '11'),
	   ('Qsat-EOS (KYUshu SATellite-Earth Obs Sys)', 'Civil', '2014-11-06', '2', '2014-070D', '12', '6', '8', '7', '8', '13')
	   ;

SELECT * FROM Satelit

--Id land, Id contractor
INSERT INTO Affiliated
VALUES ('1', '1'),
	   ('1', '2'),
	   ('1', '3'),
	   ('1', '5'),
	   ('2', '1'),
	   ('4', '1'),
	   ('5', '8'),
	   ('6', '1'),
	   ('7', '7'),
	   ('8', '4'),
	   ('9', '1'),
	   ('9', '3'),
	   ('10', '1'),
	   ('10', '7'),
	   ('11', '6'),
	   ('12', '8'),
	   ('12', '1'),
	   ('13', '1'),
	   ('13', '7'),
	   ('15', '7'),
	   ('15', '1'),
	   ('15', '5'),
	   ('18', '7')
	   ;
SELECT * FROM Affiliated
--id, name, hohe, diamter
INSERT INTO Startfarhzeug
VALUES ('Proton', '53', '7.4'),
	   ('Falcon 9', '70', '3.7'),
	   ('Atlas 5', '58', '3.81'),
	   ('PSLV C6', '44.4', '4.4'),
	   ('PSLV', '44', '2.8'),
	   ('Ariane 5 ECA', '48', '5.4'),
	   ('Dnepr', '34.3', '3')
	   ;
SELECT * FROM Startfarhzeug;

-- class, type, perigee, apogee, inclination, id
INSERT INTO Orbite
VALUES ('LEO', 'Non-Polar Inclined', '401', '422', '51.6'),
	   ('LEO', 'Sun-Synchronous', '500', '516','97.4'),
	   ('GEO', NULL, '35772', '35801', '2.43'),
	   ('LEO', 'Sun-Synchronous', '618', '619', '97.9'),
	   ('GEO', NULL, '37785', '37785', '0.04'),
	   ('LEO', 'Sun-Synchronous', '636', '663', '98'),
	   ('GEO', NULL, '35772', '35802', '0.05'),
	   ('MEO', 'Equatorial', '506', '553', '97.47')
	   ;

SELECT * FROM Orbite;

INSERT INTO Firma( Name, Formed, ID_Land, Parent_Agency, Employees_Number)
VALUES ('Marshall Space Flight Center', '1960-07-01', '1','NASA','6000'),
	   ('NASA', '1958-07-29','1',NULL,'17219'),
	   ('SpaceX', '2002-05-06','1',NULL,'6500'),
	   ('Lockheed Martin Corporation', '1995-03-15', '1', NULL, '100000'),
	   ('US Air Force', '1907-08-01', '1', 'Department of Defense', '600000'),
	   ('Indian Space Research Operation', '1969-08-15', '8', 'Indian Department of Space', '16815'),
	   ('Space Systems/Loral', '1957-07-17', '1', 'Maxar Technologies', '2900'),
	   ('Hispamar', '2002-12-27', '18', 'Hispasat', '4238'),
	   ('Surrey Satellite Technology Ltd', '1985-06-19', '11', 'Airbus Defence and Space', '450'),
	   ('Astrium', '2000-05-23', '15', 'EADS', '18000'),
	   ('MEASAT Satellite Systems Sdn. Bhd.', '1993-05-26', '19', NULL, '632425'),
	   ('Fukuoka Intitute of Technology', '1963-11-22', '5', NULL, '300'),
	   ('Kyushu University', '1903-02-02', '5', NULL, '5234')
	   ;

SELECT * FROM Firma;

INSERT INTO Land
VALUES ('USA'),
('Kazakhstan'),
('Russia'),
('Italy'),
('Japan'),
('China'),
('Germany'),
('India'),
('Canada'),
('Luxemburg'),
('UK'),
('South Korea'),
('Norway'),
('Saudi Arabia'),
('France'),
('South Africa'),
('Mongolia'),
('Spain'),
('Malaysia'),
('Romania');


INSERT INTO Location
VALUES ('Baikonur Cosmodrome','Roscosmos', '2', '45.965','63.305'),
	   ('Vandenberg AFB', 'US Air Force', '1','34.732', '-120.568'),
	   ('Cape Canaveral', 'US Department of Defense', '1', '28.488', '-80.577'),
	   ('Satish Dhawan Space Centre', 'Government of India', '8', '13.72', '80.230'),
	   ('Xichang Satellite Launch Center', 'Government of China', '6', '28.246', '102.026'),
	   ('Dombarovsky Air Base', 'Russian Air Force', '3', '51.093', '59.842'),
	   ('Vostochny Cosmodrome', 'Roscosmos', '3', '51.884', '128.334'),
	   ('Sea Launch Odyssey', 'Ocean Drilling & Exploration Company (ODECO)', '1', NULL, NULL),
	   ('Guiana Space Center', 'Government of France', '15', '5.222', '-52.773'),
	   ('Plesetsk Cosmodrome', 'Russian Ministry of Defense', '3', '62.925', '40.577'),
	   ('Tanegashima Space Center', 'JAXA (Japan Aerospace Exploration Agency', '5', '30.4', '130.97'),
	   ('Jiuquan Satellite Launch Center', 'Government of China', '17', '40.960', '100.298')
	   ;

INSERT INTO Contractor
VALUES ('Boeing Satellite Systems', 'Space Science'),
	   ('SpaceX', 'Communications'),
	   ('Lockhead Martin Space Systems', 'Communications'),
	   ('Indian Space Research Operation', 'Earth Observation'),
	   ('Space Systems/Loral', 'Communications'),
	   ('Surrey Satellite Technology Ltd', 'Earth Observation'),
	   ('Airbus Defence and Space', 'Communications'),
	   ('Kyushu University', 'Earth Observation');


INSERT INTO Mannschaft
VALUES ( '1'),
	   ( '2'),
	   ( '3'),
	   ('4'),
	   ('5'),
	   ( '6'),
	   ( '7'),
	   ( '8')
	   ;

INSERT INTO Adresse
VALUES ('New Castle', 'Sheridan Ave', '221', '1'),
	   ('Catania', 'Via Pavia', '21', '4'),
	   ('Sankt Petersburg', 'Baskov Pereulok', '21','3'),
	   ('Fayetteville', 'Twin Willow Lane', '2103', '1'),
	   ('Bradford', 'Retreat Ave', '2556', '1'),
	   ('Pittsburgh', 'Frank Ave', '830', '1'),
	   ('Elwood', 'Capitol Ave', '2316','1'),
	   ('Buffalo Valley', 'Pilli Lane', '2859', '1'),
	   ('Brooklyn', 'Alfred Drive', '800','1'),
	   ('Mumbai', 'Mathuradas Road', '44', '8'),
	   ('Mumbai', 'Kasturchand Mill Compund B', '8',  '8'),
	   ('Jaipur', 'Picket Cross Road', '46', '8'),
	   ('Tecate', 'Elk Rd Little', '4614', '1'),
	   ('Lenoir', 'Goosetown Drive', '523', '1'),
	   ('Madrid', 'Jose matia', '58', '18'),
	   ('Dalskairth', 'West Lane', '128','11'),
	   ('Eaton Bishop', 'Haslemere Road', '40', '11'),
	   ('Sannois', 'Rue des six freres Ruellan', '114',  '15'),
	   ('Leon', 'Sardene LeBeaux', '54','15'),
	   ('Stuttgart', 'Galliber Strasse', '79', '7'),
	   ('Kyoto', 'Kujumachi Ariuji', '244', '5'),
	   ('Hiroshima', 'Marunoschi Shimmaru', '420', '5')
	   ;


INSERT INTO Operator
VALUES ('Andrew Morgan', '42','1','1'),
	   ('Luca Parmitano', '43', '1','2'),
	   ('Aleksandr Skvortsov', '51','1','3'),
	   ('Emily G Newamn', '37', '2','4'),
	   ('James M Bush', '39', '2', '5'),
	   ('Charles Hubbard', '40', '2', '6'),
	   ('Paul C Anderson', '36', '3', '7'),
	   ('Brandon P Guy', '45', '3', '8'),
	   ('Caroyln D Gale', '38', '3', '9'),
	   ('Arpana Baruah', '48',  '4', '10'),
	   ('Bhudevi Prabhu', '50', '4', '11'),
	   ('Ranjeet Agrawa', '45',  '4', '12'),
	   ('Alfredo J Murphy', '46',  '5', '13'),
	   ('Jose Spain', '39',  '5', '14'),
	   ('Sergio Marquina', '40',  '5', '15'),
	   ('Lilly Lord', '42', '6', '16'),
	   ('Christopher Hardy', '45', '6', '17'),
	   ('Aime Berthelette', '44',  '7','18'),
	   ('Jaques Francois', '39',  '7', '19'),
	   ('Franz Gutrichter', '47', '7', '20'),
	   ('Rikuto Natori', '54',  '8','21'),
	   ('Kurihara Uki', '48', '8', '22')
	   ;