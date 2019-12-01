USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[UpdateDates]    Script Date: 1/12/2019 4:45:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateDates]
	-- Add the parameters for the stored procedure here
	@Id UNIQUEIDENTIFIER,
	@IdPatient UNIQUEIDENTIFIER = NULL,
	@IdService UNIQUEIDENTIFIER = NULL,
	@DateService VARCHAR(10) = NULL,
	@Description VARCHAR(10) = NULL,
	@Status BIT = NULL,
	@IdPatientJs VARCHAR(50) = NULL,
    @IdServiceJs VARCHAR(50) = NULL,
    @Dni VARCHAR(50) = NULL,
    @FirstName VARCHAR(50) = NULL,
    @LastName VARCHAR(50) = NULL,
    @Service VARCHAR(50) = NULL,
	@StatusM VARCHAR(40) = NULL
AS
BEGIN
	UPDATE Dates
	SET 
		Status = ISNULL(@Status,Status)
	WHERE Id = @Id;
END