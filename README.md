SuperVet
========

### Description

<p>Тhis is a project to learn C# language<span ><img width="60" height="60" src="https://upload.wikimedia.org/wikipedia/commons/1/17/C_Sharp_Icon.png"/><span> <br/> and more specifically ASP.Net MVC pattern. <span ><img width="60" height="40"src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Asp.net.svg/320px-Asp.net.svg.png"/></span></p>
<br/>
Otherwise, the project is a web catalog for animals sorted by species and breed.
<br/>

## More about the project  ##

### Dependncies ###
<ul>
 <li>
  <h5>Frameworks</h5>
  <ul>
   <li>Microsoft.AspNetCore.App</li>
   <li>Microsoft.NetCore.App</li>
  </ul>
 </li>
 <li>
  <h5>Packages</h5>
  <ul>
   <li>Microsoft.EntityFrameworkCore (7.0.11)</li>
   <li>Microsoft.EntityFrameworkCore.SqlServer (7.0.11)</li>
   <li>Microsoft.EntityFrameworkCore.Tools (7.0.11)</li>
  </ul>
 </li>
</ul>

 
## How to start the project ##
#### Setting up Database ####
1. Download and install ***SQL Server 2019 Developer Edition***. You can find step by step guide [here](https://www.sqlservertutorial.net/install-sql-server/).
2. Install and open Microsoft SQL Server Management Studio (MSSMS)
3. You will be prompted to <br/> ![Screenshot 2023-10-05 133710](https://github.com/AydanMurshud/SuperVet/assets/102986706/871ae383-ed9b-4eb1-8864-71ecbf45a721)<br/>
connect to the server.<br/>
****NOTE**** Server Name will be the name you provided on installation of ***SQL Server 2019 Developer Edition***.<br/>
On succesful connection to server the **Object Explorer** will open.<br/><br/>
5. <u>right-click</u> *Databases* folder and click new Database
![Screenshot 2023-10-05 133014](https://github.com/AydanMurshud/SuperVet/assets/102986706/e72afe7f-3e28-4f44-b0cd-40b3581aa1b8)<br/>
A new window will open.
6. Name the new Database (in this case we name it with the name of the project) and click Ok
![Screenshot 2023-10-05 133329](https://github.com/AydanMurshud/SuperVet/assets/102986706/e55d0029-508e-4733-9623-ccdf5ceaec96)<br/>
now you have a new Database </br>
![Screenshot 2023-10-05 133946](https://github.com/AydanMurshud/SuperVet/assets/102986706/cd8ed4f4-bd14-46e9-b68f-dc7620a5e84e)<br/>
#### Populating Database ####
1. Open the project in Visual Studio
2. Go to view and click SQL Server Object Explorer
3. When SQL Server Object Explorer is open go to your **Server -> Databases**. There should be your newly created Database<br/>
![Screenshot 2023-10-05 134626](https://github.com/AydanMurshud/SuperVet/assets/102986706/3f3bf4aa-9a34-4bae-ada8-9db9a1ecb834)<br/>
4. Right-click the Database and go to <u>properties</u><br/>
this will open properties window.
Copy the value of connection string <br/>* **Important** * Make sure you copied whole string. <br/>
![Screenshot 2023-10-05 135020](https://github.com/AydanMurshud/SuperVet/assets/102986706/62ee74bf-84a0-4885-99e0-eb17297451c1)<br/>

Then close the properties window and go to ***appsettings.json*** on Solution Explorer(app directory).
Paste the copied string as value of *DefaultConnection* prop
![Screenshot 2023-10-05 135440](https://github.com/AydanMurshud/SuperVet/assets/102986706/f415bf86-83cc-4679-9536-79aebd44b1d8)<br/>
5. Go to Package Manager Consol and type <code>Add-Migration InitialCreate</code><br/>
![Screenshot 2023-10-05 144802](https://github.com/AydanMurshud/SuperVet/assets/102986706/9621b267-e895-49d5-9436-1b1b2de3d5ba)<br/>
after <code>build succeeded</code> message type <code>Update-Database</code>.
![Screenshot 2023-10-05 145327](https://github.com/AydanMurshud/SuperVet/assets/102986706/ae276726-63c7-4f7b-8243-8a760ed38800)<br/>
<code>Add-Migration InitialCreate</code> command is to handle database schema changes in an organized and efficient manner, however in this situation we create migration file to specify tables and relations between them.<br/>
With <code>Update-Database</code> we apply the changes with the latest Migration file.<br/>

Now if we go to SQL Management Studio and *refresh Object Explorer* and go to **SuperVet database -> Tables folder**, we can see that the tables have been made.<br/>
![Screenshot 2023-10-05 151213](https://github.com/AydanMurshud/SuperVet/assets/102986706/d3f0fdd3-270b-4b4b-afa6-99a4545bb2ab)<br/>
However there isn't any data in this tables.<br/><br/>
6. To *"seed"* the database we simply go to **Developer Powershell** tab navigate to project directory <code>cd SuperVet</code> and type <code>dotnet run seeddata</code>
![Screenshot 2023-10-05 151908](https://github.com/AydanMurshud/SuperVet/assets/102986706/30584ac1-3c76-4370-ac4b-af88ff2cb2e5)
This step will *"seed"* the database with some dummy data.<br/>
Now if we go back to SSMS and refresh we can see that the tables now have data in them.
![Screenshot 2023-10-05 152357](https://github.com/AydanMurshud/SuperVet/assets/102986706/91cd0b96-66a0-4421-b240-94ceb7ba822a)<br/><br/>
### Last Step ###
Go to visual studio and click SuperVet
![Screenshot 2023-10-05 153113](https://github.com/AydanMurshud/SuperVet/assets/102986706/60b1deee-5552-4fea-80ab-4d491dcd3b5e)
