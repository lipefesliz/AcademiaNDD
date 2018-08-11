CREATE TABLE [dbo].[TBBooks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Title] NVARCHAR(50) NOT NULL, 
    [Author] NVARCHAR(50) NOT NULL, 
    [Theme] NVARCHAR(50) NOT NULL, 
    [Volume] INT NOT NULL, 
    [Publication] DATETIME NOT NULL, 
    [IsAvailable] BIT NOT NULL
)
