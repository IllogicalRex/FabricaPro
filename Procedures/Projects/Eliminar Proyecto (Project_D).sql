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