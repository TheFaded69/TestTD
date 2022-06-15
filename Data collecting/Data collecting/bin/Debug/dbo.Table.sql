CREATE TABLE [dbo].[CollectorData]
(
	[Request_number] INT NOT NULL PRIMARY KEY, 
    [Request_time] NVARCHAR(50) NULL, 
    [SlaveID] INT NULL, 
    [Adress] NVARCHAR(50) NULL, 
    [Data] INT NULL
)
