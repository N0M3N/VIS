CREATE TABLE [dbo].[StavebniDenik]
(
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Zakazka-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Zakazka] ([Id]),
	[Uzivatel-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Datum] [datetime] NOT NULL,
	[Popis] [nvarchar](150) NULL
)
