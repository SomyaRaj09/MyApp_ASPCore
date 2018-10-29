# MyApp_ASPCore

Prerequisites :  
VS2017 framework  
SQL server 2012  
IIS 7 or above  
Postman

Publish Steps

Step 1 : Open MyApp project in VS2017.  
Step 2 : Publish application - Right click on MyApp project and select publish option.  
Step 3 : After selecting publish option a new window will be opened. Select publish option again. New window will be opened with 'Pick a publish target' title.  
Step 4 : Choose IIS, FTP, etc. option and press publish button.  
Step 5 : Select file system from custom profile drop down (Publish method) and select target location.  
Step 6 : Published build can be found on targeted folder.

Deployement & run steps

Step 1 : Open IIS.  
Step 2 : Under sites option - Add website.  
Step 3 : Enter site name, Physical path, host name. User can also change port number.  
Note : Under the server's node, select Application Pools.  
Right-click the site's app pool and select Basic Settings from the contextual menu.  
In the Edit Application Pool window, set the .NET CLR version to No Managed Code.  
Step 4 : Change "MainDBConnectionString" in appsettings.json file.

Test steps : 

Step 1 : Pick postman collection from PostmanCollection folder (From GIT).  
Step 2 : Import one collection at a time from that folder.  
Step 3 : Run and verify all the services.  

Before deploying it to server user can test all the unit test cases from XUnit project in VS2017.
