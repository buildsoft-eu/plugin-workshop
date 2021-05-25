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
