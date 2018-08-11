CREATE TABLE [dbo].[TBProdutos]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [nome] NVARCHAR(50) NOT NULL, 
    [preco] MONEY NOT NULL, 
    [tipo] NVARCHAR(50) NOT NULL, 
    [quantidade] INT NOT NULL
)
