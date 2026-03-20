USE MedicalScheduleDB
GO

DROP PROCEDURE IF EXISTS [dbo].[ValidateDoctorAvailability]
GO

SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[ValidateDoctorAvailability]
@doctorID INT,
@startDateTime DATETIME,
@endDateTime DATETIME,
@dayId INT 
AS
BEGIN
    SET NOCOUNT ON;
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    DECLARE @result BIT = 0;
    DECLARE @cancelledStatusId INT;

    -- 1. Obtenemos dinámicamente el ID del estatus 'Cancelada'
    SELECT TOP 1 @cancelledStatusId = AppointmentStatusId 
    FROM AppointmentStatuses (NOLOCK)
    WHERE Name = 'Cancelada' OR Name = 'Cancelado'; -- Cubrimos ambas posibilidades

    -- Si por alguna razón no existe en la tabla, usamos el 7 como respaldo (fallback)
    SET @cancelledStatusId = ISNULL(@cancelledStatusId, 7);

    -- 2. ¿El doctor trabaja ese día y la cita cabe en su horario?
    IF EXISTS (
        SELECT 1 FROM DoctorSchedules (NOLOCK)
        WHERE DoctorId = @doctorID AND DayId = @dayId
        AND CAST(@startDateTime AS TIME) >= StartTime 
        AND CAST(@endDateTime AS TIME) <= EndTime
    )
    BEGIN
        -- 3. ¿Hay traslapes con otras citas que NO estén canceladas?
        IF NOT EXISTS (
            SELECT 1 FROM Appointments (NOLOCK)
            WHERE DoctorId = @doctorID 
            AND AppointmentStatusId <> @cancelledStatusId 
            AND @startDateTime < EndDateTime 
            AND @endDateTime > StartDateTime
        )
        BEGIN
            SET @result = 1; -- Disponible
        END
    END

    SELECT @result;
END
GO