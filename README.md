# SolicitorSync

## 1. Brief description
SolicitorSync is a lightweight ASP.NET Core Web API that simulates a case management system 
for the Solicitors Regulation Authority. The API will allow users (e.g., internal staff) to 
manage legal cases or complaints related to solicitor conduct. This project demonstrates the
ability to design RESTful APIs, interact with a database, and produce well-documented, 
high-quality code—all while using modern development practices.

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
Project aims to structure the code with a clear separation of concerns (using Controllers, 
Services, Data Access Layers) to illustrate best practices in software architecture. This 
design will allow developer to further expand its features and the technical functionalities.

### D) Error Handling & Logging:
The project uses middleware for consistent error responses and integrate basic logging to 
capture key events or errors.

### E) Unit testing 
The project uses xUnit unit tests for the service layer to demonstrate adherence to the 
software development lifecycle and quality assurance practices.

### F) Data Persistence
The project uses Entity Framework Core with a SQL database (SQLite) to store case data.

## 3. TaskList

- [x] Create GitHub repository 
- [x] Download a model database and set it up in SQLite
- [x] Create a connection string to Database and test access using the program.cs
- [ ] Create a RESTful API with CRUD operations to manage case files. Implement routing and 
HTTP methods (GET, POST, PUT, DELETE).
- [ ] Create Controllers, Services and Data Access Layers for the API
- [ ] Integrate Swagger for API documentation. Write unit tests for core functionality 
(services/business logic).
- [ ] Expand error handling to catch API connection, and request errors.
- [ ] Implement middleware for error handling. Add logging to track API requests and errors.
- [ ] Add several unit tests using xUnit
- [ ] Simulate a pull request workflow.
- [ ] Refactor code.
- [ ] Add commenting to all the code files to explain its functionalities.
- [ ] Improve documentation.


## 4. ChangeLog 

+ 2025.02.18 - Github repository created 
+ 2025.03.01 - Commited SQL database and legalcases.cs and program.cs files to be able to 
connect and work with the database
+ 2025.03.01 - Fixed the SQL connection error and added error handling for SQL connection. 
+ 2025.03.02 - Updated README.MD with project's description, features and task list.





