# Sales Shack

#### Epicodus Week 14 Team Week Project

## Contributors

* Chris Loveless and Yoonis Ali

## Description
This team week project was completed during the C# and .NET 6 section of the course. It utilizes Identity and Roles to handle User Authentication and Authorization within the app. Sales Shack is a sales management web application. It allows management to create roles and assign those roles to created users. Users with the "Administrator" role have full access to all functionality within the app. Users with the "User" role can only Create, Read, Update, and Delete for the included classes. These classes are Client, Product, and Sale. The Promotions section can be viewed by Users but Create, Update, and Delete functionality is reserved for Administrators. A User can view Products, along with their associated Sales and Promotions. This app is intended to help a company and its' managment and sales teams track Products, Sales, Promotions, and Client list all in one place. 

## Technologies Used

* _C#_
* _Html_
* _CSS_
* _ASP .NET6_
* _MySQL_
* _MVC_
* _Entity Framework Core_

## Setup/Installation Requirements

* Install MySQL Community Server and MySQL Workbench. Follow the instructions _[here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql/)_.
* Install tool to update database with ```dotnet tool install --global dotnet-ef --version 6.0.1```
* Clone down the git repo ```https://github.com/ChrisKLoveless/SalesShack.Solution.git``` to the ```desktop``` directory.
* Open the project with VSCode or a different source code editor.
* In the root directory be sure to create a ```.gitignore``` file and input the following to secure your database information:
    * ```appsettings.json```
    * ```obj```
    * ```bin```
* If you are pushing this project to a remote git repo add ```.gitignore``` to git and commit before moving on.
* Restore required packages: change directory to ```SalesShack``` and restore with ```$ dotnet restore```

## Database Setup

* To connect your database, create file ```appsettings.json``` in the production directory ```SalesShack```
* Fill in the file with the following code: Be sure to replace the required fields marked with ```[]``` that must contain the database name, user id, and password.
```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=[DB-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
}
```
* While in the ```SalesShack``` directory use ```$ dotnet build``` to build the program.
* To include this projects' data structure, change directory to ```SalesShack```, and run ```dotnet ef migrations add Initial``` and then run ```dotnet ef database update```
* While in the ```SalesShack``` directory use ```$ dotnet watch run``` to run the program in the browser with a watcher.

## Assigning Roles
1. Once some users are created through the acount view, management can asign roles by navigating to url ```https://localhost:7221/Role/Index```
2. Click the ```Create a Role``` button and create roles for ```Administrator``` and ```User```
3. Back in the index view click the ```update``` button and select available users to apply a role.

## Known Bugs

* If any bugs are found please email a brief description to: ```chriskloveless@gmail.com``` or ```yoonismahamoudali@gmail.com```


## License
Copyright (c) 2022 Chris Loveless and Yoonis Ali
_[MIT](https://choosealicense.com/licenses/mit/)_