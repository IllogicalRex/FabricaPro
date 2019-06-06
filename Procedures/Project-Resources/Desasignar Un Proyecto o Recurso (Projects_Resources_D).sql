--DESASIFNAR UN PROYECTO
CREATE PROCEDURE Projects_Resources_D
	@Pro_ID INT,
	@Rec_ID INT
AS
	DELETE FROM Projects_Resources 
		WHERE Pro_ID = @Pro_ID AND Rec_ID = @Rec_ID
GO

EXEC Projects_Resources_D 1, 1002