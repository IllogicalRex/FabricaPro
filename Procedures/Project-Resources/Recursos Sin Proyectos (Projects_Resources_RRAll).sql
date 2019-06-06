-- CONSULTAR TODOS LOS RECURSOS QUE NO TENGAN ASIGNADO PROYECTO
Create PROCEDURE Projects_Resources_RRAll
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
GO
exec Projects_Resources_RRAll
GO