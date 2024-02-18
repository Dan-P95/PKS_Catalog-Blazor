To run the project,
1. Create a new SQL server database
2. In the Server Project, add the connection string after "Default Connection" in appsettings.json file
3. In the console run the following commands
4. dotnet ef migrations add InitCreate
5. dotnet ef database update
   
That should create the database and upload sample data. The migration file can be seen created in the Migrations folder

6. Run the project

7. To use "user" features, first log in as a user by clicking the 3 dots button on the top right of the page, and clicking Log In
8. Log In using: username; test
                 password; password


9. Entire products can be deleted from the home page, or product variants can be deleted from the product details page
10. New users and new products can be added by clicking the same 3 dot button

Thanks for looking at my project 
