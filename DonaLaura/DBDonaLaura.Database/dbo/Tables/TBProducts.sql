CREATE TABLE [dbo].[TBProducts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [CostPrice] DECIMAL(9, 2) NOT NULL, 
    [SalePrice] DECIMAL(9, 2) NOT NULL, 
    [IsAvailable] BIT NOT NULL, 
    [Fabrication] DATETIME NOT NULL, 
    [Expiration] DATETIME NOT NULL, 
)
