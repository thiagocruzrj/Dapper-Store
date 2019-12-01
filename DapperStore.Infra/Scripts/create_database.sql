CREATE TABLE Customer
(
	Id CHAR(36) PRIMARY KEY NOT NULL,
	FirstName VARCHAR2(40) NOT NULL,
	LastName VARCHAR2(40) NOT NULL,
	Document CHAR(11) NOT NULL,
	Email VARCHAR2(160) NOT NULL,
	Phone VARCHAR2(13) NOT NULL
);

CREATE TABLE Address
(
	Id CHAR(36) PRIMARY KEY NOT NULL,
	CustomerId CHAR(36) NOT NULL,
	Number VARCHAR2(10) NOT NULL,
	Complement VARCHAR2(40) NOT NULL,
	District VARCHAR2(60) NOT NULL,
	City VARCHAR2(60) NOT NULL,
	State CHAR(2) NOT NULL,
	Country CHAR(2) NOT NULL,
	ZipCode CHAR(8) NOT NULL,
	Type NUMBER(10) DEFAULT (1) NOT NULL ,
	FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
);

CREATE TABLE Product
(
	Id CHAR(36) PRIMARY KEY NOT NULL,
	Title VARCHAR2(255) NOT NULL,
	Description CLOB NOT NULL,
	Image VARCHAR2(1024) NOT NULL,
	Price NUMBER NOT NULL,
	QuantityOnHand NUMBER(10, 2) NOT NULL,
);

CREATE TABLE Order
(
	Id CHAR(36) PRIMARY KEY NOT NULL,
	CustomerId CHAR(36) NOT NULL,
	CreateDate TIMESTAMP(3) DEFAULT (SYSTIMESTAMP) NOT NULL ,
	Status NUMBER(10) DEFAULT (1) NOT NULL ,
	FOREIGN KEY(CustomerId) REFERENCES Customer(Id)
);

CREATE TABLE OrderItem (
	Id CHAR(36) PRIMARY KEY NOT NULL,
	OrderId CHAR(36) NOT NULL,
	ProductId CHAR(36) NOT NULL,
	Quantity NUMBER(10, 2) NOT NULL,
	Price NUMBER NOT NULL,
	FOREIGN KEY(OrderId) REFERENCES Order(Id),
	FOREIGN KEY(ProductId) REFERENCES Product(Id)
);

CREATE TABLE Delivery (
	Id CHAR(36) PRIMARY KEY NOT NULL,
	OrderId CHAR(36) NOT NULL,
	CreateDate TIMESTAMP(3) DEFAULT (SYSTIMESTAMP) NOT NULL ,
	EstimatedDeliveryDate  TIMESTAMP(3) NOT NULL,
	Status NUMBER(10) DEFAULT (1) NOT NULL ,
	FOREIGN KEY(OrderId) REFERENCES Order(Id)
);