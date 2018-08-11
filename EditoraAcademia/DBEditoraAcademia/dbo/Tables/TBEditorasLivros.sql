CREATE TABLE [dbo].[TBEditorasLivros]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [LivroID] INT NOT NULL, 
    [EditoraID] INT NOT NULL
	CONSTRAINT [FK_EditorasLivros] FOREIGN KEY ([LivroID]) REFERENCES [TBLivros]([ID]), 
    CONSTRAINT [FK_TBEditoras_Editoras] FOREIGN KEY ([EditoraID]) REFERENCES [TBEditoras]([ID])
)
