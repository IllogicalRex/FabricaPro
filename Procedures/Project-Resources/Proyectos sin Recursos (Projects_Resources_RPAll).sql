-- CONSULTAR TODOS LOS PROYECTOS QUE NO TENGAN ASIGNADO RECURSOS
alter PROCEDURE Projects_Resources_RPAll
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
GO
EXEC Projects_Resources_RP
GO