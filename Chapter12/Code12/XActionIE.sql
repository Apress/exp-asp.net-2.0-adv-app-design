CREATE DATABASE [XActionIE]  ON 
(NAME = N'XActionIE_Data', 
FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\XActionIE_Data.MDF' , 
SIZE = 1, FILEGROWTH = 10%) 
LOG ON (NAME = N'XActionIE_Log', 
FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\XActionIE_Log.LDF' , 
SIZE = 1, FILEGROWTH = 10%)
GO

use [XActionIE]
GO

CREATE TABLE [dbo].[Customer] (
	[CustomerID] [int] NOT NULL ,
	[CustomerName] [varchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Inventory] (
	[InventoryID] [int] NOT NULL ,
	[ItemDescr] [varchar] (50) NULL ,
	[OnHand] [int] NULL ,
	[OnOrder] [int] NULL ,
	[OrderPoint] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[InventoryAudit] (
	[AuditID] [int] IDENTITY (1, 1) NOT NULL ,
	[InventoryID] [int] NULL ,
	[Quantity] [int] NULL ,
	[AttemptDate] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Order] (
	[OrderID] [int] NOT NULL ,
	[CustomerID] [int] NULL ,
	[OrderDate] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OrderItem] (
	[OrderItemID] [int] IDENTITY (1, 1) NOT NULL ,
	[OrderID] [int] NULL ,
	[InventoryID] [int] NULL ,
	[Quantity] [int] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customer] WITH NOCHECK ADD 
	CONSTRAINT [PK_Customer] PRIMARY KEY  CLUSTERED 
	(
		[CustomerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Inventory] WITH NOCHECK ADD 
	CONSTRAINT [PK_Inventory] PRIMARY KEY  CLUSTERED 
	(
		[InventoryID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[InventoryAudit] WITH NOCHECK ADD 
	CONSTRAINT [PK_InventoryAudit] PRIMARY KEY  CLUSTERED 
	(
		[AuditID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Order] WITH NOCHECK ADD 
	CONSTRAINT [PK_Order] PRIMARY KEY  CLUSTERED 
	(
		[OrderID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[OrderItem] WITH NOCHECK ADD 
	CONSTRAINT [PK_OrderItem] PRIMARY KEY  CLUSTERED 
	(
		[OrderItemID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[InventoryAudit] ADD 
	CONSTRAINT [FK_InventoryAudit_Inventory] FOREIGN KEY 
	(
		[InventoryID]
	) REFERENCES [dbo].[Inventory] (
		[InventoryID]
	)
GO

ALTER TABLE [dbo].[Order] ADD 
	CONSTRAINT [FK_Order_Customer] FOREIGN KEY 
	(
		[CustomerID]
	) REFERENCES [dbo].[Customer] (
		[CustomerID]
	)
GO

ALTER TABLE [dbo].[OrderItem] ADD 
	CONSTRAINT [FK_OrderItem_Inventory] FOREIGN KEY 
	(
		[InventoryID]
	) REFERENCES [dbo].[Inventory] (
		[InventoryID]
	),
	CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY 
	(
		[OrderID]
	) REFERENCES [dbo].[Order] (
		[OrderID]
	)
GO

CREATE TABLE [dbo].[Tuples] (
	[keyValue] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[dataValue] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tuples] WITH NOCHECK ADD 
	CONSTRAINT [PK_Tuples] PRIMARY KEY  CLUSTERED 
	(
		[keyValue]
	)  ON [PRIMARY] 
GO


insert into customer (CustomerID, CustomerName)
VALUES (1 ,'Bob Smith')

insert into customer (CustomerID, CustomerName)
VALUES (2 ,'Roger Brown')

insert into customer (CustomerID, CustomerName)
VALUES (3 ,'Matilda McIntire')

insert into customer (CustomerID, CustomerName)
VALUES (4 ,'Susan Johnson')
           
insert into inventory
(InventoryID, ItemDescr, OnHand, OnOrder, OrderPoint)
VALUES
(1 , 'Hammer', 60, 10, 5)

insert into inventory
(InventoryID, ItemDescr, OnHand, OnOrder, OrderPoint)
VALUES
(2 , 'Screwdriver', 60, 0, 5)
insert into inventor
(InventoryID, ItemDescr, OnHand, OnOrder, OrderPoint)
VALUES
(3 , 'Drill Bits', 60, 0, 15)
Go