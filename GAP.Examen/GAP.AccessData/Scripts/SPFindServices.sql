USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[FindServices]    Script Date: 1/12/2019 4:44:27 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindServices] 
AS
BEGIN
	SELECT Id, [Name]
	FROM Services
	WHERE Status = 1
END
