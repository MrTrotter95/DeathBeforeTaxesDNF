









USE [DeathData]
GO
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([ID], [Name]) VALUES (1, N'Income')
INSERT [dbo].[AccountType] ([ID], [Name]) VALUES (2, N'Expense')
INSERT [dbo].[AccountType] ([ID], [Name]) VALUES (3, N'Savings')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
GO





USE [DeathData]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [FK_AccountTypeID], [Name], [Amount], [HouseSavingsEnabled]) VALUES (1, 1, N'Savings', CAST(100.00 AS Decimal(8, 2)), 1)
INSERT [dbo].[Account] ([ID], [FK_AccountTypeID], [Name], [Amount], [HouseSavingsEnabled]) VALUES (2, 1, N'Income ', CAST(100.00 AS Decimal(8, 2)), 0)
INSERT [dbo].[Account] ([ID], [FK_AccountTypeID], [Name], [Amount], [HouseSavingsEnabled]) VALUES (3, 2, N'Bills', CAST(0.00 AS Decimal(8, 2)), 0)
INSERT [dbo].[Account] ([ID], [FK_AccountTypeID], [Name], [Amount], [HouseSavingsEnabled]) VALUES (4, 2, N'Everyday', CAST(150.00 AS Decimal(8, 2)), 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO







USE [DeathData]
GO
SET IDENTITY_INSERT [dbo].[PaymentFrequency] ON 

INSERT [dbo].[PaymentFrequency] ([ID], [Name]) VALUES (1, N'Daily')
INSERT [dbo].[PaymentFrequency] ([ID], [Name]) VALUES (2, N'Weekly')
INSERT [dbo].[PaymentFrequency] ([ID], [Name]) VALUES (3, N'Fortnightly')
INSERT [dbo].[PaymentFrequency] ([ID], [Name]) VALUES (4, N'Monthly')
SET IDENTITY_INSERT [dbo].[PaymentFrequency] OFF
GO






USE [DeathData]
GO
SET IDENTITY_INSERT [dbo].[TransactionCategory] ON 

INSERT [dbo].[TransactionCategory] ([ID], [Name]) VALUES (1, N'Housing')
INSERT [dbo].[TransactionCategory] ([ID], [Name]) VALUES (2, N'Utilities')
INSERT [dbo].[TransactionCategory] ([ID], [Name]) VALUES (3, N'Vehicle & Transportation')
INSERT [dbo].[TransactionCategory] ([ID], [Name]) VALUES (4, N'Groceries')
INSERT [dbo].[TransactionCategory] ([ID], [Name]) VALUES (5, N'Memberships & Subscriptions')
INSERT [dbo].[TransactionCategory] ([ID], [Name]) VALUES (6, N'Debt Payment')
SET IDENTITY_INSERT [dbo].[TransactionCategory] OFF
GO






USE [DeathData]
GO
SET IDENTITY_INSERT [dbo].[AutomaticPayment] ON 

INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (1, 3, 3, 1, N'Rent', CAST(650.00 AS Decimal(8, 2)), CAST(N'2024-01-03T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (3, 3, 4, 2, N'Spark Fibre (inc netflix)', CAST(97.00 AS Decimal(8, 2)), CAST(N'2024-01-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (2, 3, 3, 2, N'Electric Kiwi', CAST(100.00 AS Decimal(8, 2)), CAST(N'2024-01-03T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (4, 3, 4, 2, N'Alistair''s Phone Bill', CAST(40.00 AS Decimal(8, 2)), CAST(N'2023-12-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (5, 3, 4, 2, N'Chelsea''s Phone Bill', CAST(40.00 AS Decimal(8, 2)), CAST(N'2023-12-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (6, 3, 3, 1, N'AA Insurance', CAST(35.50 AS Decimal(8, 2)), CAST(N'2024-01-03T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (7, 3, 4, 1, N'Northland Waste', CAST(11.50 AS Decimal(8, 2)), CAST(N'2024-01-03T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (8, 3, 4, 5, N'Southern Cross Health Insurance', CAST(38.62 AS Decimal(8, 2)), CAST(N'2023-12-26T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (9, 3, 4, 5, N'Youtube', CAST(13.00 AS Decimal(8, 2)), CAST(N'2024-01-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (10, 3, 4, 4, N'CanaClinic', CAST(405.00 AS Decimal(8, 2)), CAST(N'2023-12-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (11, 4, 2, 4, N'Food', CAST(200.00 AS Decimal(8, 2)), CAST(N'2023-12-08T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (12, 4, 2, 4, N'Takeaways', CAST(140.00 AS Decimal(8, 2)), CAST(N'2023-12-08T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (13, 4, 2, 3, N'Snapper (both)', CAST(80.00 AS Decimal(8, 2)), CAST(N'2023-12-11T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (14, 4, 2, 3, N'Petrol', CAST(50.00 AS Decimal(8, 2)), CAST(N'2023-12-11T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[AutomaticPayment] ([ID], [FK_AccountID], [FK_FrequencyID], [FK_CategoryID], [Name], [Amount], [StartDate], [EndDate]) VALUES (15, 4, 4, 4, N'Vaping', CAST(60.00 AS Decimal(8, 2)), CAST(N'2023-12-11T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[AutomaticPayment] OFF
GO
