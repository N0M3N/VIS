USE [sra0051]
GO

ALTER TABLE [dbo].[Dochazka] DROP CONSTRAINT [FK__Dochazka__Zakazk__44FF419A]
GO

ALTER TABLE [dbo].[Dochazka] DROP CONSTRAINT [FK__Dochazka__Uzivat__45F365D3]
GO

/****** Object:  Table [dbo].[Dochazka]    Script Date: 22.10.2018 19:03:53 ******/
DROP TABLE [dbo].[Dochazka]
GO

/****** Object:  Table [dbo].[Dochazka]    Script Date: 22.10.2018 19:03:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dochazka](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Zakazka-Id] [int] NOT NULL,
	[Uzivatel-Id] [int] NOT NULL,
	[Datum] [date] NOT NULL,
	[Prichod] [datetime] NOT NULL,
	[Odchod] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Dochazka]  WITH CHECK ADD FOREIGN KEY([Uzivatel-Id])
REFERENCES [dbo].[Uzivatel] ([Id])
GO

ALTER TABLE [dbo].[Dochazka]  WITH CHECK ADD FOREIGN KEY([Zakazka-Id])
REFERENCES [dbo].[Zakazka] ([Id])
GO


