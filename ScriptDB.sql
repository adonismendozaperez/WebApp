USE [Test]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 17/05/2017 16:41:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumno](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Sexo] [varchar](10) NULL,
	[FechaNacimiento] [date] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AlumnoCurso]    Script Date: 17/05/2017 16:41:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AlumnoCurso](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[Alumno_id] [int] NULL,
	[Curso_id] [int] NULL,
	[Nota] [varchar](50) NULL,
 CONSTRAINT [PK_AlumnoCurso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 17/05/2017 16:41:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Curso](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AlumnoCurso]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoCurso_Alumno] FOREIGN KEY([Alumno_id])
REFERENCES [dbo].[Alumno] ([id])
GO
ALTER TABLE [dbo].[AlumnoCurso] CHECK CONSTRAINT [FK_AlumnoCurso_Alumno]
GO
ALTER TABLE [dbo].[AlumnoCurso]  WITH CHECK ADD  CONSTRAINT [FK_AlumnoCurso_Curso] FOREIGN KEY([Curso_id])
REFERENCES [dbo].[Curso] ([id])
GO
ALTER TABLE [dbo].[AlumnoCurso] CHECK CONSTRAINT [FK_AlumnoCurso_Curso]
GO
