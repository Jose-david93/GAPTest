USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[FindPatients]    Script Date: 1/12/2019 4:43:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindPatients]
	-- Add the parameters for the stored procedure here
	@Top INT,
	@Page INT
AS
BEGIN
	SELECT Id, Dni, FirstName,LastName
    FROM Patients
    ORDER BY Id  DESC 
    OFFSET @Page ROWS 
    FETCH NEXT  @Top  ROWS ONLY 
END