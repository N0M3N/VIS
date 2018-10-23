USE [sra0051]
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Uzivatel'
GO

/****** Object:  Table [dbo].[Uzivatel]    Script Date: 22.10.2018 19:10:00 ******/
DROP TABLE [dbo].[Uzivatel]
GO

/****** Object:  Table [dbo].[Uzivatel]    Script Date: 22.10.2018 19:10:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Uzivatel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Jmeno] [nvarchar](50) NOT NULL,
	[Prijmeni] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](20) NULL,
	[Login] [nvarchar](10) NOT NULL,
	[Heslo] [nvarchar](256) NOT NULL,
	[JeZakaznik] [bit] NOT NULL,
	[JeZamestnanec] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Table of Users' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Uzivatel'
GO


