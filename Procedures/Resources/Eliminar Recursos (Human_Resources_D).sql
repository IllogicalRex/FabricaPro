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
