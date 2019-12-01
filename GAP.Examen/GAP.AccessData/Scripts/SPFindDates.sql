USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[FindDates]    Script Date: 1/12/2019 4:43:18 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FindDates]
	-- Add the parameters for the stored procedure here
	@Page INT,
	@Top INT
AS
BEGIN
	SELECT  D.Id,IdPatient,Dni,FirstName,LastName,IdService,S.Name AS 'Service',D.DateService,[Description],CASE WHEN D.[Status] = 1 THEN 'Activa' ELSE 'Cancelada' END AS StatusM
    FROM Dates D 
    INNER JOIN Patients P ON P.id = D.IdPatient 
    INNER JOIN Services S ON S.id = D.IdService
    ORDER BY D.Id  DESC 
    OFFSET @Page ROWS 
    FETCH NEXT  @Top  ROWS ONLY 
END