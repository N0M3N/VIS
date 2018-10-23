USE [sra0051]
GO

/****** Object:  Table [dbo].[Stav]    Script Date: 22.10.2018 19:06:56 ******/
DROP TABLE [dbo].[Stav]
GO

/****** Object:  Table [dbo].[Stav]    Script Date: 22.10.2018 19:06:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stav](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nazev] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


