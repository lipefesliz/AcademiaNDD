CREATE TABLE [dbo].[TBSchedules]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [BookingDate] DATETIME NOT NULL, 
    [Room] NVARCHAR(50) NOT NULL, 
	[EmployeeId] INT NOT NULL, 
	[IsAvailable] BIT NOT NULL 
    CONSTRAINT [FK_Schedules_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [TBEmployees]([Id])
)
