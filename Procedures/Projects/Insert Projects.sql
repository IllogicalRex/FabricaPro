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