

 --CONSULTAR TODOS LOS PROYECTOS
ALTER PROCEDURE Project_R_ByFilter
	@Name VARCHAR(100),
	@ProyectLeader VARCHAR(100)  
AS
	IF(@Name = '')
	BEGIN
		SET @Name = NULL;
		SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
		FROM [Projects]
		WHERE 
			 (ProyectLeader LIKE '%'+@ProyectLeader+'%')
	END
	ELSE IF(@ProyectLeader = '')
	BEGIN
		SET @ProyectLeader = NULL;
		SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
		FROM [Projects]
		WHERE 
			 (Name LIKE '%'+@Name+'%')
	END
	ELSE 
	BEGIN 
		SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
		FROM [Projects]
		WHERE 
			 (Name LIKE '%'+@Name+'%') and (ProyectLeader LIKE '%'+@ProyectLeader+'%')
		--WHERE IsActive = 1
	END
GO
EXECUTE Project_R_ByFilter 'mic','carlos'
GO