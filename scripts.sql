--1. Create a database: MTTDB


--2. Create Tables
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO


CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Sku] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CategoryId] [int] NULL,
	[IsFeatured] [bit] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category_CategoryId]
GO

--3. Insert dummy data
insert into Category
Select  'Home'
union
Select 'Garden'
union
Select 'Electronics'
union
Select 'Fitness'
union
Select 'Toys'

 

insert into Products
Select 'Red Royal Carpet','1000001','Red twist',59.99,(Select Id from Category WHERE Name='Home'),1
union
Select 'Blue Royal Carpet','1000002','Blue twist',49.99,(Select Id from Category WHERE Name='Home'),1
union
Select 'Red Plant Pot','2000001','Red clay', 4.00, (Select Id from Category WHERE Name='Garden'),1
union
Select 'Green Plant Pot','2000002','Grrn clay', 4.00, (Select Id from Category WHERE Name='Garden'),1
union
Select 'Yellow Plant Pot','2000003','Red clay', 4.00, (Select Id from Category WHERE Name='Garden'),1
union
Select 'Iphone 8','3000001','Apple Iphone 8', 450, (Select Id from Category WHERE Name='Electronics'),1
union
Select 'Iphone 9','3000002','Apple Iphone 9', 850, (Select Id from Category WHERE Name='Electronics'),1
union
Select 'Samsung Z fold 3','3000002','Samsung z fold 3 black with pen', 450, (Select Id from Category WHERE Name='Electronics'),0
union
Select 'Treadmill','4000001','running stuff', 850, (Select Id from Category WHERE Name='Fitness'),0
union
Select 'Buzz lightyear','5000001','Toy story Buzz', 10.00, (Select Id from Category WHERE Name='Toys'),0
union
Select 'Woody','5000002','Toy story Woody', 10.00, (Select Id from Category WHERE Name='Toys'),0
union
Select 'Play dough','5000003','Play dough green', 2.00, (Select Id from Category WHERE Name='Toys'),0

 
 