USE [DeathData]
GO
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([ID], [Name]) VALUES (1, N'Income')
INSERT [dbo].[AccountType] ([ID], [Name]) VALUES (2, N'Expense')
INSERT [dbo].[AccountType] ([ID], [Name]) VALUES (3, N'Savings')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
GO
