USE [master]
GO
/****** Object:  Database [PobreTITO]    Script Date: 19/8/2022 16:19:14 ******/
CREATE DATABASE [PobreTITO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PobreTITO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PABLOSQL\MSSQL\DATA\PobreTITO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PobreTITO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.PABLOSQL\MSSQL\DATA\PobreTITO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PobreTITO] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PobreTITO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PobreTITO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PobreTITO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PobreTITO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PobreTITO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PobreTITO] SET ARITHABORT OFF 
GO
ALTER DATABASE [PobreTITO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PobreTITO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PobreTITO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PobreTITO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PobreTITO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PobreTITO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PobreTITO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PobreTITO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PobreTITO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PobreTITO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PobreTITO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PobreTITO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PobreTITO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PobreTITO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PobreTITO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PobreTITO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PobreTITO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PobreTITO] SET RECOVERY FULL 
GO
ALTER DATABASE [PobreTITO] SET  MULTI_USER 
GO
ALTER DATABASE [PobreTITO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PobreTITO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PobreTITO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PobreTITO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PobreTITO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PobreTITO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PobreTITO', N'ON'
GO
ALTER DATABASE [PobreTITO] SET QUERY_STORE = OFF
GO
USE [PobreTITO]
GO
/****** Object:  Table [dbo].[calle]    Script Date: 19/8/2022 16:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calle](
	[idCalle] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_calles] PRIMARY KEY CLUSTERED 
(
	[idCalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[incidente]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[incidente](
	[idIncidente] [int] NOT NULL,
	[idCategoria] [int] NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[descripcion] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[incidente_categoria]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[incidente_categoria](
	[idCategoria] [int] NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[descripcion] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reclamo]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reclamo](
	[idReclamo] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idIncidente] [int] NOT NULL,
	[estado] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](255) NULL,
	[foto] [nvarchar](150) NULL,
	[fecha] [nvarchar](100) NOT NULL,
	[altura] [nvarchar](50) NOT NULL,
	[idCalle] [int] NOT NULL,
	[idMotivo] [int] NOT NULL,
 CONSTRAINT [PK_reclamo] PRIMARY KEY CLUSTERED 
(
	[idReclamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varbinary](255) NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[altura] [nvarchar](50) NULL,
	[telefono] [nvarchar](20) NULL,
	[dni] [nvarchar](20) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[clave] [varbinary](max) NOT NULL,
	[idCalle] [int] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[calle] ON 

INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (0, N'SIN CALLE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (1, N'17 DE OCTUBRE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (2, N'1 DE MAYO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (3, N'2 DE ABRIL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (4, N'4 DE OCTUBRE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (5, N'ALBERDI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (6, N'ALEJANDRO FLEMING')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (7, N'ALEM')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (8, N'ALFREDO GOIRAN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (9, N'ALMAFUERTE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (10, N'ALMIRANTE BROWN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (11, N'AMADEO BELEN CABRERA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (12, N'AMBROSIO OLMOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (13, N'AMEGHINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (14, N'ANTONIO BERNI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (15, N'ARISTOBULO DEL VALLE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (16, N'ASUNCION')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (17, N'AUTOVIA RUTA NACIONAL 19')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (18, N'AV 9 DE SETIEMBRE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (19, N'AV ANTARTIDA ARGENTINA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (20, N'AV BRIGADIER B BUSTOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (21, N'AV BRIGADIER E. LOPEZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (22, N'AV CASEROS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (23, N'AV CERVANTES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (24, N'AV CHILE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (25, N'AV CIRCUNVALACION OESTE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (26, N'AV CRUCERO A.R.A GRAL BELGRANO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (27, N'AV DE LA UNIVERSIDAD')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (28, N'AV DE LOS CONSTITUYENTES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (29, N'AV DE LOS INMIGRANTES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (30, N'AV DR AMADEO SABATINI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (31, N'AV GENERAL SAVIO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (32, N'AV INGENIERO HUERGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (33, N'AV INT PEDRO FOSSATTI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (34, N'AV INTENDENTE TRIGUEROS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (35, N'AV JOSE TEOBALDO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (36, N'AV JUAN DE GARAY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (37, N'AV LAS ACACIAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (38, N'AV LAS MALVINAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (39, N'AV LAS MARGARITAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (40, N'AV LIBERTADOR (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (41, N'AV LIBERTADOR (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (42, N'AV LOS OLMOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (43, N'AV M GUEMES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (44, N'AV MAIPU')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (45, N'AV MAIPU Y RUTA 158')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (46, N'AV PRIMEROS COLONIZADORES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (47, N'AV ROSARIO DE SANTA FE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (48, N'AV SABATTINI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (49, N'AV TALCAHUANO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (50, N'AV URQUIZA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (51, N'AVELLANEDA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (52, N'AVENIDA PATRIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (53, N'BADERSBACH LOTHAR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (54, N'BAILON SOSA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (55, N'BASILIO DELZOPPO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (56, N'BELGRANO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (57, N'BELISARIO ROLDAN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (58, N'BENITO QUINQUELA MARTIN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (59, N'BENITO QUINQUELA MARTIN (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (60, N'BERMEJO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (61, N'BOFELLI EMILIO DOMINGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (62, N'BOLIVIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (63, N'BRASIL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (64, N'BV 25 DE MAYO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (65, N'BV 9 DE JULIO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (66, N'BV ATILIO CARAUNE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (67, N'BV BUENOS AIRES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (68, N'BV DOMINGO ALBERTO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (69, N'BV GARIBALDI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (70, N'BV GRAL. ROCA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (71, N'BV HIPOLITO YRIGOYEN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (72, N'BV JUAN B JUSTO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (73, N'BV LUIS COSTAMAGNA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (74, N'BV SAENZ PEÑA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (75, N'CALLE 70')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (76, N'CALLE PRIVADA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (77, N'CALLE PRIVADA NORCOUNTRY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (78, N'CALLE PUBLICA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (79, N'CALLE PUBLICA A (LOTEO CODINI)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (80, N'CALLE PUBLICA A (MASSARO)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (81, N'CALLE PUBLICA A (P.INDUSTRIAL)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (82, N'CALLE PUBLICA A (PARQUE MAIPU)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (83, N'CALLE PUBLICA A (PZA.SAN FCO.)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (84, N'CALLE PUBLICA B (MASSARO)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (85, N'CALLE PUBLICA B (P.INDUSTRIAL)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (86, N'CALLE PUBLICA B (PARQUE MAIPU)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (87, N'CALLE PUBLICA C (MASSARO)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (88, N'CALLE PUBLICA C (P.INDUSTRIAL)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (89, N'CALLE PUBLICA C (PARQUE MAIPU)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (90, N'CALLE PUBLICA D (MASSARO)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (91, N'CALLE PUBLICA D (P.INDUSTRIAL)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (92, N'CALLE PUBLICA D (PARQUE MAIPU)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (93, N'CALLE PUBLICA E (MASSARO)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (94, N'CALLE PUBLICA E (PARQUE MAIPU)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (95, N'CALLE PUBLICA F (MASSARO)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (96, N'CALLE PUBLICA F (PARQUE MAIPU)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (97, N'CALLE PUBLICA G (PARQUE MAIPU)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (98, N'CALLE PUBLICA J')
GO
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (99, N'CALLE PUBLICA NORCOUNTRY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (100, N'CAMINO INTERPROVINCIAL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (101, N'CAMINO PUBLICO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (102, N'CAP GIACHINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (103, N'CARLOS BOERO ROMANO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (104, N'CARLOS GILLI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (105, N'CARLOS LUSSO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (106, N'CARLOS PELLEGRINI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (107, N'CARRA MARTIN ANTONIO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (108, N'CASILLA DE CORREO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (109, N'CASTELLI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (110, N'CASTRO BARROS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (111, N'CATAMARCA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (112, N'CATAMARCA (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (113, N'CATAMARCA (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (114, N'CECILIA DUCAU')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (115, N'CENTENARIO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (116, N'CESAR PASSAMONTE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (117, N'CHACO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (118, N'CHUBUT')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (119, N'CIRCUNVALACION OESTE SUR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (120, N'CIUDAD DE NEUQUEN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (121, N'CIUDADELA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (122, N'CJAL.FERNANDO SILEONI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (123, N'CJAL.VALENTINA FANTONE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (124, N'CLAUDIO GRILLET')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (125, N'COLOMBIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (126, N'COLON')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (127, N'COLONIZADOR LUIS GENARO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (128, N'CORDOBA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (129, N'CORRIENTES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (130, N'CORTADA 1')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (131, N'COSTA RICA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (132, N'DANTE ALIGHIERI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (133, N'DEAN FUNES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (134, N'DIARIO L.V.DE S.JUSTO (RUTA 1)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (135, N'DIEHL DE SIENRA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (136, N'DOMINGA CULLEN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (137, N'DORREGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (138, N'DR. JOSE D`INTINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (139, N'DR. MARIO DANTE AGODINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (140, N'DR. ARTURO ILLIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (141, N'DR. ENRIQUE J. CARRA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (142, N'DR. ENRIQUE J. CARRA (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (143, N'DR. ENRIQUE J. CARRA (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (144, N'DR. JUAN PAVESIO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (145, N'DR. OLGUIN ESTE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (146, N'DR. OLGUIN OESTE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (147, N'DR. OLGUIN SUR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (148, N'DR. RAMON J. CARCANO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (149, N'DR. RICARDO BALBIN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (150, N'DRAGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (151, N'ECHEVERRIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (152, N'ECUADOR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (153, N'EDELMIRO LEZCANO CEBALLOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (154, N'EDUARDO LUIS SCOCCO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (155, N'ELISA DAMAR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (156, N'ELVIO ALMADA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (157, N'EMILIO PETTORUTTI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (158, N'ENRIQUETA AMALVY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (159, N'ENTRE RIOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (160, N'ENTRE RIOS (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (161, N'ENTRE RIOS (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (162, N'ERNESTO VIDAL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (163, N'ESPAÑA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (164, N'ESPERANZA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (165, N'ESTHER GILETTA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (166, N'EVA PERON')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (167, N'FALUCHO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (168, N'FANNY JACOVSKY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (169, N'FERNANDO FADER')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (170, N'FINAZZI PIETRO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (171, N'FLORENCIO MOLINA CAMPOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (172, N'FLORENCIO SANCHEZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (173, N'FORMOSA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (174, N'FORTUNATO LACAMERA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (175, N'FRANCISCA FERRAZZI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (176, N'FRANCISCO MOZZO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (177, N'FRANCISCO PERETTI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (178, N'FRENCH Y BERUTTI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (179, N'GABOTO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (180, N'GENERAL PAZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (181, N'GERONIMO DEL BARCO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (182, N'GERONIMO DEL BARCO (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (183, N'GERONIMO DEL BARCO (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (184, N'GERONIMO L. DE CABRERA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (185, N'GIORGIS Y LUPINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (186, N'GOBERNADOR DEL CASTILLO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (187, N'GOBERNADOR RAMON B.MESTRE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (188, N'GOBERNADOR RAUL LUCINI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (189, N'GOBERNADOR SAN MARTIN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (190, N'GONTERO JOSE ANTONIO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (191, N'GONZALEZ ABEL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (192, N'GUATEMALA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (193, N'GUSTAVO MALLAT')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (194, N'GUTIERREZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (195, N'GUTIERREZ (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (196, N'GUTIERREZ (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (197, N'HERMANOS BERTELLO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (198, N'HERMANOS MACCHIERALDO')
GO
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (199, N'HERMINIA BENEGAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (200, N'HNOS. CASALIS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (201, N'HONDURAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (202, N'INDEPENDENCIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (203, N'INDEPENDENCIA (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (204, N'INDEPENDENCIA (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (205, N'INGENIEROS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (206, N'INT. CAP. C. DITTRICH')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (207, N'INT. DR. ANTONIO LAMBERGHINI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (208, N'INT. DR. JOSE ALDO FERRERO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (209, N'INT. GUILLERMO JOSE PERETTI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (210, N'INT. JOSE DEVOTO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (211, N'INT. LEON SANANE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (212, N'INTENDENTE CARTIER')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (213, N'ISABEL POGOLOTTI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (214, N'ISABEL PUBILL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (215, N'ISABEL TERRAF')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (216, N'ISIDORO BRUNO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (217, N'ITALIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (218, N'ITURRASPE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (219, N'ITURRASPE NORTE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (220, N'ITURRASPE SUR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (221, N'ITUZAINGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (222, N'ITUZAINGO PEATONAL Nº2')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (223, N'ITUZAINGO PEATONAL NRO.1')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (224, N'JAVIER LOPEZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (225, N'JOAQUIN GREGORIO MARTINEZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (226, N'JONAS SALK')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (227, N'JORGE NEWBERY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (228, N'JOSE CUBA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (229, N'JOSE DE CALAZANZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (230, N'JOSE HERNANDEZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (231, N'JOSE LENCINAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (232, N'JOSE MARIA LOPEZ VILLAR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (233, N'JOSE MARMOL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (234, N'JUAN CARLOS BROOK')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (235, N'JUAN CARLOS CASTAGNINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (236, N'JUAN DIAZ DE SOLIS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (237, N'JUAN DOMINGO PERON')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (238, N'JUAN JOSE PASO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (239, N'JUAN JOSE PASO(N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (240, N'JUAN JOSE PASO(S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (241, N'JUAN M.BAGGIO FERRAZZI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (242, N'JUAN XXIII')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (243, N'JUJUY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (244, N'KM 4 - RUTA PROV. Nº 1')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (245, N'LA PAMPA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (246, N'LAMADRID')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (247, N'LAMADRID (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (248, N'LAMADRID(S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (249, N'LANFRANCHI Y ZURINI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (250, N'LARREA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (251, N'LARREA (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (252, N'LARREA (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (253, N'LAS CAMELIAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (254, N'LAS MAGNOLIAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (255, N'LAVALLE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (256, N'LEONOR CHIANALINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (257, N'LIBERTAD')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (258, N'LIMA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (259, N'LINIERS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (260, N'LINO ENEAS SPILIMBERGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (261, N'LOPEZ Y PLANES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (262, N'LORENZO FORGA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (263, N'LOS ALAMOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (264, N'LOS ALERCES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (265, N'LOS ALGARROBOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (266, N'LOS ANDES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (267, N'LOS AROMOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (268, N'LOS CEREZOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (269, N'LOS CHAÑARITOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (270, N'LOS CIRUELOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (271, N'LOS FRESNOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (272, N'LOS GARABATOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (273, N'LOS JAZMINEZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (274, N'LOS MANZANOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (275, N'LOS NARANJOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (276, N'LOS ÑANDUBAY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (277, N'LOS PARAISOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (278, N'LOS PIAMONTESES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (279, N'LOS PINOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (280, N'LOS PLATANOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (281, N'LOS ROBLES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (282, N'LOS SAUCES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (283, N'LOS TULIPANES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (284, N'LOTHAR BADERSBACH')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (285, N'MADRE ANGELINA ROMERO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (286, N'MADRE MARIA LUISA MARSILLA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (287, N'MAESTRO AMBROSIO REYNOLDI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (288, N'MAESTRO GARRONE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (289, N'MAGALLANES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (290, N'MAGNANO BARTOLO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (291, N'MAIPU Y RUTA 158')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (292, N'MANUEL TRIBOLE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (293, N'MARCONI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (294, N'MATIAS FANTINI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (295, N'MENDOZA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (296, N'MEXICO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (297, N'MIGUEL ANGEL MORINI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (298, N'MIGUEL PABLO BORGARELLO')
GO
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (299, N'MIRETTI LUIS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (300, N'MISIONES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (301, N'MITRE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (302, N'MORENO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (303, N'MORENO - 1091-BUENOS AIRES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (304, N'MORTEROS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (305, N'NAZCA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (306, N'NICOLINI MARCOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (307, N'NORMA NAVARRO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (308, N'OLEGARIO ANDRADE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (309, N'OLGA TERRAF')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (310, N'OSCAR VENTURA LIWACKI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (311, N'OSVALDO RAUL MESAGLI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (312, N'PADRE BORELLO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (313, N'PADRE GERVASI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (314, N'PAEZ NESTOR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (315, N'PAMPIGLIONE SANTIAGO GUILLERMO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (316, N'PANAMA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (317, N'PARAGUAY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (318, N'PARAGUAY(N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (319, N'PARAGUAY(S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (320, N'PASCUAL B. SOSA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (321, N'PASOS DE LOS ANDES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (322, N'PASTEUR')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (323, N'PAVON')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (324, N'PEAT. ARROYO DE LAS TORTUGAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (325, N'PEAT. ARROYO DEL MEDIO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (326, N'PEAT. BELGRANO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (327, N'PEAT. CANGALLO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (328, N'PEAT. CAÑADA JEANMAIRE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (329, N'PEAT. CAÑADA LAS VIBORAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (330, N'PEAT. CARCARAÑA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (331, N'PEAT. CECIL NEWTON')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (332, N'PEAT. DR. BENJAMIN PALACIOS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (333, N'PEAT. LAGUNA D DEL BAYO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (334, N'PEAT. RIO DULCE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (335, N'PEAT. RIO PINTO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (336, N'PEAT. RIO SUQUIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (337, N'PEAT. ZANICHELLI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (338, N'PEATONAL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (339, N'PEATONAL 1')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (340, N'PEATONAL 12')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (341, N'PEATONAL Nº 50')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (342, N'PEATONAL Nº1(O)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (343, N'PEATONAL Nº2 (E)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (344, N'PERU')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (345, N'PJE NRO 1')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (346, N'PJE. A. TAGLIORETTI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (347, N'PJE. ALASKA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (348, N'PJE. AYACUCHO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (349, N'PJE. BARTOLO BAUDINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (350, N'PJE. CANADA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (351, N'PJE. CHACABUCO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (352, N'PJE. CHAMPAGNAT (N)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (353, N'PJE. CHAMPAGNAT (S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (354, N'PJE. CIUDAD DE NEUQUEN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (355, N'PJE. CONSTITUCION')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (356, N'PJE. CURA BROCHERO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (357, N'PJE. DR. EDUARDO CESAR LESTON')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (358, N'PJE. DR. JOSE CIRIACO JUAREZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (359, N'PJE. DR. VICTORIO ELKIN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (360, N'PJE. EE.UU.')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (361, N'PJE. HAEDO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (362, N'PJE. HAITI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (363, N'PJE. INT. JUAN R. CORNAGLIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (364, N'PJE. INTENDENTE FERRERO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (365, N'PJE. LAPRIDA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (366, N'PJE. LAS GUAYANAS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (367, N'PJE. LISANDRO DE LA TORRE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (368, N'PJE. MADRE TERESA DE CALCUTA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (369, N'PJE. MARTIN FIERRO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (370, N'PJE. PADRE BORELO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (371, N'PJE. PEATONAL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (372, N'PJE. PROF. ALFREDO QUAGLIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (373, N'PJE. RECONQUISTA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (374, N'PJE. RIO I')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (375, N'PJE. RIO II')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (376, N'PJE. RIO III')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (377, N'PJE. RIO IV')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (378, N'PJE. SAAVEDRA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (379, N'PJE. SALERNI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (380, N'PJE. SAN JUAN BOSCO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (381, N'PJE. SANTA CRUZ')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (382, N'PJE. SANTO DOMINGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (383, N'PJE. SAVINO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (384, N'PJE. SOL DE MAYO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (385, N'PJE. SOR TERESA BENAGES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (386, N'PJE. TIERRA DEL FUEGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (387, N'PJE. VISCONTI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (388, N'POETA LUGONES')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (389, N'POTOSI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (390, N'PROF. DR. F. MASTROSIMONE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (391, N'PROF. ARTURO MASJOAN GARAY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (392, N'PROF. ISABEL PUBILL DE GARDELLA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (393, N'PUBLICA C')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (394, N'PUBLICA D (ALTOS DEL PRADO)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (395, N'PUBLICA G (LOS PALMARES)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (396, N'PUBLICA I (LOS PALMARES II)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (397, N'PUBLICA IV')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (398, N'PUBLICA J')
GO
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (399, N'PUBLICA Z (MAGDALENA)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (400, N'PUEYRREDON')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (401, N'PUZZI SANTIAGO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (402, N'QUAGLIA ALFREDO P.')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (403, N'RAFAELA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (404, N'RAMON Y CAJAL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (405, N'RAUL JOSE DOSANTO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (406, N'REPUBLICA ARABE DE SIRIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (407, N'REPUBLICA DEL LIBANO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (408, N'RESISTENCIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (409, N'RIO NEGRO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (410, N'RIOJA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (411, N'RIVADAVIA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (412, N'ROMA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (413, N'ROSA KARLEN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (414, N'ROSALIA PUBILL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (415, N'ROTONDA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (416, N'RUFINO VARELA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (417, N'RUTA 1 KM 4,5 -EST.EL MANA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (418, N'RUTA 1 KM 7')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (419, N'RUTA 1 Y RUTA 158')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (420, N'RUTA 158 KM 0,5')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (421, N'RUTA 158 KM 2,5')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (422, N'RUTA 158 KM 4 1/2(S)')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (423, N'RUTA 158 Y RUTA 19')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (424, N'RUTA 19')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (425, N'RUTA 19 KM 125')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (426, N'RUTA NAC.19 KM.135')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (427, N'RUTA NACIONAL 158')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (428, N'RUTA PROVIN 1 Y JUAN DE GARAY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (429, N'RUTA PROVINCIAL 1')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (430, N'S.T.DE GODOY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (431, N'SALTA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (432, N'SAN FRANCISCO DE ASIS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (433, N'SAN JUAN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (434, N'SAN LORENZO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (435, N'SAN LUIS')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (436, N'SANTA FE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (437, N'SANTA ROSA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (438, N'SANTIAGO DEL ESTERO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (439, N'SARGENTO CABRAL')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (440, N'SARMIENTO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (441, N'SENADOR JUAN B.FASSI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (442, N'SUIPACHA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (443, N'TABLADA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (444, N'TAMPIERI RICARDO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (445, N'TERESA BARRENECHEA DE CARTIER')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (446, N'TOMASA SOSA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (447, N'TORRES JUAN JOSE')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (448, N'TUCUMAN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (449, N'URUGUAY')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (450, N'VALENTIN PAGLIANO')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (451, N'VELEZ SARSFIELD')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (452, N'VENEZUELA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (453, N'VENIER JUAN')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (454, N'VENIER Y FINAZZI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (455, N'VENIER Y PUZZI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (456, N'VERONICA SADDA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (457, N'VICENTE MANSILLA')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (458, N'VICTOR ANGELI')
INSERT [dbo].[calle] ([idCalle], [nombre]) VALUES (459, N'ZONA RURAL SAN FRANCISCO')
SET IDENTITY_INSERT [dbo].[calle] OFF
GO
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (1, 1, N'Cables de alumbrado caídos ', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (2, 1, N'Columnas de alumbrado caídas o por caer ', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (3, 1, N'Corte de ramas que tocan cables de alumbrado', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (4, 1, N'Luminarias quemadas o rotas', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (5, 1, N'Semáforos - Arreglo y sincronización ', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (6, 1, N'Postes, cables caídos o por caer (Telecom, Epec, Monet)', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (7, 2, N'Bocas de registros tapadas', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (8, 2, N'Caños de agua rotos', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (9, 2, N'Colectoras tapadas', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (10, 2, N'Controles en conexiones de cloacas', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (11, 2, N'Desborde de líquidos cloacales', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (12, 2, N'Medidores de agua rotos', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (13, 3, N'Corte de ramas y árboles por caer', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (14, 3, N'Desmalezamiento de lotes y veredas', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (15, 3, N'Limpieza de espacios verdes (Ej. Plazas)', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (16, 3, N'Arreglo de calles de tierra', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (17, 3, N'Minibasurales', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (18, 3, N'Pedidos de regador', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (19, 3, N'Recolección de Inertes', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (20, 3, N'Derrames en la vía pública', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (21, 3, N'Retiro de animales muertos', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (22, 4, N'Consumo de alcohol (en la vía pública)', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (23, 4, N'Controles en  locales bailables o pubs', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (24, 4, N'Fumar en lugares prohibidos', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (25, 4, N'Música alta bares, boliches etc.', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (26, 4, N'Venta de alcohol a menores', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (27, 5, N'Baches', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (28, 5, N'Carteles de señalización vial', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (29, 5, N'Controles en obras de pavimento, baches y cordón cuneta tercerizados', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (30, 5, N'Reclamos de nomencladores y cartelería', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (31, 6, N'Animales sueltos (perros-caballos etc.)', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (32, 6, N'Arrojo de agua servida a la vía pública', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (33, 6, N'Controles en fumigaciones', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (34, 6, N'Extracción de enjambres', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (35, 6, N'Lavado de vehículos- hidrolavadora, días prohibidos', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (36, 6, N'Olores', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (37, 6, N'Pedidos de fumigaciones o desinfecciones', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (38, 6, N'Perros peligrosos', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (39, 6, N'Quema de basura, inertes', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (40, 6, N'Retiro de perros callejeros', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (41, 6, N'Ruidos molestos', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (42, 7, N'Casa abandonada', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (43, 7, N'Control de toldos, cartelería,etc. ', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (44, 7, N'Controles en demoliciones', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (45, 7, N'Materiales en la calle', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (46, 7, N'Poda indiscriminada', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (47, 7, N'Veredas obstruidas', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (48, 8, N'Prevenciones (Carga y descarga)', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (49, 8, N'Vehículos abandonados', NULL)
INSERT [dbo].[incidente] ([idIncidente], [idCategoria], [nombre], [descripcion]) VALUES (50, 8, N'Vehículos mal estacionados', NULL)
GO
INSERT [dbo].[incidente_categoria] ([idCategoria], [nombre], [descripcion]) VALUES (1, N'Alumbrado Público', NULL)
INSERT [dbo].[incidente_categoria] ([idCategoria], [nombre], [descripcion]) VALUES (2, N'Agua y cloaca', NULL)
INSERT [dbo].[incidente_categoria] ([idCategoria], [nombre], [descripcion]) VALUES (3, N'Servicios públicos', NULL)
INSERT [dbo].[incidente_categoria] ([idCategoria], [nombre], [descripcion]) VALUES (4, N'Espectáculos Públicos', NULL)
INSERT [dbo].[incidente_categoria] ([idCategoria], [nombre], [descripcion]) VALUES (5, N'Infraestructura', NULL)
INSERT [dbo].[incidente_categoria] ([idCategoria], [nombre], [descripcion]) VALUES (6, N'Medio ambiente', NULL)
INSERT [dbo].[incidente_categoria] ([idCategoria], [nombre], [descripcion]) VALUES (7, N'Obras y viviendas', NULL)
INSERT [dbo].[incidente_categoria] ([idCategoria], [nombre], [descripcion]) VALUES (8, N'Tránsito', NULL)
GO
SET IDENTITY_INSERT [dbo].[rol] ON 

INSERT [dbo].[rol] ([idRol], [nombre], [descripcion]) VALUES (0, N'Vecino', NULL)
INSERT [dbo].[rol] ([idRol], [nombre], [descripcion]) VALUES (1, N'Funcionario', NULL)
SET IDENTITY_INSERT [dbo].[rol] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idUsuario], [idRol], [nombre], [altura], [telefono], [dni], [email], [clave], [idCalle]) VALUES (2, 1, N'Tito Rodriguez', N'', N'3562124566', N'24124564', N'funcionario@gmail.com', 0x4F37C061F1854F9682F543FECB5EE9D652C803235970202DE97C6E40C8361766, 0)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
ALTER TABLE [dbo].[reclamo]  WITH CHECK ADD  CONSTRAINT [FK_reclamo_calle] FOREIGN KEY([idCalle])
REFERENCES [dbo].[calle] ([idCalle])
GO
ALTER TABLE [dbo].[reclamo] CHECK CONSTRAINT [FK_reclamo_calle]
GO
ALTER TABLE [dbo].[reclamo]  WITH CHECK ADD  CONSTRAINT [FK_reclamo_usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[reclamo] CHECK CONSTRAINT [FK_reclamo_usuario]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_calle] FOREIGN KEY([idCalle])
REFERENCES [dbo].[calle] ([idCalle])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_calle]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([idRol])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_rol]
GO
/****** Object:  StoredProcedure [dbo].[calle_listar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[calle_listar]
as
select idCalle, nombre from calle
GO
/****** Object:  StoredProcedure [dbo].[categoria_incidente]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[categoria_incidente]
@valor int
as
select i.idIncidente, i.nombre
from incidente as i inner join incidente_categoria as c on i.idCategoria = c.idCategoria
where i.idCategoria = @valor
GO
/****** Object:  StoredProcedure [dbo].[categoria_listar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[categoria_listar]
as
select idCategoria, nombre, descripcion from incidente_categoria
order by idCategoria asc
GO
/****** Object:  StoredProcedure [dbo].[incidente_listar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[incidente_listar]
as
select i.idIncidente as idIncidente, c.idCategoria as idCategoria, c.nombre as categoria, i.nombre as incidente, i.descripcion as descripcion from incidente as i inner join incidente_categoria as c on i.idCategoria = c.idCategoria
order by i.idIncidente asc
GO
/****** Object:  StoredProcedure [dbo].[reclamo_buscar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[reclamo_buscar]
@valor varchar(50)
as
select r.idReclamo as Id, i.nombre as Incidente, c.nombre as Categoria, r.estado as Estado, r.foto as Foto, r.fecha as Fecha, 
r.altura as Altura, r.idCalle as Calle, r.descripcion as Descripcion
from reclamo as r inner join incidente as i on r.idIncidente = i.idIncidente inner join incidente_categoria as c on i.idCategoria = c.idCategoria
where i.nombre like '%' + @valor + '%' or c.nombre like '%' + @valor + '%' 
order by r.idReclamo asc
GO
/****** Object:  StoredProcedure [dbo].[reclamo_eliminar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[reclamo_eliminar]
@idReclamo integer
as
delete from reclamo where idReclamo = @idReclamo
GO
/****** Object:  StoredProcedure [dbo].[reclamo_insertar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[reclamo_insertar]
@idUsuario integer,
@idIncidente integer,
@idMotivo integer,
@idCalle int,
@altura nvarchar(50),
@estado nvarchar(50),
@descripcion nvarchar(255),
@foto nvarchar(150),
@fecha nvarchar(100)
as
insert into reclamo (idUsuario,idIncidente,idMotivo,idCalle,Altura,estado,descripcion,foto,fecha) values (@idUsuario,@idIncidente,@idMotivo,@idCalle,@altura,@estado,@descripcion,@foto,@fecha)
GO
/****** Object:  StoredProcedure [dbo].[reclamo_listar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[reclamo_listar]
as
select r.idReclamo as Id, i.nombre as Incidente, c.nombre as nombreCategoria, c.idCategoria as Categoria, r.estado as Estado, r.foto as Foto, r.fecha as Fecha, 
ca.nombre as nombreCalle, r.altura as Altura, r.idCalle as Calle, r.descripcion as Descripcion
from reclamo as r inner join incidente as i on r.idIncidente = i.idIncidente inner join incidente_categoria as c on i.idCategoria = c.idCategoria inner join calle as ca on ca.idCalle = r.idCalle
order by r.idReclamo asc
GO
/****** Object:  StoredProcedure [dbo].[rol_listar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[rol_listar]
as
select idRol, nombre from rol
GO
/****** Object:  StoredProcedure [dbo].[usuario_actualizar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuario_actualizar]
@idUsuario integer,
@idRol integer,
@nombre nvarchar(100),
@altura nvarchar(50),
@calle integer,
@telefono nvarchar(20),
@dni nvarchar(20),
@email nvarchar(50),
@clave nvarchar(20)
as
if @clave <> ''
update usuario set idRol = @idRol, nombre = @nombre, idCalle = @calle, altura = @altura,  telefono = @telefono, dni = @dni,
email = @email,
clave = HASHBYTES('SHA2_256',@clave)
where idUsuario = @idUsuario;
else
update usuario set idRol = @idRol, nombre = @nombre, idCalle = @calle, altura = @altura, telefono = @telefono, dni = @dni,
email = @email
where idUsuario = @idUsuario;
GO
/****** Object:  StoredProcedure [dbo].[usuario_buscar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuario_buscar]
@valor varchar(100)
as
select u.idUsuario as ID, u.idRol, r.nombre as Rol, u.nombre as Nombre, u.dni as Dni, u.idCalle, c.nombre as Calle, 
u.altura as Altura, telefono as Telefono, u.email as Email
from rol as r inner join usuario as u on u.idRol = r.idRol inner join calle as c on u.idCalle = c.idCalle
where u.nombre like '%' + @valor + '%' or u.email like '%' + @valor + '%'
order by u.nombre asc
GO
/****** Object:  StoredProcedure [dbo].[usuario_eliminar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usuario_eliminar]
@idUsuario integer
as
delete from usuario where idUsuario = @idUsuario
GO
/****** Object:  StoredProcedure [dbo].[usuario_existe]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usuario_existe]
@valor varchar(100),
@existe bit output
as
	if exists (select email from usuario where email = ltrim(rtrim(@valor)))
		begin
			set @existe = 1
		end
	else
		begin
			set @existe = 0
		end
GO
/****** Object:  StoredProcedure [dbo].[usuario_insertar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuario_insertar]
@idRol integer,
@nombre nvarchar(100),
@calle integer,
@altura nvarchar(50),
@telefono nvarchar(20),
@dni nvarchar(20),
@email nvarchar(50),
@clave nvarchar(20)
as
insert into usuario (idRol,nombre,idCalle,altura,telefono,dni,email,clave) 
values (@idRol,@nombre,@calle,@altura,@telefono,@dni,@email,HASHBYTES('SHA2_256', @clave))
GO
/****** Object:  StoredProcedure [dbo].[usuario_listar]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuario_listar]
as
select u.idUsuario as Id, u.idRol, r.nombre as Rol, u.nombre as Nombre, u.idCalle, c.nombre as Calle, u.altura as Altura,
u.telefono as Telefono, u.dni as Dni, u.email as Email
from usuario as u inner join rol as r on u.idRol = r.idRol inner join calle as c on u.idCalle = c.idCalle
order by u.idUsuario asc
GO
/****** Object:  StoredProcedure [dbo].[usuario_login]    Script Date: 19/8/2022 16:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usuario_login]
@email nvarchar(50),
@clave nvarchar(20)
as
select u.idUsuario, u.idRol, r.nombre as Rol, u.nombre, u.idCalle, c.nombre, u.altura, u.telefono, u.dni, u.email
from usuario as u inner join rol as r on u.idRol = r.idRol inner join calle as c on u.idCalle = c.idCalle
where u.email = @email and u.clave = HASHBYTES('SHA2_256',@clave)
GO
USE [master]
GO
ALTER DATABASE [PobreTITO] SET  READ_WRITE 
GO
