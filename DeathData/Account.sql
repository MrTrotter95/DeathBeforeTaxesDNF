CREATE TABLE [dbo].[Account]
(
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[FK_AccountTypeID] INT NULL,
	[Name] NVARCHAR (50) NOT NULL,
	[Amount] DECIMAL(8,2) NULL,
	[HouseSavingsEnabled] BIT NOT NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_AccountType_ToTable] FOREIGN KEY ([FK_AccountTypeID]) 
        REFERENCES [dbo].[AccountType] ([ID]) ON DELETE CASCADE,
)
