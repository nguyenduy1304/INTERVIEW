CREATE DATABASE DEMO
GO

USE DEMO
GO

CREATE TABLE Account
(
	UniqueID			VARCHAR(50) PRIMARY KEY,
	UserName			VARCHAR(50) UNIQUE,  
	Email				VARCHAR(250) UNIQUE NOT NULL,
	Password			VARCHAR(50),
)
GO

CREATE TABLE Product
(
	UniqueID			INT IDENTITY(1,1) PRIMARY KEY,
	Title				NVARCHAR(MAX),
	PICTURE				VARCHAR(255),
	CreateDateTime		DATETIME,
	React				VARCHAR(50)
)
GO


CREATE TABLE React
(
	UniqueID			VARCHAR(50) PRIMARY KEY,
	AccountID			VARCHAR(50) FOREIGN KEY REFERENCES Account(UniqueID),
	ProductID			INT FOREIGN KEY REFERENCES Product(UniqueID),
)
GO

INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (1, N'Phim kiếm hiệp 1', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'1')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (2, N'Phim kiếm hiệp 2', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'2')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (3, N'Phim kiếm hiệp 3', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'3')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (4, N'Phim kiếm hiệp 4', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'4')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (5, N'Phim kiếm hiệp 5', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'5')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (6, N'Phim kiếm hiệp 6', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'6')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (7, N'Phim kiếm hiệp 7', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'7')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (8, N'Phim kiếm hiệp 8', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'8')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (9, N'Phim kiếm hiệp 9', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'9')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (10, N'Phim kiếm hiệp 10', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'10')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (11, N'Phim kiếm hiệp 11', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'11')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (12, N'Phim kiếm hiệp 12', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'12')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (13, N'Phim kiếm hiệp 13', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'13')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (14, N'Phim kiếm hiệp 14', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'14')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (15, N'Phim kiếm hiệp 15', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'15')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (16, N'Phim kiếm hiệp 16', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'16')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (17, N'Phim kiếm hiệp 17', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'17')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (18, N'Phim kiếm hiệp 18', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'18')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (19, N'Phim kiếm hiệp 19', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'19')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (20, N'Phim kiếm hiệp 20', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'20')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (21, N'Phim kiếm hiệp 21', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'21')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (22, N'Phim kiếm hiệp 22', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'22')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (23, N'Phim kiếm hiệp 23', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'23')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (24, N'Phim kiếm hiệp 24', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'24')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (25, N'Phim kiếm hiệp 25', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'25')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (26, N'Phim kiếm hiệp 26', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'26')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (27, N'Phim kiếm hiệp 27', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'27')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (28, N'Phim kiếm hiệp 28', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'28')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (29, N'Phim kiếm hiệp 29', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'29')
INSERT [dbo].[Product] ([UniqueID], [Title], [PICTURE], [CreateDateTime], [React]) VALUES (30, N'Phim kiếm hiệp 30', N'phim1.jpg', CAST(N'2022-08-21T00:00:00.000' AS DateTime), N'30')