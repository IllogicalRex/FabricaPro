-- CONSULTAR TODOS LOS RECURSOS QUE NO TENGAN ASIGNADO PROYECTO PAGINADO
ALTER PROCEDURE Projects_Resources_RR
	@currentPage AS INT,
	@sizeData AS INT
AS
SELECT 
	hr.Rec_ID,
	hr.Name,
	hr.LastName,
	hr.Position,
	hr.Email
FROM  Human_Resources  hr
	LEFT JOIN [Projects_Resources]  pr ON pr.Rec_ID = hr.Rec_ID 
	LEFT JOIN Projects p ON  p.Pro_ID = pr.Pro_ID
WHERE (p.Pro_ID IS NULL) --AND hr.IsActive = 1)
ORDER BY hr.Rec_ID
	OFFSET (@currentPage-1)*@sizeData ROWS 
	FETCH NEXT @sizeData ROWS ONLY
GO
exec Projects_Resources_RR 2,1
GO