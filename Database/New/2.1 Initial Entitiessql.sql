USE [HloMoneyNew]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11.10.2016 15:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 11.10.2016 15:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] NOT NULL,
	[Text] [nvarchar](256) NOT NULL,
	[Author] [nvarchar](128) NOT NULL,
	[Contest] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contest]    Script Date: 11.10.2016 15:48:55 ******/
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
	[EndTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Contest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContestPart]    Script Date: 11.10.2016 15:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContestPart](
	[Id] [int] NOT NULL,
	[Contest] [int] NOT NULL,
	[Partner] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_ContestPart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContestWinner]    Script Date: 11.10.2016 15:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContestWinner](
	[Id] [int] NOT NULL,
	[Part] [int] NOT NULL,
	[Place] [int] NOT NULL,
 CONSTRAINT [PK_ContestWinner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Report]    Script Date: 11.10.2016 15:48:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](128) NOT NULL,
	[Text] [nvarchar](2000) NOT NULL,
	[Author] [nvarchar](128) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Account] FOREIGN KEY([Author])
REFERENCES [dbo].[Account] ([UserId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Account]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Contest] FOREIGN KEY([Contest])
REFERENCES [dbo].[Contest] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Contest]
GO
ALTER TABLE [dbo].[ContestPart]  WITH CHECK ADD  CONSTRAINT [FK_ContestPart_Account] FOREIGN KEY([Partner])
REFERENCES [dbo].[Account] ([UserId])
GO
ALTER TABLE [dbo].[ContestPart] CHECK CONSTRAINT [FK_ContestPart_Account]
GO
ALTER TABLE [dbo].[ContestPart]  WITH CHECK ADD  CONSTRAINT [FK_ContestPart_Contest] FOREIGN KEY([Contest])
REFERENCES [dbo].[Contest] ([Id])
GO
ALTER TABLE [dbo].[ContestPart] CHECK CONSTRAINT [FK_ContestPart_Contest]
GO
ALTER TABLE [dbo].[ContestWinner]  WITH CHECK ADD  CONSTRAINT [FK_ContestWinner_ContestPart] FOREIGN KEY([Part])
REFERENCES [dbo].[ContestPart] ([Id])
GO
ALTER TABLE [dbo].[ContestWinner] CHECK CONSTRAINT [FK_ContestWinner_ContestPart]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Account] FOREIGN KEY([Author])
REFERENCES [dbo].[Account] ([UserId])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Account]
GO
