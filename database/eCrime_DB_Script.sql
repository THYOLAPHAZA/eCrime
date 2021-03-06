
USE [eCrime]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 04/04/2020 10:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UID] [int] NOT NULL,
	[FName] [varchar](50) NULL,
	[MName] [varchar](50) NULL,
	[LName] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[ResiNo] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[DOB] [datetime] NULL,
	[UserType] [varchar](50) NULL,
	[Details] [varchar](50) NULL,
	[PhotoName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[UserMaster] ([UID], [FName], [MName], [LName], [MobileNo], [ResiNo], [EmailId], [DOB], [UserType], [Details], [PhotoName], [Password], [Location], [CreatedBy], [CreatedDate]) VALUES (1, N'Admin', N'', N'Admin', N'0', N'0', N'admin@ecrime.com', NULL, N'Administrator', N'', NULL, N'123', N'All', N'Admin', NULL)
INSERT [dbo].[UserMaster] ([UID], [FName], [MName], [LName], [MobileNo], [ResiNo], [EmailId], [DOB], [UserType], [Details], [PhotoName], [Password], [Location], [CreatedBy], [CreatedDate]) VALUES (2, N'Mphatzo', N'', N'Thyolaphaza', N'+3539999999999', N'48', N'mthyolaphaza@ecrime.com', NULL, N'Citizen', N'Student at University', N'mthyolaphaza.jpg', N'123', N'Location 1', N'Admin Admin', CAST(0x00009E9601481B9B AS DateTime))
INSERT [dbo].[UserMaster] ([UID], [FName], [MName], [LName], [MobileNo], [ResiNo], [EmailId], [DOB], [UserType], [Details], [PhotoName], [Password], [Location], [CreatedBy], [CreatedDate]) VALUES (3, N'Anna', N'', N'Quinlan', N'+3532565887955', N'14', N'annaquinlan@ecrime.com', NULL, N'Citizen', N'Software Developer at XYZ limited', N'annaquinlan.jpg', N'123', N'Location 2', N'Admin Admin', CAST(0x00009E9601486B05 AS DateTime))
INSERT [dbo].[UserMaster] ([UID], [FName], [MName], [LName], [MobileNo], [ResiNo], [EmailId], [DOB], [UserType], [Details], [PhotoName], [Password], [Location], [CreatedBy], [CreatedDate]) VALUES (4, N'Hugh', N'', N'McGuiness', N'+3537854582156', N'24', N'hughmcguiness@ecrime.com', NULL, N'Department', N'Police Inspector', N'hughmcguiness.jpg', N'123', N'Location 1', N'Admin Admin', CAST(0x00009E96014BE323 AS DateTime))
INSERT [dbo].[UserMaster] ([UID], [FName], [MName], [LName], [MobileNo], [ResiNo], [EmailId], [DOB], [UserType], [Details], [PhotoName], [Password], [Location], [CreatedBy], [CreatedDate]) VALUES (5, N'Emma', N'', N'White', N'+3537854221589', N'62', N'emmawhite@ecrime.com', NULL, N'Department', N'Screening Officer', N'emmawhite.jpg', N'123', N'Location 2', N'Admin Admin', CAST(0x00009E96014C08BA AS DateTime))
INSERT [dbo].[UserMaster] ([UID], [FName], [MName], [LName], [MobileNo], [ResiNo], [EmailId], [DOB], [UserType], [Details], [PhotoName], [Password], [Location], [CreatedBy], [CreatedDate]) VALUES (6, N'Marco', N'', N'Tej', N'+3536584221549', N'', N'marcotej@ecrime.com', NULL, N'Citizen', N'Hardware Developer at ABC ltd', NULL, N'123', N'Location 2', N'Dept One', CAST(0x00009E9900DB17D8 AS DateTime))
/****** Object:  Table [dbo].[PhysicalApperanceMaster]    Script Date: 04/04/2020 10:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhysicalApperanceMaster](
	[PID] [int] NOT NULL,
	[CID] [int] NULL,
	[MID] [int] NULL,
	[SkinColor] [varchar](50) NULL,
	[HairColor] [varchar](50) NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[Scars] [varchar](50) NULL,
	[PhysicalDeformity] [varchar](50) NULL,
	[AdditianlDetails] [varchar](500) NULL,
	[Photo] [varchar](50) NULL,
	[EntryBy] [varchar](50) NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_PhysicalApperanceMaster] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PhysicalApperanceMaster] ([PID], [CID], [MID], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [AdditianlDetails], [Photo], [EntryBy], [EntryDate]) VALUES (1, 0, 1, N'', N'', N'', N'', N'', N'', N'', N'1Govinda001.jpg', N'Dept One', CAST(0x00009E96015A3579 AS DateTime))
INSERT [dbo].[PhysicalApperanceMaster] ([PID], [CID], [MID], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [AdditianlDetails], [Photo], [EntryBy], [EntryDate]) VALUES (2, 1, 0, N'', N'', N'', N'', N'', N'', N'', N'0Sanjay002.jpg', N'Dept One', CAST(0x00009E96015B76D3 AS DateTime))
INSERT [dbo].[PhysicalApperanceMaster] ([PID], [CID], [MID], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [AdditianlDetails], [Photo], [EntryBy], [EntryDate]) VALUES (3, 2, 0, N'', N'', N'', N'', N'', N'', N'', N'2Jodi002.JPG', N'Dept Two', CAST(0x00009E96015BD78F AS DateTime))
INSERT [dbo].[PhysicalApperanceMaster] ([PID], [CID], [MID], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [AdditianlDetails], [Photo], [EntryBy], [EntryDate]) VALUES (4, 0, 2, N'', N'', N'', N'', N'', N'', N'', N'2Shahrukh014.jpg', N'Dept Two', CAST(0x00009E96015C1E05 AS DateTime))
INSERT [dbo].[PhysicalApperanceMaster] ([PID], [CID], [MID], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [AdditianlDetails], [Photo], [EntryBy], [EntryDate]) VALUES (5, 1, 0, N'', N'', N'', N'', N'', N'', N'', N'0Sanjay002.jpg', N'Dept One', CAST(0x00009E99014691FC AS DateTime))
/****** Object:  Table [dbo].[MissingCitizenMaster]    Script Date: 04/04/2020 10:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MissingCitizenMaster](
	[MID] [int] NOT NULL,
	[FName] [varchar](50) NULL,
	[MName] [varchar](50) NULL,
	[LName] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[ResiNo] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[DOB] [datetime] NULL,
	[Photo] [varchar](50) NULL,
	[Details] [varchar](500) NULL,
	[SkinColor] [varchar](50) NULL,
	[HairColor] [varchar](50) NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[Scars] [varchar](50) NULL,
	[PhysicalDeformity] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[CreatedById] [int] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastStatus] [varchar](50) NULL,
	[LastStatusUpdBy] [varchar](50) NULL,
	[LastStatusUpdDate] [datetime] NULL,
	[PID] [int] NULL,
	[FirType] [varchar](50) NULL,
 CONSTRAINT [PK_MissingCitizenMaster] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[MissingCitizenMaster] ([MID], [FName], [MName], [LName], [MobileNo], [ResiNo], [Address], [DOB], [Photo], [Details], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [Location], [CreatedById], [CreatedBy], [CreatedDate], [LastStatus], [LastStatusUpdBy], [LastStatusUpdDate], [PID], [FirType]) VALUES (1, N'Missing', N'', N'One', N'M1', N'', N'Add1', NULL, N'1Anil001.JPG', N'', N'', N'', N'', N'', N'', N'', N'Location 1', 2, N'Citizen One', CAST(0x00009E9601501AED AS DateTime), N'Closed', N'Dept One', CAST(0x00009E96015A3579 AS DateTime), 1, NULL)
INSERT [dbo].[MissingCitizenMaster] ([MID], [FName], [MName], [LName], [MobileNo], [ResiNo], [Address], [DOB], [Photo], [Details], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [Location], [CreatedById], [CreatedBy], [CreatedDate], [LastStatus], [LastStatusUpdBy], [LastStatusUpdDate], [PID], [FirType]) VALUES (2, N'Missing', N'', N'Two', N'M2', N'', N'Add2', NULL, N'2Boby003.JPG', N'', N'fair', N'brown', N'5.7', N'65 kg', N'', N'', N'Location 2', 3, N'Citizen Second', CAST(0x00009E960152C84F AS DateTime), N'Closed', N'Dept Two', CAST(0x00009E96015C1E05 AS DateTime), 4, NULL)
INSERT [dbo].[MissingCitizenMaster] ([MID], [FName], [MName], [LName], [MobileNo], [ResiNo], [Address], [DOB], [Photo], [Details], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [Location], [CreatedById], [CreatedBy], [CreatedDate], [LastStatus], [LastStatusUpdBy], [LastStatusUpdDate], [PID], [FirType]) VALUES (3, N'vinod', N'', N'kamble', N'123', N'', N'add', NULL, N'3VinodKambli001.BMP', N'', N'black', N'black', N'', N'', N'', N'', N'Location 2', 3, N'Citizen Second', CAST(0x00009E9700D1D49C AS DateTime), N'New', NULL, NULL, 0, NULL)
INSERT [dbo].[MissingCitizenMaster] ([MID], [FName], [MName], [LName], [MobileNo], [ResiNo], [Address], [DOB], [Photo], [Details], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [Location], [CreatedById], [CreatedBy], [CreatedDate], [LastStatus], [LastStatusUpdBy], [LastStatusUpdDate], [PID], [FirType]) VALUES (4, N'test', N'', N'test', N'tets', N'', N'test', NULL, N'4classic-boy.jpg', N'', N'', N'', N'', N'', N'', N'', N'Location 1', 2, N'Citizen One', CAST(0x00009E9900E47186 AS DateTime), N'New', NULL, NULL, 0, NULL)
/****** Object:  Table [dbo].[LocationMaster]    Script Date: 04/04/2020 10:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationMaster](
	[Location] [varchar](50) NOT NULL,
	[LocationDesc] [varchar](500) NULL,
 CONSTRAINT [PK_LocationMaster] PRIMARY KEY CLUSTERED 
(
	[Location] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[LocationMaster] ([Location], [LocationDesc]) VALUES (N'Location 1', N'NA')
INSERT [dbo].[LocationMaster] ([Location], [LocationDesc]) VALUES (N'Location 2', N'NA')
/****** Object:  Table [dbo].[FoundCitizenMaster]    Script Date: 04/04/2020 10:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FoundCitizenMaster](
	[FCID] [int] NOT NULL,
	[FName] [varchar](50) NULL,
	[MName] [varchar](50) NULL,
	[LName] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[ResiNo] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[DOB] [datetime] NULL,
	[Photo] [varchar](50) NULL,
	[Details] [varchar](500) NULL,
	[SkinColor] [varchar](50) NULL,
	[HairColor] [varchar](50) NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[Scars] [varchar](50) NULL,
	[PhysicalDeformity] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[CreatedById] [int] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastStatus] [varchar](50) NULL,
	[LastStatusUpdBy] [varchar](50) NULL,
	[LastStatusUpdDate] [datetime] NULL,
	[MID] [int] NULL,
	[FirType] [varchar](50) NULL,
 CONSTRAINT [PK_FoundCitizenMaster] PRIMARY KEY CLUSTERED 
(
	[FCID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[FoundCitizenMaster] ([FCID], [FName], [MName], [LName], [MobileNo], [ResiNo], [Address], [DOB], [Photo], [Details], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [Location], [CreatedById], [CreatedBy], [CreatedDate], [LastStatus], [LastStatusUpdBy], [LastStatusUpdDate], [MID], [FirType]) VALUES (1, N'Found', N'', N'One', N'F1', N'', N'-', NULL, N'1Govinda001.jpg', N'', N'', N'', N'', N'', N'', N'', N'Location 1', 4, N'Dept One', CAST(0x00009E9601556D8B AS DateTime), N'Closed', N'Dept One', CAST(0x00009E96015A357E AS DateTime), 1, NULL)
INSERT [dbo].[FoundCitizenMaster] ([FCID], [FName], [MName], [LName], [MobileNo], [ResiNo], [Address], [DOB], [Photo], [Details], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [Location], [CreatedById], [CreatedBy], [CreatedDate], [LastStatus], [LastStatusUpdBy], [LastStatusUpdDate], [MID], [FirType]) VALUES (2, N'Found', N'', N'Two', N'f2', N'', N'f2', NULL, N'2Shahrukh014.jpg', N'', N'', N'', N'', N'', N'', N'', N'Location 2', 5, N'Dept Two', CAST(0x00009E96015C10CC AS DateTime), N'Closed', N'Dept Two', CAST(0x00009E96015C1E09 AS DateTime), 2, NULL)
/****** Object:  Table [dbo].[FirMaster]    Script Date: 04/04/2020 10:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FirMaster](
	[FirID] [int] IDENTITY(1,1) NOT NULL,
	[FirType] [varchar](50) NULL,
	[Q1] [varchar](100) NULL,
	[Q2] [varchar](100) NULL,
	[Q3] [varchar](100) NULL,
	[Q4] [varchar](100) NULL,
	[Q5] [varchar](100) NULL,
	[Q6] [varchar](100) NULL,
 CONSTRAINT [PK_FirMaster] PRIMARY KEY CLUSTERED 
(
	[FirID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FirMaster] ON
INSERT [dbo].[FirMaster] ([FirID], [FirType], [Q1], [Q2], [Q3], [Q4], [Q5], [Q6]) VALUES (1, N'Robbery Fir', N'Where did the Robbery occured?', N'When did then Robbery happen?', N'What was stolen?', N'Where were you present at the time of Robbery?', N'Were there any witness at the crime scene?', NULL)
INSERT [dbo].[FirMaster] ([FirID], [FirType], [Q1], [Q2], [Q3], [Q4], [Q5], [Q6]) VALUES (2, N'Sexual Assault Fir', N'What is the name of the victim ?', N'Who assaulted the victim ?', N'When did it happen ?', N'How many peole were involved ?', N'What are the additional details ?', NULL)
INSERT [dbo].[FirMaster] ([FirID], [FirType], [Q1], [Q2], [Q3], [Q4], [Q5], [Q6]) VALUES (3, N'Homicide Fir', N'Do you kwno the murderer ?', N'Who is he ?', N'Whom do you suspect ?', N'When did it happen ?', N'What weapens were used ?', N'Additional details ?')
INSERT [dbo].[FirMaster] ([FirID], [FirType], [Q1], [Q2], [Q3], [Q4], [Q5], [Q6]) VALUES (4, N'Kidnap Fir', N'Who got kidnapped ?', N'What is the time of kidnapping ?', N'Whom do you suspect ?', N'How much money is demanded ?', N'What is your relationship with one who got kidnapped ?', N'What are the additional details ?')
INSERT [dbo].[FirMaster] ([FirID], [FirType], [Q1], [Q2], [Q3], [Q4], [Q5], [Q6]) VALUES (5, N'Extortion Fir', N'Do you know the person demanding the money ?', N'What is his/her name ?', N'Whom do you suspect ?', N'How much money did he/she ask for ?', N'What are the additional details ?', NULL)
INSERT [dbo].[FirMaster] ([FirID], [FirType], [Q1], [Q2], [Q3], [Q4], [Q5], [Q6]) VALUES (6, N'Bribery Fir', N'What was the name of the human demanding brite?', N'How much money did he ask for ?', N'What department does he/she belong to ?', N'What is his/her designation ?', N'What are the additional details ?', NULL)
SET IDENTITY_INSERT [dbo].[FirMaster] OFF
/****** Object:  Table [dbo].[FirLogDetails]    Script Date: 04/04/2020 10:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FirLogDetails](
	[LID] [int] IDENTITY(1,1) NOT NULL,
	[FirType] [varchar](50) NULL,
	[FirID] [int] NULL,
	[Q1Ans] [varchar](50) NULL,
	[Q2Ans] [varchar](50) NULL,
	[Q3Ans] [varchar](50) NULL,
	[Q4Ans] [varchar](50) NULL,
	[Q5Ans] [varchar](50) NULL,
	[Q6Ans] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[EntryById] [int] NULL,
	[EntryBy] [varchar](50) NULL,
	[EntryDate] [datetime] NULL,
	[LastStatusUpdStatus] [varchar](50) NULL,
	[LastStatusUpdBy] [varchar](50) NULL,
	[LastStatusUpdDate] [datetime] NULL,
	[PID] [int] NULL,
 CONSTRAINT [PK_FirLogDetails] PRIMARY KEY CLUSTERED 
(
	[LID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FirLogDetails] ON
INSERT [dbo].[FirLogDetails] ([LID], [FirType], [FirID], [Q1Ans], [Q2Ans], [Q3Ans], [Q4Ans], [Q5Ans], [Q6Ans], [Location], [EntryById], [EntryBy], [EntryDate], [LastStatusUpdStatus], [LastStatusUpdBy], [LastStatusUpdDate], [PID]) VALUES (1, N'Bribery Fir', 6, N'Mr. Abc', N'5000/-', N'Legal', N'Officer', N'no', N'', N'Location 1', 2, N'Citizen One', CAST(0x00009E9601517FC3 AS DateTime), N'Closed', N'Dept One', CAST(0x00009E96015B76D8 AS DateTime), 2)
INSERT [dbo].[FirLogDetails] ([LID], [FirType], [FirID], [Q1Ans], [Q2Ans], [Q3Ans], [Q4Ans], [Q5Ans], [Q6Ans], [Location], [EntryById], [EntryBy], [EntryDate], [LastStatusUpdStatus], [LastStatusUpdBy], [LastStatusUpdDate], [PID]) VALUES (2, N'Homicide Fir', 3, N'no', N'-', N'no', N'26-02-2010 8:00 pm', N'gun', N'no', N'Location 2', 3, N'Citizen Second', CAST(0x00009E960153032D AS DateTime), N'Closed', N'Dept Two', CAST(0x00009E96015BD78F AS DateTime), 3)
INSERT [dbo].[FirLogDetails] ([LID], [FirType], [FirID], [Q1Ans], [Q2Ans], [Q3Ans], [Q4Ans], [Q5Ans], [Q6Ans], [Location], [EntryById], [EntryBy], [EntryDate], [LastStatusUpdStatus], [LastStatusUpdBy], [LastStatusUpdDate], [PID]) VALUES (3, N'Kidnap Fir', 4, N'Mr. Xyz', N'10.30 am', N'no', N'not yet', N'bro', N'no', N'Location 1', 2, N'Citizen One', CAST(0x00009E9700CD2524 AS DateTime), N'New', NULL, NULL, NULL)
INSERT [dbo].[FirLogDetails] ([LID], [FirType], [FirID], [Q1Ans], [Q2Ans], [Q3Ans], [Q4Ans], [Q5Ans], [Q6Ans], [Location], [EntryById], [EntryBy], [EntryDate], [LastStatusUpdStatus], [LastStatusUpdBy], [LastStatusUpdDate], [PID]) VALUES (4, N'Bribery Fir', 6, N'1', N'1', N'1', N'1', N'1', N'', N'Location 1', 2, N'Citizen One', CAST(0x00009E9900E4969F AS DateTime), N'Closed', N'Dept One', CAST(0x00009E990146923D AS DateTime), 5)
SET IDENTITY_INSERT [dbo].[FirLogDetails] OFF
/****** Object:  Table [dbo].[CriminalMaster]    Script Date: 04/04/2020 10:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CriminalMaster](
	[CID] [int] IDENTITY(1,1) NOT NULL,
	[FName] [varchar](50) NULL,
	[MName] [varchar](50) NULL,
	[LName] [varchar](50) NULL,
	[DOB] [datetime] NULL,
	[RelAddress] [varchar](500) NULL,
	[RelMobileNo] [varchar](50) NULL,
	[RelResiNo] [varchar](50) NULL,
	[SkinColor] [varchar](50) NULL,
	[HairColor] [varchar](50) NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[Scars] [varchar](50) NULL,
	[PhysicalDeformity] [varchar](50) NULL,
	[Photo] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_CriminalMaster] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CriminalMaster] ON
INSERT [dbo].[CriminalMaster] ([CID], [FName], [MName], [LName], [DOB], [RelAddress], [RelMobileNo], [RelResiNo], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [Photo], [CreatedBy], [CreatedDate]) VALUES (1, N'Criminal', N'', N'One', NULL, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'0Sanjay002.jpg', N'Dept One', CAST(0x00009E96015B5108 AS DateTime))
INSERT [dbo].[CriminalMaster] ([CID], [FName], [MName], [LName], [DOB], [RelAddress], [RelMobileNo], [RelResiNo], [SkinColor], [HairColor], [Height], [Weight], [Scars], [PhysicalDeformity], [Photo], [CreatedBy], [CreatedDate]) VALUES (2, N'Criminal', N'', N'Two', NULL, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'2Jodi002.JPG', N'Dept Two', CAST(0x00009E96015BBC59 AS DateTime))
SET IDENTITY_INSERT [dbo].[CriminalMaster] OFF
/****** Object:  Default [DF_MissingCitizenMaster_FirType]    Script Date: 04/04/2020 10:49:21 ******/
ALTER TABLE [dbo].[MissingCitizenMaster] ADD  CONSTRAINT [DF_MissingCitizenMaster_FirType]  DEFAULT ('Missing Citizen') FOR [FirType]
GO
/****** Object:  Default [DF_FoundCitizenMaster_FirType]    Script Date: 04/04/2020 10:49:21 ******/
ALTER TABLE [dbo].[FoundCitizenMaster] ADD  CONSTRAINT [DF_FoundCitizenMaster_FirType]  DEFAULT ('Found Citizen') FOR [FirType]
GO
