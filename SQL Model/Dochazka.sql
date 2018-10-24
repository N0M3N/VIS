CREATE TABLE [dbo].[Dochazka]
(
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Zakazka-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Zakazka] ([Id]),
	[Uzivatel-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Datum] [date] NOT NULL,
	[Prichod] [datetime] NOT NULL,
	[Odchod] [datetime] NOT NULL
)
