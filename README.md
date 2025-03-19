# SolicitorSync

## 1. Brief description
SolicitorSync is a lightweight ASP.NET Core Web API that simulates a case management system. 
The API will allow users (e.g., internal staff) to manage legal cases or complaints related 
to solicitor conduct. This project demonstrates the ability to design RESTful APIs, interact 
with a database, and produce well-documented, high-quality code—all while using modern 
development practices.

## 2. Features 

### A) CRUD Operations:
1) Create: Add new legal cases or complaints.
2) Read: Retrieve a list of cases or a specific case by ID.
3) Update: Modify existing case details.
4) Delete: Remove cases that are no longer active.

### B) RESTful API Standards:
The project utilises RESTful API to implement proper HTTP methods, status codes, and routing 
conventions.

### C) Modular Design:
The project aims to structure the code with a clear separation of concerns (using Controllers, 
Services, Data Access Layers) to illustrate best practices in software architecture. This 
design will allow the developer to further expand its features and technical functionalities.

### D) Error Handling & Logging:
The project uses middleware for consistent error responses and integrates basic logging to 
capture key events or errors.

### E) Unit testing 
The project uses xUnit unit tests for the service layer to demonstrate adherence to the 
software development lifecycle and quality assurance practices.

### F) Data Persistence
The project uses PostgreSQL with the Dapper package to store case data.

## 3. TaskList

- [x] Create a GitHub repository. 
- [x] Download a model database and set it up in SQLite.
- [x] Create a connection string to the Database and test access using the program.cs.
- [x] Create a RESTful API with CRUD operations to manage case files. Implement routing and 
HTTP methods for Create, Update, Get, GetAll and Delete requests for the temporary database.
- [x] Create slug generation and slug-based retrieval method for Get request.
- [x] Implement GUID into the database.
- [x] Integrate API calls into SQL database. 
- [x] Create Controllers, Services and Data Access Layers for the API.
- [x] Implement middleware for validating Create Case requests. 
- [ ] Add logging to track API requests and errors.
- [ ] Implement middleware for error handling.
- [ ] Expand error handling to catch API connection, and request errors.
- [ ] Integrate Swagger for API documentation. Write unit tests for core functionality 
(services/business logic).
- [ ] Add several unit tests using xUnit.
- [ ] Simulate a pull request workflow.
- [ ] Refactor code.
- [ ] Add commenting to all the code files to explain its functionalities.
- [ ] Improve documentation.


## 4. ChangeLog 

+ 2025.02.18 - GitHub repository created 
+ 2025.03.01 - Commited SQL database and legalcases.cs and program.cs files to be able to 
connect and work with the database
+ 2025.03.01 - Fixed the SQL connection error and added error handling for the SQL connection. 
+ 2025.03.02 - Updated README.MD with the project's description, features and task list.
+ 2025.03.03 - Created Contract folders with request and response files, created API folders 
and repository files.
+ 2025.03.04 - Created Controllers class in Cases.Api and configured HTTP connection, 
verified Create request.
+ 2025.03.04 - Created mappings for requests and responses, created API endpoints, and created 
and verified Get, GetAll, Update and Delete requests.
+ 2025.03.06 - Added slug generation and slug-based retrieval method for cases for 
Get request.
+ 2025.03.15 - Implemented GUID generation into the case files, and added created_date and 
updated_date attributes.
+ 2025.03.17 - Integrated API calls into PostgreSQL database using Npgsql and Dapper 
packages, added database connection and initialization files. Added Docker containerization
file. 
+ 2025.03.18 - Added 15 model cases into the database. 
+ 2025.03.18 - Added Service layer business logic. Implemented validation for Create Case 
request using FluentValidation package and added ValidationMappingMiddleware for API response.





