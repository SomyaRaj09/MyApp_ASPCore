IF NOT EXISTS(SELECT COUNT(1) From dbo.ShippingMethod Where MethodCode = '1DAY')
BEGIN
	INSERT [dbo].[ShippingMethod] ([MethodCode], [MethodName]) VALUES (N'1DAY', N'1-Day')
END
GO
IF NOT EXISTS(SELECT COUNT(1) From dbo.ShippingMethod Where MethodCode = '2DAY')
BEGIN
	INSERT [dbo].[ShippingMethod] ([MethodCode], [MethodName]) VALUES (N'2DAY', N'2-Days')
END 
GO
IF NOT EXISTS(SELECT COUNT(1) From dbo.ShippingMethod Where MethodCode = 'GROUND')
BEGIN
	INSERT [dbo].[ShippingMethod] ([MethodCode], [MethodName]) VALUES (N'GROUND', N'Ground')
END

GO
IF NOT EXISTS(SELECT COUNT(1) From dbo.Currency Where CurrencyCode = 'CAD')
BEGIN
	INSERT [dbo].[Currency] ([CurrencyCode], [CurrencyName]) VALUES (N'CAD', N'CA dollars')
END
GO
IF NOT EXISTS(SELECT COUNT(1) From dbo.Currency Where CurrencyCode = 'USD')
BEGIN
	INSERT [dbo].[Currency] ([CurrencyCode], [CurrencyName]) VALUES (N'USD', N'US dollars')
END