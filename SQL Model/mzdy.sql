USE [sra0051]
GO

ALTER TABLE [dbo].[Mzdy] DROP CONSTRAINT [FK__Mzdy__Zakazka-Id__4222D4EF]
GO

ALTER TABLE [dbo].[Mzdy] DROP CONSTRAINT [FK__Mzdy__Uzivatel-I__412EB0B6]
GO

/****** Object:  Table [dbo].[Mzdy]    Script Date: 22.10.2018 19:08:45 ******/
DROP TABLE [dbo].[Mzdy]
GO

/****** Object:  Table [dbo].[Mzdy]    Script Date: 22.10.2018 19:08:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mzdy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Uzivatel-Id] [int] NOT NULL,
	[Zakazka-Id] [int] NOT NULL,
	[Hodinova-Sazba] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Mzdy]  WITH CHECK ADD FOREIGN KEY([Uzivatel-Id])
REFERENCES [dbo].[Uzivatel] ([Id])
GO

ALTER TABLE [dbo].[Mzdy]  WITH CHECK ADD FOREIGN KEY([Zakazka-Id])
REFERENCES [dbo].[Zakazka] ([Id])
GO


