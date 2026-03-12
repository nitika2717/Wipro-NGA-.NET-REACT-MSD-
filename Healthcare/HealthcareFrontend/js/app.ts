const baseUrl = "http://localhost:5049/api";


// STATUS TEXT
function getStatusText(status: any): string {

    if (status === 0 || status === "Scheduled") return "Scheduled";
    if (status === 1 || status === "Completed") return "Completed";
    if (status === 2 || status === "Cancelled") return "Cancelled";

    return "Unknown";
}



/////////////////////////////////////
// ADD PATIENT
/////////////////////////////////////

async function addPatient() {

    const fullName = (document.getElementById("fullName") as HTMLInputElement)?.value.trim();
    const dob = (document.getElementById("dob") as HTMLInputElement)?.value;

    const msg = document.getElementById("patientMessage") as HTMLParagraphElement;

    if (!fullName || !dob) {
        if (msg) msg.innerText = "Please fill all patient fields";
        return;
    }

    try {

        const response = await fetch(`${baseUrl}/Patient`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },

            body: JSON.stringify({
                name: fullName,
                dateOfBirth: dob
            })
        });

        if (!response.ok) throw new Error();

        if (msg) msg.innerText = "Patient added successfully";

        (document.getElementById("fullName") as HTMLInputElement).value = "";
        (document.getElementById("dob") as HTMLInputElement).value = "";

        loadPatients();

    }
    catch {

        if (msg) msg.innerText = "Failed to add patient";

    }

}



/////////////////////////////////////
// LOAD PATIENTS
/////////////////////////////////////

async function loadPatients() {

    const tableBody = document.getElementById("patientTableBody") as HTMLTableSectionElement;

    if (!tableBody) return;

    try {

        const response = await fetch(`${baseUrl}/Patient`);
        const patients = await response.json();

        tableBody.innerHTML = "";

        patients.forEach((p: any) => {

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

}



/////////////////////////////////////
// ADD DOCTOR
/////////////////////////////////////

async function addDoctor() {

    const name = (document.getElementById("doctorName") as HTMLInputElement)?.value;
    const departmentId = Number((document.getElementById("departmentId") as HTMLInputElement)?.value);

    const msg = document.getElementById("doctorMessage") as HTMLParagraphElement;

    if (!name || !departmentId) {

        if (msg) msg.innerText = "Please fill all fields";
        return;

    }

    try {

        const response = await fetch(`${baseUrl}/Doctor`, {

            method: "POST",
            headers: { "Content-Type": "application/json" },

            body: JSON.stringify({
                fullName: name,
                departmentId: departmentId
            })

        });

        if (!response.ok) throw new Error();

        if (msg) msg.innerText = "Doctor added successfully";

        (document.getElementById("doctorName") as HTMLInputElement).value = "";
        (document.getElementById("departmentId") as HTMLInputElement).value = "";

        loadDoctors();

    }
    catch {

        if (msg) msg.innerText = "Failed to add doctor";

    }

}



/////////////////////////////////////
// LOAD DOCTORS
/////////////////////////////////////

async function loadDoctors() {

    const tableBody = document.getElementById("doctorTableBody") as HTMLTableSectionElement;

    if (!tableBody) return;

    try {

        const response = await fetch(`${baseUrl}/Doctor`);
        const doctors = await response.json();

        tableBody.innerHTML = "";

        doctors.forEach((d: any) => {

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

}
/////////////////////////////////////
// ADD DEPARTMENT
/////////////////////////////////////

async function addDepartment() {

    const name = (document.getElementById("departmentName") as HTMLInputElement)?.value;

    const msg = document.getElementById("departmentMessage") as HTMLParagraphElement;

    if (!name) {

        if (msg) msg.innerText = "Please enter department name";
        return;

    }

    try {

        const response = await fetch(`${baseUrl}/Department`, {

            method: "POST",
            headers: { "Content-Type": "application/json" },

            body: JSON.stringify({
                name: name
            })

        });

        if (!response.ok) throw new Error();

        if (msg) msg.innerText = "Department added successfully";

        (document.getElementById("departmentName") as HTMLInputElement).value = "";

        loadDepartments();

    }
    catch {

        if (msg) msg.innerText = "Failed to add department";

    }

}



/////////////////////////////////////
// LOAD DEPARTMENTS
/////////////////////////////////////

async function loadDepartments() {

    const tableBody = document.getElementById("departmentTableBody") as HTMLTableSectionElement;

    if (!tableBody) return;

    try {

        const response = await fetch(`${baseUrl}/Department`);
        const departments = await response.json();

        tableBody.innerHTML = "";

        departments.forEach((d: any) => {

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

}



/////////////////////////////////////
// ADD APPOINTMENT
/////////////////////////////////////

async function addAppointment() {

    const patientId = Number((document.getElementById("patientId") as HTMLInputElement)?.value);
    const doctorId = Number((document.getElementById("doctorId") as HTMLInputElement)?.value);
    const appointmentDate = (document.getElementById("appointmentDate") as HTMLInputElement)?.value;

    const msg = document.getElementById("appointmentMessage") as HTMLParagraphElement;

    if (!patientId || !doctorId || !appointmentDate) {

        if (msg) msg.innerText = "Please fill all fields";
        return;

    }

    try {

        const response = await fetch(`${baseUrl}/Appointment`, {

            method: "POST",
            headers: { "Content-Type": "application/json" },

            body: JSON.stringify({
                patientId,
                doctorId,
                appointmentDate
            })

        });

        if (!response.ok) throw new Error();

        if (msg) msg.innerText = "Appointment scheduled successfully";

        (document.getElementById("patientId") as HTMLInputElement).value = "";
        (document.getElementById("doctorId") as HTMLInputElement).value = "";
        (document.getElementById("appointmentDate") as HTMLInputElement).value = "";

        loadAppointments();

    }
    catch {

        if (msg) msg.innerText = "Failed to schedule appointment";

    }

}



/////////////////////////////////////
// LOAD APPOINTMENTS + DASHBOARD
/////////////////////////////////////

async function loadAppointments() {

    const tableBody = document.getElementById("appointmentTable") as HTMLTableSectionElement;

    if (!tableBody) return;

    try {

        const response = await fetch(`${baseUrl}/Appointment`);
        const data = await response.json();

        tableBody.innerHTML = "";

        let total = data.length;
        let scheduled = 0;
        let completed = 0;
        let cancelled = 0;

        data.forEach((a: any) => {

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

        if (totalCard) totalCard.innerText = total.toString();
        if (scheduledCard) scheduledCard.innerText = scheduled.toString();
        if (completedCard) completedCard.innerText = completed.toString();
        if (cancelledCard) cancelledCard.innerText = cancelled.toString();

    }
    catch (error) {

        console.error("Failed to load appointments", error);

    }

}



/////////////////////////////////////
// COMPLETE APPOINTMENT
/////////////////////////////////////

async function completeAppointment(id: number) {

    try {

        await fetch(`${baseUrl}/Appointment/${id}/status?status=1`, {
            method: "PUT"
        });

        loadAppointments();

    }
    catch (error) {

        console.error("Error completing appointment", error);

    }

}



/////////////////////////////////////
// CANCEL APPOINTMENT
/////////////////////////////////////

async function cancelAppointment(id: number) {

    try {

        await fetch(`${baseUrl}/Appointment/${id}/status?status=2`, {
            method: "PUT"
        });

        loadAppointments();

    }
    catch (error) {

        console.error("Error cancelling appointment", error);

    }

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

(window as any).addPatient = addPatient;
(window as any).addDoctor = addDoctor;
(window as any).addAppointment = addAppointment;
(window as any).completeAppointment = completeAppointment;
(window as any).cancelAppointment = cancelAppointment;
(window as any).addDepartment = addDepartment;