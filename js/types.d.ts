export interface Patient {
    patientId: number;
    name: string;
    dateOfBirth: string;
}
export interface Doctor {
    id: number;
    fullName: string;
    departmentId: number;
}
export declare enum AppointmentStatus {
    Pending = 0,
    Scheduled = 1,
    Completed = 2
}
export interface Appointment {
    appointmentId: number;
    patientId: number;
    doctorId: number;
    appointmentDate: string;
    status: AppointmentStatus;
    patient?: Patient;
    doctor?: Doctor;
}
//# sourceMappingURL=types.d.ts.map