USE [DeathData]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [FK_AccountTypeID], [Name], [Amount], [HouseSavingsEnabled]) VALUES (1, 1, N'Savings', CAST(100.00 AS Decimal(8, 2)), 1)
INSERT [dbo].[Account] ([ID], [FK_AccountTypeID], [Name], [Amount], [HouseSavingsEnabled]) VALUES (2, 1, N'Income ', CAST(100.00 AS Decimal(8, 2)), 0)
INSERT [dbo].[Account] ([ID], [FK_AccountTypeID], [Name], [Amount], [HouseSavingsEnabled]) VALUES (3, 2, N'Bills', CAST(0.00 AS Decimal(8, 2)), 0)
INSERT [dbo].[Account] ([ID], [FK_AccountTypeID], [Name], [Amount], [HouseSavingsEnabled]) VALUES (4, 2, N'Everyday', CAST(150.00 AS Decimal(8, 2)), 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
