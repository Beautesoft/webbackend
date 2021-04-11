SET ANSI_NULLS ON
GO

IF NOT EXISTS(Select * from Control_No where Control_description = 'APPOINTMENT CHANNEL' and control_prefix = '' 
 and Site_Code = (select top 1 product_license from title))
Begin
	insert into control_no(control_no,control_prefix,control_description,CONTROLDATE,Site_Code,Mac_Code)
values('10001','','APPOINTMENT CHANNEL','2021.03.06',(select top 1 product_license from title),null)
End

GO


IF NOT EXISTS(Select * from Control_No where Control_description = 'APPOINTMENT BOOKING STATUS' and control_prefix = '' 
 and Site_Code = (select top 1 product_license from title))
Begin
	insert into control_no(control_no,control_prefix,control_description,CONTROLDATE,Site_Code,Mac_Code)
values('10001','','APPOINTMENT BOOKING STATUS','2021.03.06',(select top 1 product_license from title),null)
End

GO

IF NOT EXISTS(Select * from Control_No where Control_description = 'APPOINTMENT SECONDARY STATUS' and control_prefix = '' 
 and Site_Code = (select top 1 product_license from title))
Begin
	insert into control_no(control_no,control_prefix,control_description,CONTROLDATE,Site_Code,Mac_Code)
values('10001','','APPOINTMENT SECONDARY STATUS','2021.03.06',(select top 1 product_license from title),null)
End

GO

IF NOT EXISTS(Select * from Control_No where Control_description = '1st Tax Code' and control_prefix = '' 
 and Site_Code = (select top 1 product_license from title))
Begin
	insert into control_no(control_no,control_prefix,control_description,CONTROLDATE,Site_Code,Mac_Code)
values('100001','TC','1st Tax Code','2021.03.09',(select top 1 product_license from title),null)
End

GO

IF NOT EXISTS(Select * from Control_No where Control_description = '2nd Tax Code' and control_prefix = '' 
 and Site_Code = (select top 1 product_license from title))
Begin
	insert into control_no(control_no,control_prefix,control_description,CONTROLDATE,Site_Code,Mac_Code)
values('100001','TC','2nd Tax Code','2021.03.09',(select top 1 product_license from title),null)
End

GO


IF NOT EXISTS (SELECT * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Stock' AND  
Column_Name = 'printUom')
BEGIN
 Alter Table Stock Add printUom varchar(1000) null;

END

GO


IF NOT EXISTS (SELECT * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Stock' AND  
Column_Name = 'MOQQty')
BEGIN
 Alter Table Stock Add MOQQty float null;

END

GO


IF NOT EXISTS (SELECT * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Stock' AND  
Column_Name = 'printDesc')
BEGIN
 Alter Table Stock Add printDesc varchar(max) null;

END

GO


IF NOT EXISTS (SELECT * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Stock' AND  
Column_Name = 'printLineNo')
BEGIN
 Alter Table Stock Add printLineNo int null;

END

GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('stockdetails'))
BEGIN
DROP View stockdetails	
END

GO

CREATE VIEW [dbo].[stockdetails]
AS
--SELECT s.item_code AS stockCode, s.Item_Name AS stockName, s.Item_Type AS Type, s.item_isactive AS isActive, iu.UOM_Code AS uom, iu.UOM_Desc AS uomDescription, s.ONHAND_QTY AS quantity, 
--                         (CASE s.Item_Div WHEN 1 THEN 'Retail Product' WHEN 2 THEN 'Salon Product' WHEN 3 THEN 'Service' WHEN 4 THEN 'Voucher' WHEN 5 THEN 'Prepaid' ELSE 'invalid Division' END) AS Division, r.itm_code AS RangeCode, 
--                         r.itm_desc AS Range, d.itm_code AS DeptCode, d.itm_desc AS Department, c.itm_code AS ClassCode, c.itm_desc AS Class, b.itm_code AS BrandCode, b.itm_desc AS Brand, l.LINK_CODE AS linkCode, s.Item_Price, 
--                         s.MOQQty
--FROM            dbo.Stock AS s LEFT OUTER JOIN
--                         dbo.Item_Link AS l ON s.item_code = l.ITEM_CODE AND l.LINK_TYPE = 'L' AND l.Itm_IsActive = 1 RIGHT OUTER JOIN
--                         dbo.Item_Range AS r ON s.Item_Range = r.itm_code RIGHT OUTER JOIN
--                         dbo.Item_Dept AS d ON s.Item_Dept = d.itm_code RIGHT OUTER JOIN
--                         dbo.item_Class AS c ON s.Item_Class = c.itm_code RIGHT OUTER JOIN
--                         dbo.Item_Brand AS b ON s.item_Brand = b.itm_code LEFT OUTER JOIN
--                         dbo.Item_UOM AS iu ON s.Item_UOM = iu.UOM_Code
--WHERE        (r.itm_status = 1) AND (d.itm_status = 1) AND (b.itm_status = 1) AND (c.itm_isactive = 1)


SELECT s.item_code AS stockCode, s.Item_Name AS stockName, s.Item_Type AS Type, s.item_isactive AS isActive, '' AS uom, '' AS uomDescription, s.ONHAND_QTY AS quantity, 
   (CASE s.Item_Div WHEN 1 THEN 'Retail Product' WHEN 2 THEN 'Salon Product' WHEN 3 THEN 'Service' WHEN 4 THEN 'Voucher' WHEN 5 THEN 'Prepaid' ELSE 'invalid Division' END) AS Division, r.itm_code AS RangeCode, 
   r.itm_desc AS Range, d.itm_code AS DeptCode, d.itm_desc AS Department, c.itm_code AS ClassCode, c.itm_desc AS Class, b.itm_code AS BrandCode, b.itm_desc AS Brand, l.LINK_CODE AS linkCode, s.Item_Price, 
	s.MOQQty FROM dbo.Item_Dept AS d,dbo.item_Class AS c,dbo.Item_Brand AS b,dbo.Item_Range AS r, dbo.Stock AS s
	LEFT OUTER JOIN dbo.Item_UOM AS iu ON s.Item_UOM = iu.UOM_Code
	LEFT OUTER JOIN  dbo.Item_Link AS l ON s.item_code = l.ITEM_CODE AND l.LINK_TYPE = 'L' AND l.Itm_IsActive = 1
	where (r.itm_status = 1) AND (d.itm_status = 1) AND (b.itm_status = 1) AND (c.itm_isactive = 1)  
	and s.Item_Dept = d.itm_code and s.Item_Class = c.itm_code and s.item_Brand = b.itm_code and s.Item_Range = r.itm_code

	--iu.UOM_Code AS uom, iu.UOM_Desc AS uomDescription,
--LEFT OUTER JOIN dbo.Item_UOM AS iu ON s.Item_UOM = iu.UOM_Code

GO


IF NOT EXISTS (SELECT * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Package_Dtl' AND  
Column_Name = 'Item_Div')
BEGIN
 Alter Table Package_Dtl Add Item_Div varchar(40) null;

END

GO

IF EXISTS(SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('packageitemdetails'))
BEGIN
DROP View packageitemdetails	
END

GO

CREATE VIEW [dbo].[packageitemdetails]
AS

SELECT s.item_code AS stockCode, s.Item_Name AS stockName, s.Item_Type AS Type, s.item_isactive AS isActive, '' AS uom, '' AS uomDescription, s.ONHAND_QTY AS quantity, 
   (CASE s.Item_Div WHEN 1 THEN 'Retail Product' WHEN 2 THEN 'Salon Product' WHEN 3 THEN 'Service' WHEN 4 THEN 'Voucher' WHEN 5 THEN 'Prepaid' ELSE 'invalid Division' END) AS Division, r.itm_code AS RangeCode, 
   r.itm_desc AS Range, d.itm_code AS DeptCode, d.itm_desc AS Department, c.itm_code AS ClassCode, c.itm_desc AS Class, b.itm_code AS BrandCode, b.itm_desc AS Brand, l.LINK_CODE AS linkCode, 
	s.MOQQty,case when p.Item_UOM is null then '' else p.Item_UOM end as Item_UOM,case when p.UOM_Unit is null then '' else p.UOM_Unit end as UOM_Unit,
	case when p.Item_Price is null then s.Item_Price else p.Item_Price end as Item_Price FROM  dbo.Item_Dept AS d,dbo.item_Class AS c,dbo.Item_Brand AS b,dbo.Item_Range AS r, dbo.Stock AS s
	LEFT OUTER JOIN dbo.Item_UOM AS iu ON s.Item_UOM = iu.UOM_Code
	LEFT OUTER JOIN  dbo.Item_Link AS l ON s.item_code = l.ITEM_CODE AND l.LINK_TYPE = 'L' AND l.Itm_IsActive = 1 
	LEFT OUTER JOIN dbo.item_uomprice p on p.item_code=s.item_code
	where s.Item_Type<>'PACKAGE' and s.item_isActive=1 and (r.itm_status = 1) AND (d.itm_status = 1) AND (b.itm_status = 1) AND (c.itm_isactive = 1)  
	and s.Item_Dept = d.itm_code and s.Item_Class = c.itm_code and s.item_Brand = b.itm_code and s.Item_Range = r.itm_code


GO


IF EXISTS(SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('GetDivRunningNo'))
BEGIN
DROP PROCEDURE GetDivRunningNo	
END

GO

Create PROCEDURE [dbo].[GetDivRunningNo]
@Div NVARCHAR(80)
AS 
BEGIN
	
	declare @itemCode nvarchar(max)
	set @itemCode=(select top 1 itm_code from item_dept where itm_desc=(select top 1 itm_desc from Item_Div  where itm_code=@Div))

	declare @itemDesc nvarchar(max)
	set @itemDesc=(select top 1 itm_desc from item_dept where itm_desc=(select top 1 itm_desc from Item_Div  where itm_code=@Div))
	
	declare @RunningNo nvarchar(max)
	set @RunningNo=(select RIGHT(max(item_code),5) from stock where Item_Div=@Div and item_dept=@itemCode)

	select @RunningNo as RunningNo,@itemCode as itm_code,@itemDesc as itm_desc 

END

GO

IF EXISTS(SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('GetDeptRunningNo'))
BEGIN
DROP PROCEDURE GetDeptRunningNo	
END

GO

CREATE PROCEDURE [dbo].[GetDeptRunningNo]
@Div NVARCHAR(80),
@Dept NVARCHAR(80)
AS 
BEGIN
	
	declare @itemCode nvarchar(max)
	set @itemCode=(select top 1 itm_code from item_dept where itm_desc=(select top 1 itm_desc from Item_Div  where itm_code=@Div))

	declare @itemDesc nvarchar(max)
	set @itemDesc=(select top 1 itm_desc from item_dept where itm_desc=(select top 1 itm_desc from Item_Div  where itm_code=@Div))
	
	declare @RunningNo nvarchar(max)
	set @RunningNo=(select RIGHT(max(item_code),6)+1 from stock where Item_Div=@Div and item_dept=@Dept)

	if(@RunningNo is null)
		set @RunningNo = '00001';
	else
		set @RunningNo = REPLICATE('0',6-LEN(@RunningNo)) + @RunningNo

	select RIGHT(@RunningNo,5) as RunningNo,@itemCode as itm_code,@itemDesc as itm_desc 

END

GO

IF EXISTS(SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('rangelist'))
BEGIN
DROP View rangelist	
END

GO

CREATE VIEW [dbo].[rangelist]
AS
SELECT        ir.itm_id, ir.itm_code, ir.itm_desc, ir.itm_status, ir.itm_SEQ, ir.itm_brand, ir.itm_Dept, ir.isProduct, ir.PIC_Path, ir.Prepaid_For_Product, ir.Prepaid_For_Service, ir.Prepaid_For_All, ir.IsService, ir.IsVoucher, ir.IsPrepaid, 
                         ir.IsCompound, id.itm_desc AS department, ib.itm_desc AS brand
FROM            dbo.Item_Range AS ir LEFT OUTER JOIN
                         dbo.Item_Dept AS id ON id.itm_code = ir.itm_Dept LEFT OUTER JOIN
                         dbo.Item_Brand AS ib ON ib.itm_code = ir.itm_brand


GO

IF NOT EXISTS (SELECT * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'PAY_GROUP' AND  
Column_Name = 'PictureLocation')
BEGIN
Alter table PAY_GROUP add PictureLocation nVarchar(200) Null  ;
END

GO

IF NOT EXISTS (SELECT * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'BusinessHrs')
BEGIN
CREATE TABLE [dbo].[BusinessHrs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[businessDay] [varchar](50) NOT NULL,
	[Status] [varchar](15) NOT NULL,
	[startTime] [datetime] NULL,
	[endTime] [datetime] NULL,
	[siteCode] [varchar](50) NULL
) ON [PRIMARY]
END

GO

--ALTER TABLE dbo.Location drop column itm_Id
--ALTER TABLE dbo.Location
--   ADD itm_Id INT IDENTITY
--       CONSTRAINT PK_Location PRIMARY KEY CLUSTERED


IF NOT EXISTS(Select * from Control_No where Control_description = 'Supplier Code' and control_prefix = 'V' 
 and Site_Code = (select top 1 product_license from title))
Begin
	insert into control_no(control_no,control_prefix,control_description,CONTROLDATE,Site_Code,Mac_Code)
values('101','V','Supplier Code','2021.01.19',(select top 1 product_license from title),null)
End

GO

--ALTER TABLE Item_Supply ALTER COLUMN SPLYACTIVE bit;

--GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('Uq_Item_Dept_ItemDesc'))
BEGIN
ALTER TABLE Item_Dept ADD CONSTRAINT Uq_Item_Dept_ItemDesc UNIQUE (itm_desc);
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('CK_Item_Dept_ItemDesc'))
BEGIN
ALTER TABLE Item_Dept ADD CONSTRAINT CK_Item_Dept_ItemDesc CHECK  ((itm_desc<>N''));
END

GO


IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('Uq_Item_Brand_ItemDesc'))
BEGIN
ALTER TABLE Item_Brand ADD CONSTRAINT Uq_Item_Brand_ItemDesc UNIQUE (itm_desc);
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('CK_Item_Brand_ItemDesc'))
BEGIN
ALTER TABLE Item_Brand ADD CONSTRAINT CK_Item_Brand_ItemDesc CHECK  ((itm_desc<>N''));
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('Uq_Item_Class_ItemDesc'))
BEGIN
ALTER TABLE Item_Class ADD CONSTRAINT Uq_Item_Class_ItemDesc UNIQUE (itm_desc);
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('CK_Item_Class_ItemDesc'))
BEGIN
ALTER TABLE Item_Class ADD CONSTRAINT CK_Item_Class_ItemDesc CHECK  ((itm_desc<>N''));
END

GO


IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('CK_Item_UOM_UOMCode'))
BEGIN
ALTER TABLE Item_UOM ADD CONSTRAINT CK_Item_UOM_UOMCode CHECK  ((UOM_Code<>N''));
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('CK_Item_UOM_UOMDesc'))
BEGIN
ALTER TABLE Item_UOM ADD CONSTRAINT CK_Item_UOM_UOMDesc CHECK  ((UOM_Desc<>N''));
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('Uq_Item_UOM_UOMCode'))
BEGIN
ALTER TABLE Item_UOM ADD CONSTRAINT Uq_Item_UOM_UOMCode UNIQUE (UOM_Code);
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('Uq_Item_UOM_UOMDesc'))
BEGIN
ALTER TABLE Item_UOM ADD CONSTRAINT Uq_Item_UOM_UOMDesc UNIQUE (UOM_Desc);
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('Uq_PAYTABLE_Pay_Code'))
BEGIN
ALTER TABLE PAYTABLE ADD CONSTRAINT Uq_PAYTABLE_Pay_Code UNIQUE (Pay_Code);
END

GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID('Uq_PAYTABLE_pay_description'))
BEGIN
ALTER TABLE PAYTABLE ADD CONSTRAINT Uq_PAYTABLE_pay_description UNIQUE (pay_description);
END

GO

--update Item_Division
update stock set Item_Divid_id=itm_id from Item_Div d where Item_Div=d.itm_Code and Item_Divid_id is null  

GO

--update Item_Department
update stock set Item_Deptid_id=itm_id from Item_Dept d where Item_Dept=d.itm_Code and Item_Deptid_id is null 

GO

--update Item_Class
update stock set Item_Classid_id=itm_id from Item_Class c where Item_Class=c.itm_Code and Item_Classid_id is null 

GO


--update Item_Range
update stock set ITem_Rangeid_id=itm_id from Item_Range r where Item_Range=r.itm_Code and ITem_Rangeid_id is null 

GO

--update Item_Type
update stock set ITem_Typeid_id=itm_id from Item_Type t where Item_Type=t.itm_name and ITem_Typeid_id is null 

GO

update stock set Is_GST=0 where IS_GST is null
GO
update stock set Value_ApplyToChild=0 where Value_ApplyToChild is null
GO
update stock set mixbrand=0 where mixbrand is null
GO
update item_Brand set Voucher_For_Sales=0 where Voucher_For_Sales is null
GO
update Item_Range set Prepaid_For_Product=0 where Prepaid_For_Product is null
GO
update Item_Range set Prepaid_For_Service=0 where Prepaid_For_Service is null
GO
update Item_Range set Prepaid_For_All=0 where Prepaid_For_All is null
GO

