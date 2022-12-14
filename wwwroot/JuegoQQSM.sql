USE [master]
GO
/****** Object:  Database [JuegoQQSM]    Script Date: 4/8/2022 11:10:04 ******/
CREATE DATABASE [JuegoQQSM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JuegoQQSM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\JuegoQQSM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JuegoQQSM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\JuegoQQSM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [JuegoQQSM] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JuegoQQSM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JuegoQQSM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JuegoQQSM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JuegoQQSM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JuegoQQSM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JuegoQQSM] SET ARITHABORT OFF 
GO
ALTER DATABASE [JuegoQQSM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JuegoQQSM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JuegoQQSM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JuegoQQSM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JuegoQQSM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JuegoQQSM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JuegoQQSM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JuegoQQSM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JuegoQQSM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JuegoQQSM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JuegoQQSM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JuegoQQSM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JuegoQQSM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JuegoQQSM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JuegoQQSM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JuegoQQSM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JuegoQQSM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JuegoQQSM] SET RECOVERY FULL 
GO
ALTER DATABASE [JuegoQQSM] SET  MULTI_USER 
GO
ALTER DATABASE [JuegoQQSM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JuegoQQSM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JuegoQQSM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JuegoQQSM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JuegoQQSM] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JuegoQQSM', N'ON'
GO
ALTER DATABASE [JuegoQQSM] SET QUERY_STORE = OFF
GO
USE [JuegoQQSM]
GO
/****** Object:  User [alumno]    Script Date: 4/8/2022 11:10:04 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 4/8/2022 11:10:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[idJugador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[PozoGanado] [int] NOT NULL,
	[ComodinDobleChance] [bit] NOT NULL,
	[Comodin50] [bit] NOT NULL,
	[ComodinSaltear] [bit] NOT NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[idJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 4/8/2022 11:10:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[idPregunta] [int] IDENTITY(1,1) NOT NULL,
	[TextoPregunta] [varchar](200) NOT NULL,
	[NivelDificultad] [int] NOT NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[idPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestas]    Script Date: 4/8/2022 11:10:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas](
	[idRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[idPregunta] [int] NOT NULL,
	[OpcionRespuesta] [char](1) NOT NULL,
	[TextoRespuesta] [varchar](200) NOT NULL,
	[Correcta] [bit] NOT NULL,
 CONSTRAINT [PK_Respuestas] PRIMARY KEY CLUSTERED 
(
	[idRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Preguntas] ON 

INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (1, N'¿Donde juega acutalmente Lionel Messi?', 1)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (2, N'¿De que pais es originario Mohamed Salah?', 1)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (3, N'¿Quien es el actual campeón del Mundial?', 1)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (4, N'¿De que posicion juega David De Gea?', 1)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (5, N'¿Quien es el actual entrenador de la Seleccion Argentina?', 1)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (6, N'¿Como es el nombre de Tevez?', 1)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (7, N'¿En que equipo debutó Sergio Agüero?', 1)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (8, N'¿Como es el nombre de Ibrahimovic?', 2)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (9, N'¿De que país es Heung Min Son?', 2)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (10, N'¿De que país en Novak Djokovic
?', 2)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (11, N'¿Como es el nombre de Scola?', 2)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (12, N'¿Cuantos jugadores hay por equipo en rugby?', 2)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (13, N'¿De que posicion juega Jérôme Boateng
?', 2)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (14, N'¿Quien es el maximo campeón de Formula 1?', 2)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (15, N'¿Quien utiliza la numero 10 en Racing Club?', 2)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (16, N'¿Quien es el maximo campeón de torneos de Golf?', 3)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (17, N'¿En que pais nació el piloto Max Verstappen?', 3)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (18, N'¿De que país es el ex basquetbolista Tony Parker?', 3)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (19, N'¿Quien metió el gol de penal para que Independiente salga campeón de la Copa Sudamericana?', 3)
INSERT [dbo].[Preguntas] ([idPregunta], [TextoPregunta], [NivelDificultad]) VALUES (20, N'¿Contra quien jugó River Plate la final de la Copa Libertadores 2015?', 3)
SET IDENTITY_INSERT [dbo].[Preguntas] OFF
GO
SET IDENTITY_INSERT [dbo].[Respuestas] ON 

INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (1, 1, N'A', N'Barcelona', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (2, 1, N'B', N'Real Madrid', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (3, 1, N'C', N'PSG', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (4, 1, N'D', N'Liverpool', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (5, 2, N'A', N'Egipto', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (6, 2, N'B', N'Arabia Saudi', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (7, 2, N'C', N'Marruecos', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (8, 2, N'D', N'Irán', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (9, 3, N'A', N'Alemania', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (10, 3, N'B', N'Francia', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (11, 3, N'C', N'Italia', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (12, 3, N'D', N'España', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (13, 4, N'A', N'Arquero', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (14, 4, N'B', N'Defensor', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (15, 4, N'C', N'Mediocampista', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (16, 4, N'D', N'Delantero', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (17, 5, N'A', N'Mostaza Merlo', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (18, 5, N'B', N'Diego Simeone', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (19, 5, N'C', N'Lionel Scaloni', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (20, 5, N'D', N'Marcelo Gallardo', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (21, 6, N'A', N'Sergio', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (22, 6, N'B', N'Carlos', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (23, 6, N'C', N'Diego', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (24, 6, N'D', N'Martin', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (25, 7, N'A', N'Independiente', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (26, 7, N'B', N'Racing', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (27, 7, N'C', N'Boca Juniors', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (28, 7, N'D', N'River Plate', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (29, 8, N'A', N'Ibrahim', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (30, 8, N'B', N'Zlatan', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (31, 8, N'C', N'Aleksander', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (32, 8, N'D', N'Jakob', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (33, 9, N'A', N'China', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (34, 9, N'B', N'Corea del Norte', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (35, 9, N'C', N'Corea del Sur', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (36, 9, N'D', N'Japón', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (37, 10, N'A', N'Eslovenia', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (38, 10, N'B', N'Eslovaquia', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (39, 10, N'C', N'Serbia', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (40, 10, N'D', N'Montenegro', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (41, 11, N'A', N'Damian', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (42, 11, N'B', N'Luis', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (43, 11, N'C', N'Miguel', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (44, 11, N'D', N'Francisco', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (45, 12, N'A', N'13', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (46, 12, N'B', N'11', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (47, 12, N'C', N'15', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (48, 12, N'D', N'9', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (49, 13, N'A', N'Arquero', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (50, 13, N'B', N'Defensor', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (51, 13, N'C', N'Mediocampista', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (52, 13, N'D', N'Delantero', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (53, 14, N'A', N'Fernando Alonso', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (54, 14, N'B', N'Lewis Hamilton', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (55, 14, N'C', N'Juan Manuel Fangio', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (56, 14, N'D', N'Sebastian Vettel', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (57, 15, N'A', N'Edwin Cardona', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (58, 15, N'B', N'Carlos Alcaraz', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (59, 15, N'C', N'Tomas Chancalay', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (60, 15, N'D', N'Matias Rojas', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (61, 16, N'A', N'Tiger Woods', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (62, 16, N'B', N'Walter Hagen', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (63, 16, N'C', N'Jack Nicklaus', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (64, 16, N'D', N'Gary Player', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (65, 17, N'A', N'Belgica', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (66, 17, N'B', N'Holanda', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (67, 17, N'C', N'Alemania', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (68, 17, N'D', N'Francia', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (70, 18, N'A', N'Estados Unidos', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (71, 18, N'B', N'Inglaterra', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (73, 18, N'C', N'Francia', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (74, 18, N'D', N'Jamaica', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (75, 19, N'A', N'Esequiel Barco', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (76, 19, N'B', N'Maximiliano Meza', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (77, 19, N'C', N'Emmanuel Gigliotti', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (78, 19, N'D', N'Martín Benitez', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (79, 20, N'A', N'Monterrey', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (80, 20, N'B', N'Tigres', 1)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (81, 20, N'C', N'Corinthians', 0)
INSERT [dbo].[Respuestas] ([idRespuesta], [idPregunta], [OpcionRespuesta], [TextoRespuesta], [Correcta]) VALUES (82, 20, N'D', N'Flamengo', 0)
SET IDENTITY_INSERT [dbo].[Respuestas] OFF
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [FK_Respuestas_Preguntas] FOREIGN KEY([idPregunta])
REFERENCES [dbo].[Preguntas] ([idPregunta])
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [FK_Respuestas_Preguntas]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [FK_Respuestas_Respuestas] FOREIGN KEY([idRespuesta])
REFERENCES [dbo].[Respuestas] ([idRespuesta])
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [FK_Respuestas_Respuestas]
GO
USE [master]
GO
ALTER DATABASE [JuegoQQSM] SET  READ_WRITE 
GO
