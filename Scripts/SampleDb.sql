USE [SampleDb]
GO
/****** Object:  Table [dbo].[ChildContainer]    Script Date: 7/28/2020 6:36:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildContainer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NULL,
	[ColorTypeId] [int] NULL,
 CONSTRAINT [PK_ChildContainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorType]    Script Date: 7/28/2020 6:36:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NULL,
	[Symbol] [char](1) NULL,
 CONSTRAINT [PK_ColorType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentChildLinkage]    Script Date: 7/28/2020 6:36:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentChildLinkage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentContainerId] [int] NULL,
	[ChildContainerId] [int] NULL,
 CONSTRAINT [PK_ParentChildLinkage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentContainer]    Script Date: 7/28/2020 6:36:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentContainer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NULL,
	[rowversion] [timestamp] NOT NULL,
 CONSTRAINT [PK_ParentContainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChildContainer] ON 

INSERT [dbo].[ChildContainer] ([Id], [Name], [ColorTypeId]) VALUES (1, N'Timmy', 1)
INSERT [dbo].[ChildContainer] ([Id], [Name], [ColorTypeId]) VALUES (2, N'Jack', 2)
INSERT [dbo].[ChildContainer] ([Id], [Name], [ColorTypeId]) VALUES (3, N'Alice', 3)
INSERT [dbo].[ChildContainer] ([Id], [Name], [ColorTypeId]) VALUES (4, N'Beth', NULL)
SET IDENTITY_INSERT [dbo].[ChildContainer] OFF
GO
SET IDENTITY_INSERT [dbo].[ColorType] ON 

INSERT [dbo].[ColorType] ([Id], [Name], [Symbol]) VALUES (1, N'Red', N'R')
INSERT [dbo].[ColorType] ([Id], [Name], [Symbol]) VALUES (2, N'Yellow', N'Y')
INSERT [dbo].[ColorType] ([Id], [Name], [Symbol]) VALUES (3, N'Blue', N'B')
INSERT [dbo].[ColorType] ([Id], [Name], [Symbol]) VALUES (4, N'Green', N'G')
SET IDENTITY_INSERT [dbo].[ColorType] OFF
GO
SET IDENTITY_INSERT [dbo].[ParentChildLinkage] ON 

INSERT [dbo].[ParentChildLinkage] ([Id], [ParentContainerId], [ChildContainerId]) VALUES (1, 1, 1)
INSERT [dbo].[ParentChildLinkage] ([Id], [ParentContainerId], [ChildContainerId]) VALUES (2, 1, 2)
INSERT [dbo].[ParentChildLinkage] ([Id], [ParentContainerId], [ChildContainerId]) VALUES (3, 2, 3)
INSERT [dbo].[ParentChildLinkage] ([Id], [ParentContainerId], [ChildContainerId]) VALUES (4, 2, 4)
SET IDENTITY_INSERT [dbo].[ParentChildLinkage] OFF
GO
SET IDENTITY_INSERT [dbo].[ParentContainer] ON 

INSERT [dbo].[ParentContainer] ([Id], [Name]) VALUES (1, N'John')
INSERT [dbo].[ParentContainer] ([Id], [Name]) VALUES (2, N'Mary')
SET IDENTITY_INSERT [dbo].[ParentContainer] OFF
GO
ALTER TABLE [dbo].[ChildContainer]  WITH CHECK ADD  CONSTRAINT [FK_ChildContainer_ColorType] FOREIGN KEY([ColorTypeId])
REFERENCES [dbo].[ColorType] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ChildContainer] CHECK CONSTRAINT [FK_ChildContainer_ColorType]
GO
ALTER TABLE [dbo].[ParentChildLinkage]  WITH CHECK ADD  CONSTRAINT [FK_ParentChildLinkage_ChildContainer] FOREIGN KEY([ChildContainerId])
REFERENCES [dbo].[ChildContainer] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ParentChildLinkage] CHECK CONSTRAINT [FK_ParentChildLinkage_ChildContainer]
GO
ALTER TABLE [dbo].[ParentChildLinkage]  WITH CHECK ADD  CONSTRAINT [FK_ParentChildLinkage_ParentContainer] FOREIGN KEY([ParentContainerId])
REFERENCES [dbo].[ParentContainer] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParentChildLinkage] CHECK CONSTRAINT [FK_ParentChildLinkage_ParentContainer]
GO
