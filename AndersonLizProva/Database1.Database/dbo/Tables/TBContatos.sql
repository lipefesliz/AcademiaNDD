CREATE TABLE [dbo].[TBContatos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(40) NOT NULL, 
    [Email] VARCHAR(40) NOT NULL, 
    [Departamento] VARCHAR(40) NOT NULL, 
    [Endereco] VARCHAR(40) NOT NULL, 
    [Telefone] VARCHAR(40) NOT NULL
)
