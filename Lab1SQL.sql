USE [Lab1SQL]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 2023-12-10 21:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClassName] [nchar](10) NULL,
 CONSTRAINT [PK__Klasser__3214EC07CA88F1FB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2023-12-10 21:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Course] [nchar](100) NULL,
	[Grade] [float] NULL,
	[DateSet] [date] NULL,
 CONSTRAINT [PK__Kurser__3214EC075496B614] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2023-12-10 21:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](100) NOT NULL,
	[LastName] [nchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffRole]    Script Date: 2023-12-10 21:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Role] [nchar](100) NULL,
 CONSTRAINT [PK__StaffRol__3214EC07175CA4CF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2023-12-10 21:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](100) NOT NULL,
	[LastName] [nchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (24, 26, N'B         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (25, 27, N'C         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (26, 28, N'A         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (27, 29, N'A         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (28, 30, N'B         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (29, 31, N'C         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (30, 32, N'B         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (31, 33, N'C         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (32, 34, N'B         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (33, 35, N'C         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (34, 36, N'B         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (35, 37, N'A         ')
INSERT [dbo].[Classes] ([Id], [UserId], [ClassName]) VALUES (40, 42, N'C         ')
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (20, 26, N'Programming                                                                                         ', 3, CAST(N'2023-12-04' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (21, 27, N'Finance                                                                                             ', 4, CAST(N'2023-03-03' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (22, 28, N'HiFi                                                                                                ', 2, CAST(N'2023-05-06' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (23, 29, N'HiFi                                                                                                ', 4, CAST(N'2023-07-16' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (24, 30, N'Finance                                                                                             ', 1, CAST(N'2023-12-03' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (25, 31, N'Programming                                                                                         ', 5, CAST(N'2023-12-01' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (26, 32, N'HiFi                                                                                                ', 5, CAST(N'2023-12-02' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (27, 33, N'Finance                                                                                             ', 2, CAST(N'2023-12-05' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (28, 34, N'Programming                                                                                         ', 2, CAST(N'2023-06-18' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (29, 35, N'HiFi                                                                                                ', 3, CAST(N'2023-08-01' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (30, 36, N'Programming                                                                                         ', 1, CAST(N'2023-02-03' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (31, 37, N'HiFi                                                                                                ', 5, CAST(N'2023-07-09' AS Date))
INSERT [dbo].[Courses] ([Id], [UserId], [Course], [Grade], [DateSet]) VALUES (36, 42, N'HiFi                                                                                                ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([Id], [FirstName], [LastName]) VALUES (16, N'Darth                                                                                               ', N'Vader                                                                                               ')
INSERT [dbo].[Staff] ([Id], [FirstName], [LastName]) VALUES (17, N'Sheev                                                                                               ', N'Palpatine                                                                                           ')
INSERT [dbo].[Staff] ([Id], [FirstName], [LastName]) VALUES (18, N'Leia                                                                                                ', N'Organa                                                                                              ')
INSERT [dbo].[Staff] ([Id], [FirstName], [LastName]) VALUES (19, N'Lando                                                                                               ', N'Calrissian                                                                                          ')
INSERT [dbo].[Staff] ([Id], [FirstName], [LastName]) VALUES (20, N'Han                                                                                                 ', N'Solo                                                                                                ')
INSERT [dbo].[Staff] ([Id], [FirstName], [LastName]) VALUES (21, N'Thomas                                                                                              ', N'Anderson                                                                                            ')
INSERT [dbo].[Staff] ([Id], [FirstName], [LastName]) VALUES (23, N'Dexter                                                                                              ', N'Morgan                                                                                              ')
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[StaffRole] ON 

INSERT [dbo].[StaffRole] ([Id], [UserId], [Role]) VALUES (6, 16, N'Administrator                                                                                       ')
INSERT [dbo].[StaffRole] ([Id], [UserId], [Role]) VALUES (7, 17, N'Principal                                                                                           ')
INSERT [dbo].[StaffRole] ([Id], [UserId], [Role]) VALUES (8, 18, N'Teacher                                                                                             ')
INSERT [dbo].[StaffRole] ([Id], [UserId], [Role]) VALUES (9, 19, N'Teacher                                                                                             ')
INSERT [dbo].[StaffRole] ([Id], [UserId], [Role]) VALUES (10, 20, N'Teacher                                                                                             ')
INSERT [dbo].[StaffRole] ([Id], [UserId], [Role]) VALUES (11, 21, N'Teacher                                                                                             ')
INSERT [dbo].[StaffRole] ([Id], [UserId], [Role]) VALUES (13, 23, N'Teacher                                                                                             ')
SET IDENTITY_INSERT [dbo].[StaffRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (26, N'Pierce                                                                                              ', N'Brosnan                                                                                             ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (27, N'John                                                                                                ', N'Malkovich                                                                                           ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (28, N'George                                                                                              ', N'Clooney                                                                                             ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (29, N'Brad                                                                                                ', N'Pitt                                                                                                ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (30, N'Bruce                                                                                               ', N'Wayne                                                                                               ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (31, N'Tom                                                                                                 ', N'Cruise                                                                                              ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (32, N'Sean                                                                                                ', N'Connery                                                                                             ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (33, N'Nicolas                                                                                             ', N'Cage                                                                                                ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (34, N'Ed                                                                                                  ', N'Harris                                                                                              ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (35, N'Morgan                                                                                              ', N'Freeman                                                                                             ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (36, N'Jack                                                                                                ', N'Nicholson                                                                                           ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (37, N'Harrison                                                                                            ', N'Ford                                                                                                ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (38, N'Denzel                                                                                              ', N'Washington                                                                                          ')
INSERT [dbo].[Students] ([Id], [FirstName], [LastName]) VALUES (42, N'Dexter                                                                                              ', N'Morgan                                                                                              ')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Classes1] FOREIGN KEY([UserId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Classes1]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Courses] FOREIGN KEY([UserId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Courses]
GO
ALTER TABLE [dbo].[StaffRole]  WITH CHECK ADD  CONSTRAINT [FK_StaffRole_Staff] FOREIGN KEY([UserId])
REFERENCES [dbo].[Staff] ([Id])
GO
ALTER TABLE [dbo].[StaffRole] CHECK CONSTRAINT [FK_StaffRole_Staff]
GO
