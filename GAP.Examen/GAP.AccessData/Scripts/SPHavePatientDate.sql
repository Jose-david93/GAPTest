USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[HavePatientDate]    Script Date: 1/12/2019 4:44:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HavePatientDate]
	@IdPatient UNIQUEIDENTIFIER,
	@DateService DATE
AS
BEGIN

	SELECT Id
    FROM Dates 
    WHERE IdPatient = @IdPatient AND CONVERT(VARCHAR,DateService,111) = @DateService AND Status = 1
END