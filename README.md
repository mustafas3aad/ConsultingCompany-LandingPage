<h1 align="center">
  🏢 Consulting Company – Landing Page Backend API
</h1>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-10-512BD4?style=flat-square&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Architecture-N--Tier-9333EA?style=flat-square" />
  <img src="https://img.shields.io/badge/SQL_Server-Database-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white" />
  <img src="https://img.shields.io/badge/ORM-Entity_Framework_Core-512BD4?style=flat-square" />
  <img src="https://img.shields.io/badge/Pattern-Repository_%26_UoW-0ea5e9?style=flat-square" />
  <img src="https://img.shields.io/badge/Email-SMTP_Templates-f59e0b?style=flat-square" />
</p>

---

<h2 align="center">🌐 Frontend & Live Demo</h2>

<div align="center">

<a href="https://github.com/mustafas3aad/consulting-company-ui" target="_blank">
  <img src="https://img.shields.io/badge/💻_Frontend_Repository-181717?style=for-the-badge&logo=github&logoColor=white" />
</a>

<br/>

<a href="https://novaedge-consulting.vercel.app" target="_blank">
  <img src="https://img.shields.io/badge/🚀_Live_Demo-000000?style=for-the-badge&logo=vercel&logoColor=white" />
</a>

</div>

---

## 📖 Overview

**Consulting Company API** is a clean, scalable, and secure **RESTful API** built with **ASP.NET Core 8**, designed to power the backend of a consulting company's landing page. The system handles lead management, contact submissions, service showcasing, and internal operations.

Built following **N-Tier Architecture** principles to enforce a clear separation of concerns across presentation, business logic, data access, and shared utilities.

---

## ✨ Key Features

- **Contact & Lead Management:** Capture and manage inquiries from landing page visitors.
- **Localization Support:** Full multi-language support via localization resource files.
- **Email Notifications:** Automated email templates for contact confirmations and internal alerts.
- **Pagination & Filtering:** Built-in pagination helpers and query param models for scalable data retrieval.
- **Specification Pattern:** Flexible and reusable query specifications in the DAL.
- **Unit of Work:** Atomic transaction management across repositories.
- **Custom Middleware & Logging:** Centralized error handling and structured logging.

---

## 🏗️ Architecture Overview

The solution follows a classic **N-Tier (Layered) Architecture** divided into 5 projects:

```
ConsultingCompany/
├── ConsultingCompany.API        → Presentation layer (Controllers, Middleware, DI)
├── ConsultingCompany.BLL        → Business Logic Layer (Services, DTOs, Mapping)
├── ConsultingCompany.DAL        → Data Access Layer (EF Core, Repos, UoW)
├── ConsultingCompany.Shared     → Cross-cutting concerns (Pagination, Localization)
└── ConsultingCompany.Tests      → Unit Tests
```

### Layer Responsibilities

| Layer | Responsibility |
|-------|----------------|
| **API** | Controllers, middleware, extensions, factories, and app entry point |
| **BLL** | Business logic services, contracts (interfaces), DTOs, AutoMapper profiles, custom exceptions, and email templates |
| **DAL** | EF Core DbContext, entities, enums, repository pattern, specification pattern, and Unit of Work |
| **Shared** | Localization, pagination, query parameters, and cross-cutting utility helpers |
| **Tests** | Unit tests for BLL services |

---

## 💻 Tech Stack

| | Technology | | Technology |
|--|------------|--|------------|
| **Framework** | ASP.NET Core 8 | **Language** | C# |
| **Database** | Microsoft SQL Server | **ORM** | Entity Framework Core | | **Mapping** | AutoMapper |
| **Architecture** | N-Tier (API → BLL → DAL) | **Patterns** | Repository, Specification, Unit of Work |
| **Email** | SMTP with HTML Templates | **Localization** | .resx Resource Files (AR / EN) |

---

## 📁 Project Structure

```
ConsultingCompany/
│
├── ConsultingCompany.API/
│   ├── Controllers/               → API endpoint controllers
│   ├── Extensions/                → Service collection & middleware extensions
│   ├── Factories/                 → Object creation / factory classes
│   ├── Logs/                      → Log files output
│   ├── MiddleWares/               → Custom middleware (error handling, etc.)
│   ├── Properties/                → Launch settings
│   ├── appsettings.json           → App configuration
│   ├── ConsultingCompany.API.http → HTTP test requests
│   └── Program.cs                 → Entry point & DI configuration
│
├── ConsultingCompany.BLL/
│   ├── Contracts/                 → Service interfaces (abstractions)
│   ├── DTOs/                      → Data Transfer Objects
│   ├── Exceptions/                → Custom exception classes
│   ├── Mapping/                   → AutoMapper profiles
│   ├── Services/                  → Business logic implementations
│   └── Templates/                 → Email / notification templates
│
├── ConsultingCompany.DAL/
│   ├── Data/                      → DbContext & seed data
│   ├── Entities/                  → Database entity models
│   ├── Enums/                     → Enum definitions
│   ├── Repositories/              → Repository pattern implementations
│   ├── Specifications/            → Query specification classes
│   └── UnitOfWork/                → Unit of Work pattern
│
├── ConsultingCompany.Shared/
│   ├── Localization/              → Multi-language resource files (AR/EN)
│   ├── Pagination/                → Pagination helpers & models
│   ├── QueryParams/               → Common query parameter models
│   └── Utility/                   → Shared utility/helper classes
│
└── ConsultingCompany.Tests/
    └── Services/                  → Unit tests for BLL services
```

## 👨‍💻 Author
 
<p>
  <a href="https://github.com/mustafas3aad" target="_blank">
    <img src="https://img.shields.io/badge/GitHub-mustafas3aad-181717?style=for-the-badge&logo=github&logoColor=white&labelColor=181717" />
  </a>
</p>


---
 
## 📸 Screenshots
 
<div align="center">
  <table border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><img src="https://github.com/user-attachments/assets/feddc43f-7e99-49c5-8b37-faf972e63614" width="100%" /></td>
      <td><img src="https://github.com/user-attachments/assets/c015bfad-4150-4cc6-afff-8b7e5452ca4d" width="100%" /></td>
    </tr>
  </table>
  <br/>
  <img src="https://github.com/user-attachments/assets/f861abb5-605a-42fb-be2b-d52777e9aac0" width="80%" />
</div>




