--ASINGAR UN PROYECTO
alter PROCEDURE Projects_Resources_C
	@Pro_ID INT,
	@Rec_ID INT
AS
	INSERT INTO [Projects_Resources] (Pro_ID, Rec_ID) VALUES (@Pro_ID,@Rec_ID)
	SELECT @Pro_ID AS Pro_ID, @Rec_ID AS Rec_ID
	SELECT @Pro_ID AS Pro_ID, @Rec_ID AS Rec_ID
GO
EXEC Projects_Resources_C 1, 1
GO