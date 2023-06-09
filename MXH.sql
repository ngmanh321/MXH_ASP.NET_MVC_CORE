USE [master]
GO
/****** Object:  Database [Test]    Script Date: 5/30/2023 4:44:26 PM ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Test] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Test] SET QUERY_STORE = OFF
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 5/30/2023 4:44:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[IDComment] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[Avatar] [nvarchar](50) NULL,
	[NoiDung] [nvarchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[IDPost] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[IDComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chat]    Script Date: 5/30/2023 4:44:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[IDChat] [int] IDENTITY(1,1) NOT NULL,
	[TKGui] [nvarchar](50) NULL,
	[TKNhan] [nvarchar](50) NULL,
	[AvatarGui] [nvarchar](50) NULL,
	[AvatarNhan] [nvarchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[NoiDung] [nvarchar](500) NULL,
	[ViTri] [int] NULL,
 CONSTRAINT [PK_Chat] PRIMARY KEY CLUSTERED 
(
	[IDChat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friend]    Script Date: 5/30/2023 4:44:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[TKGui] [nvarchar](50) NOT NULL,
	[TrangThai] [int] NULL,
	[TKNhan] [nvarchar](50) NOT NULL,
	[AvatarGui] [nvarchar](50) NULL,
	[AvatarNhan] [nvarchar](50) NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[TKGui] ASC,
	[TKNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Like]    Script Date: 5/30/2023 4:44:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[IDPost] [int] NOT NULL,
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[Avatar] [nvarchar](50) NULL,
	[NgayTao] [nvarchar](50) NULL,
 CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED 
(
	[IDPost] ASC,
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nguoidung]    Script Date: 5/30/2023 4:44:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nguoidung](
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [nvarchar](50) NULL,
	[AnhBia] [nvarchar](50) NULL,
	[Avatar] [nvarchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[GioiThieu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nguoidung] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 5/30/2023 4:44:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[IDPost] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[Avatar] [nvarchar](50) NULL,
	[NoiDung] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[Anh] [nvarchar](50) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[IDPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (63, N'ngthu321', N'ss.jpg', N'A', CAST(N'2023-04-19T00:11:28.150' AS DateTime), 52)
INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (64, N'ngmanh321', N'user8.jpg', N'B', CAST(N'2023-04-19T00:11:38.463' AS DateTime), 52)
INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (65, N'ngthu321', N'ss.jpg', N'C', CAST(N'2023-04-19T00:12:01.760' AS DateTime), 52)
INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (66, N'ngthu321', N'ss.jpg', N'AAAA', CAST(N'2023-04-19T00:14:13.640' AS DateTime), 53)
INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (67, N'ngmanh321', N'user8.jpg', N'A', CAST(N'2023-04-19T00:24:41.980' AS DateTime), 52)
INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (68, N'ngmanh321', N'user8.jpg', N'AA', CAST(N'2023-04-20T15:08:41.320' AS DateTime), 54)
INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (69, N'ngmanh321', N'user8.jpg', N'', CAST(N'2023-04-22T13:25:29.783' AS DateTime), 53)
INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (70, N'taikhoan', N'user7.jpg', N'AAAA', CAST(N'2023-04-27T08:00:29.197' AS DateTime), 64)
INSERT [dbo].[Comment] ([IDComment], [TaiKhoan], [Avatar], [NoiDung], [NgayTao], [IDPost]) VALUES (71, N'taikhoan', N'user7.jpg', N'AAA', CAST(N'2023-04-27T08:09:37.563' AS DateTime), 53)
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[Chat] ON 

INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (53, N'ngmanh999', N'ngmanhh321', N'ss.jpg', NULL, NULL, N'cmm', 2)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (54, N'ngmanh321', N'ngmanh999', N'user8.jpg', NULL, NULL, N'A', 1)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (55, N'ngmanh999', N'ngmanh321', N'ss.jpg', NULL, NULL, N'B', 1)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (56, N'ngmanh321', N'ngmanh999', N'user8.jpg', NULL, NULL, N'C
', 2)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (57, N'ngmanh999', N'ngmanh321', N'ss.jpg', NULL, NULL, N'D
', 2)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (58, N'ngmanh999', N'ngmanh321', N'ss.jpg', NULL, NULL, N'E
', 3)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (59, N'ngmanh321', N'ngmanh999', N'user8.jpg', NULL, NULL, N'F', 3)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (60, N'ngmanh999', N'ngmanh321', N'ss.jpg', NULL, NULL, N'DA', 4)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (61, N'ngmanh999', N'ngmanh321', N'ss.jpg', NULL, NULL, N'ssas', 5)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (62, N'ngmanh999', N'ngmanh321', N'ss.jpg', NULL, NULL, N'dsfsdfs', 6)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (63, N'ngmanh321', N'ngmanh999', N'user8.jpg', NULL, NULL, N'c', 4)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (64, N'ngmanh321', N'ngmanh999', N'user8.jpg', NULL, NULL, N'MM', 5)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (65, N'ngmanh321', N'ngthu321', NULL, NULL, NULL, N'C', 0)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (66, N'taikhoan', N'ngmanh321', N'user7.jpg', NULL, NULL, N'AA', 1)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (67, N'ngmanh321', N'taikhoan', N'user8.jpg', NULL, NULL, N'AA', 1)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (68, N'ngmanh321', N'taikhoan', N'user8.jpg', NULL, NULL, N'VVV', 2)
INSERT [dbo].[Chat] ([IDChat], [TKGui], [TKNhan], [AvatarGui], [AvatarNhan], [NgayTao], [NoiDung], [ViTri]) VALUES (69, N'taikhoan', N'ngmanh321', N'user7.jpg', NULL, NULL, N'AVBSBS', 2)
SET IDENTITY_INSERT [dbo].[Chat] OFF
GO
INSERT [dbo].[Friend] ([TKGui], [TrangThai], [TKNhan], [AvatarGui], [AvatarNhan]) VALUES (N'ngmanh321', 1, N'ngthu999', N'user8.jpg', N'avatar.jpg')
INSERT [dbo].[Friend] ([TKGui], [TrangThai], [TKNhan], [AvatarGui], [AvatarNhan]) VALUES (N'ngmanh321', 1, N'taikhoan', N'user8.jpg', N'user7.jpg')
INSERT [dbo].[Friend] ([TKGui], [TrangThai], [TKNhan], [AvatarGui], [AvatarNhan]) VALUES (N'ngmanh999', 1, N'ngmanh321', N'ss.jpg', N'user8.jpg')
INSERT [dbo].[Friend] ([TKGui], [TrangThai], [TKNhan], [AvatarGui], [AvatarNhan]) VALUES (N'ngthu321', 1, N'ngmanh321', N'ss.jpg', N'user8.jpg')
GO
INSERT [dbo].[Like] ([IDPost], [TaiKhoan], [Avatar], [NgayTao]) VALUES (52, N'ngmanh321', N'user8.jpg', N'Apr 22 2023  2:03PM')
INSERT [dbo].[Like] ([IDPost], [TaiKhoan], [Avatar], [NgayTao]) VALUES (52, N'ngthu321', N'ss.jpg', N'Apr 19 2023 12:11AM')
INSERT [dbo].[Like] ([IDPost], [TaiKhoan], [Avatar], [NgayTao]) VALUES (53, N'ngthu321', N'ss.jpg', N'Apr 19 2023 12:14AM')
INSERT [dbo].[Like] ([IDPost], [TaiKhoan], [Avatar], [NgayTao]) VALUES (53, N'taikhoan', N'user7.jpg', N'Apr 27 2023  8:09AM')
INSERT [dbo].[Like] ([IDPost], [TaiKhoan], [Avatar], [NgayTao]) VALUES (54, N'ngmanh321', N'user8.jpg', N'Apr 23 2023  8:02PM')
INSERT [dbo].[Like] ([IDPost], [TaiKhoan], [Avatar], [NgayTao]) VALUES (54, N'ngmanh999', N'ss.jpg', N'Apr 19 2023 12:25AM')
INSERT [dbo].[Like] ([IDPost], [TaiKhoan], [Avatar], [NgayTao]) VALUES (56, N'ngthu999', N'avatar.jpg', N'Apr 22 2023  2:05PM')
INSERT [dbo].[Like] ([IDPost], [TaiKhoan], [Avatar], [NgayTao]) VALUES (64, N'taikhoan', N'user7.jpg', N'Apr 27 2023  8:00AM')
GO
INSERT [dbo].[Nguoidung] ([TaiKhoan], [MatKhau], [Ten], [SDT], [GioiTinh], [NgaySinh], [AnhBia], [Avatar], [NgayTao], [GioiThieu]) VALUES (N'ngmanh321', N'ngthu321', N'Thu Nguyen ', N'123456781213', N'Nam', N'1-1-2002', N'vid-2.jpg', N'user8.jpg', CAST(N'2023-04-17T00:42:17.000' AS DateTime), N'Xem CCCCCCCCCCCCCCCCCCCCCCCCC')
INSERT [dbo].[Nguoidung] ([TaiKhoan], [MatKhau], [Ten], [SDT], [GioiTinh], [NgaySinh], [AnhBia], [Avatar], [NgayTao], [GioiThieu]) VALUES (N'ngmanh999', N'ngthu321', N'ABCD', N'1234567', N'Nu', N'1-1-2022', N'anhbia.jpeg', N'ss.jpg', CAST(N'2023-04-17T00:42:17.107' AS DateTime), N'Toi la Thu')
INSERT [dbo].[Nguoidung] ([TaiKhoan], [MatKhau], [Ten], [SDT], [GioiTinh], [NgaySinh], [AnhBia], [Avatar], [NgayTao], [GioiThieu]) VALUES (N'ngthu321', N'ngthu321', N'MNQ', N'123456', N'Nam', N'1-1-2000', N'anhbia.jpeg', N'ss.jpg', CAST(N'2023-04-17T00:42:17.107' AS DateTime), N'Toi la Thu')
INSERT [dbo].[Nguoidung] ([TaiKhoan], [MatKhau], [Ten], [SDT], [GioiTinh], [NgaySinh], [AnhBia], [Avatar], [NgayTao], [GioiThieu]) VALUES (N'ngthu999', N'ngthu321', N'New User', NULL, NULL, NULL, N'anhbia.jpeg', N'avatar.jpg', CAST(N'2023-04-19T14:58:17.247' AS DateTime), NULL)
INSERT [dbo].[Nguoidung] ([TaiKhoan], [MatKhau], [Ten], [SDT], [GioiTinh], [NgaySinh], [AnhBia], [Avatar], [NgayTao], [GioiThieu]) VALUES (N'taikhoan', N'taikhoan', N'New User!', NULL, N'Nu', NULL, N'vid-3.jpg', N'user7.jpg', CAST(N'2023-04-27T07:56:45.000' AS DateTime), N'AAA')
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([IDPost], [TaiKhoan], [Avatar], [NoiDung], [TrangThai], [NgayTao], [Anh]) VALUES (52, N'ngthu321', N'ss.jpg', N'Post', N'Public', CAST(N'2023-04-19T00:10:21.723' AS DateTime), N'vid-1.jpg')
INSERT [dbo].[Post] ([IDPost], [TaiKhoan], [Avatar], [NoiDung], [TrangThai], [NgayTao], [Anh]) VALUES (53, N'ngmanh321', N'user8.jpg', N'Chuc Man', N'Public', CAST(N'2023-04-19T00:13:52.000' AS DateTime), N'vid-6.jpg')
INSERT [dbo].[Post] ([IDPost], [TaiKhoan], [Avatar], [NoiDung], [TrangThai], [NgayTao], [Anh]) VALUES (54, N'ngmanh999', N'ss.jpg', N'Somthing', N'Public', CAST(N'2023-04-19T00:25:06.000' AS DateTime), N'vid-6.jpg')
INSERT [dbo].[Post] ([IDPost], [TaiKhoan], [Avatar], [NoiDung], [TrangThai], [NgayTao], [Anh]) VALUES (56, N'ngmanh321', N'user8.jpg', N'ABC', N'Public', CAST(N'2023-04-20T14:03:41.000' AS DateTime), N'vid-9.jpg')
INSERT [dbo].[Post] ([IDPost], [TaiKhoan], [Avatar], [NoiDung], [TrangThai], [NgayTao], [Anh]) VALUES (57, N'ngthu999', N'avatar.jpg', N'A', N'Public', CAST(N'2023-04-20T15:35:06.830' AS DateTime), N'vid-8.jpg')
INSERT [dbo].[Post] ([IDPost], [TaiKhoan], [Avatar], [NoiDung], [TrangThai], [NgayTao], [Anh]) VALUES (64, N'taikhoan', N'user7.jpg', N'Sua', N'Private', CAST(N'2023-04-27T07:59:52.000' AS DateTime), N'vid-7.jpg')
INSERT [dbo].[Post] ([IDPost], [TaiKhoan], [Avatar], [NoiDung], [TrangThai], [NgayTao], [Anh]) VALUES (65, N'taikhoan', N'user7.jpg', N'Share from taikhoan : AAA', N'Public', CAST(N'2023-04-27T08:01:16.803' AS DateTime), N'vid-11.jpg')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Post] FOREIGN KEY([IDPost])
REFERENCES [dbo].[Post] ([IDPost])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Post]
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD  CONSTRAINT [FK_Like_Nguoidung] FOREIGN KEY([TaiKhoan])
REFERENCES [dbo].[Nguoidung] ([TaiKhoan])
GO
ALTER TABLE [dbo].[Like] CHECK CONSTRAINT [FK_Like_Nguoidung]
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD  CONSTRAINT [FK_Like_Post] FOREIGN KEY([IDPost])
REFERENCES [dbo].[Post] ([IDPost])
GO
ALTER TABLE [dbo].[Like] CHECK CONSTRAINT [FK_Like_Post]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Nguoidung1] FOREIGN KEY([TaiKhoan])
REFERENCES [dbo].[Nguoidung] ([TaiKhoan])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Nguoidung1]
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
