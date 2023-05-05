Always Initialize your database and after that update using these commands.

--Ubuntu Users
Firstly install dotnet-ef

--> dotnet tool install --global dotnet-ef

Postgres Database Migration and Initialization

--> dotnet ef migrations add InitialDatabase

Postgres Database Update

--> dotnet ef database update