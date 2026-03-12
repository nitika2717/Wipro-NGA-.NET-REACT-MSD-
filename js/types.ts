// TypeScript types and enums

export interface Patient {
    patientId: number;
    name: string;
    dateOfBirth: string;
}

export interface Appointment {
    appointmentId: number;
    patientId: number;
    doctorId: number;
    appointmentDate: string;
    status: AppointmentStatus;
}

export enum AppointmentStatus {
    Scheduled = 0,
    Completed = 1,
    Cancelled = 2
}