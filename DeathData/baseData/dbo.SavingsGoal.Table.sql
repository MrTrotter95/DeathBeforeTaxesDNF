USE [DeathData]
GO
/****** Object:  Table [dbo].[SavingsGoal]    Script Date: 13/01/2024 10:28:23 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SavingsGoal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_AccountID] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CurrentTotal] [decimal](8, 2) NOT NULL,
	[GoalAmount] [decimal](8, 2) NOT NULL,
	[PurchaseDate] [datetime] NULL,
	[ActualBuyPrice] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SavingsGoal]  WITH CHECK ADD  CONSTRAINT [FK_SavingsGoal_ToTable] FOREIGN KEY([FK_AccountID])
REFERENCES [dbo].[Account] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SavingsGoal] CHECK CONSTRAINT [FK_SavingsGoal_ToTable]
GO
