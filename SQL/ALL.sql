






CREATE DATABASE CRUD_SP_DB;
GO 



use CRUD_SP_DB; 


create table ProductInfo_Tab 
(
ProductID int primary key,
ItemName nvarchar(50),
Color nvarchar(50),
Status nvarchar(50),
ExpiryData datetime
);







CREATE PROC SP_Product_Insert
@ProductID int,
@ItemName nvarchar(50),
@Color nvarchar(50),
@Status nvarchar(50),
@ExpiryDate datetime 
as 
begin
insert into ProductInfo_Tab (ProductID,ItemName,Color,Status,ExpiryData) values
(@ProductID,@ItemName,@Color,@Status,@ExpiryDate)
end
;










CREATE PROC SP_Product_View
as 
begin
SELECT * FROM ProductInfo_Tab
end
;




CREATE or alter PROC SP_Product_Update
@ProductID int,
@ItemName nvarchar(50),
@Color nvarchar(50),
@Status nvarchar(50),
@ExpiryDate datetime 
as 
begin
update  ProductInfo_Tab set 
ItemName=@ItemName,Color=@Color,Status=@Status,ExpiryData=@ExpiryDate where ProductID=@ProductID
end
;



















CREATE or alter PROC SP_Product_Delete
@ProductID int
as 
begin
delete ProductInfo_Tab where ProductID=@ProductID
end
;






CREATE or alter PROC SP_Product_Search
@ProductID int
as 
begin
SELECT * FROM ProductInfo_Tab where ProductID=@ProductID
end
;






-- ADD INDEX TO PEFORMANCE
USE [CRUD_SP_DB]

GO

CREATE NONCLUSTERED INDEX [NonClusteredIndex-20231102-232248] ON [dbo].[ProductInfo_Tab]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)

GO



