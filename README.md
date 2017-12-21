# Coalesce.Starter
A barebones Coalesce project which can be built upon.

For more information on Coalesce, visit http://coalesce.intellitect.com/

To quickly get up and running with a new [Coalesce](https://github.com/IntelliTect/Coalesce) project:

1. Clone this repository.
1. Run `RenameProject.ps1` to rename the solution files and code namespaces to your desired project name.

At this point, you can open up Visual Studio and run the application. However, you will probably want to do the following before running:

1. Create an initial data model by adding EF entity classes to the data project and the corresponding `DbSet<>` properties to `AppDbContext`. You will notice that this project includes a single model, `ApplicationUser`, to start with.
1. Run the `coalesce` task in the Task Runner Explorer to trigger Coalesce's code generation (or run `dotnet coalesce` in the web project's path).
1. Run `dotnet ef migrations add Init` (`Init` can be any name) in the data project to create the initial database migration.

After you've started to grow content with your project, consider the following:

* Remove the dummy authentication from `Startup.cs` and implement a proper authentication scheme.
