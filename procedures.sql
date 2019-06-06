DBCC CHECKIDENT ('[Projects]', RESEED, 0) 

DELETE FROM Projects WHERE Pro_ID = 3
GO

--====================================================================================================
--								PROYECTOS
--====================================================================================================

-- PROCEDIMIENTO PARA INSERTAR PROYECTOS

CREATE PROCEDURE Project_C
  @Name VARCHAR(100),
  @StartDate DATETIME,
  @EndDate DATETIME,
  @ProyectLeader VARCHAR(100)
AS
INSERT INTO Projects(Name, StartDate, EndDate, ProyectLeader, IsActive) VALUES(@Name, @StartDaTE, @EndDate, @ProyectLeader, 1)
SELECT CAST(@@IDENTITY AS INT) AS Pro_ID

GO

EXECUTE Project_C 'Carlos','2007-04-30', '2007-04-30', Ruben
GO
SELECT * FROM [Projects]
GO


------------------------------------------------------------------------------------------------------------------------------
 --CONSULTAR TODOS LOS PROYECTOS
create PROCEDURE Project_RAll
AS
	SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
	FROM [Projects]
	WHERE IsActive = 1
GO

EXECUTE Project_RAll
GO

------------------------------------------------------------------------------------------------------------------------------
 --CONSULTAR TODOS LOS PROYECTOS
CREATE PROCEDURE Project_R_ByID
@Pro_ID Int
AS
	SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
	FROM [Projects]
	WHERE IsActive = 1 AND Pro_ID = @Pro_ID
GO

EXEC Project_R_ByID 2

------------------------------------------------------------------------------------------------------------------------------
--ELIMINAR UN PROYECTO
CREATE PROCEDURE Project_D
	@Pro_ID Int
AS    
	UPDATE Projects
		SET IsActive = 0
		WHERE Pro_ID = @Pro_ID

	SELECT @Pro_ID AS Pro_ID
GO  

EXECUTE Project_D 3
GO
SELECT * FROM [Projects]

------------------------------------------------------------------------------------------------------------------------------
--ACTUALZIAR UN PROYECTO
CREATE PROCEDURE Project_U
	@Pro_ID Int,
	@Name VARCHAR(100),
	@StartDate DATETIME,
	@EndDate DATETIME,
	@ProyectLeader VARCHAR(100)  
AS    
	UPDATE Projects
		SET Name = @name, StartDate = @StartDate, EndDate=@EndDate, ProyectLeader = @ProyectLeader
		WHERE Pro_ID = @Pro_ID

	SELECT @Pro_ID AS Pro_ID
GO  

EXECUTE Project_U 9,'Aaron','2007-04-30 00:00:00.000','2007-04-30 00:00:00.000','Ruben'
GO
SELECT * FROM Projects
GO

--====================================================================================================
--								RECURSOS HUMANOS
--====================================================================================================

-- PROCEDIMIENTO PARA INSERTAR RECURSOS HUMANOS


CREATE PROCEDURE Human_Resources_C
  @Name VARCHAR(100),
  @LastName VARCHAR(100),
  @Position VARCHAR(100),
  @Email VARCHAR(150)
AS
INSERT INTO [Human_Resources]([Name], [LastName], [Position], [Email], [IsActive]) VALUES(@Name, @LastName, @Position, @Email, 1)
SELECT CAST(@@IDENTITY AS INT) AS Rec_ID
GO

EXECUTE Human_Resources_C 'Josue','Trujillo', 'Empleado', 'josue@gmail.com'
GO
SELECT * FROM Human_Resources
GO

------------------------------------------------------------------------------------------------------------------------------
 --CONSULTAR TODOS LOS RECURSOS HUMANOS
CREATE PROCEDURE Human_Resources_R
AS
	SELECT [Rec_ID],
		[Name] ,
		[LastName],
		[Position],
		[Email]
	FROM [Human_Resources]
	WHERE IsActive = 1
GO

EXECUTE Human_Resources_R
GO

------------------------------------------------------------------------------------------------------------------------------
 --CONSULTAR TODOS LOS RECURSOS HUMANOS CON ID
CREATE PROCEDURE Resource_R_ByID
@Rec_ID Int
AS
	SELECT Rec_ID, Name, LastName, Position, Email
	FROM [Human_Resources]
	WHERE IsActive = 1 AND Rec_ID = @Rec_ID
GO

EXEC Resource_R_ByID 2
------------------------------------------------------------------------------------------------------------------------------
--ELIMINAR RECURSOS HUMANOS
CREATE PROCEDURE Human_Resources_D
	@Rec_ID Int
AS    
	UPDATE [Human_Resources]
		SET IsActive = 0
		WHERE Rec_ID = @Rec_ID

	SELECT @Rec_ID AS Rec_ID
GO  

EXECUTE Human_Resources_D 3
GO
SELECT * FROM [Human_Resources]
GO
------------------------------------------------------------------------------------------------------------------------------
--ACTUALIZAR RECURSOS HUMANOS
CREATE PROCEDURE Human_Resources_U
	@Rec_ID Int,
	@Name VARCHAR(100),
	@LastName VARCHAR(100),
	@Position VARCHAR(100),
	@Email VARCHAR(150) 
AS    
	UPDATE [Human_Resources]
		SET Name = @Name, LastName = @LastName, Position=@Position, Email = @Email
		WHERE Rec_ID = @Rec_ID

	SELECT @Rec_ID AS Rec_ID
GO  

select * from Human_Resources
GO
--====================================================================================================
--								ASIGNACION DE PROYECTOS
--====================================================================================================
-- CONSULTAR TODOS LOS PROYECTOS QUE NO TENGAN ASIGNADO RECURSOS
alter PROCEDURE Projects_Resources_RPAll
AS
SELECT 
	P.Pro_ID,
	p.Name,
	p.StartDate,
	p.EndDate,
	p.ProyectLeader
FROM  Projects p 
	LEFT JOIN [Projects_Resources]  pr ON pr.Pro_ID = p.Pro_ID
	LEFT JOIN Human_Resources hr ON hr.Rec_ID = pr.Rec_ID 
WHERE hr.Rec_ID IS NULL --AND P.IsActive = 1
GO
EXEC Projects_Resources_RP
GO

-- CONSULTAR TODOS LOS PROYECTOS QUE NO TENGAN ASIGNADO RECURSOS
ALTER PROCEDURE Projects_Resources_RP
	@currentPage AS INT,
	@sizeData AS INT
AS
SELECT 
	P.Pro_ID,
	p.Name,
	p.StartDate,
	p.EndDate,
	p.ProyectLeader
FROM  Projects p 
	LEFT JOIN [Projects_Resources]  pr ON pr.Pro_ID = p.Pro_ID
	LEFT JOIN Human_Resources hr ON hr.Rec_ID = pr.Rec_ID 
WHERE hr.Rec_ID IS NULL --AND P.IsActive = 1
ORDER BY hr.Rec_ID
	OFFSET (@currentPage-1)*@sizeData ROWS 
	FETCH NEXT @sizeData ROWS ONLY
GO
EXEC Projects_Resources_RP 2, 6
GO


-- CONSULTAR TODOS LOS RECURSOS QUE NO TENGAN ASIGNADO PROYECTO
Create PROCEDURE Projects_Resources_RRAll
AS
SELECT 
	hr.Rec_ID,
	hr.Name,
	hr.LastName,
	hr.Position,
	hr.Email
FROM  Human_Resources  hr
	LEFT JOIN [Projects_Resources]  pr ON pr.Rec_ID = hr.Rec_ID 
	LEFT JOIN Projects p ON  p.Pro_ID = pr.Pro_ID
WHERE (p.Pro_ID IS NULL) --AND hr.IsActive = 1)
GO
exec Projects_Resources_RRAll
GO

-- CONSULTAR TODOS LOS RECURSOS QUE NO TENGAN ASIGNADO PROYECTO PAGINADO
ALTER PROCEDURE Projects_Resources_RR
	@currentPage AS INT,
	@sizeData AS INT
AS
SELECT 
	hr.Rec_ID,
	hr.Name,
	hr.LastName,
	hr.Position,
	hr.Email
FROM  Human_Resources  hr
	LEFT JOIN [Projects_Resources]  pr ON pr.Rec_ID = hr.Rec_ID 
	LEFT JOIN Projects p ON  p.Pro_ID = pr.Pro_ID
WHERE (p.Pro_ID IS NULL) --AND hr.IsActive = 1)
ORDER BY hr.Rec_ID
	OFFSET (@currentPage-1)*@sizeData ROWS 
	FETCH NEXT @sizeData ROWS ONLY
GO
exec Projects_Resources_RR 2,1
GO

-- PROCEDIMIENTO: PROYECTOS CON RECURSOS ASIGNADOS 

ALTER PROCEDURE Projects_Resources_R
AS
	SELECT 
		p.Pro_ID, 
		p.Name AS NameProject, 
		hr.Rec_ID, 
		hr.Name AS NameResource
	FROM  Human_Resources  hr
		INNER JOIN [Projects_Resources]  pr ON pr.Rec_ID = hr.Rec_ID 
		INNER JOIN Projects p ON  p.Pro_ID = pr.Pro_ID
	--WHERE p.IsActive = 1
GO
EXEC Projects_Resources_R
GO

--ASINGAR UN PROYECTO
alter PROCEDURE Projects_Resources_C
	@Pro_ID INT,
	@Rec_ID INT
AS
	INSERT INTO [Projects_Resources] (Pro_ID, Rec_ID) VALUES (@Pro_ID,@Rec_ID)
	SELECT @Pro_ID AS Pro_ID, @Rec_ID AS Rec_ID
	SELECT @Pro_ID AS Pro_ID, @Rec_ID AS Rec_ID
GO
EXEC Projects_Resources_C 1, 1
GO
--DESASIFNAR UN PROYECTO
CREATE PROCEDURE Projects_Resources_D
	@Pro_ID INT,
	@Rec_ID INT
AS
	DELETE FROM Projects_Resources 
		WHERE Pro_ID = @Pro_ID AND Rec_ID = @Rec_ID
GO

/*
--DESASIFNAR UN PROYECTO
CREATE PROCEDURE Projects_Resources_U
	@Pro_ID INT,
	@Rec_ID INT
AS
	DELETE FROM Projects_Resources 
		WHERE Pro_ID = @Pro_ID AND Rec_ID = @Rec_ID
GO
*/
EXEC Projects_Resources_D 2, 1

EXEC Projects_Resources_R


DECLARE @pagenum AS INT
DECLARE @pagesize AS INT 
SET @pagenum = 2;
SET @pagesize = 5;
SELECT 
	P.Pro_ID,
	p.Name,
	p.StartDate,
	p.EndDate,
	p.ProyectLeader
FROM  Projects p 
	LEFT JOIN [Projects_Resources]  pr ON pr.Pro_ID = p.Pro_ID
	LEFT JOIN Human_Resources hr ON hr.Rec_ID = pr.Rec_ID 
WHERE hr.Rec_ID IS NULL AND P.IsActive = 1
ORDER BY HR.Rec_ID
OFFSET (@pagenum - 1) * @pagesize ROWS 
FETCH NEXT @pagesize ROWS ONLY;



--CONSULTAR PROJECTOS CON PAGINACION
ALTER PROCEDURE Project_R
	@currentPage AS INT,
	@sizeData AS INT
AS
	SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
	FROM [Projects]
	--WHERE IsActive = 1
	ORDER BY Pro_ID
	OFFSET (@currentPage-1)*@sizeData ROWS 
	FETCH NEXT @sizeData ROWS ONLY 
GO

EXEC Project_R 2,5

SELECT * FROM Projects