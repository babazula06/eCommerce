USE [Depos]
GO
/****** Object:  Table [dbo].[Campaings]    Script Date: 3.04.2022 22:36:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campaings](
	[CampaignId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ProductCode] [nvarchar](50) NULL,
	[Duration] [int] NULL,
	[PriceManipulationLimit] [decimal](18, 2) NULL,
	[TargetSalesCount] [int] NULL,
	[RecordStatus] [tinyint] NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUserID] [int] NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateUserID] [int] NULL,
 CONSTRAINT [PK_Campaings] PRIMARY KEY CLUSTERED 
(
	[CampaignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hours]    Script Date: 3.04.2022 22:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrentHour] [int] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Hours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 3.04.2022 22:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Detail] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
	[Audit] [nvarchar](50) NULL
) ON [LOG_PartitionScheme_Small]([Date])
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3.04.2022 22:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [bigint] IDENTITY(1,1) NOT NULL,
	[CampaignId] [bigint] NULL,
	[ProductCode] [nvarchar](50) NULL,
	[OrderQuantity] [int] NULL,
	[OrderPrice] [decimal](18, 2) NULL,
	[RecordStatus] [tinyint] NOT NULL,
	[CreateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3.04.2022 22:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](50) NULL,
	[PriceActual] [decimal](18, 2) NULL,
	[PriceOrginial] [decimal](18, 2) NULL,
	[Stock] [int] NULL,
	[RecordStatus] [tinyint] NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUserID] [int] NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateUserID] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Campaings] ON 
GO
INSERT [dbo].[Campaings] ([CampaignId], [Name], [ProductCode], [Duration], [PriceManipulationLimit], [TargetSalesCount], [RecordStatus], [CreateTime], [CreateUserID], [UpdateTime], [UpdateUserID]) VALUES (1, N'C1', N'P1', 10, CAST(20.00 AS Decimal(18, 2)), 2, 9, CAST(N'2022-04-03T16:09:20.363' AS DateTime), 0, CAST(N'2022-04-03T16:09:20.367' AS DateTime), 0)
GO
INSERT [dbo].[Campaings] ([CampaignId], [Name], [ProductCode], [Duration], [PriceManipulationLimit], [TargetSalesCount], [RecordStatus], [CreateTime], [CreateUserID], [UpdateTime], [UpdateUserID]) VALUES (2, N'C2', N'P2', 3, CAST(10.00 AS Decimal(18, 2)), 3, 9, CAST(N'2022-04-03T16:24:56.047' AS DateTime), 0, CAST(N'2022-04-03T16:24:56.047' AS DateTime), 0)
GO
INSERT [dbo].[Campaings] ([CampaignId], [Name], [ProductCode], [Duration], [PriceManipulationLimit], [TargetSalesCount], [RecordStatus], [CreateTime], [CreateUserID], [UpdateTime], [UpdateUserID]) VALUES (3, N'c3', N'p4', 3, CAST(12.00 AS Decimal(18, 2)), 5, 9, CAST(N'2022-04-03T22:02:14.790' AS DateTime), 0, CAST(N'2022-04-03T22:02:14.790' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Campaings] OFF
GO
SET IDENTITY_INSERT [dbo].[Hours] ON 
GO
INSERT [dbo].[Hours] ([Id], [CurrentHour], [UpdateTime]) VALUES (1, 7, CAST(N'2022-04-03T22:33:08.570' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Hours] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderId], [CampaignId], [ProductCode], [OrderQuantity], [OrderPrice], [RecordStatus], [CreateTime]) VALUES (8, 1, N'P1', 10, CAST(32.77 AS Decimal(18, 2)), 1, CAST(N'2022-04-03T19:17:12.973' AS DateTime))
GO
INSERT [dbo].[Orders] ([OrderId], [CampaignId], [ProductCode], [OrderQuantity], [OrderPrice], [RecordStatus], [CreateTime]) VALUES (9, 1, N'P1', 10, CAST(40.96 AS Decimal(18, 2)), 1, CAST(N'2022-04-03T19:18:07.733' AS DateTime))
GO
INSERT [dbo].[Orders] ([OrderId], [CampaignId], [ProductCode], [OrderQuantity], [OrderPrice], [RecordStatus], [CreateTime]) VALUES (10, 0, N'P1', 10, CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2022-04-03T19:18:44.150' AS DateTime))
GO
INSERT [dbo].[Orders] ([OrderId], [CampaignId], [ProductCode], [OrderQuantity], [OrderPrice], [RecordStatus], [CreateTime]) VALUES (11, 3, N'P4', 5, CAST(1.00 AS Decimal(18, 2)), 1, CAST(N'2022-04-03T22:10:25.077' AS DateTime))
GO
INSERT [dbo].[Orders] ([OrderId], [CampaignId], [ProductCode], [OrderQuantity], [OrderPrice], [RecordStatus], [CreateTime]) VALUES (12, 0, N'p4', 9, CAST(1.00 AS Decimal(18, 2)), 1, CAST(N'2022-04-03T22:32:29.703' AS DateTime))
GO
INSERT [dbo].[Orders] ([OrderId], [CampaignId], [ProductCode], [OrderQuantity], [OrderPrice], [RecordStatus], [CreateTime]) VALUES (13, 0, N'p4', 8, CAST(1.00 AS Decimal(18, 2)), 1, CAST(N'2022-04-03T22:32:50.257' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [ProductCode], [PriceActual], [PriceOrginial], [Stock], [RecordStatus], [CreateTime], [CreateUserID], [UpdateTime], [UpdateUserID]) VALUES (1, N'P1', CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1000, 1, CAST(N'2022-04-03T15:29:49.597' AS DateTime), 0, CAST(N'2022-04-03T15:29:49.600' AS DateTime), 0)
GO
INSERT [dbo].[Products] ([ProductId], [ProductCode], [PriceActual], [PriceOrginial], [Stock], [RecordStatus], [CreateTime], [CreateUserID], [UpdateTime], [UpdateUserID]) VALUES (2, N'P2', CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 1000, 1, CAST(N'2022-04-03T16:24:25.937' AS DateTime), 0, CAST(N'2022-04-03T16:24:25.940' AS DateTime), 0)
GO
INSERT [dbo].[Products] ([ProductId], [ProductCode], [PriceActual], [PriceOrginial], [Stock], [RecordStatus], [CreateTime], [CreateUserID], [UpdateTime], [UpdateUserID]) VALUES (3, N'P3', CAST(500.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), 12, 1, CAST(N'2022-04-03T19:02:54.657' AS DateTime), 0, CAST(N'2022-04-03T19:02:54.657' AS DateTime), 0)
GO
INSERT [dbo].[Products] ([ProductId], [ProductCode], [PriceActual], [PriceOrginial], [Stock], [RecordStatus], [CreateTime], [CreateUserID], [UpdateTime], [UpdateUserID]) VALUES (4, N'P4', CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 2, 1, CAST(N'2022-04-03T21:37:46.413' AS DateTime), 0, CAST(N'2022-04-03T21:37:46.413' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
/****** Object:  Index [PK_Logs]    Script Date: 3.04.2022 22:36:42 ******/
ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [PK_Logs] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Campaings] ADD  CONSTRAINT [DF_Campaings_RecordStatus]  DEFAULT ((1)) FOR [RecordStatus]
GO
ALTER TABLE [dbo].[Campaings] ADD  CONSTRAINT [DF_Campaings_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Campaings] ADD  CONSTRAINT [DF_Campaings_CreateUserID]  DEFAULT ((0)) FOR [CreateUserID]
GO
ALTER TABLE [dbo].[Campaings] ADD  CONSTRAINT [DF_Campaings_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[Campaings] ADD  CONSTRAINT [DF_Campaings_UpdateUserID]  DEFAULT ((0)) FOR [UpdateUserID]
GO
ALTER TABLE [dbo].[Hours] ADD  CONSTRAINT [DF_Hours_CurrentHour]  DEFAULT ((0)) FOR [CurrentHour]
GO
ALTER TABLE [dbo].[Hours] ADD  CONSTRAINT [DF_Hours_CreateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Table_1_CreateUserID]  DEFAULT ((0)) FOR [OrderPrice]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_RecordStatus]  DEFAULT ((1)) FOR [RecordStatus]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_RecordStatus]  DEFAULT ((1)) FOR [RecordStatus]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreateUserID]  DEFAULT ((0)) FOR [CreateUserID]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UpdateUserID]  DEFAULT ((0)) FOR [UpdateUserID]
GO
