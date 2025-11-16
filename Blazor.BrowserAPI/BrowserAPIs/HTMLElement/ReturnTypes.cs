namespace BrowserAPI;

/// <summary>
/// <para>A DOMRect describes the size and position of a rectangle.</para>
/// <para>
/// The type of box represented by the DOMRect is specified by the method or property that returned it.
/// For example, Range.getBoundingClientRect() specifies the rectangle that bounds the content of the range using such objects.
/// </para>
/// </summary>
/// <param name="X">The x coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).</param>
/// <param name="Y">The y coordinate of the DOMRect's origin (typically the top-left corner of the rectangle).</param>
/// <param name="Width">The width of the DOMRect.</param>
/// <param name="Height">The height of the DOMRect.</param>
/// <param name="Top">Returns the top coordinate value of the DOMRect (has the same value as y, or y + height if height is negative).</param>
/// <param name="Bottom">Returns the bottom coordinate value of the DOMRect (has the same value as y + height, or y if height is negative).</param>
/// <param name="Left">Returns the left coordinate value of the DOMRect (has the same value as x, or x + width if width is negative).</param>
/// <param name="Right">Returns the right coordinate value of the DOMRect (has the same value as x + width, or x if width is negative).</param>
public readonly record struct DOMRect(double X, double Y, double Width, double Height, double Top, double Bottom, double Left, double Right);


/// <summary>
/// <para>Holds the drag operation's data (as a DataTransfer object).</para>
/// <para>
/// Represents a drag and drop interaction.
/// The user initiates a drag by placing a pointer device (such as a mouse) on the touch surface and then dragging the pointer to a new location (such as another DOM element).
/// Applications are free to interpret a drag and drop interaction in an application-specific way.
/// </para>
/// </summary>
/// <remarks>
/// Note: Do not forget to call <i>DispseAsync()</i> on each single file in <see cref="Files"/> when you done with it.
/// </remarks>
/// <param name="DropEffect">Gets the type of drag-and-drop operation currently selected or sets the operation to a new type. The value must be "none", "copy", "link" or "move".</param>
/// <param name="EffectAllowed">Provides all of the types of operations that are possible. Must be one of "none", "copy", "copyLink", "copyMove", "link", "linkMove", "move", "all" or "uninitialized".</param>
/// <param name="Types">Giving the formats that were set in the dragstart event.</param>
/// <param name="Files">Contains a list of all the local files available on the data transfer. If the drag operation doesn't involve dragging files, this property is an empty list.</param>
public readonly record struct DragEvent(string DropEffect, string EffectAllowed, string[] Types, IFile[] Files);

/// <summary>
/// <para>Holds the drag operation's data (as a DataTransfer object).</para>
/// <para>
/// Represents a drag and drop interaction.
/// The user initiates a drag by placing a pointer device (such as a mouse) on the touch surface and then dragging the pointer to a new location (such as another DOM element).
/// Applications are free to interpret a drag and drop interaction in an application-specific way.
/// </para>
/// </summary>
/// <remarks>
/// Note: Do not forget to call <i>Dispse()</i> on each single file in <see cref="Files"/> when you done with it.
/// </remarks>
/// <param name="DropEffect">Gets the type of drag-and-drop operation currently selected or sets the operation to a new type. The value must be "none", "copy", "link" or "move".</param>
/// <param name="EffectAllowed">Provides all of the types of operations that are possible. Must be one of "none", "copy", "copyLink", "copyMove", "link", "linkMove", "move", "all" or "uninitialized".</param>
/// <param name="Types">Giving the formats that were set in the dragstart event.</param>
/// <param name="Files">Contains a list of all the local files available on the data transfer. If the drag operation doesn't involve dragging files, this property is an empty list.</param>
public readonly record struct DragEventInProcess(string DropEffect, string EffectAllowed, string[] Types, IFileInProcess[] Files);


/// <summary>
/// Represents the event object of a securitypolicyviolation event sent on an Element, Document, or worker when its Content Security Policy (CSP) is violated.
/// </summary>
/// <param name="BlockedURI">Represents the URI of the resource that was blocked because it violates a Content Security Policy (CSP).</param>
/// <param name="EffectiveDirective">Represents the Content Security Policy (CSP) directive that was violated.</param>
/// <param name="DocumentURI">Represents the URI of the document or worker in which the Content Security Policy (CSP) violation occurred.</param>
/// <param name="LineNumber">The line number in the document or worker at which the violation occurred.</param>
/// <param name="ColumnNumber">The column number in the document or worker at which the violation occurred.</param>
/// <param name="OriginalPolicy">Contains the policy whose enforcement caused the violation.</param>
/// <param name="Referrer">Represents the URL for the referrer of the resources whose policy was violated, or null.</param>
/// <param name="SourceFile">
/// If the violation occurred as a result of a script, this will be the URL of the script; otherwise, it will be null.
/// Both columnNumber and lineNumber should have non-null values if this property is not null.
/// </param>
/// <param name="Sample">
/// <para>Represents a sample of the resource that caused the Content Security Policy (CSP) violation.</para>
/// <para>
/// This is only script-src* and style-src* violations, when the corresponding Content-Security-Policy directive contains the 'report-sample' keyword.
/// In addition, this will only be populated if the resource is an inline script, event handler, or style — external resources causing a violation will not generate a sample.
/// </para>
/// <para>The string contains usually the first 40 characters, or the empty string.</para>
/// </param>
/// <param name="StatusCode">Represents the HTTP status code of the window or worker in which the Content Security Policy (CSP) violation occurred.</param>
/// <param name="Disposition">
/// <para>Indicates how the violated Content Security Policy (CSP) is configured to be treated by the user agent.</para>
/// <para>
/// Possible values are:<br />
/// - "enforce": The policy is enforced and the resource request is blocked.<br />
/// - "report": The violation is reported but the resource request is not blocked.
/// </para>
/// </param>
public readonly record struct SecurityPolicyViolationEvent(string? BlockedURI, string? EffectiveDirective, string? DocumentURI, int? LineNumber, int? ColumnNumber, string? OriginalPolicy, string? Referrer, string? SourceFile, string? Sample, int? StatusCode, string? Disposition);


/// <summary>
/// Describe a user interaction with the keyboard; each event describes a single interaction between the user and a key (or combination of a key with modifier keys) on the keyboard.
/// The event type (keydown, keypress, or keyup) identifies what kind of keyboard activity occurred.
/// </summary>
/// <remarks>
/// Note: KeyboardEvent events just indicate what interaction the user had with a key on the keyboard at a low level, providing no contextual meaning to that interaction.
/// When you need to handle text input, use the input event instead.
/// Keyboard events may not be fired if the user is using an alternate means of entering text, such as a handwriting system on a tablet or graphics tablet.
/// </remarks>
/// <param name="Key">
/// <para>Returns the value of the key pressed by the user, taking into consideration the state of modifier keys such as Shift as well as the keyboard locale and layout.</para>
/// <para>
/// Its value is determined as follows:<br />
/// - If the pressed key has a printed representation, the returned value is a non-empty Unicode character string containing the printable representation of the key.
/// For example: if the pressed key is the Space key, the returned value is a single space (" ").
/// If the pressed key is the B key, the returned value is the string "b".
/// However, if the Shift key is pressed at the same time (so shiftKey is true), the returned value is the string "B".<br />
/// - If the pressed key is a control or special character, the returned value is one of the pre-defined key values.<br />
/// - If the KeyboardEvent represents the press of a dead key, the key value must be "Dead".<br />
/// - Some specialty keyboard keys (such as the extended keys for controlling media on multimedia keyboards) don't generate key codes on Windows; instead, they trigger WM_APPCOMMAND events.
/// These events get mapped to DOM keyboard events, and are listed among the "Virtual key codes" for Windows, even though they aren't actually key codes.<br />
/// - If the key cannot be identified, the returned value is Unidentified.
/// </para>
/// </param>
/// <param name="Code">
/// <para>
/// Represents a physical key on the keyboard (as opposed to the character generated by pressing the key).
/// In other words, this property returns a value that isn't altered by keyboard layout or the state of the modifier keys.
/// </para>
/// <para>
/// If the input device isn't a physical keyboard, but is instead a virtual keyboard or accessibility device,
/// the returned value will be set by the browser to match as closely as possible to what would happen with a physical keyboard,
/// to maximize compatibility between physical and virtual input devices.
/// </para>
/// <para>
/// This property is useful when you want to handle keys based on their physical positions on the input device rather than the characters associated with those keys;
/// this is especially common when writing code to handle input for games that simulate a gamepad-like environment using keys on the keyboard.
/// Be aware, however, that you can't use the value reported by KeyboardEvent.code to determine the character generated by the keystroke,
/// because the keycode's name may not match the actual character that's printed on the key or that's generated by the computer when the key is pressed.
/// </para>
/// <para>
/// For example, the code returned is "KeyQ" for the Q key on a QWERTY layout keyboard, but the same code value also represents the ' key on Dvorak keyboards and the A key on AZERTY keyboards.
/// That makes it impossible to use the value of code to determine what the name of the key is to users if they're not using an anticipated keyboard layout.
/// </para>
/// <para>To determine what character corresponds with the key event, use the KeyboardEvent.key property instead.</para>
/// <para>The code values for Windows, Linux, and macOS are listed on the <see href="https://developer.mozilla.org/en-US/docs/Web/API/UI_Events/Keyboard_event_code_values">KeyboardEvent: code values</see> page.</para>
/// </param>
/// <param name="Location">
/// <para>Represents the location of the key on the keyboard or other input device.</para>
/// <para>
/// Possible values are:<br />
/// - 0 (DOM_KEY_LOCATION_STANDARD): The key has only one version, or can't be distinguished between the left and right versions of the key,
/// and was not pressed on the numeric keypad or a key that is considered to be part of the keypad.<br />
/// - 1 (DOM_KEY_LOCATION_LEFT): The key was the left-hand version of the key; for example, the left-hand Control key was pressed on a standard 101 key US keyboard.
/// This value is only used for keys that have more than one possible location on the keyboard.<br />
/// - 2 (DOM_KEY_LOCATION_RIGHT): The key was the right-hand version of the key; for example, the right-hand Control key is pressed on a standard 101 key US keyboard.
/// This value is only used for keys that have more than one possible location on the keyboard.<br />
/// - 3 (DOM_KEY_LOCATION_NUMPAD): The key was on the numeric keypad, or has a virtual key code that corresponds to the numeric keypad.
/// Note: When NumLock is locked, Firefox always returns DOM_KEY_LOCATION_NUMPAD for the keys on the numeric pad.
/// Otherwise, when NumLock is unlocked and the keyboard actually has a numeric keypad, Firefox always returns DOM_KEY_LOCATION_NUMPAD too.
/// On the other hand, if the keyboard doesn't have a keypad, such as on a notebook computer, some keys become Numpad only when NumLock is locked.
/// When such keys fires key events, the location attribute value depends on the key.
/// That is, it must not be DOM_KEY_LOCATION_NUMPAD.
/// Note: NumLock key's key events indicate DOM_KEY_LOCATION_STANDARD both on Firefox and Internet Explorer.<br />
/// - [deprecated] 4 (DOM_KEY_LOCATION_MOBILE): The key was on a mobile device; this can be on either a physical keypad or a virtual keyboard.<br />
/// - [deprecated] 5 (DOM_KEY_LOCATION_JOYSTICK): The key was a button on a game controller or a joystick on a mobile device.<br />
/// </para>
/// </param>
/// <param name="CtrlKey">Indicates if the control key was pressed (true) or not (false) when the event occurred.</param>
/// <param name="ShiftKey">
/// <para>Indicates if the shift key was pressed (true) or not (false) when the event occurred.</para>
/// <para>The pressing of the shift key may change the key of the event too. For example, pressing B generates key: "b", while simultaneously pressing Shift generates key: "B".</para>
/// </param>
/// <param name="AltKey">Indicates if the alt key (Option or ⌥ on macOS) was pressed (true) or not (false) when the event occurred.</param>
/// <param name="MetaKey">Indicates if the Meta key was pressed (true) or not (false) when the event occurred. Some operating systems may intercept the key so it is never detected.</param>
/// <param name="Repeat">Is true if the given key is being held down such that it is automatically repeating.</param>
/// <param name="IsComposing">Indicates if the event is fired within a composition session, i.e., after compositionstart and before compositionend.</param>
public readonly record struct KeyboardEvent(string Key, string Code, int Location, bool CtrlKey, bool ShiftKey, bool AltKey, bool MetaKey, bool Repeat, bool IsComposing);


/// <summary>
/// Represents events that occur due to the user interacting with a pointing device (such as a mouse). Common events using this interface include click, dblclick, mouseup, mousedown.
/// </summary>
/// <param name="Button">
/// <para>Indicates which button was pressed or released on the mouse to trigger the event.</para>
/// <para>
/// This property only guarantees to indicate which buttons are pressed or released during events caused by pressing or releasing one or multiple buttons.
/// As such, it is not reliable for events such as mouseenter, mouseleave, mouseover, mouseout, or mousemove.
/// </para>
/// <para>
/// Users may change the configuration of buttons on their pointing device so that if an event's button property is zero, it may not have been caused by the button that is physically left–most on the pointing device;
/// however, it should behave as if the left button was clicked in the standard button layout.
/// </para>
/// <para>Note: Do not confuse this property with the MouseEvent.buttons property, which indicates which buttons are pressed for all mouse events types.</para>
/// <para>
/// The value is a number representing a given button:<br />
/// - 0: Main button, usually the left button or the un-initialized state<br />
/// - 1: Auxiliary button, usually the wheel button or the middle button (if present)<br />
/// - 2: Secondary button, usually the right button<br />
/// - 3: Fourth button, typically the Browser Back button<br />
/// - 4: Fifth button, typically the Browser Forward button
/// </para>
/// </param>
/// <param name="Buttons">
/// <para>Indicates which buttons are pressed on the mouse (or other input device) when a mouse event is triggered.</para>
/// <para>
/// Each button that can be pressed is represented by a given number (see below).
/// If more than one button is pressed, the button values are added together to produce a new number.
/// For example, if the secondary (2) and auxiliary (4) buttons are pressed simultaneously, the value is 6 (i.e., 2 + 4).
/// </para>
/// <para>
/// Note: Do not confuse this property with the MouseEvent.button property.
/// The MouseEvent.buttons property indicates the state of buttons pressed during any kind of mouse event,
/// while the MouseEvent.button property only guarantees the correct value for mouse events caused by pressing or releasing one or multiple buttons.
/// </para>
/// <para>
/// The value is a number representing one or more buttons. For more than one button pressed simultaneously, the values are combined (e.g., 3 is primary + secondary):<br />
/// - 0: No button or un-initialized<br />
/// - 1: Primary button (usually the left button)<br />
/// - 2: Secondary button (usually the right button)<br />
/// - 4: Auxiliary button (usually the mouse wheel button or middle button)<br />
/// - 8: 4th button (typically the "Browser Back" button)<br />
/// - 16: 5th button (typically the "Browser Forward" button)
/// </para>
/// </param>
/// <param name="MovementX">
/// <para>
/// Provides the difference in the X coordinate of the mouse pointer between the given event and the previous mousemove event.
/// In other words, the value of the property is computed like this: currentEvent.movementX = currentEvent.screenX - previousEvent.screenX.
/// </para>
/// <para>The number is always zero on any MouseEvent other than mousemove.</para>
/// <para>
/// Warning: Browsers use different units for movementX and screenX than what the specification defines.
/// Depending on the browser and operating system, the movementX units may be a physical pixel, a logical pixel, or a CSS pixel.
/// You may want to avoid the movement properties, and instead calculate the delta between the current client values (screenX, screenY) and the previous client values.
/// </para>
/// </param>
/// <param name="MovementY">
/// <para>
/// Provides the difference in the Y coordinate of the mouse pointer between the given event and the previous mousemove event.
/// In other words, the value of the property is computed like this: currentEvent.movementY = currentEvent.screenY - previousEvent.screenY.
/// </para>
/// <para>The number is always zero on any MouseEvent other than mousemove.</para>
/// <para>
/// Warning: Browsers use different units for movementY and screenY than what the specification defines.
/// Depending on the browser and operating system, the movementX units may be a physical pixel, a logical pixel, or a CSS pixel.
/// You may want to avoid the movement properties, and instead calculate the delta between the current client values (screenX, screenY) and the previous client values.
/// </para>
/// </param>
/// <param name="ClientX">
/// <para>Provides the horizontal coordinate within the application's viewport at which the event occurred (as opposed to the coordinate within the page).</para>
/// <para>For example, clicking on the left edge of the viewport will always result in a mouse event with a clientX value of 0, regardless of whether the page is scrolled horizontally.</para>
/// </param>
/// <param name="ClientY">
/// <para>Provides the vertical coordinate within the application's viewport at which the event occurred (as opposed to the coordinate within the page).</para>
/// <para>For example, clicking on the top edge of the viewport will always result in a mouse event with a clientY value of 0, regardless of whether the page is scrolled vertically.</para>
/// </param>
/// <param name="OffsetX">Provides the offset in the X coordinate of the mouse pointer between that event and the padding edge of the target node.</param>
/// <param name="OffsetY">Provides the offset in the Y coordinate of the mouse pointer between that event and the padding edge of the target node.</param>
/// <param name="PageX">
/// <para>Returns the X (horizontal) coordinate (in pixels) at which the mouse was clicked, relative to the left edge of the entire document. This includes any portion of the document not currently visible.</para>
/// <para>
/// Being based on the edge of the document as it is, this property takes into account any horizontal scrolling of the page.
/// For example, if the page is scrolled such that 200 pixels of the left side of the document are scrolled out of view, and the mouse is clicked 100 pixels inward from the left edge of the view,
/// the value returned by pageX will be 300.
/// </para>
/// <para>Originally, this property was defined as a long integer. The CSSOM View Module redefined it as a double float. See the Browser compatibility section for details.</para>
/// <para>See Coordinate systems for additional information about coordinates specified in this fashion.</para>
/// </param>
/// <param name="PageY">
/// Returns the Y (vertical) coordinate (in pixels) at which the mouse was clicked, relative to the top edge of the entire document.
/// This includes any portion of the document not currently visible.
/// See <see cref="PageX"/> for more information.
/// </param>
/// <param name="ScreenX">
/// <para>Provides the horizontal coordinate (offset) of the mouse pointer in screen coordinates.</para>
/// <para>Note: In a multiscreen environment, screens aligned horizontally will be treated as a single device, and so the range of the screenX value will increase to the combined width of the screens.</para>
/// </param>
/// <param name="ScreenY">Provides the vertical coordinate (offset) of the mouse pointer in screen coordinates.</param>
/// <param name="CtrlKey">
/// <para>Indicates whether the ctrl key was pressed or not when a given mouse event occurs.</para>
/// <para>
/// On Macintosh keyboards, this key is labeled the control key.
/// Also, note that on a Mac, a click combined with the control key is intercepted by the operating system and used to open a context menu, so ctrlKey is not detectable on click events.
/// </para>
/// <para>Pinch-zooming using a trackpad also sends a simulated wheel event with ctrlKey set to true.</para>
/// </param>
/// <param name="ShiftKey">Indicates whether the shift key was pressed or not when a given mouse event occurs.</param>
/// <param name="AltKey">
/// <para>Indicates whether the alt key was pressed or not when a given mouse event occurs.</para>
/// <para>
/// Be aware that the browser can't always detect the alt key on some operating systems.
/// On some Linux variants, for example, a left mouse click combined with the alt key is used to move or resize windows.
/// </para>
/// <para>Note: On Macintosh keyboards, this key is also known as the option key.</para>
/// </param>
/// <param name="MetaKey">
/// <para>Indicates whether the meta key was pressed or not when a given mouse event occurs.</para>
/// <para>
/// Be aware that many operating systems bind special functionality to the meta key, so this property may be false even when the key is actually pressed.
/// On Windows, for example, this key may open the Start menu.
/// </para>
/// <para>Note: On Macintosh keyboards, this key is the command key (⌘). On Windows keyboards, this key is the Windows key (⊞).</para>
/// </param>
public readonly record struct MouseEvent(int Button, int Buttons, int MovementX, int MovementY, double ClientX, double ClientY, double OffsetX, double OffsetY, double PageX, double PageY, double ScreenX, double ScreenY, bool CtrlKey, bool ShiftKey, bool AltKey, bool MetaKey);


/// <summary>
/// <para>Represents events that occur due to the user moving a mouse wheel or similar input device.</para>
/// <para>
/// Don't confuse the wheel event with the scroll event:<br />
/// - A wheel event doesn't necessarily dispatch a scroll event. For example, the element may be unscrollable at all. Zooming actions using the wheel or trackpad also fire wheel events.<br />
/// - A scroll event isn't necessarily triggered by a wheel event. Elements can also be scrolled by using the keyboard, dragging a scrollbar, or using JavaScript.<br />
/// - Even when the wheel event does trigger scrolling, the delta* values in the wheel event don't necessarily reflect the content's scrolling direction.
/// </para>
/// </summary>
/// <remarks>
/// Note: This is the standard wheel event interface to use.
/// Old versions of browsers implemented the non-standard and non-cross-browser-compatible MouseWheelEvent and MouseScrollEvent interfaces.
/// Use this interface and avoid the non-standard ones.
/// </remarks>
/// <param name="DeltaX">
/// <para>Represents the horizontal scroll amount in the WheelEvent.deltaMode unit.</para>
/// <para>
/// You must check the deltaMode property to determine the unit of the deltaX value.
/// Do not assume that the deltaX value is specified in pixels.
/// Some browsers, for compatibility reasons, may return different units for the deltaX value depending on whether deltaMode has been accessed,
/// to accommodate for websites not explicitly checking the deltaMode property.
/// </para>
/// </param>
/// <param name="DeltaY">
/// <para>Represents the vertical scroll amount in the WheelEvent.deltaMode unit.</para>
/// <para>
/// You must check the deltaMode property to determine the unit of the deltaY value.
/// Do not assume that the deltaY value is specified in pixels.
/// Some browsers, for compatibility reasons, may return different units for the deltaY value depending on whether deltaMode has been accessed,
/// to accommodate for websites not explicitly checking the deltaMode property.
/// </para>
/// </param>
/// <param name="DeltaZ">
/// <para>Represents the scroll amount along the z-axis, in the WheelEvent.deltaMode unit.</para>
/// <para>
/// You must check the deltaMode property to determine the unit of the deltaZ value.
/// Do not assume that the deltaZ value is specified in pixels.
/// Some browsers, for compatibility reasons, may return different units for the deltaZ value depending on whether deltaMode has been accessed,
/// to accommodate for websites not explicitly checking the deltaMode property.
/// </para>
/// </param>
/// <param name="DeltaMode">
/// <para>Represents the unit of the delta values scroll amount.</para>
/// <para>
/// Permitted values are:<br />
/// - 0 (DOM_DELTA_PIXEL): The delta values are specified in pixels.<br />
/// - 1 (DOM_DELTA_LINE): The delta values are specified in lines.<br />
/// - 2 (DOM_DELTA_PAGE): The delta values are specified in pages.
/// </para>
/// <para>
/// You must check the deltaMode property to determine the unit of the deltaX, deltaY, and deltaZ values.
/// Do not assume that those values are specified in pixels.
/// Some browsers, for compatibility reasons, may return different units for the delta* values depending on whether deltaMode has been accessed,
/// to accommodate for websites not explicitly checking the deltaMode property.
/// </para>
/// </param>
public readonly record struct WheelEvent(double DeltaX, double DeltaY, double DeltaZ, int DeltaMode);


/// <summary>
/// <para>
/// Represents an UIEvent which is sent when the state of contacts with a touch-sensitive surface changes.
/// This surface can be a touch screen or trackpad, for example.
/// The event can describe one or more points of contact with the screen and includes support for detecting movement, addition and removal of contact points, and so forth.
/// </para>
/// <para>Touches are represented by the <see cref="Touch"/> object; each touch is described by a position, size and shape, amount of pressure, and target element.</para>
/// </summary>
/// <param name="Touches">
/// <para>Lists all the <see cref="Touch"/> objects for touch points that are currently in contact with the touch surface, regardless of whether or not they've changed or what their target element was at touchstart time.</para>
/// <para>You can think of it as how many separate fingers are able to be identified as touching the screen.</para>
/// <para>
/// Note: Touches inside the array are not necessarily ordered by order of occurrences (the i-th element in the array being the i-th touch that happened).
/// You cannot assume a specific order. To determine the order of occurrences of the touches, use the touch object IDs.
/// </para>
/// </param>
/// <param name="TargetTouches">Lists all the <see cref="Touch"/> objects for touch points that are still in contact with the touch surface and whose touchstart event occurred inside the same target element as the current target element.</param>
/// <param name="ChangedTouches">
/// <para>A list whose <see cref="Touch"/> objects include all the touch points that contributed to this touch event.</para>
/// <para>
/// The touch points (Touch objects) varies depending on the event type, as follows:<br />
/// - For the touchstart event, it is a list of the touch points that became active with the current event.<br />
/// - For the touchmove event, it is a list of the touch points that have changed since the last event.<br />
/// - For the touchend and touchcancel events, it is a list of the touch points that have been removed from the surface (that is, the set of touch points corresponding to fingers no longer touching the surface).
/// </para>
/// </param>
/// <param name="CtrlKey">Indicates whether the control (Control) key is enabled when the touch event is created. If this key is enabled, the attribute's value is true. Otherwise, it is false.</param>
/// <param name="ShiftKey">Indicates whether or not the shift key is enabled when the touch event is created. If this key is enabled, the attribute's value is true. Otherwise, it is false.</param>
/// <param name="AltKey">Indicates whether or not the alt (Alternate) key is enabled when the touch event is created. If the alt key is enabled, the attribute's value is true. Otherwise, it is false.</param>
/// <param name="MetaKey">Indicates whether or not the Meta key is enabled when the touch event is created. If this key is enabled, the attribute's value is true. Otherwise, it is false.</param>
public readonly record struct TouchEvent(Touch[] Touches, Touch[] TargetTouches, Touch[] ChangedTouches, bool CtrlKey, bool ShiftKey, bool AltKey, bool MetaKey);

/// <summary>
/// <para>Represents a single contact point on a touch-sensitive device. The contact point is commonly a finger or stylus and the device may be a touchscreen or trackpad.</para>
/// <para>
/// The <see cref="RadiusX"/>, <see cref="RadiusY"/>, and <see cref="RotationAngle"/> describe the area of contact between the user and the screen, the touch area.
/// This can be helpful when dealing with imprecise pointing devices such as fingers.
/// These values are set to describe an ellipse that as closely as possible matches the entire area of contact (such as the user's fingertip).
/// </para>
/// </summary>
/// <remarks>
/// Note: Many of the properties' values are hardware-dependent;
/// for example, if the device doesn't have a way to detect the amount of pressure placed on the surface, the force value will always be 0.
/// This may also be the case for <see cref="RadiusX">radiusX</see> and <see cref="RadiusY">radiusY</see>; if the hardware reports only a single point, these values will be 1.
/// </remarks>
/// <param name="Identifier">
/// A value uniquely identifying this point of contact with the touch surface.
/// This value remains consistent for every event involving this finger's (or stylus's) movement on the surface until it is lifted off the surface.
/// </param>
/// <param name="ClientX">Returns the X coordinate of the touch point relative to the viewport, not including any scroll offset.</param>
/// <param name="ClientY">Returns the Y coordinate of the touch point relative to the browser's viewport, not including any scroll offset.</param>
/// <param name="PageX">Returns the X coordinate of the touch point relative to the viewport, including any scroll offset.</param>
/// <param name="PageY">Returns the Y coordinate of the touch point relative to the viewport, including any scroll offset.</param>
/// <param name="ScreenX">Returns the X coordinate of the touch point relative to the screen, not including any scroll offset.</param>
/// <param name="ScreenY">Returns the Y coordinate of the touch point relative to the screen, not including any scroll offset.</param>
/// <param name="RadiusX">
/// <para>Returns the X radius of the ellipse that most closely circumscribes the area of contact with the touch surface. The value is in CSS pixels of the same scale as Touch.screenX.</para>
/// <para>
/// This value, in combination with <see cref="RadiusY"/> and <see cref="RotationAngle"/> constructs an ellipse that approximates the size and shape of the area of contact between the user and the screen.
/// This may be a relatively large ellipse representing the contact between a fingertip and the screen or a small area representing the tip of a stylus, for example.
/// </para>
/// </param>
/// <param name="RadiusY">
/// <para>Returns the Y radius of the ellipse that most closely circumscribes the area of contact with the touch surface. The value is in CSS pixels of the same scale as Touch.screenX.</para>
/// <para>
/// This value, in combination with <see cref="RadiusX"/> and <see cref="RotationAngle"/> constructs an ellipse that approximates the size and shape of the area of contact between the user and the screen.
/// This may be a large ellipse representing the contact between a fingertip and the screen or a small one representing the tip of a stylus, for example.
/// </para>
/// </param>
/// <param name="RotationAngle">
/// Returns the rotation angle, in degrees, of the contact area ellipse defined by <see cref="RadiusX"/> and <see cref="RadiusY"/>.
/// The value may be between 0 and 90.
/// Together, these three values describe an ellipse that approximates the size and shape of the area of contact between the user and the screen.
/// This may be a relatively large ellipse representing the contact between a fingertip and the screen or a small area representing the tip of a stylus, for example.
/// </param>
/// <param name="Force">
/// <para>Returns the amount of pressure the user is applying to the touch surface for a Touch point.</para>
/// <para>
/// This is a value between 0.0 (no pressure) and 1.0 (the maximum amount of pressure the hardware can recognize).
/// A value of 0.0 is returned if no value is known (for example the touch device does not support this property).
/// In environments where force is known, the absolute pressure represented by the force attribute, and the sensitivity in levels of pressure, may vary.
/// </para>
/// </param>
public readonly record struct Touch(int Identifier, double ClientX, double ClientY, double PageX, double PageY, double ScreenX, double ScreenY, double RadiusX, double RadiusY, double RotationAngle, double Force);


/// <summary>
/// <para>
/// Represents the state of a DOM event produced by a pointer such as the geometry of the contact point,
/// the device type that generated the event,
/// the amount of pressure that was applied on the contact surface, etc.
/// </para>
/// <para>
/// A pointer is a hardware agnostic representation of input devices (such as a mouse, pen or contact point on a touch-enable surface).
/// The pointer can target a specific coordinate (or set of coordinates) on the contact surface such as a screen.
/// </para>
/// <para>
/// A pointer's hit test is the process a browser uses to determine the target element for a pointer event.
/// Typically, this is determined by considering the pointer's location and also the visual layout of elements in a document on screen media.
/// </para>
/// </summary>
/// <param name="PointerId">
/// <para>
/// An identifier assigned to a given pointer event.
/// The identifier is unique, being different from the identifiers of all other active pointer events.
/// Since the value may be randomly generated, it is not guaranteed to convey any particular meaning.
/// </para>
/// <para>
/// Note: The pointerId property is implemented inconsistently across browsers and does not always persist for each ink stroke or interaction with the screen.
/// For a reliable way of identifying multiple pointing devices on a screen simultaneously, see <see cref="PersistentDeviceId"/>.
/// </para>
/// </param>
/// <param name="PersistentDeviceId">
/// <para>
/// A unique identifier for the pointing device generating the PointerEvent.
/// This provides a secure, reliable way to identify multiple pointing devices (such as pens) interacting with the screen simultaneously.
/// </para>
/// <para>
/// A persistentDeviceId persists for the lifetime of a browsing session.
/// To avoid the risk of fingerprinting/tracking, pointing devices are assigned a new persistentDeviceId at the start of each session.
/// </para>
/// <para>Pointer events whose generating device could not be identified are assigned a persistentDeviceId value of 0.</para>
/// </param>
/// <param name="PointerType">
/// <para>Indicates the device type (mouse, pen, or touch) that caused a given pointer event.</para>
/// <para>
/// The supported values are the following strings:<br />
/// - "mouse": The event was generated by a mouse device.<br />
/// - "pen": The event was generated by a pen or stylus device.<br />
/// - "touch": The event was generated by a touch, such as a finger.
/// </para>
/// <para>
/// If the device type cannot be detected by the browser, the value can be an empty string ("").
/// If the browser supports pointer device types other than those listed above, the value should be vendor-prefixed to avoid conflicting names for different types of devices.
/// </para>
/// </param>
/// <param name="Width">
/// <para>
/// Represents the width of the pointer's contact geometry along the x-axis, measured in CSS pixels.
/// Depending on the source of the pointer device (such as a finger), for a given pointer, each event may produce a different value.
/// </para>
/// <para>If the input hardware cannot report the contact geometry to the browser, the width defaults to 1.</para>
/// </param>
/// <param name="Height">
/// <para>
/// Represents the height of the pointer's contact geometry, along the y-axis (in CSS pixels).
/// Depending on the source of the pointer device (for example a finger), for a given pointer, each event may produce a different value.
/// </para>
/// <para>If the input hardware cannot report the contact geometry to the browser, the height defaults to 1.</para>
/// </param>
/// <param name="Pressure">
/// <para>Indicates the normalized pressure of the pointer input.</para>
/// <para>
/// The value is in the range of 0 to 1, inclusive, where 0 and 1 represent the minimum and maximum pressure the hardware is capable of detecting, respectively.
/// For hardware that does not support pressure, such as a mouse, the value is 0.5 when the pointer is active buttons state and 0 otherwise.
/// </para>
/// </param>
/// <param name="TangentialPressure">
/// <para>Represents the normalized tangential pressure of the pointer input (also known as barrel pressure or cylinder stress).</para>
/// <para>
/// The value is in the range -1 to 1, inclusive, where 0 is the neutral position of the control.
/// Note that some hardware may only support positive values in the range 0 to 1. For hardware that does not support tangential pressure, the value will be 0.
/// </para>
/// </param>
/// <param name="Twist">
/// <para>Represents the clockwise rotation of the pointer (e.g., pen stylus) around its major axis, in degrees.</para>
/// <para>The value is in the range 0 to 359, inclusive. For devices that do not report twist, the value is 0.</para>
/// </param>
/// <param name="TiltX">
/// <para>The angle (in degrees) between the Y-Z plane of the pointer and the screen. This property is typically only useful for a pen/stylus pointer type.</para>
/// <para>
/// Depending on the specific hardware and platform, user agents will likely only receive one set of values for the transducer orientation relative to the screen plane
/// — either tiltX and tiltY or altitudeAngle and azimuthAngle.
/// </para>
/// <para>The range of values is -90 to 90, inclusive, where a positive value is a tilt to the right. For devices that do not support this property, the value is 0.</para>
/// </param>
/// <param name="TiltY">
/// <para>The angle (in degrees) between the X-Z plane of the pointer and the screen. This property is typically only useful for a pen/stylus pointer type.</para>
/// <para>
/// Depending on the specific hardware and platform, user agents will likely only receive one set of values for the transducer orientation relative to the screen plane
/// — either tiltX and tiltY or altitudeAngle and azimuthAngle.
/// </para>
/// <para>The range of values is -90 to 90, inclusive, where a positive value is a tilt towards the user. For devices that do not support this property, the value is 0.</para>
/// </param>
/// <param name="AltitudeAngle">
/// <para>
/// Represents the angle between a transducer (a pointer or stylus) axis and the X-Y plane of a device screen.
/// The altitude angle describes whether the transducer is perpendicular to the screen, parallel, or at some angle in between.
/// </para>
/// <para>
/// Depending on the specific hardware and platform, user agents will likely only receive one set of values for the transducer orientation relative to the screen plane
/// — either tiltX and tiltY or altitudeAngle and azimuthAngle.
/// </para>
/// <para>
/// The value is an angle in radians between 0 and π/2 where 0 is parallel to the device surface (X-Y plane), and π/2 is perpendicular to the surface.
/// Defaults to π/2 (perpendicular to the surface) which differs from the altitudeAngle in touch events which defaults to 0 (parallel to the surface).
/// For hardware and platforms that do not report tilt or angle, the value is π/2.
/// </para>
/// </param>
/// <param name="AzimuthAngle">
/// <para>Represents the angle between the Y-Z plane and the plane containing both the transducer (pointer or stylus) axis and the Y axis.</para>
/// <para>
/// Depending on the specific hardware and platform, user agents will likely only receive one set of values for the transducer orientation relative to the screen plane
/// — either tiltX and tiltY or altitudeAngle and azimuthAngle.
/// </para>
/// <para>
/// The value is an angle in radians between 0 and 2π where 0 represents a transducer whose cap is pointing in the direction of increasing X values (point to "3 o'clock" if looking straight down) on the X-Y plane,
/// and the values progressively increase when going clockwise (π/2 at "6 o'clock", π at "9 o'clock", 3π/2 at "12 o'clock").
/// When the transducer is perpendicular to the surface (altitudeAngle of π/2), the value is 0.
/// For hardware and platforms that do not report tilt or angle, the value is 0.
/// </para>
/// </param>
/// <param name="IsPrimary">
/// <para>
/// Indicates whether or not the pointer device that created the event is the primary pointer.
/// It returns true if the pointer that caused the event to be fired is the primary one and returns false otherwise.
/// </para>
/// <para>
/// In a multi-pointer scenario (such as a touch screen that supports more than one touch point), this property is used to identify a master pointer among the set of active pointers for each pointer type.
/// Only a primary pointer will produce compatibility mouse events.
/// Authors who desire only single-pointer interaction can achieve that by ignoring non-primary pointers.
/// </para>
/// <para>
/// A pointer is considered primary if the pointer represents a mouse device.
/// A pointer representing pen input is considered the primary pen input if its pointerdown event was dispatched when no other active pointers representing pen input existed.
/// A pointer representing touch input is considered the primary touch input if its pointerdown event was dispatched when no other active pointers representing touch input existed.
/// </para>
/// <para>
/// When two or more pointer device types are being used concurrently, multiple pointers (one for each pointerType) are considered primary.
/// For example, a touch contact and a mouse cursor moved simultaneously will produce pointers that are both considered primary.
/// If there are multiple primary pointers, these pointers will all produce compatibility mouse events (see Pointer events for more information about pointer, mouse and touch interaction).
/// </para>
/// </param>
/// <param name="Button">
/// <para>Indicates which button was pressed or released on the mouse to trigger the event.</para>
/// <para>
/// This property only guarantees to indicate which buttons are pressed or released during events caused by pressing or releasing one or multiple buttons.
/// As such, it is not reliable for events such as mouseenter, mouseleave, mouseover, mouseout, or mousemove.
/// </para>
/// <para>
/// Users may change the configuration of buttons on their pointing device so that if an event's button property is zero, it may not have been caused by the button that is physically left–most on the pointing device;
/// however, it should behave as if the left button was clicked in the standard button layout.
/// </para>
/// <para>Note: Do not confuse this property with the MouseEvent.buttons property, which indicates which buttons are pressed for all mouse events types.</para>
/// <para>
/// The value is a number representing a given button:<br />
/// - 0: Main button, usually the left button or the un-initialized state<br />
/// - 1: Auxiliary button, usually the wheel button or the middle button (if present)<br />
/// - 2: Secondary button, usually the right button<br />
/// - 3: Fourth button, typically the Browser Back button<br />
/// - 4: Fifth button, typically the Browser Forward button
/// </para>
/// </param>
/// <param name="Buttons">
/// <para>Indicates which buttons are pressed on the mouse (or other input device) when a mouse event is triggered.</para>
/// <para>
/// Each button that can be pressed is represented by a given number (see below).
/// If more than one button is pressed, the button values are added together to produce a new number.
/// For example, if the secondary (2) and auxiliary (4) buttons are pressed simultaneously, the value is 6 (i.e., 2 + 4).
/// </para>
/// <para>
/// Note: Do not confuse this property with the MouseEvent.button property.
/// The MouseEvent.buttons property indicates the state of buttons pressed during any kind of mouse event,
/// while the MouseEvent.button property only guarantees the correct value for mouse events caused by pressing or releasing one or multiple buttons.
/// </para>
/// <para>
/// The value is a number representing one or more buttons. For more than one button pressed simultaneously, the values are combined (e.g., 3 is primary + secondary):<br />
/// - 0: No button or un-initialized<br />
/// - 1: Primary button (usually the left button)<br />
/// - 2: Secondary button (usually the right button)<br />
/// - 4: Auxiliary button (usually the mouse wheel button or middle button)<br />
/// - 8: 4th button (typically the "Browser Back" button)<br />
/// - 16: 5th button (typically the "Browser Forward" button)
/// </para>
/// </param>
/// <param name="MovementX">
/// <para>
/// Provides the difference in the X coordinate of the mouse pointer between the given event and the previous mousemove event.
/// In other words, the value of the property is computed like this: currentEvent.movementX = currentEvent.screenX - previousEvent.screenX.
/// </para>
/// <para>The number is always zero on any MouseEvent other than mousemove.</para>
/// <para>
/// Warning: Browsers use different units for movementX and screenX than what the specification defines.
/// Depending on the browser and operating system, the movementX units may be a physical pixel, a logical pixel, or a CSS pixel.
/// You may want to avoid the movement properties, and instead calculate the delta between the current client values (screenX, screenY) and the previous client values.
/// </para>
/// </param>
/// <param name="MovementY">
/// <para>
/// Provides the difference in the Y coordinate of the mouse pointer between the given event and the previous mousemove event.
/// In other words, the value of the property is computed like this: currentEvent.movementY = currentEvent.screenY - previousEvent.screenY.
/// </para>
/// <para>The number is always zero on any MouseEvent other than mousemove.</para>
/// <para>
/// Warning: Browsers use different units for movementY and screenY than what the specification defines.
/// Depending on the browser and operating system, the movementX units may be a physical pixel, a logical pixel, or a CSS pixel.
/// You may want to avoid the movement properties, and instead calculate the delta between the current client values (screenX, screenY) and the previous client values.
/// </para>
/// </param>
/// <param name="ClientX">
/// <para>Provides the horizontal coordinate within the application's viewport at which the event occurred (as opposed to the coordinate within the page).</para>
/// <para>For example, clicking on the left edge of the viewport will always result in a mouse event with a clientX value of 0, regardless of whether the page is scrolled horizontally.</para>
/// </param>
/// <param name="ClientY">
/// <para>Provides the vertical coordinate within the application's viewport at which the event occurred (as opposed to the coordinate within the page).</para>
/// <para>For example, clicking on the top edge of the viewport will always result in a mouse event with a clientY value of 0, regardless of whether the page is scrolled vertically.</para>
/// </param>
/// <param name="OffsetX">Provides the offset in the X coordinate of the mouse pointer between that event and the padding edge of the target node.</param>
/// <param name="OffsetY">Provides the offset in the Y coordinate of the mouse pointer between that event and the padding edge of the target node.</param>
/// <param name="PageX">
/// <para>Returns the X (horizontal) coordinate (in pixels) at which the mouse was clicked, relative to the left edge of the entire document. This includes any portion of the document not currently visible.</para>
/// <para>
/// Being based on the edge of the document as it is, this property takes into account any horizontal scrolling of the page.
/// For example, if the page is scrolled such that 200 pixels of the left side of the document are scrolled out of view, and the mouse is clicked 100 pixels inward from the left edge of the view,
/// the value returned by pageX will be 300.
/// </para>
/// <para>Originally, this property was defined as a long integer. The CSSOM View Module redefined it as a double float. See the Browser compatibility section for details.</para>
/// <para>See Coordinate systems for additional information about coordinates specified in this fashion.</para>
/// </param>
/// <param name="PageY">
/// Returns the Y (vertical) coordinate (in pixels) at which the mouse was clicked, relative to the top edge of the entire document.
/// This includes any portion of the document not currently visible.
/// See <see cref="PageX"/> for more information.
/// </param>
/// <param name="ScreenX">
/// <para>Provides the horizontal coordinate (offset) of the mouse pointer in screen coordinates.</para>
/// <para>Note: In a multiscreen environment, screens aligned horizontally will be treated as a single device, and so the range of the screenX value will increase to the combined width of the screens.</para>
/// </param>
/// <param name="ScreenY">Provides the vertical coordinate (offset) of the mouse pointer in screen coordinates.</param>
/// <param name="CtrlKey">
/// <para>Indicates whether the ctrl key was pressed or not when a given mouse event occurs.</para>
/// <para>
/// On Macintosh keyboards, this key is labeled the control key.
/// Also, note that on a Mac, a click combined with the control key is intercepted by the operating system and used to open a context menu, so ctrlKey is not detectable on click events.
/// </para>
/// <para>Pinch-zooming using a trackpad also sends a simulated wheel event with ctrlKey set to true.</para>
/// </param>
/// <param name="ShiftKey">Indicates whether the shift key was pressed or not when a given mouse event occurs.</param>
/// <param name="AltKey">
/// <para>Indicates whether the alt key was pressed or not when a given mouse event occurs.</para>
/// <para>
/// Be aware that the browser can't always detect the alt key on some operating systems.
/// On some Linux variants, for example, a left mouse click combined with the alt key is used to move or resize windows.
/// </para>
/// <para>Note: On Macintosh keyboards, this key is also known as the option key.</para>
/// </param>
/// <param name="MetaKey">
/// <para>Indicates whether the meta key was pressed or not when a given mouse event occurs.</para>
/// <para>
/// Be aware that many operating systems bind special functionality to the meta key, so this property may be false even when the key is actually pressed.
/// On Windows, for example, this key may open the Start menu.
/// </para>
/// <para>Note: On Macintosh keyboards, this key is the command key (⌘). On Windows keyboards, this key is the Windows key (⊞).</para>
/// </param>
public readonly record struct PointerEvent(int PointerId, int PersistentDeviceId, string PointerType, int Width, int Height, double Pressure, double TangentialPressure, int Twist, int TiltX, int TiltY, double AltitudeAngle, double AzimuthAngle, bool IsPrimary,
    int Button, int Buttons, int MovementX, int MovementY, double ClientX, double ClientY, double OffsetX, double OffsetY, double PageX, double PageY, double ScreenX, double ScreenY, bool CtrlKey, bool ShiftKey, bool AltKey, bool MetaKey);
