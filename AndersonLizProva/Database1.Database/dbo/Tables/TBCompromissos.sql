CREATE TABLE [dbo].[TBCompromissos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Assunto] VARCHAR(40) NOT NULL, 
    [Local] VARCHAR(40) NOT NULL, 
    [Inicio] DATETIME NOT NULL, 
    [Termino] DATETIME NOT NULL
)
