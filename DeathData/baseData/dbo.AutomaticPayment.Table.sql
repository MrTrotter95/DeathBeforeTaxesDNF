USE [DeathData]
GO
/****** Object:  Table [dbo].[AutomaticPayment]    Script Date: 13/01/2024 10:28:23 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutomaticPayment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_AccountID] [int] NULL,
	[FK_FrequencyID] [int] NULL,
	[FK_CategoryID] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Amount] [decimal](8, 2) NULL,
	[LastPaymentDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[IsRequired] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AutomaticPayment]  WITH CHECK ADD  CONSTRAINT [FK_Automatic_Payment_AccountID] FOREIGN KEY([FK_AccountID])
REFERENCES [dbo].[Account] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AutomaticPayment] CHECK CONSTRAINT [FK_Automatic_Payment_AccountID]
GO
ALTER TABLE [dbo].[AutomaticPayment]  WITH CHECK ADD  CONSTRAINT [FK_Automatic_Payment_CategoryID] FOREIGN KEY([FK_CategoryID])
REFERENCES [dbo].[TransactionCategory] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AutomaticPayment] CHECK CONSTRAINT [FK_Automatic_Payment_CategoryID]
GO
ALTER TABLE [dbo].[AutomaticPayment]  WITH CHECK ADD  CONSTRAINT [FK_Automatic_Payment_FrequencyID] FOREIGN KEY([FK_FrequencyID])
REFERENCES [dbo].[PaymentFrequency] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AutomaticPayment] CHECK CONSTRAINT [FK_Automatic_Payment_FrequencyID]
GO
