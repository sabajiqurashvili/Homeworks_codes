Loan API
RESTful Web API სესხების მართვისთვის, რომელიც უზრუნველყოფს მომხმარებლისა და ბუღალტრის (Accountant) როლებზე დაფუძნებულ ავტორიზაციას, სესხის მოთხოვნას, მართვას და კონტროლს.
________________________________________
📌 Overview
Loan API საშუალებას აძლევს მომხმარებლებს მოითხოვონ სესხი, ნახონ და მართონ მხოლოდ საკუთარი სესხები, ხოლო Accountant როლს აქვს სრული წვდომა ყველა სესხზე და მომხმარებლების დაბლოკვის შესაძლებლობა.
პროექტი აგებულია REST principles-ის მიხედვით, გამოიყენება JWT Authentication, Role-Based Authorization და Clean Architecture მიდგომა.
________________________________________
🧰 Tech Stack
•	Language: C#
•	Framework: ASP.NET Core Web API
•	Database: SQL Server
•	ORM: Entity Framework Core
•	Authentication: JWT (Json Web Token)
•	Authorization: Role Based (User, Accountant)
•	Validation: FluentValidation
•	Logging: Serilog (File logging)
•	Testing: xUnit, Moq
•	Documentation: Swagger (OpenAPI)
________________________________________
👥 Roles
👤 User
•	რეგისტრაცია და ავტორიზაცია
•	საკუთარი პროფილის ნახვა
•	სესხის მოთხოვნა
•	მხოლოდ საკუთარი სესხების ნახვა / განახლება / წაშლა
•	ვერ ცვლის სესხის სტატუსს
•	ვერ ითხოვს სესხს თუ IsBlocked = true
👨‍💼 Accountant
•	ყველა მომხმარებლის სესხის ნახვა
•	სესხის სტატუსის შეცვლა
•	ნებისმიერი სესხის წაშლა
•	მომხმარებლის დაბლოკვა გარკვეული დროით
________________________________________
💳 Loan Entity
Loan fields: - LoanType (Fast, Auto, Installment) - Amount - Currency - Period (months) - Status (Processing, Approved, Rejected)
სესხის შექმნისას სტატუსი ავტომატურად არის Processing.
________________________________________
🚀 API Endpoints
🔐 Authentication
Method	Endpoint	Description
POST	/api/auth/register	User registration
POST	/api/auth/login	User login (JWT)
________________________________________
👤 User – Loans
Method	Endpoint	Description
POST	/api/loans	Request a new loan
GET	/api/loans/my	Get my loans
GET	/api/loans/{id}	Get my loan by id
PUT	/api/loans/{id}	Update loan (only Processing)
DELETE	/api/loans/{id}	Delete loan (only Processing)
________________________________________
👨‍💼 Accountant – Loans
Method	Endpoint	Description
GET	/api/accountant/loans	Get all loans
DELETE	/api/accountant/loans/{id}	Delete any loan
________________________________________
👨‍💼 Accountant – Users
Method	Endpoint	Description
PUT	/api/users/block/{id}	Block user
________________________________________
⚙️ Configuration
appsettings.json
{
  "ConnectionStrings": {
   "BankAppEntityFrameworkWEBAPI": "Server=DESKTOP-SPEG7LL\\SQLEXPRESS;Database=BankApp;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True"
  },
  "Jwt": {
    "Key": "super-secret-key",
    "Issuer": "LoanAPI",
    "Audience": "LoanAPIUsers"
  }
}
________________________________________
🛡️ Security
•	JWT Authentication
•	Role-Based Authorization
•	Passwords are stored hashed
•	Unauthorized users cannot access protected endpoints
________________________________________
🧪 Testing
•	Service layer fully covered with unit tests
•	Controllers tested using mocks
Run tests:
dotnet test
________________________________________
🧱 Architecture
•	Controllers contain no business logic
•	Business logic implemented in Services
•	Interfaces used for dependency inversion
•	SOLID principles followed
________________________________________
📁 Folder Structure
Controllers
Services
 ├── Interfaces
 └── Implementations
Models(DTOs)
Validators
Domain
Data
Tests
________________________________________
📄 Notes
•	All exceptions are handled globally
•	API always returns meaningful HTTP status codes and messages
•	Logs are stored in file system
________________________________________
▶️ How to Run
dotnet restore
dotnet update database
dotnet run
________________________________________
📜 License
This project is for educational purposes.
