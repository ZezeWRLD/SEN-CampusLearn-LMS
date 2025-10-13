# CampusLearn LMS

CampusLearn is a **Learning Management System (LMS)** designed to support online teaching, learning, and assessment through a modular, scalable, and secure architecture built using **ASP.NET Core**. It integrates user management, course delivery, topic creation, messaging, and analytics into a unified system.

---

## 🧱 System Architecture

CampusLearn follows a **multi-layered ASP.NET Core architecture**:

| **Layer**                   | **Description**                                                                                                                                                     |
| --------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Presentation Layer (UI)** | Built with **Razor Pages** or **Blazor Components**. Provides the user interface and interacts with the backend via RESTful APIs and SignalR for real-time events. |
| **API / Middleware Layer**  | **ASP.NET Core Web API** handles HTTP requests/responses, enforces validation, authentication (JWT), and role-based authorization.                                  |
| **Business / Domain Layer** | Contains core logic, including services like `UserService`, `CourseService`, `TopicService`, and `MessageService`.                                                |
| **Data Layer / Storage**    | Uses **Entity Framework Core** with a **PostgreSQL** database (3NF schema). Supports file storage and optional Redis caching.                                      |

All layers use **Dependency Injection (DI)** for maintainability, scalability, and testability.

---

## ⚙️ API Overview

CampusLearn APIs follow **RESTful conventions**:

| **Category**          | **Endpoints**                                                | **Purpose**                                  |
| --------------------- | ------------------------------------------------------------ | -------------------------------------------- |
| **User Management**   | `/api/users/register`, `/api/users/login`                   | Handles accounts and authentication         |
| **Course Management** | `/api/courses`, `/api/courses/{id}`                         | Tutors/admins manage courses                |
| **Topic Management**  | `/api/topics`                                                | Tutors create/update course topics          |
| **Messaging**         | `/api/messages`                                              | Direct messaging between users              |
| **Assessment & Q&A**  | `/api/qna`                                                   | Manage question-answer interactions         |
| **File Uploads**      | `/api/files/upload`                                          | Upload course materials (PDF, images, etc.) |

**HTTP Methods Used**:

* **GET** → Retrieve resources  
* **POST** → Create resources  
* **PUT/PATCH** → Update resources  
* **DELETE** → Remove resources  

All endpoints return **JSON** responses and standard **HTTP status codes**.

---

## 🔒 Authentication & Authorization

* **ASP.NET Identity** + **JWT tokens**  
* Tokens issued on login and validated per request  
* **Role-based access**:

  * **Student**  
  * **Tutor**  
  * **Admin**

Ensures only authorized users can perform specific actions.

---

## 🧪 Automated UI Testing

Implemented **xUnit + Selenium tests** for end-to-end validation:

| **Test**               | **Purpose**                                      |
| ---------------------- | ----------------------------------------------- |
| Login Test             | Valid credentials redirect to the dashboard     |
| Registration Test      | Confirms successful user sign-up               |
| Course Creation Test   | Validates tutor course creation workflow       |
| Topic Creation Test    | Ensures topics can be added under courses      |
| Messaging Test         | Checks message sending and chat display        |

Tests run on **Visual Studio 2022** using **ChromeDriver (headless mode)** to simulate real browser interactions.

---

## 🧩 Technology Stack

| **Category**                | **Technology / Tool**        | **Purpose**                          |
| --------------------------- | ---------------------------- | ------------------------------------ |
| **Frontend**                | Razor Pages / Blazor         | UI/UX rendering                       |
| **Backend**                 | ASP.NET Core Web API         | Business logic & endpoints            |
| **Database**                | PostgreSQL + EF Core         | Data persistence                      |
| **Authentication**          | JWT + ASP.NET Identity       | Secure token-based authentication     |
| **Real-time Communication** | SignalR                      | Chat and notifications                |
| **Testing**                 | xUnit + Selenium             | Automated UI testing                  |
| **Logging**                 | Serilog                      | Structured logging                     |
| **Caching (optional)**      | Redis                        | Performance optimization              |
| **Hosting**                 | IIS / Azure App Service      | Deployment environment                |

---

## 🔄 How It Works

Example: **User Login Flow**

1. **UI Layer** → Login page captures credentials  
2. **API Layer** → `POST /api/users/login` request sent  
3. **Business Layer** → `AuthService` validates credentials  
4. **Data Layer** → EF Core queries the `Users` table  
5. **Response** → JWT token returned to client  
6. **UI Layer** → Dashboard rendered; Selenium test verifies workflow  

This demonstrates end-to-end integration from UI to database.

---

## ✅ Core Advantages

* **Separation of Concerns** → Distinct responsibilities per layer  
* **Scalability** → Easily add new features/services  
* **Security** → JWT + HTTPS + role-based access  
* **Extensibility** → APIs can power mobile/desktop clients  
* **Testability** → Automated regression and integration tests  

---

## 📈 Project Status

Completed:

* Layered, secure architecture  
* RESTful APIs with well-defined endpoints  
* Automated UI tests for core workflows  
* Comprehensive documentation  

Potential Enhancements:

* CI/CD pipelines with GitHub Actions or Azure  
* Additional unit/mock tests with xUnit + Moq  
* Extended test coverage for error handling and authorization  

---

## 📚 References

* [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core)  
* [Entity Framework Core](https://learn.microsoft.com/ef/core)  
* [xUnit Documentation](https://xunit.net/)  
* [Selenium WebDriver](https://www.selenium.dev/documentation/webdriver/)  
