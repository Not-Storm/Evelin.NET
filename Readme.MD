# Readme

Discord bot in C# made using [Discord.NET](https://github.com/discord-net/Discord.Net) discord api wrapper 

P.S. Its a humble request from me to anyone working with this project to follow coding [conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) for the sake of other fellow programmers. I will recommend [Stylecop.Alanyzer](https://www.nuget.org/packages/StyleCop.Analyzers/1.2.0-beta.354)and [Discord.NET analyzer](https://nuget.org/packages/Discord.Net.Analyzer/2.4.0?_src=template) as the analyzer for this project


How to use
------------------------------

How to use:  
Create a file named `appsettings.json`  
give 2 values in this format   

```
{
    "Prefix": "your discord bot's prefix"
}
```  
Then create a [enviroment variable](https://www.alphr.com/environment-variables-windows-10/) named `token`  
this will contain your bot's token  

Save it in the base directory (\Evelin) itself
then run `Program.cs` and it should run 
properly until there are errors in code  

```
dotnet run Program.cs
```

Dependencies
----------------------------------  

Dependencies required:

```
Discord.NET
Discord.Addons.Hosting
Microsoft.Extensions.Configuration
Microsoft.Extensions.Hosting
Microsoft.Extensions.DependencyInjection
StyleCop.Analyzer
Discord.Net.Analyzer
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

[token](https://www.writebots.com/discord-bot-token/#:~:text=Generating%20Your%20Token%20Step-by-Step%201%20Go%20to%20the,Add%20Your%20Bot%20to%20a%20Discord%20Server.%20)  
[dependencies](https://nuget.org) or you can very well use inbuilt package manager in Visual Studio
