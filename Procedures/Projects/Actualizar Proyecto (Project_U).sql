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