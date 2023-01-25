# Sales Shack

#### Epicodus Week 14 Team Week Project

## Contributors

* Chris Loveless and Yoonis Ali

## Description
This independent project demonstrates proficiency with many to many relationships, user authentication using Identity, and authorization using roles. The user can view lists of Treats and Flavors, however the user must sign in or register an account before they can Create, Update, or Delete any of the classes or joined entities. With roles active only users with the role of "admin" can Create, Update, or Delete.

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
* Clone down the git repo ```https://github.com/ChrisKLoveless/TreatShop.Solution.git``` to the ```desktop``` directory.
* Open the project with VSCode or a different source code editor.
* In the root directory be sure to create a ```.gitignore``` file and input the following to secure your database information:
    * ```appsettings.json```
    * ```obj```
    * ```bin```
* If you are pushing this project to a remote git repo add ```.gitignore``` to git and commit before moving on.
* Restore required packages: change directory to ```TreatShop``` and restore with ```$ dotnet restore```

## Database Setup

* To connect your database, create file ```appsettings.json``` in the production directory ```TreatShop```
* Fill in the file with the following code: Be sure to replace the required fields marked with ```[]``` that must contain the database name, user id, and password.
```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=[DB-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
}
```
* While in the ```TreatShop``` directory use ```$ dotnet build``` to build the program.
* To include this projects' data structure, change directory to ```TreatShop```, and run ```dotnet ef migrations add Initial``` and then run ```dotnet ef database update```
* While in the ```TreatShop``` directory use ```$ dotnet watch run``` to run the program in the browser with a watcher.

## Known Bugs

* If any bugs are found please email a brief description to: ```chriskloveless@gmail.com```

## License
Copyright (c) 2022 Chris Loveless
_[MIT](https://choosealicense.com/licenses/mit/)_