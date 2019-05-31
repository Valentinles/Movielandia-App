# Movielandia
**Movielandia** is a open-source .NET Core MVC project where *users* can order tickets for movies. They can see the movies, read short information about specific movie, make orders and take a look at their orders. The *admin* can create/delete/edit movies, change the prices of the tickets and also can see all made orders from the users. [Gallery](https://github.com/Valentinles/Movielandia-App/wiki/Gallery) 
## Getting Started

###### Run the application:

- If you don't have *Sql server* on your machine you should replace the configuration in *Movielandia.Web/appsettings.json* with this code
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=Movielandia;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
- In your *package manger console* type 

```
update-database
```
- **Important!** The **first** registered account will be promoted to **admin** and every other will be a **normal user**.

## Used technologies
- C#
- .NET Core 2.1
- .NET Core MVC
- Entity Framework Core
- Bootstrap 4.0
- HTML
- CSS
- jQuery
