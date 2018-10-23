USE [sra0051]
GO

ALTER TABLE [dbo].[Zakazka] DROP CONSTRAINT [FK__Zakazka__Uzivate__398D8EEE]
GO

ALTER TABLE [dbo].[Zakazka] DROP CONSTRAINT [FK__Zakazka__Uzivate__38996AB5]
GO

ALTER TABLE [dbo].[Zakazka] DROP CONSTRAINT [FK__Zakazka__Stav-Id__3A81B327]
GO

/****** Object:  Table [dbo].[Zakazka]    Script Date: 22.10.2018 19:10:59 ******/
DROP TABLE [dbo].[Zakazka]
GO

/****** Object:  Table [dbo].[Zakazka]    Script Date: 22.10.2018 19:10:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Zakazka](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Uzivatel-Id-Zakaznik] [int] NOT NULL,
	[Uzivatel-Id-Zamestnanec] [int] NOT NULL,
	[Stav-Id] [int] NOT NULL,
	[Adresa] [nvarchar](100) NOT NULL,
	[Deadline] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Zakazka]  WITH CHECK ADD FOREIGN KEY([Stav-Id])
REFERENCES [dbo].[Stav] ([Id])
GO

ALTER TABLE [dbo].[Zakazka]  WITH CHECK ADD FOREIGN KEY([Uzivatel-Id-Zakaznik])
REFERENCES [dbo].[Uzivatel] ([Id])
GO

ALTER TABLE [dbo].[Zakazka]  WITH CHECK ADD FOREIGN KEY([Uzivatel-Id-Zamestnanec])
REFERENCES [dbo].[Uzivatel] ([Id])
GO


