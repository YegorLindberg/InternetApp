CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [roleId] INT NULL DEFAULT 0, 
    [email] NCHAR(50) NOT NULL, 
    [password] NCHAR(20) NOT NULL, 
    [fullName] NCHAR(30) NOT NULL, 
    [description] NCHAR(100) NULL
)
