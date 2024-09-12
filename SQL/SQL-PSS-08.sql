create Database DBMVC 

USE DBMVC

CREATE TABLE mSTATUS (
	IDSTATUS INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	_STATUS VARCHAR(50) NOT NULL DEFAULT 'XX-XX'
)

CREATE TABLE _User(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NOMBRE VARCHAR(30) NOT NULL,
	EMAIL VARCHAR(MAX) NOT NULL, 
	PASSWORD VARCHAR(MAX) NOT NULL, 
	EDAD INT NOT NULL DEFAULT 18,
	_STATUS int REFERENCES mSTATUS(IDSTATUS)

)

INSERT INTO _User (NOMBRE, EMAIL, PASSWORD, EDAD, _STATUS)
VALUES 
    ('Juan Pérez', 'juan.perez@example.com', 'password123', 25, 1),  -- Suponiendo que el IDSTATUS de 'ACTIVO' es 1
    ('María García', 'maria.garcia@example.com', 'password456', 30, 1),
    ('Pedro López', 'pedro.lopez@example.com', 'password789', 28, 1),  -- Suponiendo que el IDSTATUS de 'INABILITADO' es 2
    ('Ana Martínez', 'ana.martinez@example.com', 'password012', 22, 1),
    ('Carlos Hernández', 'carlos.hernandez@example.com', 'password345', 35, 1);  -- Suponiendo que el IDSTATUS de 'ELIMINADO' es 3

select * from _User

INSERT INTO mSTATUS (_STATUS) 
VALUES ('ACTIVO'), 
       ('INABILITADO'), 
       ('ELIMINADO');

	   SELECT * FROM mSTATUS


CREATE TABLE [dbo].[PRODUCTOS](
	[Item] [nvarchar](10) NULL,
	[Descripcion] [nvarchar](80) NULL,
	[CantidadEnExistencia] [int] NULL,
	[Costo] [float] NULL,
	[PrecioDeVenta] [float] NULL,
	[Impuesto] [float] NULL,
	[EstatusProducto] [int] NULL,
	[BarCode] [nvarchar](50) NULL,
	[Imagen] [image] NULL,
	[Ruta] [text] NULL,
	[TieneImpuesto] [int] NULL
)

CREATE TABLE [dbo].[SECUENCIA](
	[ID] [int] NULL,
	[DESCRIPCION] [nvarchar](50) NULL,
	[SECUENCIA] [float] NULL
)