-- PROCEDIMIENTO: PROYECTOS CON RECURSOS ASIGNADOS 
ALTER PROCEDURE Projects_Resources_R
AS
	SELECT 
		p.Pro_ID, 
		p.Name AS NameProject, 
		hr.Rec_ID, 
		hr.Name AS NameResource
	FROM  Human_Resources  hr
		INNER JOIN [Projects_Resources]  pr ON pr.Rec_ID = hr.Rec_ID 
		INNER JOIN Projects p ON  p.Pro_ID = pr.Pro_ID
	--WHERE p.IsActive = 1
GO
EXEC Projects_Resources_R
GO