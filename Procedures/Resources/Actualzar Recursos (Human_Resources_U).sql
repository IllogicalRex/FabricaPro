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