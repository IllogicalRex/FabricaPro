 --CONSULTAR PROJECTOS POR ID
alter PROCEDURE Project_R_ByID
@Pro_ID Int
AS
	SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
	FROM [Projects]
	WHERE /*IsActive = 1 AND*/ Pro_ID = @Pro_ID
GO
EXEC Project_R_ByID 1002
GO