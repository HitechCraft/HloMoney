USE [HloMoney]
GO

CREATE TABLE [dbo].[UserInfo](
	[Id] [int] NOT NULL,
	[VkId] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Avatar] [varbinary](MAX) NOT NULL,
	[IsSynchron] [tinyint] NOT NULL,
	[LastUpdate] [datetime] NOT NULL
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[VkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO