# QLess
Exam
API

Created in Visual Studio 2019


Api

Application Layer
Framework: .NET Standard 2.1
Packages: 
    AutoMapper.Extensions.Microsoft.DependencyInjection (11.0.0)
    MediatR.Extensions.Microsoft.DependencyInjection (10.0.1)

Domain Layer
Framework: .NET Standard 2.1

Infrastructure Layer
Framework: .NET Standard 2.1
Packages: 
    Microsoft.EntityFrameworkCore.SqlServer (5.0.8)
    Microsoft.Extensions.Options.ConfigurationExtensions (6.0.0)

Test - xUnit Test Project
Framework: .NET 5.0
Packages: 
	Moq (4.18.2)
	Shouldly (4.0.3)
	xunit (2.4.1)


====================================================

UI

Created using Visual Studio Code


Angular CLI: 9.0.7
Node: 12.14.0
OS: win32 x64
@angular/material 9.2.4
Node.js v12.14.0

===================================================
How to build and run:

Prerequisites:

1. Install Visual Studio 2019
2. Install .NET SDL and .Net Runtime
3. Install Visual Studio Code
4. Install SQL Server Management Studio (I have version 2016)
5. Install Node.Js
6. Install Angular CLI

Build:

1. Run the API project in visual studio 2019 
2. When there is no Error for requirement 1 and 2 you can check the Unit Test 
3. Run test to check the criterias
4. Set MRT.CardManagement.Application as Start up Project then press F5
5. Swagger should open
6. Go to UI folder MRTCARDADMINPORTAL-UI. open via cmd and run ng serv -o
