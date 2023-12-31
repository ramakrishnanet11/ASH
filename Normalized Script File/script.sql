USE [ASH]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 11/18/2023 9:55:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](30) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[address1] [varchar](100) NOT NULL,
	[payPerHour] [decimal](10, 2) NULL,
	[annualSalary] [decimal](10, 0) NULL,
	[maxExpenseAmount] [decimal](10, 2) NULL,
	[employeeTypeId] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[createdBy] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [datetime] NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employeeTypes]    Script Date: 11/18/2023 9:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeeTypes](
	[id] [int] NOT NULL,
	[title] [varchar](100) NOT NULL,
	[description] [varchar](500) NULL,
	[isActive] [bit] NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[createdBy] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [datetime] NULL,
 CONSTRAINT [PK_employeeType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 11/18/2023 9:55:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] NOT NULL,
	[userName] [varchar](100) NOT NULL,
	[isActive] [bit] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[employees] ON 

INSERT [dbo].[employees] ([id], [firstName], [lastName], [address1], [payPerHour], [annualSalary], [maxExpenseAmount], [employeeTypeId], [isActive], [isDeleted], [createdBy], [createdOn], [modifiedBy], [modifiedOn]) VALUES (1, N'Rama', N'Krishna', N'Texas', CAST(0.00 AS Decimal(10, 2)), CAST(0 AS Decimal(10, 0)), CAST(0.00 AS Decimal(10, 2)), 1, 1, 0, 1, CAST(N'2023-11-18T21:40:36.927' AS DateTime), NULL, NULL)
INSERT [dbo].[employees] ([id], [firstName], [lastName], [address1], [payPerHour], [annualSalary], [maxExpenseAmount], [employeeTypeId], [isActive], [isDeleted], [createdBy], [createdOn], [modifiedBy], [modifiedOn]) VALUES (2, N'Krisha', N'Ram', N'Texas', CAST(0.00 AS Decimal(10, 2)), CAST(0 AS Decimal(10, 0)), CAST(0.00 AS Decimal(10, 2)), 2, 1, 0, 1, CAST(N'2023-11-18T21:51:42.557' AS DateTime), NULL, NULL)
INSERT [dbo].[employees] ([id], [firstName], [lastName], [address1], [payPerHour], [annualSalary], [maxExpenseAmount], [employeeTypeId], [isActive], [isDeleted], [createdBy], [createdOn], [modifiedBy], [modifiedOn]) VALUES (3, N'Ramki', N'Golla', N'Texas', CAST(0.00 AS Decimal(10, 2)), CAST(0 AS Decimal(10, 0)), CAST(0.00 AS Decimal(10, 2)), 3, 1, 0, 1, CAST(N'2023-11-18T21:51:59.323' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[employees] OFF
GO
INSERT [dbo].[employeeTypes] ([id], [title], [description], [isActive], [isDeleted], [createdBy], [createdOn], [modifiedBy], [modifiedOn]) VALUES (1, N'Employee', N'Normal employee', 1, 0, 1, CAST(N'2023-11-18T18:15:00.000' AS DateTime), 1, CAST(N'2023-11-18T18:15:00.000' AS DateTime))
INSERT [dbo].[employeeTypes] ([id], [title], [description], [isActive], [isDeleted], [createdBy], [createdOn], [modifiedBy], [modifiedOn]) VALUES (2, N'Supervisor', N'Supervisor Type', 1, 0, 1, CAST(N'2023-11-18T18:16:00.000' AS DateTime), 1, CAST(N'2023-11-18T18:16:00.000' AS DateTime))
INSERT [dbo].[employeeTypes] ([id], [title], [description], [isActive], [isDeleted], [createdBy], [createdOn], [modifiedBy], [modifiedOn]) VALUES (3, N'Manager', N'Manager Type', 1, 0, 1, CAST(N'2023-11-18T18:16:45.000' AS DateTime), 1, CAST(N'2023-11-18T18:16:45.000' AS DateTime))
GO
INSERT [dbo].[users] ([id], [userName], [isActive], [isDeleted]) VALUES (1, N'System', 1, 0)
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF_employees_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF_employees_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[employeeTypes] ADD  CONSTRAINT [DF_employeeType_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[employeeTypes] ADD  CONSTRAINT [DF_employeeType_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_employeeTypes] FOREIGN KEY([employeeTypeId])
REFERENCES [dbo].[employeeTypes] ([id])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_employeeTypes]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_users] FOREIGN KEY([createdBy])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_users]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_users1] FOREIGN KEY([modifiedBy])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_users1]
GO
ALTER TABLE [dbo].[employeeTypes]  WITH CHECK ADD  CONSTRAINT [FK_employeeTypes_users] FOREIGN KEY([modifiedBy])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[employeeTypes] CHECK CONSTRAINT [FK_employeeTypes_users]
GO
