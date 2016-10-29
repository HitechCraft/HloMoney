USE HloMoneyNew
GO

ALTER TABLE [UserInfo]
DROP COLUMN [Name]
GO

ALTER TABLE [UserInfo]
ADD [FirstName] nvarchar(128) NOT NULL
GO

ALTER TABLE [UserInfo]
ADD [LastName] nvarchar(128) NOT NULL
GO