-- === USUARIOS ===
CREATE OR ALTER PROCEDURE [Acce].[sp_Usuarios_crear]
    @Usua_Usuario VARCHAR(50),
    @Usua_Clave VARCHAR(50),
    @Rol_Id INT,
    @Usua_IsAdmin BIT,
    @Usua_Creacion INT,
    @Usua_FechaCreacion DATETIME,
    @ID INT OUTPUT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbUsuarios] (Usua_Usuario, Usua_Clave, Rol_Id, Usua_IsAdmin, Usua_Creacion, Usua_FechaCreacion)
        VALUES (@Usua_Usuario, HASHBYTES('SHA2_512', @Usua_Clave), @Rol_Id, @Usua_IsAdmin, @Usua_Creacion, @Usua_FechaCreacion);
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Usuarios_editar]
    @Usua_Id INT,
    @Usua_Usuario VARCHAR(50),
    @Usua_Clave VARCHAR(50),
    @Rol_Id INT,
    @Usua_IsAdmin BIT,
    @Usua_Modificacion INT,
    @Usua_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbUsuarios]
        SET Usua_Usuario = @Usua_Usuario,
            Usua_Clave = HASHBYTES('SHA2_512', @Usua_Clave),
            Rol_Id = @Rol_Id,
            Usua_IsAdmin = @Usua_IsAdmin,
            Usua_Modificacion = @Usua_Modificacion,
            Usua_FechaModificacion = @Usua_FechaModificacion
        WHERE Usua_Id = @Usua_Id;
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Usuarios_eliminar]
    @Usua_Id INT,
    @Usua_Estado BIT,
    @Usua_Modificacion INT,
    @Usua_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbUsuarios]
        SET Usua_Estado = @Usua_Estado,
            Usua_Modificacion = @Usua_Modificacion,
            Usua_FechaModificacion = @Usua_FechaModificacion
        WHERE Usua_Id = @Usua_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Usuarios_listar]
AS
BEGIN
    SELECT Usua_Id, Usua_Usuario, Usua_Clave, u.Rol_Id, r.Rol_Descripcion, Usua_IsAdmin 
    FROM [Acce].[tbUsuarios] as u
    JOIN [Acce].[tbRoles] as r on u.Rol_Id = r.Rol_Id
    WHERE Usua_Estado = 1 AND r.Rol_Estado = 1;
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Usuarios_obtener]
    @Usua_Id INT
AS
BEGIN
    SELECT Usua_Id, Usua_Usuario, Usua_Clave, u.Rol_Id, r.Rol_Descripcion, Usua_IsAdmin, Usua_Creacion, Usua_FechaCreacion, Usua_Modificacion, Usua_FechaModificacion
    FROM [Acce].[tbUsuarios] as u
    JOIN [Acce].[tbRoles] as r on u.Rol_Id = r.Rol_Id
    WHERE Usua_Id = @Usua_Id AND Usua_Estado = 1 AND r.Rol_Estado = 1;
END
GO

-- === ROLES ===
CREATE OR ALTER PROCEDURE [Acce].[sp_Roles_crear]
    @Rol_Descripcion VARCHAR(50),
    @Rol_Creacion INT,
    @Rol_FechaCreacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbRoles] (Rol_Descripcion, Rol_Creacion, Rol_FechaCreacion) VALUES (@Rol_Descripcion, @Rol_Creacion, @Rol_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Roles_editar]
    @Rol_Id INT,
    @Rol_Descripcion VARCHAR(50),
    @Rol_Modificacion INT,
    @Rol_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbRoles]
        SET Rol_Descripcion = @Rol_Descripcion,
            Rol_Modificacion = @Rol_Modificacion,
            Rol_FechaModificacion = @Rol_FechaModificacion
        WHERE Rol_Id = @Rol_Id;
        SELECT 1 AS Resultado;  

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Roles_eliminar]
    @Rol_Id INT,
    @Rol_Estado BIT,
    @Rol_Modificacion INT,
    @Rol_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbRoles]
        SET Rol_Estado = @Rol_Estado,
            Rol_Modificacion = @Rol_Modificacion,
            Rol_FechaModificacion = @Rol_FechaModificacion 
        WHERE Rol_Id = @Rol_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Roles_listar] AS
BEGIN
    SELECT Rol_Id, Rol_Descripcion
    FROM [Acce].[tbRoles]
    WHERE Rol_Estado = 1;
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Roles_obtener]
    @Rol_Id INT
AS
BEGIN
    SELECT Rol_Id, Rol_Descripcion, Rol_Creacion, Rol_FechaCreacion, Rol_Modificacion, Rol_FechaModificacion
    FROM [Acce].[tbRoles]
    WHERE Rol_Id = @Rol_Id AND Rol_Estado = 1;
END
GO

-- === PANTALLAS ===
CREATE OR ALTER PROCEDURE [Acce].[sp_Pantallas_crear]
    @Pant_Descripcion varchar(50),
    @Pant_Creacion int,
    @Pant_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbPantallas] (Pant_Descripcion, Pant_Creacion, Pant_FechaCreacion)
        VALUES (@Pant_Descripcion, @Pant_Creacion, @Pant_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Pantallas_editar]
    @Pant_Id int,
    @Pant_Descripcion varchar(50),
    @Pant_Modificacion int,
    @Pant_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbPantallas]
        SET Pant_Descripcion = @Pant_Descripcion,
            Pant_Modificacion = @Pant_Modificacion,
            Pant_FechaModificacion = @Pant_FechaModificacion
        WHERE Pant_Id = @Pant_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Pantallas_eliminar]
    @Pant_Id int,
    @Pant_Estado bit,
    @Pant_Modificacion int,
    @Pant_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbPantallas]
        SET Pant_Estado = @Pant_Estado,
            Pant_Modificacion = @Pant_Modificacion,
            Pant_FechaModificacion = @Pant_FechaModificacion
        WHERE Pant_Id = @Pant_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Pantallas_listar] AS
BEGIN
    SELECT Pant_Id, Pant_Descripcion
    FROM [Acce].[tbPantallas]
    WHERE Pant_Estado = 1;
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Pantallas_obtener]
    @Pant_Id int
AS
BEGIN
    SELECT Pant_Id, Pant_Descripcion, Pant_Creacion, Pant_FechaCreacion, Pant_Modificacion, Pant_FechaModificacion
    FROM [Acce].[tbPantallas]
    WHERE Pant_Id = @Pant_Id AND Pant_Estado = 1;
END
GO

-- === PANTALLAS POR ROL ===
CREATE OR ALTER PROCEDURE [Acce].[sp_PantallasPorRol_crear]
    @Rol_Id int,
    @Pant_Id int,
    @Prol_Creacion int,
    @Prol_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbPantallasPorRol] (Rol_Id, Pant_Id, Prol_Creacion, Prol_FechaCreacion)
        VALUES (@Rol_Id, @Pant_Id, @Prol_Creacion, @Prol_FechaCreacion);
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_PantallasPorRol_eliminar]
    @Rol_Id int
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM [Acce].[tbPantallasPorRol]
        WHERE Prol_Id = @Rol_Id;
        SELECT 1 AS Resultado; 

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

-- === ESTADOS ===
CREATE OR ALTER PROCEDURE [Acce].[sp_Estados_crear]
    @Esta_Id varchar(2),
    @Esta_Descripcion varchar(50),
    @Esta_Creacion int,
    @Esta_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Acce].[tbEstados] ( Esta_Id, Esta_Descripcion, Esta_Creacion, Esta_FechaCreacion)
        VALUES (@Esta_Id, @Esta_Descripcion, @Esta_Creacion, @Esta_FechaCreacion);
        SELECT @Esta_Id AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Estados_editar]
    @Esta_Id varchar(2),
    @Esta_Descripcion varchar(50),
    @Esta_Modificacion int,
    @Esta_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Acce].[tbEstados]
        SET Esta_Descripcion = @Esta_Descripcion,
            Esta_Modificacion = @Esta_Modificacion,
            Esta_FechaModificacion = @Esta_FechaModificacion
        WHERE Esta_Id = @Esta_Id;
        SELECT 1 AS Resultado;

        COMMIT; 
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Estados_eliminar]
    @Esta_Id varchar(2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM [Acce].[tbEstados]
        WHERE Esta_Id = @Esta_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Estados_listar] AS
BEGIN
    SELECT Esta_Id, Esta_Descripcion
    FROM [Acce].[tbEstados]
    WHERE Esta_Estado = 1;
END
GO

CREATE OR ALTER PROCEDURE [Acce].[sp_Estados_obtener]
    @Esta_Id varchar(2)
AS
BEGIN
    SELECT Esta_Id, Esta_Descripcion, Esta_Creacion, Esta_FechaCreacion, Esta_Modificacion, Esta_FechaModificacion
    FROM [Acce].[tbEstados]
    WHERE Esta_Id = @Esta_Id AND Esta_Estado = 1;
END
GO

-- === CIUDADES ===
CREATE OR ALTER PROCEDURE [Gene].[sp_Ciudades_crear]
    @Ciud_Id varchar(4),
    @Esta_Id varchar(2),
    @Ciud_Descripcion varchar(50),
    @Ciud_Creacion int,
    @Ciud_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Gene].[tbCiudades] ( Ciud_Id, Esta_Id, Ciud_Descripcion, Ciud_Creacion, Ciud_FechaCreacion)
        VALUES ( @Ciud_Id, @Esta_Id, @Ciud_Descripcion, @Ciud_Creacion, @Ciud_FechaCreacion);
        SELECT @Ciud_Id AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[tbCiudades_editar]
    @Ciud_Id varchar(4),
    @Esta_Id varchar(2),
    @Ciud_Descripcion varchar(50),
    @Ciud_Modificacion int,
    @Ciud_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbCiudades]
        SET Esta_Id = @Esta_Id,
            Ciud_Descripcion = @Ciud_Descripcion,
            Ciud_Modificacion = @Ciud_Modificacion,
            Ciud_FechaModificacion = @Ciud_FechaModificacion
        WHERE Ciud_Id = @Ciud_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Ciudades_eliminar]
    @Ciud_Id varchar(4)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM [Gene].[tbCiudades]
        WHERE Ciud_Id = @Ciud_Id;
        SELECT 1 AS Resultado;

        COMMIT;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Ciudades_listar] AS
BEGIN
    SELECT Ciud_Id, Ciud_Descripcion, c.Esta_Id, e.Esta_Descripcion
    FROM [Gene].[tbCiudades] c
    JOIN [Gene].[tbEstados] e ON c.Esta_Id = e.Esta_Id
    WHERE Ciud_Estado = 1 AND e.Esta_Estado = 1;
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Ciudades_obtener]
    @Ciud_Id varchar(4)
AS
BEGIN
    SELECT Ciud_Id, Ciud_Descripcion, c.Esta_Id, e.Esta_Descripcion, Ciud_Creacion, Ciud_FechaCreacion, Ciud_Modificacion, Ciud_FechaModificacion
    FROM [Gene].[tbCiudades] c
    JOIN [Gene].[tbEstados] e ON c.Esta_Id = e.Esta_Id
    WHERE Ciud_Id = @Ciud_Id AND Ciud_Estado = 1 AND e.Esta_Estado = 1;
END
GO

-- === ESTADOS CIVILES ===
CREATE OR ALTER PROCEDURE [Gene].[sp_EstadosCiviles_crear]
    @EsCi_Descripcion varchar(50),
    @EsCi_Creacion int,
    @EsCi_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Gene].[tbEstadosCiviles] (EsCi_Descripcion, EsCi_Creacion, EsCi_FechaCreacion)
        VALUES (@EsCi_Descripcion, @EsCi_Creacion, @EsCi_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_EstadosCiviles_editar]
    @EsCi_Id int,
    @EsCi_Descripcion varchar(50),
    @EsCi_Modificacion int,
    @EsCi_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbEstadosCiviles]
        SET EsCi_Descripcion = @EsCi_Descripcion,
            EsCi_Modificacion = @EsCi_Modificacion,
            EsCi_FechaModificacion = @EsCi_FechaModificacion
        WHERE EsCi_Id = @EsCi_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_EstadosCiviles_eliminar]
    @EsCi_Id int,
    @EsCi_Estado bit,
    @EsCi_Modificacion int,
    @EsCi_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbEstadosCiviles]
        SET EsCi_Estado = @EsCi_Estado,
            EsCi_Modificacion = @EsCi_Modificacion,
            EsCi_FechaModificacion = @EsCi_FechaModificacion
        WHERE EsCi_Id = @EsCi_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER [Gene].[sp_EstadosCiviles_listar] AS
BEGIN
    SELECT EsCi_Id, EsCi_Descripcion
    FROM [Gene].[tbEstadosCiviles]
    WHERE EsCi_Estado = 1;
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_EstadosCiviles_obtener]
    @EsCi_Id int
AS
BEGIN
    SELECT EsCi_Id, EsCi_Descripcion, EsCi_Creacion, EsCi_FechaCreacion, EsCi_Modificacion, EsCi_FechaModificacion
    FROM [Gene].[tbEstadosCiviles]
    WHERE EsCi_Id = @EsCi_Id AND EsCi_Estado = 1;
END
GO

-- === PERSONAS ===
CREATE OR ALTER PROCEDURE [Gene].[sp_Personas_crear]
    @Pers_Identidad varchar(13),
    @Pers_PrimerNombre varchar(50),
    @Pers_SegundoNombre varchar(50),
    @Pers_PrimerApellido varchar(50),
    @Pers_SegundoApellido varchar(50),
    @EsCi_Id int,
    @Pers_Sexo char(1),
    @Pers_Creacion int,
    @Pers_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Gene].[tbPersonas] (Pers_Identidad, Pers_PrimerNombre, Pers_SegundoNombre, Pers_PrimerApellido, Pers_SegundoApellido, EsCi_Id, Pers_Sexo, Pers_Creacion, Pers_FechaCreacion)
        VALUES (@Pers_Identidad, @Pers_PrimerNombre, @Pers_SegundoNombre, @Pers_PrimerApellido, @Pers_SegundoApellido, @EsCi_Id, @Pers_Sexo, @Pers_Creacion, @Pers_FechaCreacion);
        SELECT @Pers_Identidad AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Personas_editar]
    @Pers_Identidad varchar(13),
    @Pers_PrimerNombre varchar(50),
    @Pers_SegundoNombre varchar(50),
    @Pers_PrimerApellido varchar(50),
    @Pers_SegundoApellido varchar(50),
    @EsCi_Id int,
    @Pers_Sexo char(1),
    @Pers_Modificacion int,
    @Pers_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbPersonas]
        SET Pers_PrimerNombre = @Pers_PrimerNombre,
            Pers_SegundoNombre = @Pers_SegundoNombre,
            Pers_PrimerApellido = @Pers_PrimerApellido,
            Pers_SegundoApellido = @Pers_SegundoApellido,
            EsCi_Id = @EsCi_Id,
            Pers_Sexo = @Pers_Sexo,
            Pers_Modificacion = @Pers_Modificacion,
            Pers_FechaModificacion = @Pers_FechaModificacion
        WHERE Pers_Identidad = @Pers_Identidad;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Personas_eliminar]
    @Pers_Identidad varchar(13),
    @Pers_Estado bit,
    @Pers_Modificacion int,
    @Pers_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbPersonas]
        SET Pers_Estado = @Pers_Estado,
            Pers_Modificacion = @Pers_Modificacion,
            Pers_FechaModificacion = @Pers_FechaModificacion
        WHERE Pers_Identidad = @Pers_Identidad;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

-- === CARGOS ===
CREATE OR ALTER PROCEDURE [Gene].[sp_Cargos_crear]
    @Carg_Descripcion varchar(50),
    @Carg_Creacion int,
    @Carg_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Gene].[tbCargos] (Carg_Descripcion, Carg_Creacion, Carg_FechaCreacion)
        VALUES (@Carg_Descripcion, @Carg_Creacion, @Carg_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Cargos_editar]
    @Carg_Id int,
    @Carg_Descripcion varchar(50),
    @Carg_Modificacion int,
    @Carg_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbCargos]
        SET Carg_Descripcion = @Carg_Descripcion,
            Carg_Modificacion = @Carg_Modificacion,
            Carg_FechaModificacion = @Carg_FechaModificacion
        WHERE Carg_Id = @Carg_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Cargos_eliminar]
    @Carg_Id int,
    @Carg_Estado bit,
    @Carg_Modificacion int,
    @Carg_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Gene].[tbCargos]
        SET Carg_Estado = @Carg_Estado,
            Carg_Modificacion = @Carg_Modificacion,
            Carg_FechaModificacion = @Carg_FechaModificacion
        WHERE Carg_Id = @Carg_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Cargos_listar]
AS
BEGIN
    SELECT Carg_Id, Carg_Descripcion
    FROM [Gene].[tbCargos]
    WHERE Carg_Estado = 1;
END
GO

CREATE OR ALTER PROCEDURE [Gene].[sp_Cargos_obtener]
    @Carg_Id int
AS
BEGIN
    SELECT Carg_Id, Carg_Descripcion
    FROM [Gene].[tbCargos]
    WHERE Carg_Id = @Carg_Id;
END
GO

-- === HOSPITALES ===
CREATE OR ALTER PROCEDURE [Turn].[sp_Hospitales_crear]
    @Hosp_Descripcion varchar(50),
    @Hosp_Direccion varchar(50),
    @Ciud_Id varchar(4),
    @Hosp_Creacion int,
    @Hosp_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Turn].[tbHospitales] (Hosp_Descripcion, Hosp_Direccion, Ciud_Id, Hosp_Creacion, Hosp_FechaCreacion)
        VALUES (@Hosp_Descripcion, @Hosp_Direccion, @Ciud_Id, @Hosp_Creacion, @Hosp_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_Hospitales_editar]
    @Hosp_Id int,
    @Hosp_Descripcion varchar(50),
    @Hosp_Direccion varchar(50),
    @Ciud_Id varchar(4),
    @Hosp_Modificacion int,
    @Hosp_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbHospitales]
        SET Hosp_Descripcion = @Hosp_Descripcion,
            Hosp_Direccion = @Hosp_Direccion,
            Ciud_Id = @Ciud_Id,
            Hosp_Modificacion = @Hosp_Modificacion,
            Hosp_FechaModificacion = @Hosp_FechaModificacion
        WHERE Hosp_Id = @Hosp_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_Hospitales_eliminar]
    @Hosp_Id INT,
    @Hosp_Estado BIT,
    @Hosp_Modificacion INT,
    @Hosp_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [turn].[tbHospitales]
        SET Hosp_Estado = @Hosp_Estado,
            Hosp_Modificacion = @Hosp_Modificacion,
            Hosp_FechaModificacion = @Hosp_FechaModificacion
        WHERE Hosp_Id = @Hosp_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER [Turn].[sp_Hospitales_listar] AS
BEGIN
    SELECT [Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], h.Ciud_Id, c.Ciud_Descripcion
    FROM [Turn].[tbHospitales] h
    INNER JOIN [Gene].[tbCiudades] c ON c.Ciud_Id = h.Ciud_Id
    WHERE [Hosp_Estado] = 1 AND c.Ciud_Estado = 1;
END
GO

CREATE OR ALTER [turn].[sp_Hospitales_obtener] 
@Hosp_Id int
AS
BEGIN
    SELECT [Hosp_Id], [Hosp_Descripcion], [Hosp_Direccion], [Ciud_Id], h.[Ciud_Descripcion], Ciud_Creacion, Ciud_FechaCreacion, Ciud_Modificacion, Ciud_FechaModificacion
    FROM [Turn].[tbHospitales] h
    INNER JOIN [Gene].[tbCiudades] c ON c.Ciud_Id = h.Ciud_Id
    WHERE [Hosp_Estado] = 1 AND c.Ciud_Estado = 1 AND [Hosp_Id] = @Hosp_Id;
END
GO

-- === EMPLEADOS ===
CREATE OR ALTER PROCEDURE [Turn].[sp_Empleados_crear]
    @Pers_Identidad varchar(13),
    @Usua_Id int,
    @Carg_Id int,
    @Hosp_Id int,
    @Empl_Creacion int,
    @Empl_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Turn].[tbEmpleados] (Pers_Identidad, Usua_Id, Carg_Id, Hosp_Id, Empl_Creacion, Empl_FechaCreacion)
        VALUES (@Pers_Identidad, @Usua_Id, @Carg_Id, @Hosp_Id, @Empl_Creacion, @Empl_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_Empleados_editar]
    @Empl_Id int,
    @Pers_Identidad varchar(13),
    @Usua_Id int,
    @Carg_Id int,
    @Hosp_Id int,
    @Empl_Modificacion int,
    @Empl_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbEmpleados]
        SET Pers_Identidad = @Pers_Identidad,
            Usua_Id = @Usua_Id,
            Carg_Id = @Carg_Id,
            Hosp_Id = @Hosp_Id,
            Empl_Modificacion = @Empl_Modificacion,
            Empl_FechaModificacion = @Empl_FechaModificacion
        WHERE Empl_Id = @Empl_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_Empleados_eliminar]
    @Empl_Id INT,
    @Empl_Estado BIT,
    @Empl_Modificacion INT,
    @Empl_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbEmpleados]
        SET Empl_Estado = @Empl_Estado,
            Empl_Modificacion = @Empl_Modificacion,
            Empl_FechaModificacion = @Empl_FechaModificacion
        WHERE Empl_Id = @Empl_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER [Turn].[sp_Empleados_listar] AS
BEGIN
    SELECT [Empl_Id], [Pers_Identidad], CONCAT(p.Pers_PrimerNombre, ' ', p.Pers_PrimerApellido) as Nombre, [Carg_Id], c.Carg_Descripcion, [Hosp_Id], h.Hosp_Descripcion
    FROM [Turn].[tbEmpleados]
    JOIN [Gene].[tbCargos] c ON c.Carg_Id = [Carg_Id]
    JOIN [Turn].[tbHospitales] h ON h.Hosp_Id = [Hosp_Id]
    JOIN [Gene].[tbPersonas] p ON p.Pers_Identidad = [Pers_Identidad]
    WHERE [Empl_Estado] = 1 AND c.Carg_Estado = 1 AND h.Hosp_Estado = 1 AND p.Pers_Estado = 1 AND [Empl_Id] = @Empl_Id;
END
GO

CREATE OR ALTER [Turn].[sp_Empleados_buscar] AS
@Empl_Id INT
BEGIN
    SELECT [Empl_Id], [Pers_Identidad], CONCAT(p.Pers_PrimerNombre, ' ', p.Pers_PrimerApellido) as Nombre,
    p.Pers_PrimerNombre, p.Pers_SegundoNombre, p.Pers_PrimerApellido, p.Pers_SegundoApellido, p.Pers_Sexo, p.EsCi_Id, es.EsCi_Descripcion, [Carg_Id], c.Carg_Descripcion, [Hosp_Id], h.Hosp_Descripcion
    FROM [Turn].[tbEmpleados]
    JOIN [Gene].[tbCargos] c ON c.Carg_Id = [Carg_Id]
    JOIN [Turn].[tbHospitales] h ON h.Hosp_Id = [Hosp_Id]
    JOIN [Gene].[tbPersonas] p ON p.Pers_Identidad = [Pers_Identidad]
    JOIN [Gene].[tbEstadosCiviles] es ON es.EsCi_Id = p.EsCi_Id
    WHERE [Empl_Id] = @Empl_Id AND [Empl_Estado] = 1 AND c.Carg_Estado = 1 AND h.Hosp_Estado = 1 AND p.Pers_Estado = 1;
END
GO


-- === TURNOS ===
CREATE OR ALTER PROCEDURE [Turn].[sp_Turnos_crear]
    @Turn_Descripcion varchar(50),
    @Turn_Horario time,
    @Turn_Creacion int,
    @Turn_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Turn].[tbTurnos] (Turn_Descripcion, Turn_Horario, Turn_Creacion, Turn_FechaCreacion)
        VALUES (@Turn_Descripcion, @Turn_Horario, @Turn_Creacion, @Turn_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_Turnos_editar]
    @Turn_Id int,
    @Turn_Descripcion varchar(50),
    @Turn_Horario time,
    @Turn_Modificacion int,
    @Turn_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbTurnos]
        SET Turn_Descripcion = @Turn_Descripcion,
            Turn_Horario = @Turn_Horario,
            Turn_Modificacion = @Turn_Modificacion,
            Turn_FechaModificacion = @Turn_FechaModificacion
        WHERE Turn_Id = @Turn_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_Turnos_eliminar]
    @Turn_Id INT,
    @Turn_Estado BIT,
    @Turn_Modificacion INT,
    @Turn_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbTurnos]
        SET Turn_Estado = @Turn_Estado,
            Turn_Modificacion = @Turn_Modificacion,
            Turn_FechaModificacion = @Turn_FechaModificacion
        WHERE Turn_Id = @Turn_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE  [Turn].[sp_Turnos_listar] AS
BEGIN
    SELECT [Turn_Id], [Turn_Descripcion], [Turn_Horario]
    FROM [Turn].[tbTurnos]
    WHERE [Turn_Estado] = 1;
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_Turnos_buscar] AS
@Turn_Id int
BEGIN
    SELECT [Turn_Id], [Turn_Descripcion], [Turn_Horario]
    FROM [Turn].[tbTurnos]
    WHERE [Turn_Id] = @Turn_Id AND [Turn_Estado] = 1;
END
GO

-- === TURNOS POR EMPLEADOS ===
CREATE OR ALTER PROCEDURE [Turn].[sp_TurnosPorEmpleados_crear]
    @TuEm_FechaInicio date,
    @Turn_Id int,
    @Empl_Id int,
    @TuEm_Creacion int,
    @TuEm_FechaCreacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO [Turn].[tbTurnosPorEmpleados] (TuEm_FechaInicio, Turn_Id, Empl_Id, TuEm_Creacion, TuEm_FechaCreacion)
        VALUES (@TuEm_FechaInicio, @Turn_Id, @Empl_Id, @TuEm_Creacion, @TuEm_FechaCreacion);
        DECLARE @ID INT;
        SET @ID = SCOPE_IDENTITY();
        SELECT @ID AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_TurnosPorEmpleados_editar]
    @TuEm_Id int,
    @TuEm_FechaInicio date,
    @Turn_Id int,
    @Empl_Id int,
    @TuEm_Modificacion int,
    @TuEm_FechaModificacion datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbTurnosPorEmpleados]
        SET TuEm_FechaInicio = @TuEm_FechaInicio,
            Turn_Id = @Turn_Id,
            Empl_Id = @Empl_Id,
            TuEm_Modificacion = @TuEm_Modificacion,
            TuEm_FechaModificacion = @TuEm_FechaModificacion
        WHERE TuEm_Id = @TuEm_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE [Turn].[sp_TurnosPorEmpleados_eliminar]
    @TuEm_Id INT,
    @TuEm_Estado BIT,
    @TuEm_Modificacion INT,
    @TuEm_FechaModificacion DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE [Turn].[tbTurnosPorEmpleados]
        SET TuEm_Estado = @TuEm_Estado,
            TuEm_Modificacion = @TuEm_Modificacion,
            TuEm_FechaModificacion = @TuEm_FechaModificacion
        WHERE TuEm_Id = @TuEm_Id;
        SELECT 1 AS Resultado;

        COMMIT;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Resultado;
        ROLLBACK;
    END CATCH
END
GO