USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[FindloginViewModel]    Script Date: 1/12/2019 4:43:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindloginViewModel]
	@userName VARCHAR(10),
	@passWord VARCHAR(10)
AS
BEGIN
	SELECT *
	FROM Users
	WHERE UserName = @userName AND PassWord = @passWord AND Status = 1
END
