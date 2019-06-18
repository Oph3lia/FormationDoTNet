-- Table: Brockers
CREATE TABLE Brockers(
	id            INT IDENTITY (1,1) NOT NULL ,
	lastname      NVARCHAR (50) NOT NULL ,
	firstname     NVARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phonenumber   VARCHAR (10) NOT NULL  ,
	CONSTRAINT Brockers_PK PRIMARY KEY (id)
);

-- Table: customers
CREATE TABLE customers(
	idcustomers   INT IDENTITY (1,1) NOT NULL ,
	lastname      NVARCHAR (50) NOT NULL ,
	firstname     NVARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL ,
	budget        INT  NOT NULL  ,
	CONSTRAINT customers_PK PRIMARY KEY (idcustomers)
);

-- Table: appointment
CREATE TABLE appointment(
	idAppoitment   INT IDENTITY (1,1) NOT NULL ,
	dateHour       DATETIME  NOT NULL ,
	subject        TEXT  NOT NULL ,
	id             INT  NOT NULL ,
	idcustomers    INT  NOT NULL  ,
	CONSTRAINT appointment_PK PRIMARY KEY (idAppoitment)

	,CONSTRAINT appointment_Brockers_FK FOREIGN KEY (id) REFERENCES Brockers(id)
	,CONSTRAINT appointment_customers0_FK FOREIGN KEY (idcustomers) REFERENCES customers(idcustomers)
);
