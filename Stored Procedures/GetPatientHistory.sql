USE MedicalScheduleDB
GO

DROP PROCEDURE IF EXISTS [dbo].[GetPatientHistory]
GO

CREATE PROCEDURE [dbo].[GetPatientHistory]
	@patientId INT

AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

BEGIN
	SELECT 
		p.FullName AS PatientFullName, 
		d.FullName AS DoctorName, 
		s.Name AS SpecialityName, 
		a.StartDateTime AS AppointmentStartTime, 
		a.EndDateTime AS AppointmentEndTime, 
		aps.Name AS AppointmentStatus
	FROM MedicalScheduleDB.dbo.Appointments a
	INNER JOIN MedicalScheduleDB.dbo.Patients p ON p.PatientId = a.PatientId
	INNER JOIN MedicalScheduleDB.dbo.Doctors d ON d.DoctorId = a.DoctorId
	INNER JOIN MedicalScheduleDB.dbo.Specialties s ON s.SpecialtyId = d.SpecialtyId
	LEFT JOIN MedicalScheduleDB.dbo.AppointmentStatuses aps ON aps.AppointmentStatusId = a.AppointmentStatusId
	WHERE a.PatientId = @patientId
	ORDER BY a.StartDateTime ASC
END
