CREATE TABLE [dbo].[Contact]
(
	[ContactID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [ContactNo] VARCHAR(20) NULL, 
    [Address] VARCHAR(255) NULL, 
    [Gender] VARCHAR(20) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([ContactID]), 
   
)
