USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[IsCancelable]    Script Date: 1/12/2019 4:45:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsCancelable]
	-- Add the parameters for the stored procedure here
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT ID, DateService,  DATEADD(day, -1 , GETDATE()),GETDATE()
	FROM Dates
	WHERE Id=@Id AND DATEADD(day ,-1,DateService) > GETDATE() ;
END
