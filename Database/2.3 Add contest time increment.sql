USE [HloMoney]
GO

CREATE TABLE [dbo].[TimeIncrement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contest] [int] NOT NULL,
	[Increment] [float] NOT NULL
 CONSTRAINT [PK_TimeIncrement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[TimeIncrement]  WITH CHECK ADD  CONSTRAINT [FK_Contest_TimeIncrement] FOREIGN KEY([Contest])
REFERENCES [dbo].[Contest] ([Id])
GO
