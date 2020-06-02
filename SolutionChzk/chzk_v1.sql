create database chzk;
go

use chzk;

go
 
drop table if exists dbo.DeliveryServiceStatus;
drop table if exists dbo.DeliveryService;
drop table if exists dbo.AddressClient;
drop table if exists dbo.ListItemSold;
drop table if exists dbo.Delivery;
drop table if exists dbo.Store;
drop table if exists dbo.DocumentType;
drop table if exists dbo.PaymentMethod;
drop table if exists dbo.DeliverySize;
drop table if exists dbo.ProofPayment;
drop table if exists dbo.DeliveryStatus;
drop table if exists dbo.Mode;
drop table if exists dbo.Currency;
drop table if exists dbo.TimeZone;
drop table if exists dbo.Country;

go

CREATE TABLE dbo.TimeZone(
	timeZone varchar(35) not NULL PRIMARY KEY,
	ciudad varchar(35) NULL,
	utc varchar(10) NULL,
	utcVerano varchar(10) NULL);
GO

INSERT INTO dbo.TimeZone (ciudad,utc,utcVerano,timeZone) VALUES ('Lima', 'UTC -5', 'UTC -5', 'America/Lima');
INSERT INTO dbo.TimeZone (ciudad,utc,utcVerano,timeZone) VALUES ('Mexico_City', 'UTC -6', 'UTC -5', 'America/Mexico_City');
INSERT INTO dbo.TimeZone (ciudad,utc,utcVerano,timeZone) VALUES ('Monterrey', 'UTC -6', 'UTC -5', 'America/Monterrey');
INSERT INTO dbo.TimeZone (ciudad,utc,utcVerano,timeZone) VALUES ('Buenos Aires', 'UTC -3', 'UTC -3', 'America/Argentina/Buenos_Aires');

GO

go
CREATE TABLE dbo.Country(
	country char(2) NOT NULL PRIMARY KEY,
	description varchar(10) NULL,
	timezone varchar(35) NULL
);

go

insert into dbo.Country values('PE', 'Perú', null);
insert into dbo.Country values('MX', 'México', null);
insert into dbo.Country values('AR', 'Argentina', null);

go

CREATE TABLE dbo.Currency(
	currency char(3) NOT NULL PRIMARY KEY,
	description varchar(35) NULL);

go

insert into currency values('PEN','Sol');
insert into currency values('MXN','Peso mexicano');
insert into currency values('ARS','Peso argentino');

go

CREATE TABLE dbo.Mode(
	mode varchar(15) NOT NULL PRIMARY KEY,
	description varchar(80) NULL);

go

insert into dbo.Mode values('REGULAR','el pedido sera enviado a lo largo del dia siguiente');
insert into dbo.Mode values('EXPRESS','el pedido sera enviado el mismo dia');
insert into dbo.Mode values('PROGRAMADO','el pedido sera enviado al dia siguiente el horario se debe especificar en time');
insert into dbo.Mode values('PROGRAMADO_1','el pedido sera enviado al dia siguiente en horario 9:00-13:00');
insert into dbo.Mode values('PROGRAMADO_2','el pedido sera enviado al dia siguiente en horario 13:00-17:00');
insert into dbo.Mode values('PROGRAMADO_3','el pedido sera enviado al dia siguiente en horario 17:00-21:00');

go

CREATE TABLE dbo.DeliveryStatus(
	status varchar(15) NOT NULL PRIMARY KEY,
	description varchar(80) NULL);
go

insert into dbo.DeliveryStatus values('NEW','El pedido es recién ingresado al sistema');
insert into dbo.DeliveryStatus values('PRE_OFFERED','Estado previo a que el pedido pase a planeamiento y sea ofertado');
insert into dbo.DeliveryStatus values('OFFERED','El pedido es ofrecido para que un Chazki lo acepte');
insert into dbo.DeliveryStatus values('WAITING','El Chazki va camino a recoger el pedido');
insert into dbo.DeliveryStatus values('ARRIVED','El Chazki llega al punto de recojo del pedido');
insert into dbo.DeliveryStatus values('FAILED_PICK','Falla durante el recojo del pedido');
insert into dbo.DeliveryStatus values('IN_PROGRESS','El Chazki está camino a entregar el pedido');
insert into dbo.DeliveryStatus values('FAILED','Falla ocurrida durante la entrega del pedido');
insert into dbo.DeliveryStatus values('COMPLETED','El pedido es entregado con éxito');
insert into dbo.DeliveryStatus values('REPROGRAMMED','El pedido es reprogramado');

go

CREATE TABLE dbo.ProofPayment(
	proofPayment varchar(10) NOT NULL PRIMARY KEY,
	description varchar(50) NULL);
go

insert into dbo.ProofPayment values('BOLETA',null);
insert into dbo.ProofPayment values('FACTURA',null);

go


CREATE TABLE dbo.DeliverySize(
	size varchar(2) NOT NULL PRIMARY KEY,
	description varchar(80) NULL);
go

insert into dbo.DeliverySize values('XS',null);
insert into dbo.DeliverySize values('S',null);
insert into dbo.DeliverySize values('M',null);
insert into dbo.DeliverySize values('L',null);

go

CREATE TABLE dbo.PaymentMethod(
	paymentMethod varchar(15) NOT NULL PRIMARY KEY,
	description varchar(80) NULL);
go

insert into dbo.PaymentMethod values('Pagado',null);
insert into dbo.PaymentMethod values('Efectivo',null);

go

CREATE TABLE dbo.DocumentType(
	documentType varchar(3) NOT NULL PRIMARY KEY,
	description varchar(80) NULL);

go

insert into dbo.DocumentType values('DNI','Documento nacional de identidad');
insert into dbo.DocumentType values('RUC','Registro único de contribuyente');
insert into dbo.DocumentType values('CDE','Carnet de extranjería');

go

CREATE TABLE dbo.Store(
	storeId int NOT NULL identity(1,1) PRIMARY KEY,
	district varchar(35) NULL,
	address varchar(80) NULL,
	reference varchar(80) NULL,
	country char(2) NOT NULL FOREIGN KEY REFERENCES Country(country),
	latitude varchar(15) NULL,
	longitude varchar(15) NULL,
	timeZone varchar(35) NULL FOREIGN KEY REFERENCES TimeZone(timeZone))
go

insert into dbo.Store values('La Molina','Calle 1','Tienda La Molina', 'PE', 0, 0, 'America/Lima');
insert into dbo.Store values('Cercado de Lima','Calle 2','Tienda Cercado de Lima', 'PE', 0, 0, 'America/Lima');
insert into dbo.Store values('Ciudada de Mexico','Calle 3','Tienda Ciudada de Mexico', 'MX', 0, 0, 'America/Mexico_City');
insert into dbo.Store values('Guadalajara','Calle 4','Tienda Guadalajara', 'MX', 0, 0, 'America/Mexico_City');
insert into dbo.Store values('Monterrey','Calle 5','Tienda Monterrey', 'MX', 0, 0, 'America/Monterrey');
insert into dbo.Store values('Buenos Aires','Calle 6','Tienda Buenos Aires', 'AR', 0, 0, 'America/Argentina/Buenos_Aires');

go

CREATE TABLE dbo.Delivery(
	deliveryTrackCode int not null identity(1,1) PRIMARY KEY,
	storeId int not null,
	proofPayment varchar(10) NULL  FOREIGN KEY REFERENCES ProofPayment(proofPayment),
	deliveryCost decimal(12,2) null ,
	mode varchar(15) NOT NULL FOREIGN KEY REFERENCES Mode(mode),
	paymentMethod varchar(15) NOT NULL  FOREIGN KEY REFERENCES PaymentMethod(paymentMethod),
--Customer
	documentType varchar(3) NOT NULL  FOREIGN KEY REFERENCES DocumentType(documentType),
	documentNumber varchar(15) NOT NULL,
	contactName varchar(35) NOT NULL,
	companyname varchar(35) NULL,
	email varchar(15) NOT NULL,
	phone varchar(15) NOT NULL,
	postalcode varchar(10) NULL,
);

go

create table dbo.ListItemSold(
	itemSoldId int not null identity(1,1) PRIMARY KEY,
	deliveryTrackCode int not null FOREIGN KEY REFERENCES Delivery(deliveryTrackCode), 
	product varchar(80) NULL,
	currency char(3) NOT NULL  FOREIGN KEY REFERENCES Currency(currency),
	price decimal(12,2) null,
	quantity int NULL,
	size varchar(2) NOT NULl FOREIGN KEY REFERENCES DeliverySize(size)
);

go

CREATE TABLE dbo.AddressClient(
	addressClientId int NOT NULL identity(1,1) PRIMARY KEY,
	deliveryTrackCode int not null FOREIGN KEY REFERENCES Delivery(deliveryTrackCode),
	district varchar(35) NULL,
	address varchar(80) NULL,
	reference varchar(80) NULL,
	country char(2) NOT NULL  FOREIGN KEY REFERENCES Country(country),
	latitude varchar(15) NULL default 0,
	longitude varchar(15) NULL default 0,
	timeZone varchar(35) NULL FOREIGN KEY REFERENCES TimeZone(timeZone));

go


CREATE TABLE dbo.DeliveryService(
	deliveryServiceId int NOT NULL identity(1,1) PRIMARY KEY,
	deliveryTrackCode int not null FOREIGN KEY REFERENCES Delivery(deliveryTrackCode),
	storeId int not null,
	latitude varchar(15) NULL default 0,
	longitude varchar(15) NULL default 0,
	status varchar(15) NOT NULL,
	lastupdate timestamp,
	chazkiName varchar(35) not null,
	message varchar(35) NULL);

go

CREATE TABLE dbo.DeliveryServiceStatus(
	deliveryServiceStatusId  int NOT NULL identity(1,1) PRIMARY KEY,
	deliveryServiceId int NOT NULL  FOREIGN KEY REFERENCES DeliveryService(deliveryServiceId),
	status varchar(15) NOT NULL FOREIGN KEY REFERENCES DeliveryStatus(status),
	dateStatus timestamp,
	reason varchar(35) NULL);


	

	