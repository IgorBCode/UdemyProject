## Getting Started

Clone repo.
Have SQL Server Manager and Microsoft SQL Server installed. If you need help with that here is the install instructions: 
https://www.youtube.com/watch?v=7zXtA0LwoHs


### Prerequisites

Requirements for the software and other tools to build
- [Microsoft SQL Server] https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
- [SQL Server Manager] https://www.microsoft.com/en-us/sql-server/sql-server-downloads

## Before you run

Do this before you run the project otherwise nothing will work.
1. In UdemyProject/appsettings.json, where you see "Server=****", replace **** with your server name. You can find this when you open up microsoft sql server manager and connect window pops up, you will see "Server name"
2. (Try to run the app at this point, it may automatically create all the database stuff. If not, continue following these steps)In VS go to the menu item Tool/NuGet Package Manager/Package Manger Console. Run the following commands in the package manager console:
   1. add-migration AddCategoryTableAndSeedData
   2. update-database
   3. add-migration AddProductTableAndSeedData
   4. update-database


### Run Application

Click run or debug and run button. The app will come up in your browser. The pages you can interact with can be found in the "Content Management" menu.
