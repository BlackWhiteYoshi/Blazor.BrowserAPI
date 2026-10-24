# Web MIDI

The Web MIDI API connects to and interacts with Musical Instrument Digital Interface (MIDI) Devices.

The interfaces deal with the practical aspects of sending and receiving MIDI messages.
Therefore, the API can be used for musical and non-musical uses, with any MIDI device connected to your computer.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IWebMIDI WebMIDI { private get; init; }

    private IMIDIInput[] inputPorts = [];
    private IMIDIOutput[] outputPorts = [];


    protected override async Task OnInitializedAsync() {
        await using IMIDIAccess midiAccess = await WebMIDI.RequestMIDIAccess();
        inputPorts = await midiAccess.Inputs;
        outputPorts = await midiAccess.Outputs;
    }

    public async ValueTask DisposeAsync() {
        await inputPorts.DisposeAsync();
        await outputPorts.DisposeAsync();
    }


    private async Task ListenOnInputPort() {
        IMIDIInput? inputPort = inputPorts.FirstOrDefault();
        if (inputPort is null)
            return;

        await inputPort.Open();
        inputPort.OnMIDIMessage += (byte[]? data) => Console.WriteLine($"message received: {data}");
    }

    private async ValueTask SendDataOnOutputPort() {
        IMIDIOutput? outputPort = outputPorts.FirstOrDefault();
        if (outputPort is null)
            return;

        await outputPort.Open();
        await outputPort.Send([0x90, 60, 0x7f]); // Note on middle C, full velocity
    }

    private async Task PrintPorts() {
        foreach (IMIDIPort port in inputPorts.Concat<IMIDIPort>(outputPorts))
            Console.WriteLine($"Id: {port.Id} , Manufacturer: {port.Manufacturer} , Name: {port.Name} , Type: {port.Type} , Version: {port.Version} , State: {port.State} , Connection: {port.Connection}");
    }
}
```


<br><br />
## Members

### IWebMIDI

#### Methods

| **Name**          | **Parameters**                                                                                 | **ReturnType**                               | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| ----------------- | ---------------------------------------------------------------------------------------------- | -------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| RequestMIDIAccess | [bool sysex = false], [bool software = false], [CancellationToken cancellationToken = default] | ValueTask&lt;[IMIDIAccess](#imidiaccess)&gt; | Represents a request for access to MIDI devices on a user's system. This method is part of the Web MIDI API, which provides a means for accessing, enumerating, and manipulating MIDI devices.<br></br>This method may prompt the user for access to MIDI devices available to their system, or it may use a previously established preference to grant or deny access. If permission is granted then the Promise resolves and a MIDIAccess object is returned. |


<br></br>
### IMIDIAccess

Provides methods for listing MIDI input and output devices, and obtaining access to those devices.

#### Properties

| **Name**     | **Type**                                     | get/set | **Description**                                                                           |
| ------------ | -------------------------------------------- | ------- | ----------------------------------------------------------------------------------------- |
| Inputs       | ValueTask&lt;[IMIDIInput](#imidiinput)&gt;   | get     | Provides access to any available MIDI input ports.                                        |
| Outputs      | ValueTask&lt;[IMIDIOutput](#imidioutput)&gt; | get     | Provides access to any available MIDI output ports.                                       |
| SysexEnabled | ValueTask&lt;bool&gt;                        | get     | Indicates whether system exclusive support is enabled on the current MIDIAccess instance. |

#### Methods

| **Name**         | **Parameters**                        | **ReturnType**                               | **Description**             |
| ---------------- | ------------------------------------- | -------------------------------------------- | --------------------------- |
| GetInputs        | CancellationToken cancellationToken   | ValueTask&lt;[IMIDIInput](#imidiinput)&gt;   | see Property *Inputs*       |
| GetOutputs       | CancellationToken cancellationToken   | ValueTask&lt;[IMIDIOutput](#imidioutput)&gt; | see Property *Outputs*      |
| GetSysexEnabled  | CancellationToken cancellationToken   | ValueTask&lt;bool&gt;                        | see Property *SysexEnabled* |

#### Events

| **Name**      | **Type**                              | **Description**                                                                                                                                                                                                                                      |
| ------------- | ------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnStateChange | Action&lt;[IMIDIPort](#imidiport)&gt; | Fired when a new MIDI port is added or when an existing port changes state.<br></br>Parameter is the MIDIPort instance for a port that has been connected or disconnected.<br />Note: Dispose the given MIDIPort instance when you are done with it. |


<br></br>
### IMIDIPort

Represents a MIDI input or output port.

A MIDIPort instance is created when a new MIDI device is connected. Therefore it has no constructor.

#### Properties

| **Name**     | **Type**                | get/set | **Description**                                                                                                                                                                                                                                                                                                                                            |
| ------------ | ----------------------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Id           | ValueTask&lt;string&gt; | get     | Contains the unique ID of the port.                                                                                                                                                                                                                                                                                                                        |
| Manufacturer | ValueTask&lt;string&gt; | get     | Contains the manufacturer of the port.                                                                                                                                                                                                                                                                                                                     |
| Name         | ValueTask&lt;string&gt; | get     | Contains the system name of the port.                                                                                                                                                                                                                                                                                                                      |
| Type         | ValueTask&lt;string&gt; | get     | Contains the type of the port, one of:<br/>- "input": The MIDIPort is an input port.<br/>- "output": The MIDIPort is an output port.                                                                                                                                                                                                                       |
| Version      | ValueTask&lt;string&gt; | get     | Contains the version of the port.                                                                                                                                                                                                                                                                                                                          |
| State        | ValueTask&lt;string&gt; | get     | Contains the state of the port, one of:<br/>- "connected": The device that this MIDIPort represents is currently connected.<br/>- "disconnected": The device that this MIDIPort represents is disconnected from the system.                                                                                                                                |
| Connection   | ValueTask&lt;string&gt; | get     | Contains the connection state of the port, one of:<br/>- "open": The device that this MIDIPort represents has been opened and is available.<br/>- "closed": The device that this MIDIPort represents has not been opened, or has been closed.<br/>- "pending": The device that this MIDIPort represents has been opened but has subsequently disconnected. |

#### Methods

| **Name**        | **Parameters**                                  | **ReturnType**          | **Description**                                                                                                                                                                                                                                                                                                                                                                             |
| --------------- | ----------------------------------------------- | ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetId           | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | see Property *Id*                                                                                                                                                                                                                                                                                                                                                                           |
| GetManufacturer | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | see Property *Manufacturer*                                                                                                                                                                                                                                                                                                                                                                 |
| GetName         | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | see Property *Name*                                                                                                                                                                                                                                                                                                                                                                         |
| GetType         | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | see Property *Type*                                                                                                                                                                                                                                                                                                                                                                         |
| GetVersion      | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | see Property *Version*                                                                                                                                                                                                                                                                                                                                                                      |
| GetState        | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | see Property *State*                                                                                                                                                                                                                                                                                                                                                                        |
| GetConnection   | CancellationToken cancellationToken             | ValueTask&lt;string&gt; | see Property *Connection*                                                                                                                                                                                                                                                                                                                                                                   |
| Open            | [CancellationToken cancellationToken = default] | ValueTask               | Makes the MIDI device connected to this MIDIPort explicitly available.<br></br>If the port is successfully opened a new MIDIConnectionEvent is queued to the MIDIPort statechange and MIDIAccess statechange events, and the MIDIPort.connection property is changed to "open".<br></br>If the port is already open when this method is called, then the promise will resolve successfully. |
| Close           | [CancellationToken cancellationToken = default] | ValueTask               | Makes the access to the MIDI device connected to this MIDIPort unavailable.<br></br>If the port is successfully opened a new MIDIConnectionEvent is queued to the MIDIPort statechange and MIDIAccess statechange events, and the MIDIPort.connection property is changed to "closed".                                                                                                      |

#### Events

| **Name**      | **Type** | **Description**                                                      |
| ------------- | -------- | -------------------------------------------------------------------- |
| OnStateChange | Action   | Fired when this port changes from open to closed, or closed to open. |


<br></br>
### IMIDIInput

The MIDIInput interface of the Web MIDI API receives messages from a MIDI input port.

#### Inheritance

- [IMIDIPort](#imidiport)

#### Events

| **Name**      | **Type**              | **Description**                                                                                                                                                                                                                                                                                                                                                                                   |
| ------------- | --------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnMIDIMessage | Action&lt;byte[]?&gt; | Fired when the MIDI port corresponding to this MIDIInput finishes receiving one or more MIDI messages. An instance of MIDIMessageEvent containing the message that was received is passed to the event handler.<br></br>Parameter contains the data bytes of a single MIDI message. See the [MIDI specification](https://midi.org/summary-of-midi-1-0-messages) for more information on its form. |


<br></br>
### IMIDIOutput

The MIDIOutput interface of the Web MIDI API provides methods to add messages to the queue of an output device, and to clear the queue of messages.

#### Inheritance

- [IMIDIPort](#imidiport)

#### Methods

| **Name** | **Parameters**                                                                       | **ReturnType** | **Description**                                                                                                                       |
| -------- | ------------------------------------------------------------------------------------ | -------------- | ------------------------------------------------------------------------------------------------------------------------------------- |
| Send     | int[] data, [long? timestamp = null],[CancellationToken cancellationToken = default] | ValueTask      | Queues messages for the corresponding MIDI port. The message can be sent immediately, or with an optional timestamp to delay sending. |
| Clear    | [CancellationToken cancellationToken = default]                                      | ValueTask      | Clears the queue of messages being sent to the output device.                                                                         |



<br></br>
### IWebMIDIInProcess

#### Methods

| **Name**          | **Parameters**                                                                                 | **ReturnType**                                                 | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| ----------------- | ---------------------------------------------------------------------------------------------- | -------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| RequestMIDIAccess | [bool sysex = false], [bool software = false], [CancellationToken cancellationToken = default] | ValueTask&lt;[IMIDIAccessInProcess](#imidiaccessinprocess)&gt; | Represents a request for access to MIDI devices on a user's system. This method is part of the Web MIDI API, which provides a means for accessing, enumerating, and manipulating MIDI devices.<br></br>This method may prompt the user for access to MIDI devices available to their system, or it may use a previously established preference to grant or deny access. If permission is granted then the Promise resolves and a MIDIAccess object is returned. |


<br></br>
### IMIDIAccessInProcess

Provides methods for listing MIDI input and output devices, and obtaining access to those devices.

#### Properties

| **Name**     | **Type**                                      | get/set | **Description**                                                                           |
| ------------ | --------------------------------------------- | ------- | ----------------------------------------------------------------------------------------- |
| Inputs       | [IMIDIInputInProcess](#imidiinputinprocess)   | get     | Provides access to any available MIDI input ports.                                        |
| Outputs      | [IMIDIOutputInProcess](#imidioutputinprocess) | get     | Provides access to any available MIDI output ports.                                       |
| SysexEnabled | bool                                          | get     | Indicates whether system exclusive support is enabled on the current MIDIAccess instance. |

#### Events

| **Name**      | **Type**                                                | **Description**                                                                                                                                                                                                                                      |
| ------------- | ------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnStateChange | Action&lt;[IMIDIPortInProcess](#imidiportinprocess)&gt; | Fired when a new MIDI port is added or when an existing port changes state.<br></br>Parameter is the MIDIPort instance for a port that has been connected or disconnected.<br />Note: Dispose the given MIDIPort instance when you are done with it. |


<br></br>
### IMIDIPortInProcess

Represents a MIDI input or output port.

A MIDIPort instance is created when a new MIDI device is connected. Therefore it has no constructor.

#### Properties

| **Name**     | **Type** | get/set | **Description**                                                                                                                                                                                                                                                                                                                                            |
| ------------ | -------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Id           | string   | get     | Contains the unique ID of the port.                                                                                                                                                                                                                                                                                                                        |
| Manufacturer | string   | get     | Contains the manufacturer of the port.                                                                                                                                                                                                                                                                                                                     |
| Name         | string   | get     | Contains the system name of the port.                                                                                                                                                                                                                                                                                                                      |
| Type         | string   | get     | Contains the type of the port, one of:<br/>- "input": The MIDIPort is an input port.<br/>- "output": The MIDIPort is an output port.                                                                                                                                                                                                                       |
| Version      | string   | get     | Contains the version of the port.                                                                                                                                                                                                                                                                                                                          |
| State        | string   | get     | Contains the state of the port, one of:<br/>- "connected": The device that this MIDIPort represents is currently connected.<br/>- "disconnected": The device that this MIDIPort represents is disconnected from the system.                                                                                                                                |
| Connection   | string   | get     | Contains the connection state of the port, one of:<br/>- "open": The device that this MIDIPort represents has been opened and is available.<br/>- "closed": The device that this MIDIPort represents has not been opened, or has been closed.<br/>- "pending": The device that this MIDIPort represents has been opened but has subsequently disconnected. |

#### Methods

| **Name**        | **Parameters**                                  | **ReturnType**          | **Description**                                                                                                                                                                                                                                                                                                                                                                             |
| --------------- | ----------------------------------------------- | ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Open            | [CancellationToken cancellationToken = default] | ValueTask               | Makes the MIDI device connected to this MIDIPort explicitly available.<br></br>If the port is successfully opened a new MIDIConnectionEvent is queued to the MIDIPort statechange and MIDIAccess statechange events, and the MIDIPort.connection property is changed to "open".<br></br>If the port is already open when this method is called, then the promise will resolve successfully. |
| Close           | [CancellationToken cancellationToken = default] | ValueTask               | Makes the access to the MIDI device connected to this MIDIPort unavailable.<br></br>If the port is successfully opened a new MIDIConnectionEvent is queued to the MIDIPort statechange and MIDIAccess statechange events, and the MIDIPort.connection property is changed to "closed".                                                                                                      |

#### Events

| **Name**      | **Type** | **Description**                                                      |
| ------------- | -------- | -------------------------------------------------------------------- |
| OnStateChange | Action   | Fired when this port changes from open to closed, or closed to open. |


<br></br>
### IMIDIInputInProcess

The MIDIInput interface of the Web MIDI API receives messages from a MIDI input port.

#### Inheritance

- [IMIDIPortInProcess](#imidiportinprocess)

#### Events

| **Name**      | **Type**              | **Description**                                                                                                                                                                                                                                                                                                                                                                                   |
| ------------- | --------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnMIDIMessage | Action&lt;byte[]?&gt; | Fired when the MIDI port corresponding to this MIDIInput finishes receiving one or more MIDI messages. An instance of MIDIMessageEvent containing the message that was received is passed to the event handler.<br></br>Parameter contains the data bytes of a single MIDI message. See the [MIDI specification](https://midi.org/summary-of-midi-1-0-messages) for more information on its form. |


<br></br>
### IMIDIOutputInProcess

The MIDIOutput interface of the Web MIDI API provides methods to add messages to the queue of an output device, and to clear the queue of messages.

#### Inheritance

- [IMIDIPortInProcess](#imidiportinprocess)

#### Methods

| **Name** | **Parameters**                       | **ReturnType** | **Description**                                                                                                                       |
| -------- | ------------------------------------ | -------------- | ------------------------------------------------------------------------------------------------------------------------------------- |
| Send     | int[] data, [long? timestamp = null] | void           | Queues messages for the corresponding MIDI port. The message can be sent immediately, or with an optional timestamp to delay sending. |
| Clear    | *empty*                              | void           | Clears the queue of messages being sent to the output device.                                                                         |
