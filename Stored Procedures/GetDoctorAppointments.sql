
USE MedicalScheduleDB
GO

DROP PROCEDURE IF EXISTS [dbo].[GetDoctorAppointments]
GO

CREATE PROCEDURE [dbo].[GetDoctorAppointments]
    @doctorId INT,
    @appointmentDate DATE
AS
BEGIN
    SELECT 
        a.StartDateTime AS AppointmentStartTime, 
        a.EndDateTime AS AppointmentEndTime, 
        p.FullName AS PatientName, 
        p.PhoneNumber AS PatientPhoneNumber, 
        a.Reason AS AppointmentReason, 
        aps.Name AS AppointmentStatus
    FROM MedicalScheduleDB.dbo.Appointments a
    INNER JOIN MedicalScheduleDB.dbo.Patients p on p.PatientId = a.PatientId
    LEFT JOIN MedicalScheduleDB.dbo.AppointmentStatuses aps on aps.AppointmentStatusId = a.AppointmentStatusId
    WHERE CONVERT(DATE, a.StartDateTime) = @appointmentDate
    AND @doctorId = a.DoctorId
    ORDER BY StartDateTime ASC
END

