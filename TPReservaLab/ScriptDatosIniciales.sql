USE TPReservaLab;
GO

-- --------------------------------------------
-- 1. Laboratorios (Laboratorio)
-- Requisito: La empresa cuenta con 6 laboratorios.
-- --------------------------------------------
INSERT INTO Laboratorio (Numero, UbicacionPiso, CapacidadPuestos)
VALUES 
(101, 'Planta Baja', 30),
(205, 'Primer Piso', 25),
(302, 'Segundo Piso', 20),
(303, 'Segundo Piso', 20),
(401, 'Tercer Piso', 35),
(501, 'Cuarto Piso', 25);
GO

-- --------------------------------------------
-- 2. Profesores (Profesor)
-- --------------------------------------------
INSERT INTO Profesor (NombreCompleto, Email)
VALUES 
('Dr. Marcelo García', 'marcelo.garcia@inst.edu'),     -- ProfesorId: 1
('Ing. Ana López', 'ana.lopez@inst.edu'),             -- ProfesorId: 2
('Lic. Ricardo Pérez', 'ricardo.perez@inst.edu'),     -- ProfesorId: 3
('Mgs. Julia Fernández', 'julia.fdez@inst.edu');      -- ProfesorId: 4
GO

-- --------------------------------------------
-- 3. Carreras (Carrera)
-- --------------------------------------------
INSERT INTO Carrera (Nombre)
VALUES 
('Ingeniería en Sistemas de Información'),  -- CarreraId: 1
('Licenciatura en Diseño Gráfico'),         -- CarreraId: 2
('Tecnicatura en Redes Informáticas');      -- CarreraId: 3
GO

-- --------------------------------------------
-- 4. Asignaturas (Asignatura)
-- --------------------------------------------
INSERT INTO Asignatura (Nombre, CarreraId)
VALUES 
('Programación Avanzada', 1),   -- AsignaturaId: 1 (Ing. Sistemas)
('Bases de Datos I', 1),        -- AsignaturaId: 2 (Ing. Sistemas)
('Diseño Web', 2),              -- AsignaturaId: 3 (Lic. Diseño)
('Sistemas Operativos', 3);     -- AsignaturaId: 4 (Tec. Redes)
GO

-- --------------------------------------------
-- 5. Comisiones (Comision)
-- --------------------------------------------
INSERT INTO Comision (Codigo, Anio, AsignaturaId)
VALUES 
('SIA2025C1', 2025, 1),  -- ComisionId: 1 (Prog. Avanzada - 2025)
('BDI2024C2', 2024, 2),  -- ComisionId: 2 (Bases de Datos I - 2024)
('DWG2025C1', 2025, 3),  -- ComisionId: 3 (Diseño Web - 2025)
('SOI2025C3', 2025, 4);  -- ComisionId: 4 (Sistemas Operativos - 2025)
GO

-- --------------------------------------------
-- 6. Reservas
-- Nota: La tabla TipoReserva (IDs 1: Cuatrimestral, 2: Eventual) ya fue poblada en el DDL.
-- --------------------------------------------
DECLARE @Hoy DATETIME = GETDATE();
DECLARE @ProxLunes DATETIME = DATEADD(dd, 7 - (@@DATEFIRST + DATEPART(dw, @Hoy) - 2) % 7, @Hoy);

-- Reserva Cuatrimestral (Semanal)
INSERT INTO Reserva (TipoReservaId, LaboratorioId, ProfesorId, CarreraId, AsignaturaId, ComisionId, FechaInicio, FechaFin, Observaciones)
VALUES 
(1, 1, 1, 1, 1, 1, DATEADD(hour, 10, @ProxLunes), DATEADD(hour, 12, @ProxLunes), 'Clase teórica/práctica semanal');
DECLARE @ReservaCuatriId INT = SCOPE_IDENTITY();

INSERT INTO ReservaCuatrimestral (ReservaId, Frecuencia, FechaFinCuatri)
VALUES (@ReservaCuatriId, 'Semanal', DATEADD(week, 16, @ProxLunes));

-- Reserva Eventual (Un solo evento)
INSERT INTO Reserva (TipoReservaId, LaboratorioId, ProfesorId, CarreraId, AsignaturaId, ComisionId, FechaInicio, FechaFin, Observaciones)
VALUES 
(2, 2, 2, 2, 3, 3, DATEADD(hour, 14, @ProxLunes), DATEADD(hour, 16, @ProxLunes), 'Taller especial de Photoshop');
DECLARE @ReservaEventualId INT = SCOPE_IDENTITY();

INSERT INTO ReservaEventual (ReservaId, CantidadSemanas)
VALUES (@ReservaEventualId, 1);

-- Reserva Conflictiva/Activa (Usada para probar la lógica de baja de Laboratorio)
INSERT INTO Reserva (TipoReservaId, LaboratorioId, ProfesorId, CarreraId, AsignaturaId, ComisionId, FechaInicio, FechaFin, Observaciones, IsActive)
VALUES 
(2, 3, 3, 3, 4, 4, DATEADD(hour, 19, @ProxLunes), DATEADD(hour, 21, @ProxLunes), 'Clase de laboratorio activo', 1);
DECLARE @ReservaActivaId INT = SCOPE_IDENTITY();

INSERT INTO ReservaEventual (ReservaId, CantidadSemanas)
VALUES (@ReservaActivaId, 1);


-- --------------------------------------------
-- 7. Ocurrencias (ReservaOcurrencia)
-- Materializamos algunas sesiones para el reporte.
-- --------------------------------------------

-- Ocurrencias para la Reserva Cuatrimestral (ID: @ReservaCuatriId)
INSERT INTO ReservaOcurrencia (ReservaId, LaboratorioId, FechaInicio, FechaFin)
VALUES
(@ReservaCuatriId, 1, DATEADD(hour, 10, @ProxLunes), DATEADD(hour, 12, @ProxLunes)),              -- Semana 1
(@ReservaCuatriId, 1, DATEADD(hour, 10, DATEADD(week, 1, @ProxLunes)), DATEADD(hour, 12, DATEADD(week, 1, @ProxLunes))), -- Semana 2

-- Ocurrencia para la Reserva Activa (ID: @ReservaActivaId)
(@ReservaActivaId, 3, DATEADD(hour, 19, @ProxLunes), DATEADD(hour, 21, @ProxLunes));
GO

SELECT 'Datos de Prueba Insertados Correctamente' AS Estado;
SELECT * FROM Laboratorio;
SELECT * FROM Profesor;
SELECT * FROM Carrera;
SELECT * FROM Asignatura;
SELECT * FROM Comision;
SELECT * FROM Reserva;
SELECT * FROM ReservaCuatrimestral;
SELECT * FROM ReservaEventual;
SELECT * FROM ReservaOcurrencia;
GO