 --CONSULTAR TODOS LOS RECURSOS HUMANOS
ALTER PROCEDURE Human_Resources_RAll
AS
	SELECT [Rec_ID],
		[Name] ,
		[LastName],
		[Position],
		[Email]
	FROM [Human_Resources]
	--WHERE IsActive = 1
GO

EXECUTE Human_Resources_RAll
GO