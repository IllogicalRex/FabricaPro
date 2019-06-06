
-- PROCEDIMIENTO PARA INSERTAR RECURSOS HUMANOS
CREATE PROCEDURE Human_Resources_C
  @Name VARCHAR(100),
  @LastName VARCHAR(100),
  @Position VARCHAR(100),
  @Email VARCHAR(150)
AS
INSERT INTO [Human_Resources]([Name], [LastName], [Position], [Email], [IsActive]) VALUES(@Name, @LastName, @Position, @Email, 1)
SELECT CAST(@@IDENTITY AS INT) AS Rec_ID
GO

EXECUTE Human_Resources_C 'Josue','Trujillo', 'Empleado', 'josue@gmail.com'
GO
SELECT * FROM Human_Resources
GO
