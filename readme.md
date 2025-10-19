# 🏎️ CDA Ruedas Felices

**CDA Ruedas Felices** is a console-based application developed in **C# (.NET 8)**  
for managing a **Vehicle Inspection Center (CDA)**.  
It allows you to register clients, inspectors, and vehicles, and schedule mechanical inspection appointments,  
ensuring no duplicate records, validating compatibility, and maintaining a log of all emails sent.

---

## 🚀 Main Features

- 👥 **Client Management:** Register, edit, validate by ID, and list all clients.
- 🧍‍♂️ **Inspector Management:** Register, edit, and filter inspectors by inspection type.
- 🚗 **Vehicle Management:** Register vehicles per client, validate unique plates, search by plate.
- 📅 **Appointment Management:** Schedule, cancel, complete, and validate conflicting appointments.
- 📧 **Email System:** Simulates email notifications and keeps a full log of sent messages.
- 🧱 **Layered Architecture:** Organized into `Models`, `Data`, `Interfaces`, `Repositories`, `Services`, and `Menus`.

---

## 🧩 Project Structure

RuedasFelices/
│
├── Data/
│ └── Database.cs
│
├── Interfaces/
│ ├── IClientRepository.cs
│ ├── IInspectorRepository.cs
│ ├── IVehicleRepository.cs
│ ├── IAppointmentRepository.cs
│ ├── IEmailLogRepository.cs
│ └── IEmailService.cs
│
├── Models/
│ ├── Person.cs
│ ├── Client.cs
│ ├── Inspector.cs
│ ├── Vehicle.cs
│ ├── Appointment.cs
│ └── EmailLog.cs
│
├── Repositories/
│ ├── ClientRepository.cs
│ ├── InspectorRepository.cs
│ ├── VehicleRepository.cs
│ ├── AppointmentRepository.cs
│ └── EmailLogRepository.cs
│
├── Services/
│ ├── ClientService.cs
│ ├── InspectorService.cs
│ ├── VehicleService.cs
│ ├── AppointmentService.cs
│ ├── EmailService.cs
│ └── EmailSender.cs
│
├── Menus/
│ ├── MainMenu.cs
│ ├── ClientMenu.cs
│ ├── InspectorMenu.cs
│ ├── VehicleMenu.cs
│ ├── AppointmentMenu.cs
│ └── EmailLogMenu.cs
│
└── Program.cs


---

## ⚙️ Installation and Execution

### 1️⃣ Clone the repository
```bash
git clone https://github.com/YOUR_USERNAME/CDA-Ruedas-Felices.git
cd CDA-Ruedas-Felices

2️⃣ Build the project

dotnet build

3️⃣ Run the application

dotnet run

🧠 Requirements

    ✅ .NET 8 SDK
    Download here

    💻 Visual Studio 2022 or VS Code

    💾 MySQL / PostgreSQL (optional, for future persistence layer)

🏗️ Layered Architecture Overview
Layer	Purpose	Example
Models	Domain entities	Client, Vehicle, Appointment
Data	In-memory data source	Database.cs
Interfaces	Contracts for repositories and services	IClientRepository
Repositories	Implement data access logic	ClientRepository
Services	Business logic and validation	AppointmentService
Menus	Console user interface	MainMenu, ClientMenu
🧪 Execution Flow

Program.cs
   ↓
MainMenu.Show()
   ↓
(Modules: ClientMenu, VehicleMenu, etc.)
   ↓
Services (business logic)
   ↓
Repositories (data access)
   ↓
Database (in-memory storage)

💡 Example Workflow
Scheduling an Appointment

    Register a new client.

    Register a vehicle linked to that client.

    Register an inspector with a specific inspection type.

    Navigate to Appointments → Add Appointment.

    The system validates:

        No overlapping appointments for the same vehicle or inspector.

        The inspector’s inspection type matches the vehicle type.

    Once valid, the appointment is saved and a confirmation email (simulated) is sent.

📨 Email System

The system uses a simulated email sender (EmailSender) that displays sent messages in the console.
All email logs are stored in memory (Database.EmailLogs)
and can be viewed through:

Main Menu → Option 5 (Email Log)



👨‍💻 Author

Developed by: Jafit Barraza Barbosa
Academic Development Team — CDA Ruedas Felices Project
📚 Based on the performance test: Mechanical Inspection Scheduling System
🔗 References: SanVicenteHospital and MedicalAppointments repositories on GitHub.
🪪 License

This project is released under the MIT License.
You are free to use, modify, and distribute it for educational or personal purposes.
