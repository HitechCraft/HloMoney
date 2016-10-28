USE HloMoneyNew
GO

ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_UserInfo] FOREIGN KEY([Author])
REFERENCES [dbo].[UserInfo] ([VkId])
GO

ALTER TABLE [dbo].[ContestPart]  WITH CHECK ADD  CONSTRAINT [FK_ContestPart_UserInfo] FOREIGN KEY([Partner])
REFERENCES [dbo].[UserInfo] ([VkId])
GO

ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_UserInfo] FOREIGN KEY([Author])
REFERENCES [dbo].[UserInfo] ([VkId])
GO