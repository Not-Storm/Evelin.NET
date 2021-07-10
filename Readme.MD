# Readme

Discord bot in C# made using Discord.NET api wrapper


How to use
------------------------------

How to use:  
Create a file named `appsettings.json`  
give 2 values in this format   

```
{
    "token": "your discord bot's token",
    "Prefix": "your discord bot's prefix"
}
```
Save it in the base directory (\Evelin) itself
then run `main.cs` and it should run properly until there are some unsolved mistakes in the code itself  


Dependencies
----------------------------------  

Dependencies required:

```
Discord.NET
Discord.Addons.Hosting
Microsoft.Extensions.Configuration
Microsoft.Extensions.Hosting
Microsoft.Extensions.DependencyInjection
```
How to install dependencies:  
1) Using Command Line:
```
dotnet add package "package url without quotes"
```
This will automatically install the latest version of packages. The url can be found [here](https://nuget.org)  

2) Nuget Package Manager:
```
You can use the builtin package manager which can be found in
Tools > Nuget Package Manager > Manage NuGet Packages for solutions
```


Links
----------------------------------  

reference links:

[token](https://discord.com/developers)  
[dependencies](https://nuget.org) or you can very well use inbuilt package manager in Visual Studio
