-- CONSULTAR TODOS LOS PROYECTOS QUE NO TENGAN ASIGNADO RECURSOS
ALTER PROCEDURE Projects_Resources_RP
	@currentPage AS INT,
	@sizeData AS INT
AS
SELECT 
	P.Pro_ID,
	p.Name,
	p.StartDate,
	p.EndDate,
	p.ProyectLeader
FROM  Projects p 
	LEFT JOIN [Projects_Resources]  pr ON pr.Pro_ID = p.Pro_ID
	LEFT JOIN Human_Resources hr ON hr.Rec_ID = pr.Rec_ID 
WHERE hr.Rec_ID IS NULL --AND P.IsActive = 1
ORDER BY hr.Rec_ID
	OFFSET (@currentPage-1)*@sizeData ROWS 
	FETCH NEXT @sizeData ROWS ONLY
GO
EXEC Projects_Resources_RP 2, 6
GO