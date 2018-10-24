IF OBJECT_ID('Mzdy', 'U') IS NOT NULL
BEGIN DROP TABLE [dbo].[Mzdy] END;

IF OBJECT_ID('Dochazka', 'U') IS NOT NULL
BEGIN DROP TABLE [dbo].[Dochazka] END;

IF OBJECT_ID('StavebniDenik', 'U') IS NOT NULL
BEGIN DROP TABLE [dbo].[StavebniDenik] END;

IF OBJECT_ID('Zakazka', 'U') IS NOT NULL
BEGIN DROP TABLE [dbo].[Zakazka] END;

IF OBJECT_ID('Uzivatel', 'U') IS NOT NULL
BEGIN DROP TABLE [dbo].[Uzivatel] END;

IF OBJECT_ID('Stav', 'U') IS NOT NULL
BEGIN DROP TABLE [dbo].[Stav] END;

CREATE TABLE [dbo].[Stav]
(
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Nazev] [nvarchar](20) NOT NULL
)

CREATE TABLE [dbo].[Uzivatel](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Jmeno] [nvarchar](50) NOT NULL,
	[Prijmeni] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](20) NULL,
	[Login] [nvarchar](10) NOT NULL,
	[Heslo] [nvarchar](256) NOT NULL,
	[JeZakaznik] [bit] NOT NULL,
	[JeZamestnanec] [bit] NOT NULL,
)

CREATE TABLE [dbo].[Zakazka]
(
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Zakaznik-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[UZamestnanec-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Stav-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Stav] ([Id]),
	[Adresa] [nvarchar](100) NOT NULL,
	[Deadline] [datetime] NULL
)

CREATE TABLE [dbo].[Dochazka]
(
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Zakazka-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Zakazka] ([Id]),
	[Zamestnanec-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Datum] [date] NOT NULL,
	[Prichod] [datetime] NOT NULL,
	[Odchod] [datetime] NOT NULL
)

CREATE TABLE [dbo].[StavebniDenik]
(
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Zakazka-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Zakazka] ([Id]),
	[Uzivatel-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Datum] [datetime] NOT NULL,
	[Popis] [nvarchar](150) NULL
)

CREATE TABLE [dbo].[Mzdy]
(
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Uzivatel-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Uzivatel] ([Id]),
	[Zakazka-Id] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Zakazka] ([Id]),
	[Hodinova-Sazba] [int] NOT NULL
)