 --CONSULTAR TODOS LOS RECURSOS HUMANOS CON ID

CREATE PROCEDURE Resource_R_ByID
@Rec_ID Int
AS
	SELECT Rec_ID, Name, LastName, Position, Email
	FROM [Human_Resources]
	WHERE IsActive = 1 AND Rec_ID = @Rec_ID
GO

EXEC Resource_R_ByID 2
GO