CREATE TABLE [dbo].[TBCompromissosContatos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ContatoID] INT NOT NULL, 
    [CompromissoID] INT NOT NULL,
	CONSTRAINT [FK_CompromissosContato] FOREIGN KEY ([ContatoID]) REFERENCES [TBContatos]([ID]), 
    CONSTRAINT [FK_TBCompromissos_Compromissos] FOREIGN KEY ([CompromissoID]) REFERENCES [TBCompromissos]([ID])
)
