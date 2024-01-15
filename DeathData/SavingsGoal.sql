CREATE TABLE [dbo].[SavingsGoal] 
(
    [ID] INT IDENTITY (1, 1) NOT NULL,
    [FK_AccountID] INT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [CurrentTotal] DECIMAL(8, 2) NOT NULL,
    [GoalAmount] DECIMAL(8, 2) NOT NULL,
    [PurchaseDate] DATETIME NULL,
    [ActualBuyPrice] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SavingsGoal_ToTable] FOREIGN KEY ([FK_AccountID]) 
        REFERENCES [dbo].[Account] ([ID]) ON DELETE CASCADE,
)
