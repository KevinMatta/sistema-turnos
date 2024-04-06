-- === ESTADOS ===
INSERT INTO [Gene].[tbEstados] ([Esta_Id], [Esta_Descripcion], [Esta_Creacion], [Esta_FechaCreacion])
VALUES 
('04', 'Copan', 1, GETDATE()),
('02', 'Colon', 1,  GETDATE()),
('06', 'Choluteca', 1, GETDATE()),
('09', 'Gracias a Dios', 1, GETDATE()),
('10', 'Intibuca', 1, GETDATE()),
('08', 'Francisco Morazan', 1, GETDATE()),
('05', 'Cortes', 1, GETDATE());
GO
-- === CIUDADES ===
INSERT INTO [Gene].[tbCiudades] ([Ciud_Id], [Ciud_Descripcion], [Esta_Id], [Ciud_Creacion], [Ciud_FechaCreacion])
VALUES
('0401', 'Santa Rosa de Copan', '04', 1, GETDATE()),
('0201', 'trujillo', '02', 1, GETDATE()),
('0601', 'Choluteca', '06', 1, GETDATE()),
('0901', 'Puerto Lempira', '09', 1, GETDATE()),
('1001', 'La Esperanza', '10', 1, GETDATE()),
('0501', 'San Pedro Sula', '05', 1, GETDATE()),
('0801', 'Tegucigalpa', '08', 1, GETDATE());
GO

-- === PERSONAS ===
INSERT INTO [Gene].[tbPersonas] (
    [Pers_Identidad], 
    [Pers_PrimerNombre], 
    [Pers_PrimerApellido], 
    [EsCi_Id], 
    [Pers_Sexo], 
    [Pers_Creacion], 
    [Pers_FechaCreacion]
) 
VALUES  ('0320200100293', 'Mindy', 'Campos', 1, 'F', 1, GETDATE()),
        ('0512200600338', 'Alejandra', 'Solis', 1, 'F', 1, GETDATE()),
        ('1240200100004', 'Pavel', 'Campos', 1, 'M', 1, GETDATE()),
        ('0501200403104', 'Jason', 'Campos', 1, 'M', 1, GETDATE()),
        ('0410200101233', 'Victor', 'Campos', 1, 'M', 1, GETDATE());
GO

-- === CARGOS ===
INSERT INTO [Gene].[tbCargos] ([Carg_Descripcion], [Carg_Creacion], [Carg_FechaCreacion])
VALUES 
('Enfermero/a', 1, GETDATE()),
('Cirujano/a', 1, GETDATE()),
('Anestesiólogo/a', 1, GETDATE()),
('Técnico/a de Laboratorio', 1, GETDATE()),
('Farmacéutico/a', 1, GETDATE());
GO

-- === HOSPITALES ===
INSERT INTO [Turn].[tbHospitales] ([Hosp_Descripcion], [Hosp_Direccion], [Ciud_Id], [Hosp_Creacion], [Hosp_FechaCreacion])
VALUES 
('Hospital Escuela', 'Avenida La Paz', '0801', 1, GETDATE()),
('Hospital San Felipe', 'Calle Real', '0501', 1, GETDATE()),
('Hospital Mario Catarino Rivas', 'Avenida 15 de Septiembre', '0501', 1, GETDATE()),
('Hospital Leonardo Martínez', 'Avenida República de Honduras', '0801', 1, GETDATE()),
('Hospital Psiquiátrico Santa Rosita', 'Calle Principal', '0801', 1, GETDATE());
GO

-- === EMPLEADOS ===
INSERT INTO [Turn].[tbEmpleados] ([Pers_Identidad], [Carg_Id], [Hosp_Id], [Empl_Creacion], [Empl_FechaCreacion])
VALUES 
('0320200100293', 1, 1, 1, GETDATE()),
('0512200600338', 2, 2, 1, GETDATE()), 
('1240200100004', 3, 3, 1, GETDATE()),
('0501200403104', 4, 4, 1, GETDATE()), 
('0410200101233', 5, 5, 1, GETDATE()); 
GO

-- === TURNOS ===
INSERT INTO [Turn].[tbTurnos] ([Turn_Descripcion], [Turn_Horario], [Turn_Creacion], [Turn_FechaCreacion])
VALUES 
    ('Turno de mañana', '08:00:00', 1, GETDATE()),
    ('Turno de tarde', '6:00:00', 1, GETDATE()),
    ('Turno de noche', '10:00:00', 1, GETDATE()),
    ('Turno de guardia', '4:00:00', 1, GETDATE()),
    ('Turno especial', '12:00:00', 1, GETDATE());
GO

-- === TURNOS POR EMPLEADOS ===
INSERT INTO [Turn].[tbTurnosPorEmpleados] ([TuEm_FechaInicio], [Turn_Id], [Empl_Id], [TuEm_Creacion], [TuEm_FechaCreacion])
VALUES 
    ('2024-04-04', 1, 3, 1, GETDATE()),
    ('2024-04-04', 2, 4, 1, GETDATE()), 
    ('2024-04-04', 3, 5, 1, GETDATE()), 
    ('2024-04-05', 4, 6, 1, GETDATE()),
    ('2024-04-06', 5, 7, 1, GETDATE()); 
GO

