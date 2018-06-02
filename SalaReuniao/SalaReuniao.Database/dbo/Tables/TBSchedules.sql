CREATE TABLE [dbo].[TBSchedules]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [BookingDate] DATETIME NOT NULL, 
    [RoomId] INT NOT NULL, 
	[EmployeeId] INT NOT NULL 
	CONSTRAINT [FK_Schedules_Room] FOREIGN KEY ([RoomId]) REFERENCES [TBRooms]([Id]), 
    CONSTRAINT [FK_Schedules_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [TBEmployees]([Id])
)
