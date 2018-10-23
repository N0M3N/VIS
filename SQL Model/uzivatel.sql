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
