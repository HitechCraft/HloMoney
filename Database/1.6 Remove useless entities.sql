USE [HloMoney]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [ContestPartError]
GO

DROP TABLE [ContestWinner]
GO

DROP TABLE [ContestPart]
GO

ALTER TABLE [Contest]
DROP COLUMN [Type]
GO

ALTER TABLE [Contest]
DROP COLUMN [Status]
GO

ALTER TABLE [Contest]
DROP COLUMN [StartTime]
GO

ALTER TABLE [Contest]
DROP COLUMN [EndTime]
GO

ALTER TABLE [Contest]
DROP COLUMN [Winners]
GO