USE [HloMoneyNew]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 11.10.2016 14:50:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] NOT NULL,
	[Text] [nvarchar](256) NOT NULL,
	[AuthorId] [nvarchar](128) NOT NULL,
	[Contest] [int] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contest]    Script Date: 11.10.2016 14:50:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contest](
	[Id] [int] NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[Gift] [nvarchar](128) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
	[WinnerCount] [int] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContestPart]    Script Date: 11.10.2016 14:50:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContestPart](
	[Id] [int] NOT NULL,
	[Contest] [int] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContestWinner]    Script Date: 11.10.2016 14:50:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContestWinner](
	[Id] [int] NOT NULL,
	[Part] [int] NOT NULL,
	[Place] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Report]    Script Date: 11.10.2016 14:50:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Text] [nvarchar](2000) NOT NULL,
	[AuthorId] [nvarchar](128) NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]

GO
