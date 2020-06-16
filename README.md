# Toolkie.Configuration

## Configuration settings

Library contains extension for add common configuration (settings usage) to project.

Settings read in order (every next override previos):

- appsettings.json
- secrets.json
- environment variables
- command line arguments  

__Usage:__

```c++
public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run(;
    }
    public static IHostBuilderCreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseToolkieConfiguration(args)
            .ConfigureWebHostDefault(webBuilder => webBuilderUseStartup<Startup>());
}
```

## Bonus

### Version

Get current version of application

```c++
ApplicationVersion.InformationalVersion();
```

Add version page to Mvc project with `UseInfoPage` extension for `IApplicationBuilder`

```c++
app.UseInfoPage("/info");
```
