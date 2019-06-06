ALTER PROCEDURE Human_Resources_R
	@currentPage AS INT,
	@sizeData AS INT
AS
	SELECT [Rec_ID],
		[Name] ,
		[LastName],
		[Position],
		[Email]
	FROM [Human_Resources]
	--WHERE IsActive = 1
	ORDER BY [Rec_ID]
	OFFSET (@currentPage-1)*@sizeData ROWS 
	FETCH NEXT @sizeData ROWS ONLY 
GO

EXECUTE Human_Resources_R 2, 3
GO