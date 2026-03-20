--Script para llenar datos basicos para pruebas
USE MedicalScheduleDB
GO

DECLARE @currentDateTime DATETIME = GETDATE()

--Tabla Days
INSERT INTO Days(Name) VALUES('Lunes')
INSERT INTO Days(Name) VALUES('Martes')
INSERT INTO Days(Name) VALUES('Miercoles')
INSERT INTO Days(Name) VALUES('Jueves')
INSERT INTO Days(Name) VALUES('Viernes')
INSERT INTO Days(Name) VALUES('Sabado')
INSERT INTO Days(Name) VALUES('Domingo')

--Tabla AppointmentStatuses
INSERT INTO AppointmentStatuses(Name, CreatedAt) VALUES('Pendiente', @currentDateTime)
INSERT INTO AppointmentStatuses(Name, CreatedAt) VALUES('Confirmada', @currentDateTime)
INSERT INTO AppointmentStatuses(Name, CreatedAt) VALUES('En Sala de Espera', @currentDateTime)
INSERT INTO AppointmentStatuses(Name, CreatedAt) VALUES('En Consulta', @currentDateTime)
INSERT INTO AppointmentStatuses(Name, CreatedAt) VALUES('Completada', @currentDateTime)
INSERT INTO AppointmentStatuses(Name, CreatedAt) VALUES('Cancelada', @currentDateTime)


--Tabla Specialties
INSERT INTO Specialties(Name, DurationMinutes, CreatedAt) VALUES('Medicina General', 20, @currentDateTime)
INSERT INTO Specialties(Name, DurationMinutes, CreatedAt) VALUES('Cardiologia', 30, @currentDateTime)
INSERT INTO Specialties(Name, DurationMinutes, CreatedAt) VALUES('Cirugia', 45, @currentDateTime)
INSERT INTO Specialties(Name, DurationMinutes, CreatedAt) VALUES('Pediatria', 20, @currentDateTime)
INSERT INTO Specialties(Name, DurationMinutes, CreatedAt) VALUES('Ginecologia', 30, @currentDateTime)

--Tabla Doctors
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dr. Juan Fragoso', 1, @currentDateTime)
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dr. Perez Royal', 1, @currentDateTime)
--
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dr. Gerardo Coronado', 2, @currentDateTime)
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dr. Antonio Peruyero', 2, @currentDateTime)
--
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dra. Gemma Tovanche', 3, @currentDateTime)
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dr. Jose Barbosa', 3, @currentDateTime)
--
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dr. Montes Chaverri', 4, @currentDateTime)
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dr. Hector Hugo Gonzalez', 4, @currentDateTime)
--
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dra. Fernanda Coronado', 5, @currentDateTime)
INSERT INTO Doctors(FullName, SpecialtyId, CreatedAt) VALUES('Dra. Lourdes Rodriguez', 5, @currentDateTime)


--Tabla DoctorSchedules
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(1, 1, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(1, 3, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(1, 5, '10:00', '16:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(1, 7, '10:00', '17:00', @currentDateTime)
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(2, 2, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(2, 4, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(2, 6, '10:00', '16:00', @currentDateTime)
--
--
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(3, 1, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(3, 3, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(3, 5, '10:00', '16:00', @currentDateTime)
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(4, 2, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(4, 4, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(4, 6, '10:00', '16:00', @currentDateTime)
--
--
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(5, 1, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(5, 3, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(5, 5, '10:00', '16:00', @currentDateTime)
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(6, 2, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(6, 4, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(6, 6, '10:00', '16:00', @currentDateTime)
--
--
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(7, 1, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(7, 3, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(7, 5, '10:00', '16:00', @currentDateTime)
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(8, 2, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(8, 4, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(8, 6, '10:00', '16:00', @currentDateTime)
--
--
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(9, 1, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(9, 3, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(9, 5, '10:00', '16:00', @currentDateTime)
--
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(10, 2, '8:00', '14:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(10, 4, '9:00', '15:00', @currentDateTime)
INSERT INTO DoctorSchedules(DoctorId, DayId, StartTime, EndTime, CreatedAt) VALUES(10, 6, '10:00', '16:00', @currentDateTime)





--Tabla patients
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Gabriela Macias', '1980-01-01', '8183381000', 'gabrielamacias@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Geraldine viveros', '1981-02-02', '8183381001', 'geraldineviveros@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Francisco Cepeda', '1982-03-03', '8183381002', 'franciscocepeda@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Jonathan Salinas C', '1983-04-04', '8183381003', 'jonathansalinas@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Oliver Salinas C', '1984-05-05', '8183381004', 'oliversalinas@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Valeria Gonzalez', '1985-06-06', '8183381005', 'valeriagonzalez@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Ignacio Hernandez', '1986-07-07', '8183381006', 'ignaciohernandez@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Carlos Garcia', '1987-08-08', '8183381007', 'carlosgarcia@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Hector Quirino', '1988-09-09', '8183381008', 'hectorquirino@mail.com', @currentDateTime)
INSERT INTO Patients(FullName, BirthDate, PhoneNumber, Email, CreatedAt) VALUES('Jason Zacarias', '1989-10-10', '8183381009', 'jasonzacarias@mail.com', @currentDateTime)




--Tabla appointments
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(9, 6, '2026-03-05 09:00:00.000', '2026-03-05 09:30:00.000', 'Chequeo de Inicio de anio', 6, 'Tuvo mucho trabajo', @currentDateTime)
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(9, 6, '2026-03-07 10:00:00.000', '2026-03-07 10:30:00.000', 'Chequeo de Inicio de anio - segunda cita', 6, 'compromisos personales', @currentDateTime)
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(9, 6, '2026-03-09 11:00:00.000', '2026-03-09 11:30:00.000', 'Chequeo de Inicio de anio - tercer cita', 6, 'Salio de viaje', @currentDateTime)
--
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(1, 1, '2026-03-23 10:00:00.000', '2026-03-23 10:20:00.000', 'Dolor de cabeza', 1, NULL, @currentDateTime)
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(1, 2, '2026-03-23 11:00:00.000', '2026-03-23 11:20:00.000', 'Gripa', 1, NULL, @currentDateTime)
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(1, 3, '2026-03-25 10:00:00.000', '2026-03-25 10:20:00.000', 'Dolor de estomago', 1, NULL, @currentDateTime)
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(1, 4, '2026-03-25 11:00:00.000', '2026-03-23 11:20:00.000', 'Sangrado', 1, NULL, @currentDateTime)
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(1, 5, '2026-03-27 10:00:00.000', '2026-03-27 10:20:00.000', 'Chequeo', 1, NULL, @currentDateTime)
INSERT INTO Appointments(DoctorId, PatientId, StartDateTime, EndDateTime, Reason, AppointmentStatusId, CancelationReason, CreatedAt) VALUES(1, 6, '2026-03-27 11:00:00.000', '2026-03-27 11:20:00.000', 'Dolor de piernas', 1, NULL, @currentDateTime)


--Tinal check

SELECT * FROM Days
SELECT * FROM AppointmentStatuses
SELECT * FROM Specialties
SELECT * FROM Doctors
SELECT * FROM DoctorSchedules where DoctorId =1
SELECT * FROM Patients
SELECT * FROM Appointments