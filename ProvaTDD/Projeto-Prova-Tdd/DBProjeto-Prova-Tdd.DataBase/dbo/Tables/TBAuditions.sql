CREATE TABLE [dbo].[TBAuditions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Theme] NVARCHAR(50) NOT NULL, 
    [TestDate] DATETIME NOT NULL, 
    [ResultId] INT NOT NULL, 
)
