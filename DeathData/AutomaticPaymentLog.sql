CREATE TABLE [dbo].[AutomaticPaymentLog]
(
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[FK_AutomaticPaymentID] INT NULL,
	[TransactionDate] DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Transaction_AutomaticPaymentID] FOREIGN KEY ([FK_AutomaticPaymentID]) 
		REFERENCES [dbo].[AutomaticPayment] ([ID]) ON DELETE CASCADE,
)
