CREATE TABLE [dbo].[Mzdy]
(
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Uzivatel-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Zakazka-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Zakazka] ([Id]),
	[Hodinova-Sazba] [int] NOT NULL
)
