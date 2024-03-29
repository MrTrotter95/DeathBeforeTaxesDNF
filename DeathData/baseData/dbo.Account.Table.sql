USE [DeathData]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 13/01/2024 10:28:23 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_AccountTypeID] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Amount] [decimal](8, 2) NULL,
	[HouseSavingsEnabled] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_AccountType_ToTable] FOREIGN KEY([FK_AccountTypeID])
REFERENCES [dbo].[AccountType] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_AccountType_ToTable]
GO
