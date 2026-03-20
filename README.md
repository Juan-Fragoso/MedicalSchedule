# MedicalSchedule

Aplicación web para la gestión de citas médicas, pacientes, médicos y especialidades.  
Desarrollada en .NET 10

## 🏥 Descripción
MedicalSchedule es una API RESTful que permite administrar la programación de citas médicas, así como la gestión de pacientes, médicos y especialidades.  
Incluye endpoints para operaciones CRUD y consultas especializadas.

## 🚀 Contexto y Arquitectura
El sistema se desarrolló siguiendo una Arquitectura en Capas (N-Tier Architecture) para garantizar la escalabilidad y facilidad de mantenimiento:

* Capa de API (Presentación): Controladores REST que gestionan las peticiones HTTP y validan los modelos de entrada.

* Capa de Servicios (Lógica de Negocio): Donde reside toda la inteligencia del sistema: validación de horarios, cálculo de duraciones de citas, gestión de transacciones (Commit/Rollback) y registro de auditoría.

* Capa de Datos (Repositorios): Abstracción de la base de datos utilizando Entity Framework Core para operaciones CRUD y ejecución de procedimientos almacenados.

* Capa de Modelos: Entidades de base de datos e interfaces compartidas.


## 🛠️ Especificaciones Técnicas
IDE: Visual Studio 2026 (Versión 18.3.0)

Framework: .NET 10.0

Base de Datos: SQL Server 2022+

ORM: Entity Framework Core con soporte para Transacciones y SQL Raw.

## Instalación

1. Clona el repositorio:
```
git clone https://github.com/Juan-Fragoso/MedicalSchedule.git
```
2. Abre la solución en Visual Studio.
3. Configura la cadena de conexión en `appsettings.json`.
4. Ejecuta las migraciones y el seed de datos si es necesario.
5. Inicia el proyecto.


## ⚙️ Instalación y Configuración
1. Base de Datos
Siga este orden estrictamente para preparar el entorno:

* Esquema: Ejecute el script en /database/schema.sql para crear la base de datos MedicalScheduleDB y sus tablas.

* Procedimientos Almacenados: Ejecute los scripts en /database/Stored Procedures/.

* Importante: Verifique que el usuario de la base de datos tenga permisos de ejecución (GRANT EXECUTE) sobre estos procedimientos.

* Datos de Ejemplo: Ejecute el script en /database/SeedData.sql/ para poblar el catálogo de especialidades, doctores y estatus iniciales.


## Endpoints y Ejemplos de JSON

### 1. Especialidades (`/api/Specialties`)

#### Obtener todas las especialidades
- **GET** `/api/Specialties`
- **Respuesta ejemplo:**
```json
[
   {
        "specialtyId": 1,
        "name": "Medicina General",
        "durationMinutes": 20,
        "createdAt": "2026-03-19T20:32:18.03"
    },
    {
        "specialtyId": 2,
        "name": "Cardiologia",
        "durationMinutes": 30,
        "createdAt": "2026-03-19T20:32:18.03"
    }
]
```

#### Obtener especialidad por ID
- **GET** `/api/Specialties/{id}`
- **Respuesta ejemplo:**
```json
 {
      "specialtyId": 1,
      "name": "Medicina General",
      "durationMinutes": 20,
      "createdAt": "2026-03-19T20:32:18.03"
  }
```

#### Crear especialidad
- **POST** `/api/Specialties`
- **JSON de entrada:**
```json
  {
      "name": "Ginecología",
      "durationMinutes": 30
  }
```
- **Respuesta:**
```json
{
    "specialtyId": 1,
    "name": "Ginecología",
    "durationMinutes": 30,
    "createdAt": "2026-03-19T20:27:48.3540004-06:00"
}
```

### 2. Pacientes (`/api/Patients`)

#### Obtener todos los pacientes
- **GET** `/api/Patients`
- **Respuesta ejemplo:**
```json
[
  {
        "patientId": 1,
        "fullName": "Gabriela Macias",
        "birthDate": "1980-01-01T00:00:00",
        "phoneNumber": "8183381000",
        "email": "gabrielamacias@mail.com",
        "createdAt": "2026-03-19T20:32:18.03",
    },
    {
        "patientId": 2,
        "fullName": "Geraldine viveros",
        "birthDate": "1981-02-02T00:00:00",
        "phoneNumber": "8183381001",
        "email": "geraldineviveros@mail.com",
        "createdAt": "2026-03-19T20:32:18.03",
    },
]
```

#### Obtener paciente por ID
- **GET** `/api/Patients/{id}`
- **Respuesta ejemplo:**
```json
{
    "patientId": 1,
    "fullName": "Gabriela Macias",
    "birthDate": "1980-01-01T00:00:00",
    "phoneNumber": "8183381000",
    "email": "gabrielamacias@mail.com",
    "createdAt": "2026-03-19T20:32:18.03",
}
```
#### Crear paciente
- **POST** `/api/Patients`
- **JSON de entrada:**
```json
{
  "FullName": "Carlos Ruiz",
  "BirthDate": "2001-07-15",
  "PhoneNumber": "8183381000",
  "Email": "carlos@example.com"
}
```
- **Respuesta:**
```json
{
    "patientId": 11,
    "fullName": "Carlos Ruiz",
    "birthDate": "2001-07-15T00:00:00",
    "phoneNumber": "8183381000",
    "email": "carlos@example.com",
    "createdAt": "2026-03-19T21:31:54.9549733-06:00",
}
```

#### Actualizar paciente
- **PUT** `/api/Patients`
- **JSON de entrada:**
```json
{
  "PatientId": 4,
  "FullName": "Julio Rojas",
  "BirthDate": "2014-02-15",
  "PhoneNumber": "8184858964",
  "Email": "julio@example.com"
}
```
- **Respuesta:**
```json
{ "message": "Paciente actualizado" }
```

#### Eliminar paciente
- **DELETE** `/api/Patients/{id}`
- **Respuesta:**
```json
{ "message": "Paciente eliminado." }
```
---

### 3. Médicos (`/api/Doctors`)

#### Obtener todos los médicos
- **GET** `/api/Doctors`
- **Respuesta ejemplo:**
```json
[
   {
        "doctorId": 1,
        "fullName": "Dr. Juan Fragoso",
        "specialtyId": 1,
        "specialty": {
            "specialtyId": 1,
            "name": "Medicina General",
            "durationMinutes": 20,
        },
    },
    {
        "doctorId": 2,
        "fullName": "Dr. Perez Royal",
        "specialtyId": 1,
        "specialty": {
            "specialtyId": 1,
            "name": "Medicina General",
            "durationMinutes": 20,
        }
    },
]
```

#### Obtener médico por ID
- **GET** `/api/Doctors/{id}`
- **Respuesta ejemplo:**
```json
{
    "doctorId": 1,
    "fullName": "Dr. Juan Fragoso",
    "specialtyId": 1,
    "createdAt": "2026-03-19T20:32:18.03",
    "specialty": {
        "specialtyId": 1,
        "name": "Medicina General",
        "durationMinutes": 20,
    },
    "schedules": [
        {
            "doctorScheduleId": 1,
            "dayId": 1,
            "startTime": "08:00:00",
            "endTime": "14:00:00",
        }
    ]
}
```


#### Crear médico
##### schedules: DayId debe corresponder a los IDs de la tabla Days (1-7).
- **POST** `/api/Doctors`
- **JSON de entrada:**
```json
{
  "fullName": "Juan Jose ",
  "specialtyId": 2,
  "schedules": [
        {
            "DayId": 1, 
            "endTime": "14:00:00"
        },
        {
            "DayId": 2,
            "startTime": "09:00:00",
            "endTime": "15:00:00"
        },
        {
            "DayId": 3,
            "startTime": "09:00:00",
            "endTime": "15:00:00"
        }
     
    ]
}
```
- **Respuesta:**
```json
{
    "doctorId": 11,
    "fullName": "Juan reys ",
    "specialtyId": 1,
    "specialty": {
        "specialtyId": 1,
        "name": "Medicina General",
        "durationMinutes": 20,
    },
    "schedules": [
        {
            "doctorScheduleId": 32,
            "doctorId": 11,
            "dayId": 1,
            "startTime": "00:00:00",
            "endTime": "14:00:00",
        }        
    ]
}
```

#### Actualizar médico
En el método put el array de objetos schedules es opcional
- **PUT** `/api/Doctors`
- **JSON de entrada:**
```json
{
  "DoctorId":12,
  "fullName": "Dra Maria Gomez",
  "specialtyId": 1 ,
  "schedules": [
        {
            "DayId": 1, 
            "startTime": "09:00:00",
            "endTime": "13:00:00"
        }   
    ]
}
```
- **Respuesta:**
```json
{ "message": "Médico actualizado" }
```

#### Eliminar médico
- **DELETE** `/api/Doctors/{id}`
- **Respuesta:**
```json
{ "message": "Doctor eliminado exitosamente" }
```
---

### 4. Citas (`/api/Appointments`)

#### Obtener todas las citas
- **GET** `/api/Appointments`
- **Respuesta ejemplo:**
```json
[
  {
        "appointmentId": 8,
        "doctorId": 1,
        "patientId": 5,
        "startDateTime": "2026-03-27T10:00:00",
        "endDateTime": "2026-03-27T10:20:00",
        "reason": "Chequeo",
        "appointmentStatusId": 1,
        "cancelationReason": null,
        "createdAt": "2026-03-19T20:32:18.03",
        "doctor": {
            "doctorId": 1,
            "fullName": "Dr. Juan Fragoso",
            "specialtyId": 1,
        },
    },
]
```

#### Crear cita
- **POST** `/api/Appointments`
- **JSON de entrada:**
```json
{
    "DoctorId": 1,
    "PatientId": 1,
    "StartDateTime": "2026-03-20T10:30:00",
    "Reason": "consulta general",
    "AppointmentStatusId": 1
}

```
- **Respuesta:**
```json
{
   "message": "Cita agendada correctamente. ",
    "data": {
        "appointmentId": 11,
        "alert": ""
    }
}
```
- **Error:**
```json
{
    "message": "El horario no está disponible.",
    "suggestions": {
        "suggestedDates": [
            "2026-03-20T11:10:00",
            "2026-03-20T11:30:00",
            "2026-03-20T11:50:00",
            "2026-03-20T12:10:00",
            "2026-03-20T12:30:00"
        ]
    }
}
```

#### Cancelar cita
- **PATCH** `/api/Appointments/cancel`
- **JSON de entrada:**
```json
{
  "appointmentId": 1,
  "cancelationReason": "Paciente no puede asistir"
}
```
- **Respuesta:**
```json
{ "message": "Cita cancelada exitosamente" }
```

#### Obtener agenda de un médico
- **GET** `/api/Appointments/agenda?doctorId={id}&date={fecha}`
- **Respuesta ejemplo:**
```json
[
   {
        "appointmentStartTime": "2026-03-20T10:30:00",
        "appointmentEndTime": "2026-03-20T10:50:00",
        "patientName": "Gabriela Macias",
        "patientPhoneNumber": "8183381000",
        "appointmentReason": "consulta general",
        "appointmentStatus": "Cancelada"
    },
]
```
- **Error:**
```json
{ "message": "No hay citas programadas para este médico en la fecha seleccionada." }
```

#### Obtener historial de un paciente
- **GET** `/api/Appointments/patient/{patientId}/history`
- **Respuesta ejemplo:**
```json
[
  {
    "patientFullName": "Valeria Gonzalez",
    "doctorName": "Dra. Fernanda Coronado",
    "specialityName": "Ginecologia",
    "appointmentStartTime": "2026-03-05T09:00:00",
    "appointmentEndTime": "2026-03-05T09:30:00",
    "appointmentStatus": "Cancelada"
  },
]
```


#### Obtener agenda disponible de un médico
- **GET** `/api/Appointments/availableAgenda?doctorId={id}&date={fecha}`
- **Respuesta ejemplo:**
```json
{
  "message": "Horarios disponibles",
  "availableSlots": [
    "2024-06-01T09:00:00",
    "2024-06-01T11:00:00"
  ]
}
```
- **Error:**
```json
{ "message": "No hay horarios disponibles" }
```
---
## 🛡️ Manejo de Errores y Logs
El sistema cuenta con un bloqueador de errores global. Cualquier fallo técnico (como conflictos de llaves foráneas) se registra automáticamente en la tabla SystemLog.

Transaccionalidad: Todas las operaciones de escritura utilizan BeginTransactionAsync. Si algo falla, se realiza un Rollback automático para mantener la integridad de la base de datos.

Limpieza de Estado: Se implementó ChangeTracker.Clear() para asegurar que los registros de error se guarden correctamente sin arrastrar estados corruptos de la memoria de EF Core.
