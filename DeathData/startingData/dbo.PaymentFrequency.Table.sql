USE [DeathData]
GO
SET IDENTITY_INSERT [dbo].[PaymentFrequency] ON 

INSERT [dbo].[PaymentFrequency] ([ID], [Name]) VALUES (1, N'Daily')
INSERT [dbo].[PaymentFrequency] ([ID], [Name]) VALUES (2, N'Weekly')
INSERT [dbo].[PaymentFrequency] ([ID], [Name]) VALUES (3, N'Fortnightly')
INSERT [dbo].[PaymentFrequency] ([ID], [Name]) VALUES (4, N'Monthly')
SET IDENTITY_INSERT [dbo].[PaymentFrequency] OFF
GO
