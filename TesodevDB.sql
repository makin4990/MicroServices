USE [master]
GO
/****** Object:  Database [TesodevDB]    Script Date: 28.08.2021 23:20:09 ******/
CREATE DATABASE [TesodevDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TesodevDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TesodevDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TesodevDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TesodevDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TesodevDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TesodevDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TesodevDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TesodevDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TesodevDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TesodevDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TesodevDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TesodevDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TesodevDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TesodevDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TesodevDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TesodevDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TesodevDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TesodevDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TesodevDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TesodevDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TesodevDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TesodevDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TesodevDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TesodevDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TesodevDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TesodevDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TesodevDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TesodevDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TesodevDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TesodevDB] SET  MULTI_USER 
GO
ALTER DATABASE [TesodevDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TesodevDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TesodevDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TesodevDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TesodevDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TesodevDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TesodevDB] SET QUERY_STORE = OFF
GO
USE [TesodevDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 28.08.2021 23:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [uniqueidentifier] NOT NULL,
	[AddressLine] [varchar](250) NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[CityCode] [int] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 28.08.2021 23:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 28.08.2021 23:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[AddressId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 28.08.2021 23:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[ImageUrl] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Addresses] ([Id], [AddressLine], [City], [Country], [CityCode], [CustomerId]) VALUES (N'0e6d89af-c4c4-4954-6b30-08d9663d44e8', N'Çifte Havuzlar Mah. Eski Londra Asfaltı Cad. Kuluçka Merkezi D2 Blok No: 151/1F İç Kapı No: 2B03 Esenler', N'İstanbul', N'Turkey', 34220, N'6c89b0db-8901-ec11-ad1c-204ef6a9b4ee')
INSERT [dbo].[Addresses] ([Id], [AddressLine], [City], [Country], [CityCode], [CustomerId]) VALUES (N'232d928b-b201-ec11-ad1c-204ef6a9b4ee', N'Mimar Sinan Mah 2339. Sok', N'Aydın', N'Turkey', 9100, N'd4382973-b805-4b63-ab19-c2b369565667')
INSERT [dbo].[Addresses] ([Id], [AddressLine], [City], [Country], [CityCode], [CustomerId]) VALUES (N'242d928b-b201-ec11-ad1c-204ef6a9b4ee', N'Çifte Havuzlar Mah. Eski Londra Asfaltı Cad. Kuluçka Merkezi D2 Blok No: 151/1F İç Kapı No: 2B03 Esenler', N'İstanbul', N'Turkey', 34220, N'6c89b0db-8901-ec11-ad1c-204ef6a9b4ee')
INSERT [dbo].[Addresses] ([Id], [AddressLine], [City], [Country], [CityCode], [CustomerId]) VALUES (N'252d928b-b201-ec11-ad1c-204ef6a9b4ee', N'Levent Mah, Büyükdere Cd. No:185,Şişli', N'İstanbul', N'Turkey', 34394, N'86fa7d1b-6469-4d20-acfb-2c20c666e607')
GO
INSERT [dbo].[Customers] ([Id], [Name], [Email], [UpdatedAt], [CreatedAt]) VALUES (N'6c89b0db-8901-ec11-ad1c-204ef6a9b4ee', N'Tesodev Project', N'bilgi@tesodev.com', CAST(N'2021-08-20T00:00:00.000' AS DateTime), CAST(N'2021-08-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Customers] ([Id], [Name], [Email], [UpdatedAt], [CreatedAt]) VALUES (N'86fa7d1b-6469-4d20-acfb-2c20c666e607', N'Serhat Şermet', N'serhatsermet@gmail.com', CAST(N'2021-08-20T00:00:00.000' AS DateTime), CAST(N'2021-08-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Customers] ([Id], [Name], [Email], [UpdatedAt], [CreatedAt]) VALUES (N'd4382973-b805-4b63-ab19-c2b369565667', N'Muhammed Akın', N'm.akin4990@gmail.com', CAST(N'1990-07-21T00:00:00.000' AS DateTime), CAST(N'2021-08-18T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [CustomerId], [Quantity], [Price], [Status], [AddressId], [ProductId], [CreatedAt], [UpdatedAt]) VALUES (N'48451c21-b501-ec11-ad1c-204ef6a9b4ee', N'6c89b0db-8901-ec11-ad1c-204ef6a9b4ee', 4, 3900, N'Status ... ', N'242d928b-b201-ec11-ad1c-204ef6a9b4ee', N'010e9eff-b401-ec11-ad1c-204ef6a9b4ee', CAST(N'2021-08-20T00:00:00.000' AS DateTime), CAST(N'2021-08-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([Id], [CustomerId], [Quantity], [Price], [Status], [AddressId], [ProductId], [CreatedAt], [UpdatedAt]) VALUES (N'c92fe371-b501-ec11-ad1c-204ef6a9b4ee', N'd4382973-b805-4b63-ab19-c2b369565667', 9, 3899, N'Status2', N'232d928b-b201-ec11-ad1c-204ef6a9b4ee', N'262fb80c-b501-ec11-ad1c-204ef6a9b4ee', CAST(N'2021-08-20T00:00:00.000' AS DateTime), CAST(N'2021-08-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([Id], [CustomerId], [Quantity], [Price], [Status], [AddressId], [ProductId], [CreatedAt], [UpdatedAt]) VALUES (N'9eaec098-25af-44bb-92e4-42369f24d554', N'6c89b0db-8901-ec11-ad1c-204ef6a9b4ee', 4, 3900, N'Status ... ', N'0e6d89af-c4c4-4954-6b30-08d9663d44e8', N'e01c9a2d-353e-41f6-0b86-08d9663d44ea', CAST(N'2021-08-20T00:00:00.000' AS DateTime), CAST(N'2021-08-20T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ImageUrl], [Name]) VALUES (N'e01c9a2d-353e-41f6-0b86-08d9663d44ea', N'/env/img', N'product4')
INSERT [dbo].[Products] ([Id], [ImageUrl], [Name]) VALUES (N'010e9eff-b401-ec11-ad1c-204ef6a9b4ee', N'/env/img', N'product1')
INSERT [dbo].[Products] ([Id], [ImageUrl], [Name]) VALUES (N'262fb80c-b501-ec11-ad1c-204ef6a9b4ee', N'/env/img', N'product2')
INSERT [dbo].[Products] ([Id], [ImageUrl], [Name]) VALUES (N'272fb80c-b501-ec11-ad1c-204ef6a9b4ee', N'/env/img', N'product3')
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_ProductId]  DEFAULT (newsequentialid()) FOR [ProductId]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Customers1] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Customers1]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Addresses_] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Addresses_]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products]
GO
USE [master]
GO
ALTER DATABASE [TesodevDB] SET  READ_WRITE 
GO
