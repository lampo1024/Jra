USE [Jra]
GO
/****** Object:  Table [dbo].[OnlineUser]    Script Date: 2017/7/27 11:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OnlineUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[LoginDate] [datetime] NULL,
	[IpAddress] [nvarchar](20) NULL,
 CONSTRAINT [PK_OnlineUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OnlineUser] ON 
GO
INSERT [dbo].[OnlineUser] ([Id], [Guid], [Name], [LoginDate], [IpAddress]) VALUES (1, N'DCA95366-51C6-448D-8EFB-0594E3C359D9', N'Curry', CAST(N'2017-07-27T10:38:00.000' AS DateTime), N'::1')
GO
SET IDENTITY_INSERT [dbo].[OnlineUser] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在线用户列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OnlineUser'
GO
