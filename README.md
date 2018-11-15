# pong-tennis-multiplayer

A pong game server/client development: 2 clients can play actually.

VS Code project, install it and load the folder with the project.

Add C# component, restart VS and add whatever asked to when trying to run.

Modify the connectionstring properly in the appsettings.json file in the root of the installed files.

To do so, change the capslock words with a valid sqlserver or sqlexpress instance and replace the "DefaultConnection" line that you find there:

"DefaultConnection": "Data Source=NAME_OF_THE_SQL_SERVER;Initial Catalog=Tennis;Persist Security Info=True;User ID=USER_ID;Password=THE_PASSWORD"
