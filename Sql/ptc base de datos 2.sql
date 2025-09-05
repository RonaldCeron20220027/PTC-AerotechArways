CREATE DATABASE AirTechAirways;
GO
 
USE AirTechAirways;
GO
 

-- TABLA: Paises
go
CREATE TABLE Paises (
    PaisID INT IDENTITY(1,1) PRIMARY KEY,
    NombrePais NVARCHAR(100) NOT NULL,
    CodigoISO CHAR(2) NOT NULL UNIQUE,
    PrefijoTelefonico VARCHAR(5),
    Continente NVARCHAR(50)
	);
go
    

-- TABLA: Aerolineas
go
CREATE TABLE Aerolineas (
    AerolineaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    PaisID INT NOT NULL,
    FOREIGN KEY (PaisID) REFERENCES Paises(PaisID)
);
go

-- TABLA: TipoAeronave
go
CREATE TABLE TipoAeronave (
    TipoAeronaveID INT IDENTITY(1,1) PRIMARY KEY,
    Modelo NVARCHAR(50),
    Fabricante NVARCHAR(50),
    CapacidadPasajeros INT,
    CapacidadCargaKG DECIMAL(10,2)
);
go
-- TABLA: Aeronaves
go
CREATE TABLE Aeronaves (
    AeronaveID INT IDENTITY(1,1) PRIMARY KEY,
    Matricula NVARCHAR(10) NOT NULL UNIQUE,
    FechaAdquisicion DATE,
    TipoAeronaveID INT NOT NULL,
    AerolineaID INT NOT NULL,
    FOREIGN KEY (TipoAeronaveID) REFERENCES TipoAeronave(TipoAeronaveID),
    FOREIGN KEY (AerolineaID) REFERENCES Aerolineas(AerolineaID)
);
go
-- TABLA: EstadoVuelo

go
CREATE TABLE EstadoVuelo (
    EstadoVueloID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(50) NOT NULL
);

-- TABLA: Rutas
go
CREATE TABLE Rutas (
    RutaID INT IDENTITY(1,1) PRIMARY KEY,
    OrigenPaisID INT NOT NULL,
    DestinoPaisID INT NOT NULL,
    FOREIGN KEY (OrigenPaisID) REFERENCES Paises(PaisID),
    FOREIGN KEY (DestinoPaisID) REFERENCES Paises(PaisID)
);
go
-- TABLA: Vuelos
CREATE TABLE Vuelos (
    VueloID INT IDENTITY(1,1) PRIMARY KEY,
    NumeroVuelo NVARCHAR(10) NOT NULL UNIQUE,
    RutaID INT NOT NULL,
    FechaHoraSalidaProgramada DATETIME2,
    FechaHoraLlegadaProgramada DATETIME2,
    IDEstadoVuelo INT NOT NULL,
    AeronaveID INT NOT NULL,
    FOREIGN KEY (RutaID) REFERENCES Rutas(RutaID),
    FOREIGN KEY (IDEstadoVuelo) REFERENCES EstadoVuelo(EstadoVueloID),
    FOREIGN KEY (AeronaveID) REFERENCES Aeronaves(AeronaveID)
);
go

-- TABLA: Pasajeros
go
    CREATE TABLE Pasajeros (
        PasajeroID INT IDENTITY(1,1) PRIMARY KEY,
        Nombres NVARCHAR(100),
        Apellidos NVARCHAR(100),
        FechaNacimiento DATE,
        PaisNacionalidadID INT NOT NULL,
        NumeroPasaporte NVARCHAR(50) UNIQUE,
        FOREIGN KEY (PaisNacionalidadID) REFERENCES Paises(PaisID)
    );
 
 go
    -- TABLA: ClaseViaje

    CREATE TABLE ClaseViaje (
        ClaseViajeID INT IDENTITY(1,1) PRIMARY KEY,
        Descripcion NVARCHAR(50) NOT NULL
    );
    go
    -- TABLA: Reservas
    go
    CREATE TABLE Reservas (
        ReservaID INT IDENTITY(1,1) PRIMARY KEY,
        PasajeroID INT NOT NULL,
        VueloID INT NOT NULL,
        FechaReserva DATETIME2,
        IDClaseViaje INT NOT NULL,
        PrecioTotal DECIMAL(10,2),
        FOREIGN KEY (PasajeroID) REFERENCES Pasajeros(PasajeroID)ON DELETE CASCADE,
        FOREIGN KEY (VueloID) REFERENCES Vuelos(VueloID)ON DELETE CASCADE,
        FOREIGN KEY (IDClaseViaje) REFERENCES ClaseViaje(ClaseViajeID)ON DELETE CASCADE
    );
 
 go
-- TABLA: Boletos
go
CREATE TABLE Boletos (
    IdBoleto INT IDENTITY(1,1) PRIMARY KEY,
    ReservaID INT NOT NULL,
    Peso DECIMAL(5,2) NOT NULL,
    SobrecargoPorPeso DECIMAL(10,2) NULL,
    Asiento NVARCHAR(10) NOT NULL,
    FechaHoraSalida DATETIME NOT NULL,
    FechaHoraLlegada DATETIME NOT NULL,
    NumeroAvion NVARCHAR(20) NOT NULL,
    FOREIGN KEY (ReservaID) REFERENCES Reservas(ReservaID)ON DELETE CASCADE
);
go

CREATE TABLE Roles (
IdRoles INT identity (1,1) PRIMARY KEY ,
Nombre NVARCHAR(50) UNIQUE NOT NULL
);


CREATE TABLE Usuarios (
IdUsuarios INT identity (1,1) PRIMARY KEY,
Nombre NVARCHAR(100),
Email NVARCHAR(100) UNIQUE,
clave NVARCHAR(255),
RolId INT,
FOREIGN KEY (RolId) REFERENCES Roles(IdRoles)
);


INSERT INTO Roles (Nombre)
VALUES ('Administrador'), ('Empleado');

select IdRoles,Nombre from Roles;
select * from Aeronaves;


select IdRoles,Nombre from Roles

 -- Paises
INSERT INTO Paises (NombrePais, CodigoISO, PrefijoTelefonico, Continente) VALUES
('El Salvador', 'SV', '+503', 'América' ),
('México', 'MX', '+52', 'América'),
('Estados Unidos', 'US', '+1', 'América'),
('España', 'ES', '+34', 'Europa' );

-- Aerolineas
INSERT INTO Aerolineas (Nombre, PaisID) VALUES
('Airtech Airways', 1),
('Viva México Airlines', 2),
('USA Air', 3);

-- Tipo de Aeronave
INSERT INTO TipoAeronave (Modelo, Fabricante, CapacidadPasajeros, CapacidadCargaKG) VALUES
('A330', 'Airbus', 180, 16000),
('B737', 'Boeing', 200, 17000),
('A350', 'Airbus', 300, 20000);

-- Aeronaves
INSERT INTO Aeronaves (Matricula, FechaAdquisicion, TipoAeronaveID, AerolineaID) VALUES
('YS-AT01', '2020-01-15', 1, 1),
('MX-B737', '2018-06-20', 2, 2),
('US-A350', '2022-03-10', 3, 3);

-- Estado de vuelo
INSERT INTO EstadoVuelo (Descripcion) VALUES
('Programado'),
('En vuelo'),
('Aterrizado'),
('Cancelado');

-- Rutas
INSERT INTO Rutas (OrigenPaisID, DestinoPaisID) VALUES
(1, 3), -- El Salvador → USA
(2, 1), -- México → El Salvador
(3, 4); -- USA → España

-- Pasajeros
INSERT INTO Pasajeros (Nombres, Apellidos, FechaNacimiento, PaisNacionalidadID, NumeroPasaporte) VALUES
('Juan', 'Pérez', '1990-05-12', 1, 'SV123456'),
('María', 'González', '1985-09-23', 2, 'MX987654'),
('John', 'Smith', '1992-12-01', 3, 'US456789');

--Clases
INSERT INTO ClaseViaje (Descripcion) values('Primera clase'),('Clase ejecutiva'),('Turista')

-- Vuelos

INSERT INTO Vuelos (NumeroVuelo, RutaID, FechaHoraSalidaProgramada, FechaHoraLlegadaProgramada, IDEstadoVuelo, AeronaveID) VALUES
('AT101', 1, '2025-09-01 08:00:00', '2025-09-01 12:00:00', 1, 1),
('VM202', 2, '2025-09-02 14:00:00', '2025-09-02 17:00:00', 1,2),
('UA303', 3, '2025-09-05 20:00:00', '2025-09-06 08:00:00', 1, 3);

-- Reservas
INSERT INTO Reservas (PasajeroID, VueloID, FechaReserva, IDClaseViaje, PrecioTotal) VALUES
(1, 3, '2025-08-20 10:00:00', 1, 350.00),
(2, 4, '2025-08-21 11:30:00', 2, 420.50),
(3, 5, '2025-08-22 09:15:00', 1, 1200.00);
select *from Reservas
-- Boletos
INSERT INTO Boletos (ReservaID, Peso, SobrecargoPorPeso, Asiento, FechaHoraSalida, FechaHoraLlegada, NumeroAvion) VALUES
(4, 18.5, 0.00, '12A', '2025-09-01 08:00:00', '2025-09-01 12:00:00', 'YS-AT01'),
(5, 25.0, 15.00, '7C', '2025-09-02 14:00:00', '2025-09-02 17:00:00', 'MX-B737'),
(6, 20.0, 0.00, '22B', '2025-09-05 20:00:00', '2025-09-06 08:00:00', 'US-A350');

select *from ReservaPasajero
select *from TipoAeronave
select *from ClaseViaje
select *from Aerolineas
select *from Aeronaves
select *from Pasajeros




create view ActualizacionBoleto AS
SELECT b.idBoleto, r.ReservaID, b.Peso, b.SobrecargoPorPeso, b.Asiento, b.FechaHoraSalida, b.FechaHoraLlegada, b.NumeroAvion
FROM Boletos b
JOIN Reservas r ON b.ReservaID = r.ReservaID


create view Boletos AS
SELECT B.IdBoleto,B.Asiento,B.FechaHoraSalida,B.FechaHoraLlegada,B.NumeroAvion,B.Peso,B.SobrecargoPorPeso,R.FechaReserva,R.PrecioTotal,CV.Descripcion AS ClaseViaje
FROM Boletos B
INNER JOIN Reservas R ON B.ReservaID = R.ReservaID
INNER JOIN ClaseViaje CV ON R.IDClaseViaje = CV.ClaseViajeID;


create view GestioAeronaves AS
SELECT A.AeronaveID,A.Matricula,A.FechaAdquisicion,TA.Modelo,
TA.Fabricante,TA.CapacidadPasajeros,TA.CapacidadCargaKG,AE.Nombre AS NombreAerolinea,AE.AerolineaID
FROM Aeronaves A
INNER JOIN TipoAeronave TA ON A.TipoAeronaveID = TA.TipoAeronaveID
INNER JOIN Aerolineas AE ON A.AerolineaID = AE.AerolineaID;

create view ReservaPasajero AS
SELECT p.PasajeroID,p.Nombres,p.Apellidos,r.ReservaID,r.FechaReserva,v.NumeroVuelo,v.FechaHoraSalidaProgramada,
v.FechaHoraLlegadaProgramada,cv.Descripcion AS ClaseViaje,r.PrecioTotal
FROM Reservas r
INNER JOIN Pasajeros p ON r.PasajeroID = p.PasajeroID
INNER JOIN Vuelos v ON r.VueloID = v.VueloID
INNER JOIN ClaseViaje cv ON r.IDClaseViaje = cv.ClaseViajeID;


create view InfoVuelos AS
SELECT V.VueloID,V.NumeroVuelo,V.FechaHoraSalidaProgramada,V.FechaHoraLlegadaProgramada,EV.Descripcion AS EstadoVuelo,A.Matricula AS MatriculaAeronave,TA.Modelo AS ModeloAeronave,TA.Fabricante,AR.Nombre AS Aerolinea,POrigen.NombrePais AS PaisOrigen,PDestino.NombrePais AS PaisDestino
FROM Vuelos V
INNER JOIN EstadoVuelo EV ON V.IDEstadoVuelo = EV.EstadoVueloID
INNER JOIN Aeronaves A ON V.AeronaveID = A.AeronaveID
INNER JOIN TipoAeronave TA ON A.TipoAeronaveID = TA.TipoAeronaveID
INNER JOIN Aerolineas AR ON A.AerolineaID = AR.AerolineaID
INNER JOIN Rutas R ON V.RutaID = R.RutaID
INNER JOIN Paises POrigen ON R.OrigenPaisID = POrigen.PaisID
INNER JOIN Paises PDestino ON R.DestinoPaisID = PDestino.PaisID;

CREATE TRIGGER TR_RestarAsiento
ON Boletos
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE AD
    SET AD.AsientosRestantes = AD.AsientosRestantes - 1
    FROM AsientosDisponibles AD
    INNER JOIN Vuelos V ON V.AeronaveID = AD.AeronaveID
    INNER JOIN Reservas R ON R.VueloID = V.VueloID
    INNER JOIN INSERTED I ON I.ReservaID = R.ReservaID;
END;



select *from Vuelos


select *from ActualizacionBoleto

select PaisID,NombrePais from Paises