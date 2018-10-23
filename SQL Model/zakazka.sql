CREATE TABLE [dbo].[Zakazka]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Uzivatel-Id-Zakaznik] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Uzivatel-Id-Zamestnanec] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Stav-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Stav] ([Id]),
	[Adresa] [nvarchar](100) NOT NULL,
	[Deadline] [datetime] NULL
)
