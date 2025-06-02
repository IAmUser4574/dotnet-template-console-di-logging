# dotnet-template-console-di-logging

### Features

This is a C# template project intended to be used to springboard new Console App projects with the modern C# features I've found to be necessary for functional projects:
* `Logging`
  * [Serilog](https://github.com/serilog/serilog)
    * Excellent, versatile, and extensible logging framework
  * File and Console sinks
    * One log command will pipe to multiple locations with proper formatting
    * File logs are set to write to the `logs/` directory as `.txt` files with daily rollover
* `AppSettings`
  * A json configuration file used to configure Serilog and ready for application-specific configuration items
* `Dependency Injection`
  * A service container and service registration are provided in the `Program` class
  * Supports full constructor dependency injection 

### Install

Clone this repo, then add the template to your Rider custom project templates (File -> New Solution -> Manage Templates -> Install Template -> select clone directory.

Note - not currently tested with Visual Studio
