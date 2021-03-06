
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_ShippingMethod_MethodCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_ShippingMethod_MethodCode]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Currency_CurrencyCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Currency_CurrencyCode]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderItems_Orders_OrderNumber]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItems]'))
ALTER TABLE [dbo].[OrderItems] DROP CONSTRAINT [FK_OrderItems_Orders_OrderNumber]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAddress_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerAddress]'))
ALTER TABLE [dbo].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Customers_CustomerId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Currency_Currency1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Currency]'))
ALTER TABLE [dbo].[Currency] DROP CONSTRAINT [FK_Currency_Currency1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Currency_Currency]') AND parent_object_id = OBJECT_ID(N'[dbo].[Currency]'))
ALTER TABLE [dbo].[Currency] DROP CONSTRAINT [FK_Currency_Currency]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingInfo_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingInfo]'))
ALTER TABLE [dbo].[BillingInfo] DROP CONSTRAINT [FK_BillingInfo_Customers_CustomerId]
GO
/****** Object:  Index [IDX_OrderItems_OrderNumber]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems]') AND name = N'IDX_OrderItems_OrderNumber')
DROP INDEX [IDX_OrderItems_OrderNumber] ON [dbo].[OrderItems]
GO
/****** Object:  Index [IDX_CustomerAddress_CustomerId]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress]') AND name = N'IDX_CustomerAddress_CustomerId')
DROP INDEX [IDX_CustomerAddress_CustomerId] ON [dbo].[CustomerAddress]
GO
/****** Object:  Index [IDX_BillingInfo_CustomerId]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BillingInfo]') AND name = N'IDX_BillingInfo_CustomerId')
DROP INDEX [IDX_BillingInfo_CustomerId] ON [dbo].[BillingInfo]
GO
/****** Object:  Table [dbo].[ShippingMethod]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShippingMethod]') AND type in (N'U'))
DROP TABLE [dbo].[ShippingMethod]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems]') AND type in (N'U'))
DROP TABLE [dbo].[OrderItems]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[CustomerAddress]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress]') AND type in (N'U'))
DROP TABLE [dbo].[CustomerAddress]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currency]') AND type in (N'U'))
DROP TABLE [dbo].[Currency]
GO
/****** Object:  Table [dbo].[BillingInfo]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingInfo]') AND type in (N'U'))
DROP TABLE [dbo].[BillingInfo]
GO
/****** Object:  StoredProcedure [dbo].[SampleWhileLoop]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SampleWhileLoop]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SampleWhileLoop]
GO
/****** Object:  StoredProcedure [dbo].[SampleTransaction]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SampleTransaction]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SampleTransaction]
GO
/****** Object:  StoredProcedure [dbo].[sampleCursorWithXML]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sampleCursorWithXML]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sampleCursorWithXML]
GO
/****** Object:  StoredProcedure [dbo].[Orders_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_Save]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Orders_Save]
GO
/****** Object:  StoredProcedure [dbo].[Orders_GetAll]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Orders_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Orders_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Orders_Delete]
GO
/****** Object:  StoredProcedure [dbo].[OrderItems_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems_Save]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrderItems_Save]
GO
/****** Object:  StoredProcedure [dbo].[OrderItem_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem_Save]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrderItem_Save]
GO
/****** Object:  StoredProcedure [dbo].[OrderItem_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[OrderItem_Delete]
GO
/****** Object:  StoredProcedure [dbo].[Order_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_Save]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Order_Save]
GO
/****** Object:  StoredProcedure [dbo].[Order_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Order_Delete]
GO
/****** Object:  StoredProcedure [dbo].[Customers_GetAll]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customers_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[CustomerAddress_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress_Save]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CustomerAddress_Save]
GO
/****** Object:  StoredProcedure [dbo].[CustomerAddress_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CustomerAddress_Delete]
GO
/****** Object:  StoredProcedure [dbo].[Customer_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Save]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_Save]
GO
/****** Object:  StoredProcedure [dbo].[Customer_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_Delete]
GO
/****** Object:  StoredProcedure [dbo].[BillingInfo_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingInfo_Save]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BillingInfo_Save]
GO
/****** Object:  StoredProcedure [dbo].[BillingInfo_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingInfo_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BillingInfo_Delete]
GO
USE [master]
GO
/****** Object:  Database [TestDB]    Script Date: 10/28/2018 7:53:31 PM ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'TestDB')
DROP DATABASE [TestDB]
GO
/****** Object:  Database [TestDB]    Script Date: 10/28/2018 7:53:31 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TestDB')
BEGIN
CREATE DATABASE [TestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CustomerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CustomerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CustomerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestDB] SET  MULTI_USER 
GO
ALTER DATABASE [TestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [TestDB]
GO
/****** Object:  StoredProcedure [dbo].[BillingInfo_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingInfo_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-26 14:32:00>
-- Description:	<SP to delete customer billing data>
-- =============================================
CREATE PROCEDURE [dbo].[BillingInfo_Delete] 
	-- Add the parameters for the stored procedure here
	(
		@CustomerId int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from dbo.BillingInfo where CustomerId = @CustomerId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BillingInfo_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingInfo_Save]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-26 12:02:00>
-- Description:	<SP to save billing info>
-- =============================================
CREATE PROCEDURE [dbo].[BillingInfo_Save]
	-- Add the parameters for the stored procedure here
	(
		@BillingInfoId int,
		@CustomerId int,
		@CardType varchar(20),
		@CardHolderName varchar(100),
		@CardNumber varchar(100),
		@ExpiryDate date,
		@CVV int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @BillingInfoId is null OR @BillingInfoId = 0
	Begin
		Insert into dbo.BillingInfo(CustomerId, CardType, CardHolderName, CardNumber, ExpiryDate, CVV)
		Values (@CustomerId, @CardType, @CardHolderName, @CardNumber, @ExpiryDate, @CVV)
	End
	Else 
	Begin
		Update dbo.BillingInfo
		set CardType = @CardType,
			CardholderName = @CardHolderName,
			CardNumber = @CardNumber,
			ExpiryDate = @ExpiryDate,
			CVV = @CVV
		Where BillingInfoId = @BillingInfoId
		And CustomerId = @CustomerId
	End
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Customer_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-25 12:03:00>
-- Description:	<Sp to delete data from customer table>
-- =============================================
CREATE PROCEDURE [dbo].[Customer_Delete]
	-- Add the parameters for the stored procedure here
	(
		@CustomerId int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from dbo.Customers where CustomerId = @CustomerId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Customer_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_Save]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-23 08:10:00>
-- Description:	<Sp to insert and update in Customer table>
-- =============================================
CREATE PROCEDURE [dbo].[Customer_Save]--0, ''Mr'', ''test'', ''help'', ''Female'', ''2018-10-10'', null
	-- Add the parameters for the stored procedure here
	(
		@CustomerId int,
		@Title varchar(10),
		@FirstName varchar(100),
		@LastName varchar(100),
		@Gender varchar(10),
		@DateOfBirth date,
		@CustomerAddressList xml,
		@CustomerBillingInfoList xml
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @CustomerId is null OR @CustomerId = 0
	BEGIN
		Insert into dbo.Customers(Title, FirstName, LastName, Gender, DateOfBirth, CreatedOn, UpdatedOn)
		values(@Title, @FirstName, @LastName, @Gender, @DateOfBirth, GETUTCDATE(), null)
		Set @CustomerId = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		Update dbo.Customers
		set Title = @Title,
			FirstName = @FirstName,
			LastName = @LastName,
			Gender = @Gender,
			DateOfBirth = @DateOfBirth,
			UpdatedOn = GETUTCDATE()
		Where CustomerId = @CustomerId
	END
	Select @CustomerId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[CustomerAddress_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-26 14:32:00>
-- Description:	<SP to delete customer address data>
-- =============================================
CREATE PROCEDURE [dbo].[CustomerAddress_Delete] 
	-- Add the parameters for the stored procedure here
	(
		@CustomerId int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from dbo.CustomerAddress where CustomerId = @CustomerId
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[CustomerAddress_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress_Save]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-23 11:11:00>
-- Description:	<Sp to insert and update customer address>
-- =============================================
CREATE PROCEDURE [dbo].[CustomerAddress_Save] 
	-- Add the parameters for the stored procedure here
	(
		@CustomerId int,
		@AddressId int,
		@Address1 varchar(500),
		@Address2 varchar(500),
		@City varchar(20),
		@State varchar(20),
		@Country varchar(20),
		@PostalCode varchar(20),
		@IsShipping bit,
		@IsBilling bit
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	If @AddressId is null OR @AddressId = 0
	BEGIN
		Insert into dbo.CustomerAddress(CustomerId, Address1, Address2, City, State, Country, PostalCode, IsShipping, IsBilling)
		Values(@CustomerId, @Address1, @Address2, @City, @State, @Country, @PostalCode, @IsShipping, @IsBilling)
	END
	Else 
	BEGIN
		Update dbo.CustomerAddress
		set Address1 = @Address1,
			Address2 = @Address2,
			City = @City,
			State = @State,
			Country = @Country,
			PostalCode = @PostalCode,
			IsShipping = @IsShipping,
			IsBilling = @IsBilling
		Where CustomerId = @CustomerId
		And AddressId = @AddressId
	END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Customers_GetAll]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-23 08:00:00>
-- Description:	<SP to get all customer records>
-- =============================================
--[dbo].[Customers_GetAll]1, 100
CREATE PROCEDURE [dbo].[Customers_GetAll]--1, 100
	-- Add the parameters for the stored procedure here
	@PageNo int = 1,
	@PageSize int = 1000,
	@OrderBy varchar(20) = '''',
	@FirstName varchar(100) = '''',
	@LastName varchar(100) = ''''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Select statements for procedure here
	SELECT 
		CustomerId, 
		Title, 
		LastName, 
		FirstName, 
		Gender, 
		DateOfBirth
	FROM dbo.Customers (nolock)
	Where 
		(isnull(@FirstName, '''') = '''' OR FirstName like ''%'' + @FirstName + ''%'')
		And (isnull(@LastName, '''') = '''' OR LastName like ''%'' + @LastName + ''%'')
	Order by CustomerId
	OFFSET (@PageNo - 1) * @PageSize ROWS
			FETCH NEXT @PageSize ROWS ONLY

	Declare @CustomerIds table (id int)
	Insert Into @CustomerIds
	SELECT 
			CustomerId		
	FROM dbo.Customers (nolock)
	Where 
		(isnull(@FirstName, '''') = '''' OR FirstName like ''%'' + @FirstName + ''%'')
		And (isnull(@LastName, '''') = '''' OR LastName like ''%'' + @LastName + ''%'')
	Order by CustomerId
	OFFSET (@PageNo - 1) * @PageSize ROWS
			FETCH NEXT @PageSize ROWS ONLY

	Select cust.id CustomerId, AddressId, Address1, Address2, City, State, Country, PostalCode, IsShipping, IsBilling
	from CustomerAddress ca (nolock) inner join @CustomerIds cust
	On ca.CustomerId = cust.id

	Select cust.id CustomerId, BillingInfoId, CardType, CardholderName, CardNumber, ExpiryDate, CVV
	from BillingInfo bi (nolock) inner join @CustomerIds cust
	On bi.CustomerId = cust.id
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Order_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-25 12:05:00>
-- Description:	<Sp to delete orders and related order items table>
-- =============================================
CREATE PROCEDURE [dbo].[Order_Delete]
	-- Add the parameters for the stored procedure here
	(
		@OrderNumber int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from dbo.Orders where OrderNumber = @OrderNumber
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Order_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_Save]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-23 08:30:00>
-- Description:	<Sp to insert and update order>
-- =============================================
/*
[dbo].[Orders_Save] 0, 1, ''2018-10-25 08:00:00'', 2, ''1Day'', 20, ''USD'', 10, 2, ''Coupon''
*/
CREATE PROCEDURE [dbo].[Order_Save]
	-- Add the parameters for the stored procedure here
	(
		@OrderNumber int,
		@CustomerId int,
		@OrderDate datetime, 
		@OrderTotal float,
		@ShippingMethodCode varchar(20),
		@ShippingCost float,
		@CurrencyCode varchar(10),
		@Taxes float,
		@DiscountAmount float,
		@CouponCode varchar(20),
		@OrderItemList xml
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @OrderNumber is null OR @OrderNumber = 0
	BEGIN
		Insert into dbo.Orders(CustomerId, OrderDate, OrderTotal, ShippingMethodCode, ShippingCost, CurrencyCode, Taxes, DiscountAmount, CouponCode, CreatedOn, UpdatedOn)
		values(@CustomerId, @OrderDate, @OrderTotal, @ShippingMethodCode, @ShippingCost, @CurrencyCode, @Taxes, @DiscountAmount, @CouponCode, GETUTCDATE(), null)
		Set @OrderNumber = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		Update dbo.Orders
		set OrderDate = @OrderDate,
			OrderTotal = @OrderTotal,
			ShippingMethodCode = @ShippingMethodCode,
			ShippingCost = @ShippingCost,
			CurrencyCode = @CurrencyCode,
			Taxes = @Taxes,
			DiscountAmount = @DiscountAmount,
			CouponCode = @CouponCode,
			UpdatedOn = GETUTCDATE()
		Where OrderNumber = @OrderNumber
	END
	SELECT @OrderNumber
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrderItem_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-26 14:30.00>
-- Description:	<SP to delete order item data>
-- =============================================
CREATE PROCEDURE [dbo].[OrderItem_Delete]
	-- Add the parameters for the stored procedure here
	(
		@OrderNumber int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from dbo.OrderItems Where OrderNumber = @OrderNumber
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrderItem_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem_Save]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-25 11:40:00>
-- Description:	<SP to insert and update order items>
-- =============================================
/*
[dbo].[OrderItems_Save]0,2,''item 2'',''itemcode2'',30,4
*/
CREATE PROCEDURE [dbo].[OrderItem_Save]
	-- Add the parameters for the stored procedure here
	(
		@OrderItemId int,
		@OrderNumber int,
		@ItemName varchar(200),
		@ItemCode varchar(50),
		@Price float,
		@Quantity int,
		@TotalPrice float
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @OrderItemId is null OR @OrderItemId = 0
	Begin
		Insert into dbo.OrderItems(OrderNumber, ItemName, ItemCode, Price, Quantity, TotalPrice)
		Values (@OrderNumber, @ItemName, @ItemCode, @Price, @Quantity, @Price * @Quantity)
	End
	Else 
	Begin
		Update dbo.OrderItems
		set ItemName = @ItemName,
			ItemCode = @ItemCode,
			Price = @Price,
			Quantity = @Quantity,
			TotalPrice = @Price * @Quantity
		Where OrderItemId = @OrderItemId
		And OrderNumber = @OrderNumber
	End
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[OrderItems_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems_Save]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-25 11:40:00>
-- Description:	<SP to insert and update order items>
-- =============================================
/*
[dbo].[OrderItems_Save]0,2,''item 2'',''itemcode2'',30,4
*/
CREATE PROCEDURE [dbo].[OrderItems_Save]
	-- Add the parameters for the stored procedure here
	(
		@OrderItemId int,
		@OrderNumber int,
		@ItemName varchar(200),
		@ItemCode varchar(50),
		@Price float,
		@Quantity int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @OrderItemId is null OR @OrderItemId = 0
	Begin
		Insert into dbo.OrderItems(OrderNumber, ItemName, ItemCode, Price, Quantity, TotalPrice)
		Values (@OrderNumber, @ItemName, @ItemCode, @Price, @Quantity, @Price * @Quantity)
	End
	Else 
	Begin
		Update dbo.OrderItems
		set ItemName = @ItemName,
			ItemCode = @ItemCode,
			Price = @Price,
			Quantity = @Quantity,
			TotalPrice = @Price * @Quantity
		Where OrderItemId = @OrderItemId
		And OrderNumber = @OrderNumber
	End
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Orders_Delete]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-25 12:05:00>
-- Description:	<Sp to delete orders and related order items table>
-- =============================================
CREATE PROCEDURE [dbo].[Orders_Delete]
	-- Add the parameters for the stored procedure here
	(
		@OrderNumber int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from dbo.OrderItems where OrderNumber = @OrderNumber
	Delete from dbo.Orders where OrderNumber = @OrderNumber
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Orders_GetAll]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-23 08:20:00>
-- Description:	<Sp to get all order list>
-- =============================================
/*
[dbo].[Orders_GetAll]1, 100, '''', 0, 2, null, ''''
*/
CREATE PROCEDURE [dbo].[Orders_GetAll]--1, 100
	-- Add the parameters for the stored procedure here
	@PageNo int = 1,
	@PageSize int = 1000,
	@OrderBy varchar(20) = '''',
	@OrderNumber int = 0,
	@OrderDate date = null,
	@ShippingMethodCode varchar(50) = ''''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		Orders.OrderNumber,
		OrderDate, 
		OrderTotal, 
		Orders.ShippingMethodCode,
		sm.MethodName,
		ShippingCost,
		Orders.CurrencyCode,
		c.CurrencyName,
		Taxes,
		DiscountAmount,
		CouponCode
	from dbo.Orders (nolock)
	left join dbo.Currency c (nolock)
	on c.CurrencyCode = Orders.CurrencyCode
	left join dbo.ShippingMethod sm (nolock)
	on sm.MethodCode = orders.ShippingMethodCode
	Where 
		(isnull(@OrderNumber, 0) = 0 OR Orders.OrderNumber = @OrderNumber)
		AND
		(@OrderDate is null OR CAST(Orders.OrderDate as date) = @OrderDate)
		AND
		(isnull(@ShippingMethodCode, '''') = '''' OR Orders.ShippingMethodCode = @ShippingMethodCode)
	Order by OrderNumber
	OFFSET (@PageNo - 1) * @PageSize ROWS
			FETCH NEXT @PageSize ROWS ONLY
				
	Declare @OrderNumbers table (id int)
	Insert Into @OrderNumbers

	SELECT 
			OrderNumber
	FROM dbo.Orders (nolock)
	Where 
		(isnull(@OrderNumber, 0) = 0 OR Orders.OrderNumber = @OrderNumber)
		OR
		(@OrderDate is null OR CAST(Orders.OrderDate as date) = @OrderDate)
		OR
		(isnull(@ShippingMethodCode, '''') = '''' OR Orders.ShippingMethodCode = @ShippingMethodCode)
	Order by OrderNumber
	OFFSET (@PageNo - 1) * @PageSize ROWS
			FETCH NEXT @PageSize ROWS ONLY

	Select OrderItemId, ordN.id OrderNumber, ItemName, ItemCode, Price, Quantity, TotalPrice
	from OrderItems OI (nolock) inner join @OrderNumbers ordN
	On OI.OrderNumber = ordN.id

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Orders_Save]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders_Save]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Somya Raj>
-- Create date: <2018-10-23 08:30:00>
-- Description:	<Sp to insert and update order>
-- =============================================
/*
[dbo].[Orders_Save] 0, 1, ''2018-10-25 08:00:00'', 2, ''1Day'', 20, ''USD'', 10, 2, ''Coupon''
*/
CREATE PROCEDURE [dbo].[Orders_Save]
	-- Add the parameters for the stored procedure here
	(
		@OrderNumber int,
		@CustomerId int,
		@OrderDate datetime, 
		@OrderTotal int,
		@ShippingMethodCode varchar(20),
		@ShippingCost float,
		@CurrencyCode varchar(10),
		@Taxes float,
		@DiscountAmount float,
		@CouponCode varchar(20)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @OrderNumber is null OR @OrderNumber = 0
	BEGIN
		Insert into dbo.Orders(CustomerId, OrderDate, OrderTotal, ShippingMethodCode, ShippingCost, CurrencyCode, Taxes, DiscountAmount, CouponCode, CreatedOn, UpdatedOn)
		values(@CustomerId, @OrderDate, @OrderTotal, @ShippingMethodCode, @ShippingCost, @CurrencyCode, @Taxes, @DiscountAmount, @CouponCode, GETUTCDATE(), null)
		Set @OrderNumber = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		Update dbo.Orders
		set OrderDate = @OrderDate,
			OrderTotal = @OrderTotal,
			ShippingMethodCode = @ShippingMethodCode,
			ShippingCost = @ShippingCost,
			CurrencyCode = @CurrencyCode,
			Taxes = @Taxes,
			DiscountAmount = @DiscountAmount,
			CouponCode = @CouponCode,
			UpdatedOn = GETUTCDATE()
		Where OrderNumber = @OrderNumber
	END
END
' 
END
GO
/****** Object:  Table [dbo].[BillingInfo]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BillingInfo](
	[BillingInfoId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CardType] [varchar](20) NOT NULL,
	[CardholderName] [varchar](100) NOT NULL,
	[CardNumber] [varchar](100) NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[CVV] [int] NOT NULL,
 CONSTRAINT [PK_BillingInfo] PRIMARY KEY CLUSTERED 
(
	[BillingInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currency]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Currency](
	[CurrencyCode] [varchar](10) NOT NULL,
	[CurrencyName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[CurrencyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerAddress]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerAddress](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Address1] [varchar](500) NOT NULL,
	[Address2] [varchar](500) NOT NULL,
	[City] [varchar](20) NOT NULL,
	[State] [varchar](20) NOT NULL,
	[Country] [varchar](20) NOT NULL,
	[PostalCode] [varchar](20) NOT NULL,
	[IsShipping] [bit] NOT NULL,
	[IsBilling] [bit] NOT NULL,
 CONSTRAINT [PK_CustomerAddress] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](10) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderItems](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [int] NOT NULL,
	[ItemName] [varchar](200) NOT NULL,
	[ItemCode] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Orders](
	[OrderNumber] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderTotal] [float] NOT NULL,
	[ShippingMethodCode] [varchar](50) NOT NULL,
	[ShippingCost] [float] NOT NULL,
	[CurrencyCode] [varchar](10) NOT NULL,
	[Taxes] [float] NOT NULL,
	[DiscountAmount] [float] NOT NULL,
	[CouponCode] [varchar](20) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShippingMethod]    Script Date: 10/28/2018 7:53:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShippingMethod]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ShippingMethod](
	[MethodCode] [varchar](50) NOT NULL,
	[MethodName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ShippingMethod] PRIMARY KEY CLUSTERED 
(
	[MethodCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BillingInfo] ON 

GO
INSERT [dbo].[BillingInfo] ([BillingInfoId], [CustomerId], [CardType], [CardholderName], [CardNumber], [ExpiryDate], [CVV]) VALUES (1, 1, N'DEBIT', N'test name', N'1230 0919 0123 0912', CAST(0x0000A98500000000 AS DateTime), 787)
GO
INSERT [dbo].[BillingInfo] ([BillingInfoId], [CustomerId], [CardType], [CardholderName], [CardNumber], [ExpiryDate], [CVV]) VALUES (2, 2, N'DEBIT', N'name 1', N'2563 2541 2898 7856', CAST(0x0000A98500000000 AS DateTime), 568)
GO
SET IDENTITY_INSERT [dbo].[BillingInfo] OFF
GO
INSERT [dbo].[Currency] ([CurrencyCode], [CurrencyName]) VALUES (N'CAD', N'CA dollars')
GO
INSERT [dbo].[Currency] ([CurrencyCode], [CurrencyName]) VALUES (N'USD', N'US dollars')
GO
SET IDENTITY_INSERT [dbo].[CustomerAddress] ON 

GO
INSERT [dbo].[CustomerAddress] ([AddressId], [CustomerId], [Address1], [Address2], [City], [State], [Country], [PostalCode], [IsShipping], [IsBilling]) VALUES (1, 1, N'Test address 1', N'Test address 2', N'Test city', N'Test state', N'Test country', N'122017', 1, 0)
GO
INSERT [dbo].[CustomerAddress] ([AddressId], [CustomerId], [Address1], [Address2], [City], [State], [Country], [PostalCode], [IsShipping], [IsBilling]) VALUES (2, 2, N'a1', N'a2', N'city1', N'state1', N'country1', N'246761', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[CustomerAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

GO
INSERT [dbo].[Customers] ([CustomerId], [Title], [FirstName], [LastName], [Gender], [DateOfBirth], [CreatedOn], [UpdatedOn]) VALUES (1, N'Mr.', N'Test first', N'Test last', N'MALE', CAST(0xE03E0B00 AS Date), CAST(0x0000A985009E95C8 AS DateTime), CAST(0x0000A98500C5F94D AS DateTime))
GO
INSERT [dbo].[Customers] ([CustomerId], [Title], [FirstName], [LastName], [Gender], [DateOfBirth], [CreatedOn], [UpdatedOn]) VALUES (2, N't1', N'f1', N'l1', N'Male', CAST(0xE03E0B00 AS Date), CAST(0x0000A98500ACC040 AS DateTime), CAST(0x0000A98500C5BFA7 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

GO
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderNumber], [ItemName], [ItemCode], [Price], [Quantity], [TotalPrice]) VALUES (1, 2, N'item name', N'item code', 10, 3, 30)
GO
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderNumber], [ItemName], [ItemCode], [Price], [Quantity], [TotalPrice]) VALUES (2, 3, N'item 1', N'code 1', 10, 2, 20)
GO
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

GO
INSERT [dbo].[Orders] ([OrderNumber], [CustomerId], [OrderDate], [OrderTotal], [ShippingMethodCode], [ShippingCost], [CurrencyCode], [Taxes], [DiscountAmount], [CouponCode], [CreatedOn], [UpdatedOn]) VALUES (2, 1, CAST(0x0000A98500C63FEA AS DateTime), 30, N'GROUND', 10, N'CAD', 2, 0, N'Coupon', CAST(0x0000A985009F48B0 AS DateTime), CAST(0x0000A98500C688AA AS DateTime))
GO
INSERT [dbo].[Orders] ([OrderNumber], [CustomerId], [OrderDate], [OrderTotal], [ShippingMethodCode], [ShippingCost], [CurrencyCode], [Taxes], [DiscountAmount], [CouponCode], [CreatedOn], [UpdatedOn]) VALUES (3, 2, CAST(0x0000A98500C63FEA AS DateTime), 30, N'GROUND', 10, N'CAD', 2, 0, N'Coupon', CAST(0x0000A98500ADA117 AS DateTime), CAST(0x0000A98500C6A646 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[ShippingMethod] ([MethodCode], [MethodName]) VALUES (N'1DAY', N'1-Day')
GO
INSERT [dbo].[ShippingMethod] ([MethodCode], [MethodName]) VALUES (N'2DAY', N'2-Days')
GO
INSERT [dbo].[ShippingMethod] ([MethodCode], [MethodName]) VALUES (N'GROUND', N'Ground')
GO
/****** Object:  Index [IDX_BillingInfo_CustomerId]    Script Date: 10/28/2018 7:53:31 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[BillingInfo]') AND name = N'IDX_BillingInfo_CustomerId')
CREATE NONCLUSTERED INDEX [IDX_BillingInfo_CustomerId] ON [dbo].[BillingInfo]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IDX_CustomerAddress_CustomerId]    Script Date: 10/28/2018 7:53:31 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress]') AND name = N'IDX_CustomerAddress_CustomerId')
CREATE NONCLUSTERED INDEX [IDX_CustomerAddress_CustomerId] ON [dbo].[CustomerAddress]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IDX_OrderItems_OrderNumber]    Script Date: 10/28/2018 7:53:31 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems]') AND name = N'IDX_OrderItems_OrderNumber')
CREATE NONCLUSTERED INDEX [IDX_OrderItems_OrderNumber] ON [dbo].[OrderItems]
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingInfo_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingInfo]'))
ALTER TABLE [dbo].[BillingInfo]  WITH CHECK ADD  CONSTRAINT [FK_BillingInfo_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BillingInfo_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[BillingInfo]'))
ALTER TABLE [dbo].[BillingInfo] CHECK CONSTRAINT [FK_BillingInfo_Customers_CustomerId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Currency_Currency]') AND parent_object_id = OBJECT_ID(N'[dbo].[Currency]'))
ALTER TABLE [dbo].[Currency]  WITH CHECK ADD  CONSTRAINT [FK_Currency_Currency] FOREIGN KEY([CurrencyCode])
REFERENCES [dbo].[Currency] ([CurrencyCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Currency_Currency]') AND parent_object_id = OBJECT_ID(N'[dbo].[Currency]'))
ALTER TABLE [dbo].[Currency] CHECK CONSTRAINT [FK_Currency_Currency]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Currency_Currency1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Currency]'))
ALTER TABLE [dbo].[Currency]  WITH CHECK ADD  CONSTRAINT [FK_Currency_Currency1] FOREIGN KEY([CurrencyCode])
REFERENCES [dbo].[Currency] ([CurrencyCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Currency_Currency1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Currency]'))
ALTER TABLE [dbo].[Currency] CHECK CONSTRAINT [FK_Currency_Currency1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAddress_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerAddress]'))
ALTER TABLE [dbo].[CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddress_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAddress_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerAddress]'))
ALTER TABLE [dbo].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress_Customers_CustomerId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderItems_Orders_OrderNumber]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItems]'))
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderNumber] FOREIGN KEY([OrderNumber])
REFERENCES [dbo].[Orders] ([OrderNumber])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrderItems_Orders_OrderNumber]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderItems]'))
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderNumber]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Currency_CurrencyCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Currency_CurrencyCode] FOREIGN KEY([CurrencyCode])
REFERENCES [dbo].[Currency] ([CurrencyCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Currency_CurrencyCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Currency_CurrencyCode]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Customers_CustomerId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_ShippingMethod_MethodCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_ShippingMethod_MethodCode] FOREIGN KEY([ShippingMethodCode])
REFERENCES [dbo].[ShippingMethod] ([MethodCode])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_ShippingMethod_MethodCode]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_ShippingMethod_MethodCode]
GO
USE [master]
GO
ALTER DATABASE [TestDB] SET  READ_WRITE 
GO
