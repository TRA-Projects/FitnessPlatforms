# 🏋️ Fitness Platform API

An integrated backend system built with **.NET 8 Web API** for managing fitness platform operations, including users, trainers, members, workout programs, nutrition plans, subscriptions, and automated email notifications.

---

## 🚀 Features

- 🔐 Authentication & Authorization using JWT
- 👥 Role-Based Access Control (Admin, Trainer, Member)
- 🔑 Secure password hashing with BCrypt
- 📧 Automatic Welcome Email using MailKit
- 👤 User & Member Management
- 🏋️ Trainer Management
- 💳 Membership Plans & Subscriptions
- 💪 Workout Programs & Exercises
- 🥗 Nutrition Plans
- 📏 Body Measurements Tracking
- 📅 Workout Sessions
- 📄 Swagger API Documentation

---

## 🛠 Tech Stack

- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- BCrypt.Net
- MailKit & MimeKit
- Swagger / OpenAPI

---

## 📂 Project Structure

```text
FitnessPlatform/
│
├── Configurations/      # Configuration classes (EmailSettings, JWT, etc.)
├── Controllers/         # API Controllers
├── DTOs/                # Data Transfer Objects
├── Models/              # Database Models
├── Repos/               # Repository Layer
│   └── Interfaces/
├── Services/            # Business Logic
├── Data/                # DbContext
├── appsettings.json
└── Program.cs
```

---

## 📊 Database Entities

- User
- Member
- Trainer
- MembershipPlan
- Subscription
- WorkoutProgram
- Exercise
- ProgramExercise
- WorkoutSession
- NutritionPlan
- BodyMeasurement

---

## 🔑 Authentication

The API uses **JWT Bearer Token Authentication**.

After login, include the token in every request:

```http
Authorization: Bearer YOUR_TOKEN
```

---

## 📧 Email Notifications

The system automatically sends a welcome email after successful user registration using SMTP with **MailKit**.

---

## 📚 API Documentation

Swagger is enabled for testing all API endpoints.

```
https://localhost:5001/swagger
```

---

## ⚙️ Installation

1. Clone the repository

```bash
git clone https://github.com/YourUsername/FitnessPlatform.git
```

2. Navigate to the project

```bash
cd FitnessPlatform
```

3. Restore packages

```bash
dotnet restore
```

4. Update the database

```bash
dotnet ef database update
```

5. Run the project

```bash
dotnet run
```

---

## 👩‍💻 Authors

Developed as a Graduation Project using **ASP.NET Core Web API**.