# Window Management

The *Window Management API* allows you to get detailed information on the displays connected to your device and more easily place windows on specific screens,
paving the way towards more effective multi-screen applications.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required IWindowManagement WindowManagement { private get; init; }

    private async Task GetDisplayInfos() {
        string orientation = await WindowManagement.Screen.OrientationType;
        int width = await WindowManagement.Screen.AvailWidth;
        int height = await WindowManagement.Screen.AvailHeight;


        await using IScreenDetails screenDetails = await WindowManagement.GetScreenDetails();
        await using IScreenDetailed screenDetailed = await screenDetails.CurrentScreen;

        string label = await screenDetailed.Label;
        double ratio = await screenDetailed.DevicePixelRatio;
        bool isPrimary = await screenDetailed.IsPrimary;


        Console.WriteLine($"""
            The Display "{label}"
            - has {width} x {height} -> pixel ratio {ratio}
            - with orientation "{orientation}"
            - {(isPrimary ? "is" : "is not")} your primary display
            """);
    }
}
```


<br><br />
## Members

### IWindowManagement

The *Window Management API* allows you to get detailed information on the displays connected to your device and more easily place windows on specific screens,
paving the way towards more effective multi-screen applications.

#### Properties

| **Name** | **Type**             | get/set | **Description**                                                                                                                                                                                                                                                    |
| -------- | -------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Screen   | [IScreen](#iscreen)  | get     | The Window property *screen* returns a reference to the screen object associated with the window. The screen object, implementing the Screen interface, is a special object for inspecting properties of the screen on which the current window is being rendered. |

#### Methods

| **Name**         | **Parameters**                                                                                                            | **ReturnType**                                     | **Description**                                                                                                                                                                                          |
| ---------------- | ------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetScreenDetails | [CancellationToken cancellationToken = default]                                                                           | ValueTask&lt;[IScreenDetails](#iscreendetails)&gt; | The *getScreenDetails()* method of the Window interface returns a Promise that fulfills with a ScreenDetails object instance representing the details of all the screens available to the user's device. |
| Open             | [string? url = null], [string? target = null], [string? features = null], [CancellationToken cancellationToken = default] | ValueTask                                          | The *open()* method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name.                          |


<br></br>
### IScreen

The *Screen* interface represents a screen, usually the one on which the current window is being rendered, and is obtained using window.screen.

Note that browsers determine which screen to report as current by detecting which screen has the center of the browser window.

#### Properties

| **Name**         | **Type**                | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                            |
| ---------------- | ----------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Width            | ValueTask&lt;int&gt;    | get     | Returns the width of the screen in CSS pixels.                                                                                                                                                                                                                                                                                                                                             |
| Height           | ValueTask&lt;int&gt;    | get     | Returns the height of the screen in CSS pixels.                                                                                                                                                                                                                                                                                                                                            |
| AvailWidth       | ValueTask&lt;int&gt;    | get     | Returns the amount of horizontal space (in CSS pixels) available to the window.                                                                                                                                                                                                                                                                                                            |
| AvailHeight      | ValueTask&lt;int&gt;    | get     | Returns the height, in CSS pixels, of the space available for Web content on the screen. Since Screen is exposed on the Window interface's window.screen property, you access *availHeight* using *window.screen.availHeight*.                                                                                                                                                             |
| ColorDepth       | ValueTask&lt;int&gt;    | get     | Returns the color depth of the screen. Per the CSSOM, some implementations return 24 for compatibility reasons. See the browser compatibility section for those that don't.                                                                                                                                                                                                                |
| PixelDepth       | ValueTask&lt;int&gt;    | get     | Returns the bit depth of the screen. Per the CSSOM, some implementations return 24 for compatibility reasons. See the browser compatibility section for those that don't.                                                                                                                                                                                                                  |
| IsExtended       | ValueTask&lt;bool&gt;   | get     | Returns true if the user's device has multiple screens, and false if not.<br />This property is typically accessed via window.screen.isExtended, and can be used to test whether multiple screens are available before attempting to create a multi-window, multi-screen layout using the [Window Management API](https://developer.mozilla.org/en-US/docs/Web/API/Window_Management_API). |
| OrientationType  | ValueTask&lt;string&gt; | get     | Returns the document's current orientation type, one of:<br />- "portrait-primary"<br />- "portrait-secondary"<br />- "landscape-primary"<br />- "landscape-secondary"                                                                                                                                                                                                                     |
| OrientationAngle | ValueTask&lt;double&gt; | get     | Returns the document's current orientation angle.                                                                                                                                                                                                                                                                                                                                          |

#### Methods

| **Name**            | **Parameters**                                                      | **ReturnType**          | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| ------------------- | ------------------------------------------------------------------- | ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetWidth            | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *Width*                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| GetHeight           | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *Height*                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| GetAvailWidth       | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *AvailWidth*                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| GetAvailHeight      | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *AvailHeight*                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| GetColorDepth       | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *ColorDepth*                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| GetPixelDepth       | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *PixelDepth*                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| GetIsExtended       | CancellationToken cancellationToken                                 | ValueTask&lt;bool&gt;   | see Property *IsExtended*                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| GetOrientationType  | CancellationToken cancellationToken                                 | ValueTask&lt;string&gt; | see Property *OrientationType*                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| GetOrientationAngle | CancellationToken cancellationToken                                 | ValueTask&lt;double&gt; | see Property *OrientationAngle*                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| LockOrientation     | string orientation, [CancellationToken cancellationToken = default] | ValueTask               | Locks the orientation of the containing document to the specified orientation.<br />Typically orientation locking is only enabled on mobile devices, and when the browser context is full screen. If locking is supported, then it must work for all the parameter values listed as follows:<br />- "any"<br />- "natural"<br />- "landscape"<br />- "landscape-primary"<br />- "landscape-secondary"<br />- "portrait"<br />- "portrait-primary"<br />- "portrait-secondary" |
| UnlockOrientation   | [CancellationToken cancellationToken = default]                     | ValueTask               | Unlocks the orientation of the containing document from its default orientation.                                                                                                                                                                                                                                                                                                                                                                                              |

#### Events

| **Name**             | **Type** | **Description**                                                                                                                                                                            |
| -------------------- | -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| OnChange             | Action   | Fired on a specific screen when one or more of the following properties change on it:<br />- width<br />- height<br />- availWidth<br />- availHeight<br />- colorDepth<br />- orientation |
| OnOrientationChange  | Action   | Fired whenever the screen changes orientation, for example when a user rotates their mobile phone.                                                                                         |


<br></br>
### IScreenDetails

The *ScreenDetails* interface of the Window Management API represents the details of all the screens available to the user's device.

This information is accessed via the *Window.getScreenDetails()* method.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Properties

| **Name**         | **Type**                                               | get/set | **Description**                                                                                                                          |
| ---------------- | ------------------------------------------------------ | ------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| CurrentScreen    | ValueTask&lt;[IScreenDetailed](#iscreendetailed)&gt;   | get     | A single ScreenDetailed object representing detailed information about the screen that the current browser window is displayed in.       |
| Screens          | ValueTask&lt;[IScreenDetailed](#iscreendetailed)[]&gt; | get     | An array of ScreenDetailed objects, each one representing detailed information about one specific screen available to the user's device. |

#### Methods

| **Name**         | **Parameters**                      | **ReturnType**                                         | **Description**              |
| ---------------- | ----------------------------------- | ------------------------------------------------------ | ---------------------------- |
| GetCurrentScreen | CancellationToken cancellationToken | ValueTask&lt;[IScreenDetailed](#iscreendetailed)&gt;   | see Property *CurrentScreen* |
| GetScreens       | CancellationToken cancellationToken | ValueTask&lt;[IScreenDetailed](#iscreendetailed)[]&gt; | see Property *Screens*       |

#### Events

| **Name**              | **Type** | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| --------------------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnCurrentScreenChange | Action   | Is fired when the ScreenDetails.currentScreen changes in one of the following ways:<br />- The current screen changes to a different screen, i.e., the current browser window is moved to a different screen.<br />- One or more of the following properties change on the current screen: width, height, availWidth, availHeight, colorDepth, orientation<br />- One or more properties of [ScreenDetailed](https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetailed) changes. |
| OnScreensChange       | Action   | Is fired when the set of screens available to the system has changed: that is, a new screen has become available or an existing screen has become unavailable. This will be reflected in a change in the screens array.                                                                                                                                                                                                                                                                |


<br></br>
### IScreenDetailed

The *ScreenDetailed* interface of the Window Management API represents detailed information about one specific screen available to the user's device.

*ScreenDetailed* objects can be accessed via the *ScreenDetails.screens* and *ScreenDetails.currentScreen* properties.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Properties

| **Name**         | **Type**                | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                           |
| ---------------- | ----------------------- | ------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Left             | ValueTask&lt;int&gt;    | get     | A number representing the x-coordinate (left-hand edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.<br/>This is equal to the true left-hand edge, ignoring any OS UI element drawn at the left of the screen. Windows cannot be placed in those areas; to get the left-hand coordinate of the screen area that windows can be placed in, use *AvailLeft*.                     |
| Top              | ValueTask&lt;int&gt;    | get     | A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.<br/>This is equal to the true top edge, ignoring any OS UI element drawn at the top of the screen. Windows cannot be placed in those areas; to get the top coordinate of the screen area that windows can be placed in, use *AvailTop*.                                         |
| AvailLeft        | ValueTask&lt;int&gt;    | get     | A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.<br/>This is equal to the *Left* property, plus the width of any OS UI element drawn on the left of the screen. Windows cannot be placed in those areas, so availLeft is useful for giving you the left boundary of the actual area available to open or place windows.          |
| AvailTop         | ValueTask&lt;int&gt;    | get     | A number representing the y-coordinate (top edge) of the available screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.<br/>This is equal to the *Top* property, plus the height of any OS UI element drawn at the top of the screen. Windows cannot be placed in those areas, so availTop is useful for giving you the top boundary of the actual area available to open or place windows.         |
| Label            | ValueTask&lt;string&gt; | get     | A descriptive label for the screen, for example "Built-in Retina Display".<br/>This is useful for constructing a list of options to display to the user if you want them to choose a screen to display content on.                                                                                                                                                                                                                        |
| DevicePixelRatio | ValueTask&lt;double&gt; | get     | A number representing the screen's device pixel ratio.<br/>This is the same as the value returned by *Window.devicePixelRatio*, except that *Window.devicePixelRatio*:<br />- always returns the device pixel ratio for the current screen.<br />- also includes scaling of the window itself, i.e., page zoom (at least on some browser implementations).                                                                                |
| IsPrimary        | ValueTask&lt;bool&gt;   | get     | A boolean indicating whether the screen is set as the operating system (OS) primary screen or not.<br/>The OS hosting the browser will have one primary screen, and one or more secondary screens. The primary screen can usually be specified by the user via OS settings, and generally contains OS UI features such as the taskbar/icon dock. The primary screen may change for a number of reasons, such as a screen being unplugged. |
| IsInternal       | ValueTask&lt;bool&gt;   | get     | A boolean indicating whether the screen is internal to the device or external. External devices are generally manufactured separately from the device they are attached to and can be connected and disconnected as needed,  whereas internal screens are part of the device and not intended to be disconnected.                                                                                                                         |
| Width            | ValueTask&lt;int&gt;    | get     | see Property *IScreen.Width*                                                                                                                                                                                                                                                                                                                                                                                                              |
| Height           | ValueTask&lt;int&gt;    | get     | see Property *IScreen.Height*                                                                                                                                                                                                                                                                                                                                                                                                             |
| AvailWidth       | ValueTask&lt;int&gt;    | get     | see Property *IScreen.AvailWidth*                                                                                                                                                                                                                                                                                                                                                                                                         |
| AvailHeight      | ValueTask&lt;int&gt;    | get     | see Property *IScreen.AvailHeight*                                                                                                                                                                                                                                                                                                                                                                                                        |
| ColorDepth       | ValueTask&lt;int&gt;    | get     | see Property *IScreen.ColorDepth*                                                                                                                                                                                                                                                                                                                                                                                                         |
| PixelDepth       | ValueTask&lt;int&gt;    | get     | see Property *IScreen.PixelDepth*                                                                                                                                                                                                                                                                                                                                                                                                         |
| IsExtended       | ValueTask&lt;bool&gt;   | get     | see Property *IScreen.IsExtended*                                                                                                                                                                                                                                                                                                                                                                                                         |
| OrientationType  | ValueTask&lt;string&gt; | get     | see Property *IScreen.OrientationType*                                                                                                                                                                                                                                                                                                                                                                                                    |
| OrientationAngle | ValueTask&lt;double&gt; | get     | see Property *IScreen.OrientationAngle*                                                                                                                                                                                                                                                                                                                                                                                                   |

#### Methods

| **Name**            | **Parameters**                                                      | **ReturnType**          | **Description**                        |
| ------------------- | ------------------------------------------------------------------- | ----------------------- | -------------------------------------- |
| GetLeft             | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *Left*                    |
| GetTop              | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *Top*                     |
| GetAvailLeft        | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *AvailLeft*               |
| GetAvailTop         | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *AvailTop*                |
| GetLabel            | CancellationToken cancellationToken                                 | ValueTask&lt;string&gt; | see Property *Label*                   |
| GetDevicePixelRatio | CancellationToken cancellationToken                                 | ValueTask&lt;double&gt; | see Property *DevicePixelRatio*        |
| GetIsPrimary        | CancellationToken cancellationToken                                 | ValueTask&lt;bool&gt;   | see Property *IsPrimary*               |
| GetIsInternal       | CancellationToken cancellationToken                                 | ValueTask&lt;bool&gt;   | see Property *IsInternal*              |
| GetWidth            | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *Width*                   |
| GetHeight           | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *Height*                  |
| GetAvailWidth       | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *AvailWidth*              |
| GetAvailHeight      | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *AvailHeight*             |
| GetColorDepth       | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *ColorDepth*              |
| GetPixelDepth       | CancellationToken cancellationToken                                 | ValueTask&lt;int&gt;    | see Property *PixelDepth*              |
| GetIsExtended       | CancellationToken cancellationToken                                 | ValueTask&lt;bool&gt;   | see Property *IsExtended*              |
| GetOrientationType  | CancellationToken cancellationToken                                 | ValueTask&lt;string&gt; | see Property *OrientationType*         |
| GetOrientationAngle | CancellationToken cancellationToken                                 | ValueTask&lt;double&gt; | see Property *OrientationAngle*        |
| LockOrientation     | string orientation, [CancellationToken cancellationToken = default] | ValueTask               | see Method *IScreen.LockOrientation*   |
| UnlockOrientation   | [CancellationToken cancellationToken = default]                     | ValueTask               | see Method *IScreen.UnlockOrientation* |

#### Events

| **Name**             | **Type** | **Description**                         |
| -------------------- | -------- | --------------------------------------- |
| OnChange             | Action   | see Event *IScreen.OnChange*            |
| OnOrientationChange  | Action   | see Event *IScreen.OnOrientationChange* |



<br></br>
### IWindowManagementInProcess

The *Window Management API* allows you to get detailed information on the displays connected to your device and more easily place windows on specific screens,
paving the way towards more effective multi-screen applications.

#### Properties

| **Name** | **Type**                               | get/set | **Description**                                                                                                                                                                                                                                                    |
| -------- | -------------------------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Screen   | [IScreenInProcess](#iscreeninprocess)  | get     | The Window property *screen* returns a reference to the screen object associated with the window. The screen object, implementing the Screen interface, is a special object for inspecting properties of the screen on which the current window is being rendered. |

#### Methods

| **Name**         | **Parameters**                                                           | **ReturnType**                                                       | **Description**                                                                                                                                                                                          |
| ---------------- | ------------------------------------------------------------------------ | -------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetScreenDetails | [CancellationToken cancellationToken = default]                          | ValueTask&lt;[IScreenDetailsInProcess](#iscreendetailsinprocess)&gt; | The *getScreenDetails()* method of the Window interface returns a Promise that fulfills with a ScreenDetails object instance representing the details of all the screens available to the user's device. |
| Open             | [string? url = null], [string? target = null], [string? features = null] | void                                                                 | The *open()* method of the Window interface loads a specified resource into a new or existing browsing context (that is, a tab, a window, or an iframe) under a specified name.                          |


<br></br>
### IScreenInProcess

The *Screen* interface represents a screen, usually the one on which the current window is being rendered, and is obtained using window.screen.

Note that browsers determine which screen to report as current by detecting which screen has the center of the browser window.

#### Properties

| **Name**         | **Type** | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                            |
| ---------------- | -------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Width            | int      | get     | Returns the width of the screen in CSS pixels.                                                                                                                                                                                                                                                                                                                                             |
| Height           | int      | get     | Returns the height of the screen in CSS pixels.                                                                                                                                                                                                                                                                                                                                            |
| AvailWidth       | int      | get     | Returns the amount of horizontal space (in CSS pixels) available to the window.                                                                                                                                                                                                                                                                                                            |
| AvailHeight      | int      | get     | Returns the height, in CSS pixels, of the space available for Web content on the screen. Since Screen is exposed on the Window interface's window.screen property, you access *availHeight* using *window.screen.availHeight*.                                                                                                                                                             |
| ColorDepth       | int      | get     | Returns the color depth of the screen. Per the CSSOM, some implementations return 24 for compatibility reasons. See the browser compatibility section for those that don't.                                                                                                                                                                                                                |
| PixelDepth       | int      | get     | Returns the bit depth of the screen. Per the CSSOM, some implementations return 24 for compatibility reasons. See the browser compatibility section for those that don't.                                                                                                                                                                                                                  |
| IsExtended       | bool     | get     | Returns true if the user's device has multiple screens, and false if not.<br />This property is typically accessed via window.screen.isExtended, and can be used to test whether multiple screens are available before attempting to create a multi-window, multi-screen layout using the [Window Management API](https://developer.mozilla.org/en-US/docs/Web/API/Window_Management_API). |
| OrientationType  | string   | get     | Returns the document's current orientation type, one of:<br />- "portrait-primary"<br />- "portrait-secondary"<br />- "landscape-primary"<br />- "landscape-secondary"                                                                                                                                                                                                                     |
| OrientationAngle | double   | get     | Returns the document's current orientation angle.                                                                                                                                                                                                                                                                                                                                          |

#### Methods

| **Name**            | **Parameters**                                                      | **ReturnType** | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| ------------------- | ------------------------------------------------------------------- | -------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| LockOrientation     | string orientation, [CancellationToken cancellationToken = default] | ValueTask      | Locks the orientation of the containing document to the specified orientation.<br />Typically orientation locking is only enabled on mobile devices, and when the browser context is full screen. If locking is supported, then it must work for all the parameter values listed as follows:<br />- "any"<br />- "natural"<br />- "landscape"<br />- "landscape-primary"<br />- "landscape-secondary"<br />- "portrait"<br />- "portrait-primary"<br />- "portrait-secondary" |
| UnlockOrientation   | *empty*                                                             | void           | Unlocks the orientation of the containing document from its default orientation.                                                                                                                                                                                                                                                                                                                                                                                              |

#### Events

| **Name**             | **Type** | **Description**                                                                                                                                                                            |
| -------------------- | -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| OnChange             | Action   | Fired on a specific screen when one or more of the following properties change on it:<br />- width<br />- height<br />- availWidth<br />- availHeight<br />- colorDepth<br />- orientation |
| OnOrientationChange  | Action   | Fired whenever the screen changes orientation, for example when a user rotates their mobile phone.                                                                                         |


<br></br>
### IScreenDetailsInProcess

The *ScreenDetails* interface of the Window Management API represents the details of all the screens available to the user's device.

This information is accessed via the *Window.getScreenDetails()* method.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Properties

| **Name**         | **Type**                                                | get/set | **Description**                                                                                                                          |
| ---------------- | ------------------------------------------------------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| CurrentScreen    | [IScreenDetailedInProcess](#iscreendetailedinprocess)   | get     | A single ScreenDetailed object representing detailed information about the screen that the current browser window is displayed in.       |
| Screens          | [IScreenDetailedInProcess](#iscreendetailedinprocess)[] | get     | An array of ScreenDetailed objects, each one representing detailed information about one specific screen available to the user's device. |

#### Events

| **Name**              | **Type** | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| --------------------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnCurrentScreenChange | Action   | Is fired when the ScreenDetails.currentScreen changes in one of the following ways:<br />- The current screen changes to a different screen, i.e., the current browser window is moved to a different screen.<br />- One or more of the following properties change on the current screen: width, height, availWidth, availHeight, colorDepth, orientation<br />- One or more properties of [ScreenDetailed](https://developer.mozilla.org/en-US/docs/Web/API/ScreenDetailed) changes. |
| OnScreensChange       | Action   | Is fired when the set of screens available to the system has changed: that is, a new screen has become available or an existing screen has become unavailable. This will be reflected in a change in the screens array.                                                                                                                                                                                                                                                                |


<br></br>
### IScreenDetailedInProcess

The *ScreenDetailed* interface of the Window Management API represents detailed information about one specific screen available to the user's device.

*ScreenDetailed* objects can be accessed via the *ScreenDetails.screens* and *ScreenDetails.currentScreen* properties.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Properties

| **Name**         | **Type** | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                           |
| ---------------- | -------- | ------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Left             | int      | get     | A number representing the x-coordinate (left-hand edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.<br/>This is equal to the true left-hand edge, ignoring any OS UI element drawn at the left of the screen. Windows cannot be placed in those areas; to get the left-hand coordinate of the screen area that windows can be placed in, use *AvailLeft*.                     |
| Top              | int      | get     | A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.<br/>This is equal to the true top edge, ignoring any OS UI element drawn at the top of the screen. Windows cannot be placed in those areas; to get the top coordinate of the screen area that windows can be placed in, use *AvailTop*.                                         |
| AvailLeft        | int      | get     | A number representing the y-coordinate (top edge) of the total screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.<br/>This is equal to the *Left* property, plus the width of any OS UI element drawn on the left of the screen. Windows cannot be placed in those areas, so availLeft is useful for giving you the left boundary of the actual area available to open or place windows.          |
| AvailTop         | int      | get     | A number representing the y-coordinate (top edge) of the available screen area inside the OS virtual screen arrangement, relative to the multi-screen origin.<br/>This is equal to the *Top* property, plus the height of any OS UI element drawn at the top of the screen. Windows cannot be placed in those areas, so availTop is useful for giving you the top boundary of the actual area available to open or place windows.         |
| Label            | string   | get     | A descriptive label for the screen, for example "Built-in Retina Display".<br/>This is useful for constructing a list of options to display to the user if you want them to choose a screen to display content on.                                                                                                                                                                                                                        |
| DevicePixelRatio | double   | get     | A number representing the screen's device pixel ratio.<br/>This is the same as the value returned by *Window.devicePixelRatio*, except that *Window.devicePixelRatio*:<br />- always returns the device pixel ratio for the current screen.<br />- also includes scaling of the window itself, i.e., page zoom (at least on some browser implementations).                                                                                |
| IsPrimary        | bool     | get     | A boolean indicating whether the screen is set as the operating system (OS) primary screen or not.<br/>The OS hosting the browser will have one primary screen, and one or more secondary screens. The primary screen can usually be specified by the user via OS settings, and generally contains OS UI features such as the taskbar/icon dock. The primary screen may change for a number of reasons, such as a screen being unplugged. |
| IsInternal       | bool     | get     | A boolean indicating whether the screen is internal to the device or external. External devices are generally manufactured separately from the device they are attached to and can be connected and disconnected as needed,  whereas internal screens are part of the device and not intended to be disconnected.                                                                                                                         |
| Width            | int      | get     | see Property *IScreenInProcess.Width*                                                                                                                                                                                                                                                                                                                                                                                                     |
| Height           | int      | get     | see Property *IScreenInProcess.Height*                                                                                                                                                                                                                                                                                                                                                                                                    |
| AvailWidth       | int      | get     | see Property *IScreenInProcess.AvailWidth*                                                                                                                                                                                                                                                                                                                                                                                                |
| AvailHeight      | int      | get     | see Property *IScreenInProcess.AvailHeight*                                                                                                                                                                                                                                                                                                                                                                                               |
| ColorDepth       | int      | get     | see Property *IScreenInProcess.ColorDepth*                                                                                                                                                                                                                                                                                                                                                                                                |
| PixelDepth       | int      | get     | see Property *IScreenInProcess.PixelDepth*                                                                                                                                                                                                                                                                                                                                                                                                |
| IsExtended       | bool     | get     | see Property *IScreenInProcess.IsExtended*                                                                                                                                                                                                                                                                                                                                                                                                |
| OrientationType  | string   | get     | see Property *IScreenInProcess.OrientationType*                                                                                                                                                                                                                                                                                                                                                                                           |
| OrientationAngle | double   | get     | see Property *IScreenInProcess.OrientationAngle*                                                                                                                                                                                                                                                                                                                                                                                          |

#### Methods

| **Name**            | **Parameters**                                                      | **ReturnType**          | **Description**                                 |
| ------------------- | ------------------------------------------------------------------- | ----------------------- | ----------------------------------------------- |
| LockOrientation     | string orientation, [CancellationToken cancellationToken = default] | ValueTask               | see Method *IScreenInProcess.LockOrientation*   |
| UnlockOrientation   | *empty*                                                             | void                    | see Method *IScreenInProcess.UnlockOrientation* |

#### Events

| **Name**             | **Type** | **Description**                                  |
| -------------------- | -------- | ------------------------------------------------ |
| OnChange             | Action   | see Event *IScreenInProcess.OnChange*            |
| OnOrientationChange  | Action   | see Event *IScreenInProcess.OnOrientationChange* |
