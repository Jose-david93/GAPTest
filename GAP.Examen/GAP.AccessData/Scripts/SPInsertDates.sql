USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[InsertDates]    Script Date: 1/12/2019 4:44:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDates]
	-- Add the parameters for the stored procedure here
	@IdPatient UNIQUEIDENTIFIER,
	@IdService UNIQUEIDENTIFIER,
	@DateService DATETIME,
	@Description VARCHAR(500)
AS
BEGIN
	INSERT INTO Dates (IdPatient,IdService,DateService,Description) 
	OUTPUT inserted.Id
	VALUES (@IdPatient,@IdService,@DateService,@Description);
END