CREATE TABLE [dbo].[IncomeStream]
(
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[FK_FrequencyID] INT NULL,
	[Person] NVARCHAR (50) NOT NULL,
	[Amount] DECIMAL(8,2) NULL,
	[StartDate] DATETIME NULL,
	[EndDate] DATETIME NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_IncomeStream_FrequencyID] FOREIGN KEY ([FK_FrequencyID]) 
        REFERENCES [dbo].[PaymentFrequency] ([ID]) ON DELETE CASCADE,
)
