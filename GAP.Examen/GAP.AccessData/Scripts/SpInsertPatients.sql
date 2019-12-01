USE [Clinic_db]
GO
/****** Object:  StoredProcedure [dbo].[InsertPatients]    Script Date: 1/12/2019 4:45:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPatients]
	-- Add the parameters for the stored procedure here
	@Dni VARCHAR(30),
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50)
AS
BEGIN
	INSERT INTO Patients (Dni,FirstName,LastName)
	OUTPUT inserted.Id
	VALUES (@Dni,@FirstName,@LastName);
END