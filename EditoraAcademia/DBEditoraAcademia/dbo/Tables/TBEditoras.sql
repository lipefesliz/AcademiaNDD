﻿CREATE TABLE [dbo].[TBEditoras]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Nome] VARCHAR(40) NOT NULL, 
    [Endereco] VARCHAR(40) NOT NULL, 
    [Telefone] VARCHAR(16) NOT NULL
)
