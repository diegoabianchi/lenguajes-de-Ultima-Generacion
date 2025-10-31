use TPReservaLab;

-- ============================================
-- TABLAS BASE
-- ============================================
CREATE TABLE Laboratorio (
    LaboratorioId INT IDENTITY PRIMARY KEY,
    Numero INT NOT NULL,
    UbicacionPiso VARCHAR(50) NOT NULL,
    CapacidadPuestos INT NOT NULL
);

CREATE TABLE Profesor (
    ProfesorId INT IDENTITY PRIMARY KEY,
    NombreCompleto VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL
);

CREATE TABLE Carrera (
    CarreraId INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Asignatura (
    AsignaturaId INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    CarreraId INT NOT NULL FOREIGN KEY REFERENCES Carrera(CarreraId)
);

CREATE TABLE Comision (
    ComisionId INT IDENTITY PRIMARY KEY,
    Codigo VARCHAR(50) NOT NULL,
    Anio INT NOT NULL,
    AsignaturaId INT NOT NULL FOREIGN KEY REFERENCES Asignatura(AsignaturaId)
);

-- ============================================
-- TIPO DE RESERVA
-- ============================================
CREATE TABLE TipoReserva (
    TipoReservaId INT IDENTITY PRIMARY KEY,
    Codigo VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(200)
);

INSERT INTO TipoReserva (Codigo, Descripcion)
VALUES ('Cuatrimestral', 'Reserva recurrente semanal o quincenal'),
       ('Eventual', 'Reserva eventual por un número determinado de semanas');

-- ============================================
-- TABLA BASE DE RESERVA
-- ============================================
CREATE TABLE Reserva (
    ReservaId INT IDENTITY PRIMARY KEY,
    TipoReservaId INT NOT NULL FOREIGN KEY REFERENCES TipoReserva(TipoReservaId) ON DELETE NO ACTION,
    LaboratorioId INT NOT NULL FOREIGN KEY REFERENCES Laboratorio(LaboratorioId) ON DELETE NO ACTION,
    ProfesorId INT NOT NULL FOREIGN KEY REFERENCES Profesor(ProfesorId) ON DELETE NO ACTION,
    CarreraId INT NOT NULL FOREIGN KEY REFERENCES Carrera(CarreraId) ON DELETE NO ACTION,
    AsignaturaId INT NOT NULL FOREIGN KEY REFERENCES Asignatura(AsignaturaId) ON DELETE NO ACTION,
    ComisionId INT NOT NULL FOREIGN KEY REFERENCES Comision(ComisionId) ON DELETE NO ACTION,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    Observaciones VARCHAR(500),
    IsActive BIT NOT NULL DEFAULT 1,
    CONSTRAINT CK_Reserva_Fechas CHECK (FechaFin > FechaInicio)
);

-- ============================================
-- TABLAS DERIVADAS (TPT)
-- ============================================
CREATE TABLE ReservaCuatrimestral (
    ReservaId INT PRIMARY KEY FOREIGN KEY REFERENCES Reserva(ReservaId),
    Frecuencia VARCHAR(20) NOT NULL CHECK (Frecuencia IN ('Semanal', 'Quincenal')),
    FechaFinCuatri DATETIME NOT NULL
);

CREATE TABLE ReservaEventual (
    ReservaId INT PRIMARY KEY FOREIGN KEY REFERENCES Reserva(ReservaId),
    CantidadSemanas INT NOT NULL CHECK (CantidadSemanas > 0)
);

-- ============================================
-- OCURRENCIAS (Materialización de sesiones)
-- ============================================
/*
	Sirve para materializar cada instancia individual de una reserva repetitiva. 
	Gracias a ella podremos:
	- Consultar disponibilidad exacta de un laboratorio por fecha y hora.
	- Detectar conflictos de reservas en una fecha específica.
	- Generar reportes históricos o de uso semanal.
	- Cancelar o modificar solo una de las repeticiones (sin eliminar toda la reserva general).
	- Registrar asistencia o incidencias en una clase puntual, sin afectar la reserva completa.
*/
CREATE TABLE ReservaOcurrencia (
    OcurrenciaId INT IDENTITY PRIMARY KEY,
    ReservaId INT NOT NULL FOREIGN KEY REFERENCES Reserva(ReservaId),
    LaboratorioId INT NOT NULL FOREIGN KEY REFERENCES Laboratorio(LaboratorioId),
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    CONSTRAINT CK_Ocurrencia_Fechas CHECK (FechaFin > FechaInicio)
);

CREATE INDEX IX_ReservaOcurrencia_Lab_Fecha
ON ReservaOcurrencia (LaboratorioId, FechaInicio);
