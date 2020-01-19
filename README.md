**AkuFintechTest**

**Features In this Application**

* Signup with Email and Password
* Login with email and password
* Email Verification
* Password Reset
* File Upload
* Submited File Comparism
* View All History
* View Selected History
* View Profile
* Edit Profile
* Rerun Test on History

**Technologies Used**
* Language : C#
* Framework : .Net Core 2.2
* Design Pattern : MVP with Dependency Injection
* Database: SQL Server 2014
* Server Management Sudio: MSSMS 2017
* Documentation: Swagger
* Security: JWT 
* IDE : Visual Studio 2017
* Host Environment: Microsoft Azure

**How To Install**
* git clone repository
* Run sln file in visual studio
* Modify Default Connection string in the appsetting.json file to point to your local server 
* Run add-migration <Migration Name> to create new db migration from models
* Run Update-database  to generate new DB
* Click on run in Visul Studio
* In brower navigate to https://localhost:5001/swagger/index.html

**Testing The API**
* Please not that all the API endpoints can be tested via the Swagger API Documentation
* Signup with valid credentials using the documentation
* Copy generated token on login
* Click on Authenticate and Enter: Bearer <Token you copied> then submit
  
**Deployment URL**
* Local Host URL: https://localhost:5001/swagger/index.html
* Live URL: https://acutestrestapi20200119013938.azurewebsites.net/swagger/index.html
