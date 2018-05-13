CREATE TABLE [dbo].[TBSaleProducts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [ProductId] INT NOT NULL, 
    [SaleId] INT NOT NULL, 
	CONSTRAINT [FK_TBSaleProducts] FOREIGN KEY ([ProductId]) REFERENCES [TBProducts]([Id]), 
    CONSTRAINT [FK_TBSale_Products] FOREIGN KEY ([SaleId]) REFERENCES [TBSales]([Id])
)
