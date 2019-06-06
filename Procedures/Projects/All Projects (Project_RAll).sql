 --CONSULTAR TODOS LOS PROYECTOS

alter PROCEDURE Project_RAll
AS
	SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
	FROM [Projects]
	--WHERE IsActive = 1
GO
EXECUTE Project_RAll
GO