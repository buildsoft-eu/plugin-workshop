# Plugin Workshop

This project provides a starter solution to develop plugins for BuildSoft's BIM Expert software.

## Setup

You need a properly licensed copy of `BIM Expert` running on your machine.  Contact BuildSoft support for more information.
The workshop project connects to BIM Expert in exactly the same way your plugin will connect to it once it's being hosted as an actual plugin.

* Make sure `Gateway Server`, `Gateway` and `BIM Expert` are running on your machine.
* Clone this solution to your work space.
* Make sure `Plugin.Workshop` is set as the startup project.

## Entry points

`IUBSMConverter` contains all the entry points used by BIM Expert to communicate with the plugin. `Plugin.Example/ApiPlugin.cs` contains the class that implements this interface.

* *Info*: contains general information about the plugin.
* *Export*: WPF control and entry point to export a UBSM model to the target application.
* *Import*: WPF control and entry point to import from the target application into a UBSM model.
* *Progress*: Event to trigger a progress update in `BIM Expert`.
* *Settings*: WPF control to adjust settings for the plugin.

## Example API

The example represents the API of a fictional program used to define simple portal frames.
In its simplest form an external API provides a data model to be used, either by providing a compatible .NET library, or by describing the XML/JSON/Custom file format.
More advanced APIs allow direct communication with the application. This kind of functionality is outside of the scope of this example. 
However, the implementation would be similar. In the end all that is needed is a mechanism to read and write information about the external program through the use of some library, here represented by the `Example.API` project.

The `Plugin.Workshop` project is a host application for plugin development. It connects to a running instance of BIM Expert to get access to the database elements, e.g. materials.
It provides a sandbox for the developer and should not be changed during plugin development.
There are three tabs to represent the three WPF user controls that should be provided by every plugin, settings, import, and export.
Similar to BIM Expert it allows for cancellation and reporting progress.
For import you need to specify an save path for the UBSM XML file that will be generated. This can then be imported into BIM Expert to visualize the model and be exported to another application to test more advanced scenarios.
Similarly you need to provide the path to the UBSM XML file to run the export control. These files can be created by importing from another application into BIM Export and then exporting to a UBSM XML file.

The actual plugin should be created in a separate project, in this case `Plugin.Example`.
There is no special framework or programming paradigm required to implement a plugin, but using MVVM and services inspired by Domain Driven Design is definitely recommended.

The original plugin code was created before the introduction of async/await.
This made waiting for user input tricky, changing the paradigm to an async method is recommended to be able to use newer C# techniques and is exactly what the example plugin does.

```csharp
    var (structure, path) = importService.RunAsync(
            _importViewModel.UpdateTitle,
            progress,
            token)
        .GetAwaiter()
        .GetResult();
```

This allows us to create some custom awaiters, e.g. `ButtonAwaiter` waits for a button click, and `ConflictsSolvedAwaiter{T}` waits until all conflicts during mapping are resolved.
Using custom awaiters can make the code easier to understand, but any mechanism used to wait for user input will work.
For example, the original plugins used the `ManualResetEvent` to wait for the click event to be fired.

BIM Expert supports localizing the plugin, and creating separate resource files for this purpose is highly recommended.
