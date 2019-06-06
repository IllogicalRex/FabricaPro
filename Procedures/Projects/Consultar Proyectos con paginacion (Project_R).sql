--CONSULTAR PROJECTOS CON PAGINACION

ALTER PROCEDURE Project_R
	@currentPage AS INT,
	@sizeData AS INT
AS
	SELECT Pro_ID, Name, StartDate, EndDate, ProyectLeader
	FROM [Projects]
	--WHERE IsActive = 1
	ORDER BY Pro_ID
	OFFSET (@currentPage-1)*@sizeData ROWS 
	FETCH NEXT @sizeData ROWS ONLY 
GO