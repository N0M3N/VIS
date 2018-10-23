USE [sra0051]
GO

ALTER TABLE [dbo].[StavebniDenik] DROP CONSTRAINT [FK__StavebniD__Zakaz__3D5E1FD2]
GO

ALTER TABLE [dbo].[StavebniDenik] DROP CONSTRAINT [FK__StavebniD__Uziva__3E52440B]
GO

/****** Object:  Table [dbo].[StavebniDenik]    Script Date: 22.10.2018 19:08:59 ******/
DROP TABLE [dbo].[StavebniDenik]
GO

/****** Object:  Table [dbo].[StavebniDenik]    Script Date: 22.10.2018 19:08:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StavebniDenik](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Zakazka-Id] [int] NOT NULL,
	[Uzivatel-Id] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[Popis] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StavebniDenik]  WITH CHECK ADD FOREIGN KEY([Uzivatel-Id])
REFERENCES [dbo].[Uzivatel] ([Id])
GO

ALTER TABLE [dbo].[StavebniDenik]  WITH CHECK ADD FOREIGN KEY([Zakazka-Id])
REFERENCES [dbo].[Zakazka] ([Id])
GO


