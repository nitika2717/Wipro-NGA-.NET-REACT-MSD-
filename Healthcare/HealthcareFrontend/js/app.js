// ===============================
// API BASE URL
// ===============================
const baseUrl = "http://localhost:5049/api";


// ===============================
// LOAD APPOINTMENTS
// ===============================
async function loadAppointments() {

    const tableBody = document.getElementById("appointmentTable");

    if (!tableBody) return;

    try {

        const response = await fetch(`${baseUrl}/Appointment`);
        const appointments = await response.json();

        console.log("Appointments:", appointments);

        tableBody.innerHTML = "";

        let total = appointments.length;
        let scheduled = 0;
        let completed = 0;
        let cancelled = 0;

        appointments.forEach(a => {

            let status = Number(a.status);

            let statusText = "";
            let badgeClass = "";
            let actions = "";

            // ===============================
            // STATUS CHECK
            // ===============================

            if (status === 0) {

                scheduled++;
                statusText = "Scheduled";
                badgeClass = "bg-primary";

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

            else if (status === 1) {

                completed++;
                statusText = "Completed";
                badgeClass = "bg-success";
                actions = "-";

            }

            else if (status === 2) {

                cancelled++;
                statusText = "Cancelled";
                badgeClass = "bg-danger";
                actions = "-";

            }

            else {

                statusText = "Unknown";
                badgeClass = "bg-secondary";
                actions = "-";

            }

            tableBody.innerHTML += `
            <tr>
                <td>${a.appointmentId}</td>
                <td>${a.patientId}</td>
                <td>${a.doctorId}</td>
                <td>${new Date(a.appointmentDate).toLocaleString()}</td>
                <td><span class="badge ${badgeClass}">${statusText}</span></td>
                <td>${actions}</td>
            </tr>
            `;

        });

        // ===============================
        // UPDATE DASHBOARD CARDS
        // ===============================

        const totalCard = document.getElementById("totalCount");
        const scheduledCard = document.getElementById("scheduledCount");
        const completedCard = document.getElementById("completedCount");
        const cancelledCard = document.getElementById("cancelledCount");

        if (totalCard) totalCard.innerText = total;
        if (scheduledCard) scheduledCard.innerText = scheduled;
        if (completedCard) completedCard.innerText = completed;
        if (cancelledCard) cancelledCard.innerText = cancelled;

    }

    catch (error) {

        console.error("Failed to load appointments", error);

    }

}


// ===============================
// ADD APPOINTMENT
// ===============================
async function addAppointment() {

    const patientId = Number(document.getElementById("patientId")?.value);
    const doctorId = Number(document.getElementById("doctorId")?.value);
    const appointmentDate = document.getElementById("appointmentDate")?.value;

    const msg = document.getElementById("appointmentMessage");

    if (!patientId || !doctorId || !appointmentDate) {

        if (msg) msg.innerText = "❌ Please fill all fields";
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

        if (msg) msg.innerText = "✅ Appointment scheduled";

        document.getElementById("patientId").value = "";
        document.getElementById("doctorId").value = "";
        document.getElementById("appointmentDate").value = "";

        loadAppointments();

    }

    catch {

        if (msg) msg.innerText = "❌ Failed to schedule appointment";

    }

}


// ===============================
// COMPLETE APPOINTMENT
// ===============================
async function completeAppointment(id) {

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


// ===============================
// CANCEL APPOINTMENT
// ===============================
async function cancelAppointment(id) {

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


// ===============================
// LOAD PAGE
// ===============================
document.addEventListener("DOMContentLoaded", () => {

    loadAppointments();

});


// ===============================
// EXPOSE FUNCTIONS TO HTML
// ===============================
window.addAppointment = addAppointment;
window.completeAppointment = completeAppointment;
window.cancelAppointment = cancelAppointment;