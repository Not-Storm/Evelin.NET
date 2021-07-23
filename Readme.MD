# Readme

Discord bot in C# made using [Discord.NET](https://github.com/discord-net/Discord.Net) discord api wrapper 

How to use
------------------------------

How to use:  
`Evelin\EvelinInfrastructure` contains the files for the database while `Evelin\Evelin` contains the source code for the bot
    
In the file `Evelin\appsettings.json` set your prefix enclosed in quotes

```
{
    "Prefix": "your discord bot's prefix"
}
```  
Then create a [enviroment variable](https://www.alphr.com/environment-variables-windows-10/) named `token`  
this will contain your bot's token  

    
The main project is inside the Evelin directory  
Run the project by
```
cd Evelin
dotnet run Program.cs
```

Dependencies
----------------------------------  

Dependencies required:

```
Discord.Net
Discord.Addons.Hosting
Discord.InteractivityAddon
Discord.Net.Analyzers
Microsoft.EntityFrameworkCore
Pomelo.EntityFrameworkCore.MySql
StyleCop.Analyzers
```  


How to install dependencies:  
1) Using Command Line:
```
cd Evelin
dotnet add package Discord.Net
dotnet add package Discord.Addons.Hosting
dotnet add package Discord.InteractivityAddon
dotnet add package Discord.Net.Analyzers
dotnet add package StyleCop.Analyzers
cd ..
cd EvelinInfrastructure
dotnet add package Discord.Net.Analyzers
dotnet add package StyleCop.Analyzers
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql
```
This will automatically install the latest version of packages.  

2) Nuget Package Manager:
```
You can use the builtin package manager which can be found in
Tools > Nuget Package Manager > Manage NuGet Packages for solutions
```


Links
----------------------------------  

reference links:

[token](https://www.writebots.com/discord-bot-token/#:~:text=Generating%20Your%20Token%20Step-by-Step%201%20Go%20to%20the,Add%20Your%20Bot%20to%20a%20Discord%20Server.%20)  
[enviroment variables](https://www.alphr.com/environment-variables-windows-10/)
