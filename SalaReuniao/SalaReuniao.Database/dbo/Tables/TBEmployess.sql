CREATE TABLE [dbo].[TBEmployees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Post] NVARCHAR(50) NOT NULL, 
    [BranchLine] INT NOT NULL, 
)
