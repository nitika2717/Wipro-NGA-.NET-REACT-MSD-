"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
const baseUrl = "http://localhost:5049/api";
// STATUS TEXT
function getStatusText(status) {
    if (status === 0 || status === "Scheduled")
        return "Scheduled";
    if (status === 1 || status === "Completed")
        return "Completed";
    if (status === 2 || status === "Cancelled")
        return "Cancelled";
    return "Unknown";
}
/////////////////////////////////////
// ADD PATIENT
/////////////////////////////////////
function addPatient() {
    return __awaiter(this, void 0, void 0, function* () {
        var _a, _b;
        const fullName = (_a = document.getElementById("fullName")) === null || _a === void 0 ? void 0 : _a.value.trim();
        const dob = (_b = document.getElementById("dob")) === null || _b === void 0 ? void 0 : _b.value;
        const msg = document.getElementById("patientMessage");
        if (!fullName || !dob) {
            if (msg)
                msg.innerText = "Please fill all patient fields";
            return;
        }
        try {
            const response = yield fetch(`${baseUrl}/Patient`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    name: fullName,
                    dateOfBirth: dob
                })
            });
            if (!response.ok)
                throw new Error();
            if (msg)
                msg.innerText = "Patient added successfully";
            document.getElementById("fullName").value = "";
            document.getElementById("dob").value = "";
            loadPatients();
        }
        catch (_c) {
            if (msg)
                msg.innerText = "Failed to add patient";
        }
    });
}
/////////////////////////////////////
// LOAD PATIENTS
/////////////////////////////////////
function loadPatients() {
    return __awaiter(this, void 0, void 0, function* () {
        const tableBody = document.getElementById("patientTableBody");
        if (!tableBody)
            return;
        try {
            const response = yield fetch(`${baseUrl}/Patient`);
            const patients = yield response.json();
            tableBody.innerHTML = "";
            patients.forEach((p) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${p.patientId}</td>
                <td>${p.name}</td>
                <td>${new Date(p.dateOfBirth).toLocaleDateString()}</td>
            `;
                tableBody.appendChild(row);
            });
        }
        catch (error) {
            console.error("Failed to load patients", error);
        }
    });
}
/////////////////////////////////////
// ADD DOCTOR
/////////////////////////////////////
function addDoctor() {
    return __awaiter(this, void 0, void 0, function* () {
        var _a, _b;
        const name = (_a = document.getElementById("doctorName")) === null || _a === void 0 ? void 0 : _a.value;
        const departmentId = Number((_b = document.getElementById("departmentId")) === null || _b === void 0 ? void 0 : _b.value);
        const msg = document.getElementById("doctorMessage");
        if (!name || !departmentId) {
            if (msg)
                msg.innerText = "Please fill all fields";
            return;
        }
        try {
            const response = yield fetch(`${baseUrl}/Doctor`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    fullName: name,
                    departmentId: departmentId
                })
            });
            if (!response.ok)
                throw new Error();
            if (msg)
                msg.innerText = "Doctor added successfully";
            document.getElementById("doctorName").value = "";
            document.getElementById("departmentId").value = "";
            loadDoctors();
        }
        catch (_c) {
            if (msg)
                msg.innerText = "Failed to add doctor";
        }
    });
}
/////////////////////////////////////
// LOAD DOCTORS
/////////////////////////////////////
function loadDoctors() {
    return __awaiter(this, void 0, void 0, function* () {
        const tableBody = document.getElementById("doctorTableBody");
        if (!tableBody)
            return;
        try {
            const response = yield fetch(`${baseUrl}/Doctor`);
            const doctors = yield response.json();
            tableBody.innerHTML = "";
            doctors.forEach((d) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${d.id}</td>
                <td>${d.fullName}</td>
                <td>${d.departmentId}</td>
            `;
                tableBody.appendChild(row);
            });
        }
        catch (error) {
            console.error("Failed to load doctors", error);
        }
    });
}
/////////////////////////////////////
// ADD DEPARTMENT
/////////////////////////////////////
function addDepartment() {
    return __awaiter(this, void 0, void 0, function* () {
        var _a;
        const name = (_a = document.getElementById("departmentName")) === null || _a === void 0 ? void 0 : _a.value;
        const msg = document.getElementById("departmentMessage");
        if (!name) {
            if (msg)
                msg.innerText = "Please enter department name";
            return;
        }
        try {
            const response = yield fetch(`${baseUrl}/Department`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    name: name
                })
            });
            if (!response.ok)
                throw new Error();
            if (msg)
                msg.innerText = "Department added successfully";
            document.getElementById("departmentName").value = "";
            loadDepartments();
        }
        catch (_b) {
            if (msg)
                msg.innerText = "Failed to add department";
        }
    });
}
/////////////////////////////////////
// LOAD DEPARTMENTS
/////////////////////////////////////
function loadDepartments() {
    return __awaiter(this, void 0, void 0, function* () {
        const tableBody = document.getElementById("departmentTableBody");
        if (!tableBody)
            return;
        try {
            const response = yield fetch(`${baseUrl}/Department`);
            const departments = yield response.json();
            tableBody.innerHTML = "";
            departments.forEach((d) => {
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${d.id}</td>
                <td>${d.name}</td>
            `;
                tableBody.appendChild(row);
            });
        }
        catch (error) {
            console.error("Failed to load departments", error);
        }
    });
}
/////////////////////////////////////
// ADD APPOINTMENT
/////////////////////////////////////
function addAppointment() {
    return __awaiter(this, void 0, void 0, function* () {
        var _a, _b, _c;
        const patientId = Number((_a = document.getElementById("patientId")) === null || _a === void 0 ? void 0 : _a.value);
        const doctorId = Number((_b = document.getElementById("doctorId")) === null || _b === void 0 ? void 0 : _b.value);
        const appointmentDate = (_c = document.getElementById("appointmentDate")) === null || _c === void 0 ? void 0 : _c.value;
        const msg = document.getElementById("appointmentMessage");
        if (!patientId || !doctorId || !appointmentDate) {
            if (msg)
                msg.innerText = "Please fill all fields";
            return;
        }
        try {
            const response = yield fetch(`${baseUrl}/Appointment`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    patientId,
                    doctorId,
                    appointmentDate
                })
            });
            if (!response.ok)
                throw new Error();
            if (msg)
                msg.innerText = "Appointment scheduled successfully";
            document.getElementById("patientId").value = "";
            document.getElementById("doctorId").value = "";
            document.getElementById("appointmentDate").value = "";
            loadAppointments();
        }
        catch (_d) {
            if (msg)
                msg.innerText = "Failed to schedule appointment";
        }
    });
}
/////////////////////////////////////
// LOAD APPOINTMENTS + DASHBOARD
/////////////////////////////////////
function loadAppointments() {
    return __awaiter(this, void 0, void 0, function* () {
        const tableBody = document.getElementById("appointmentTable");
        if (!tableBody)
            return;
        try {
            const response = yield fetch(`${baseUrl}/Appointment`);
            const data = yield response.json();
            tableBody.innerHTML = "";
            let total = data.length;
            let scheduled = 0;
            let completed = 0;
            let cancelled = 0;
            data.forEach((a) => {
                let actions = "";
                if (a.status === 0 || a.status === "Scheduled") {
                    scheduled++;
                    actions = `
                    <button class="btn btn-success btn-sm me-2"
                        onclick="completeAppointment(${a.appointmentId})">
                        Complete
                    </button>

                    <button class="btn btn-danger btn-sm"
                        onclick="cancelAppointment(${a.appointmentId})">
                        Cancel
                    </button>
                `;
                }
                else if (a.status === 1 || a.status === "Completed") {
                    completed++;
                    actions = "-";
                }
                else if (a.status === 2 || a.status === "Cancelled") {
                    cancelled++;
                    actions = "-";
                }
                const row = document.createElement("tr");
                row.innerHTML = `
                <td>${a.appointmentId}</td>
                <td>${a.patientId}</td>
                <td>${a.doctorId}</td>
                <td>${new Date(a.appointmentDate).toLocaleString()}</td>
                <td>${getStatusText(a.status)}</td>
                <td>${actions}</td>
            `;
                tableBody.appendChild(row);
            });
            // UPDATE DASHBOARD CARDS
            const totalCard = document.getElementById("totalCount");
            const scheduledCard = document.getElementById("scheduledCount");
            const completedCard = document.getElementById("completedCount");
            const cancelledCard = document.getElementById("cancelledCount");
            if (totalCard)
                totalCard.innerText = total.toString();
            if (scheduledCard)
                scheduledCard.innerText = scheduled.toString();
            if (completedCard)
                completedCard.innerText = completed.toString();
            if (cancelledCard)
                cancelledCard.innerText = cancelled.toString();
        }
        catch (error) {
            console.error("Failed to load appointments", error);
        }
    });
}
/////////////////////////////////////
// COMPLETE APPOINTMENT
/////////////////////////////////////
function completeAppointment(id) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            yield fetch(`${baseUrl}/Appointment/${id}/status?status=1`, {
                method: "PUT"
            });
            loadAppointments();
        }
        catch (error) {
            console.error("Error completing appointment", error);
        }
    });
}
/////////////////////////////////////
// CANCEL APPOINTMENT
/////////////////////////////////////
function cancelAppointment(id) {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            yield fetch(`${baseUrl}/Appointment/${id}/status?status=2`, {
                method: "PUT"
            });
            loadAppointments();
        }
        catch (error) {
            console.error("Error cancelling appointment", error);
        }
    });
}
/////////////////////////////////////
// PAGE LOAD
/////////////////////////////////////
window.onload = () => {
    if (document.getElementById("patientTableBody")) {
        loadPatients();
    }
    if (document.getElementById("appointmentTable")) {
        loadAppointments();
    }
    if (document.getElementById("doctorTableBody")) {
        loadDoctors();
    }
    if (document.getElementById("departmentTableBody")) {
        loadDepartments();
    }
};
/////////////////////////////////////
// EXPOSE FUNCTIONS TO HTML
/////////////////////////////////////
window.addPatient = addPatient;
window.addDoctor = addDoctor;
window.addAppointment = addAppointment;
window.completeAppointment = completeAppointment;
window.cancelAppointment = cancelAppointment;
window.addDepartment = addDepartment;
