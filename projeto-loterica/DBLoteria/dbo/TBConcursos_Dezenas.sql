CREATE TABLE [dbo].[TBConcursos_Dezenas]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ConcursoId] INT NOT NULL FOREIGN KEY REFERENCES TBConcursos(Id), 
    [Dezena] INT NOT NULL
)
