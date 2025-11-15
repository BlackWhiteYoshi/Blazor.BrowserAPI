# HTMLDialogElement

The *HTMLDialogElement* interface provides methods to manipulate &lt;dialog&gt; elements.
It inherits properties and methods from the HTMLElement interface.


<br><br />
## Example

```razor
<dialog @ref="dialogElement">
    <p>Content of dialog</p>
</dialog>
```

```csharp
public sealed partial class ExampleComponent : ComponentBase, IAsyncDisposable {
    [Inject]
    public required IElementFactory ElementFactory { private get; init; }

    private ElementReference dialogElement;
    private IHTMLDialogElement? dialog;

    protected override void OnAfterRender(bool firstRender) {
        if (firstRender)
            dialog = ElementFactory.CreateHTMLDialogElement(dialogElement);
    }

    public ValueTask DisposeAsync() => dialog?.DisposeAsync() ?? ValueTask.CompletedTask;


    private async Task Example() {
        await dialog!.Show();
    }
}
```

**Note**: The null-forgiving operator is used in the method *Example*.
If *Example* is used for an interaction event, like a click event, this is fine, but if it is used somewhere before *OnAfterRender* is executed, a NullReferenceException will occur.


<br><br />
## Members

### IElementFactory

An instance of this class takes a *ElementReference* and exposes an interface to interact with it.

This factory **does not dispose** the created objects, they must disposed manually.
So do not forget to call DisposeAsync() on a dialog-object when you are done with it.

#### Methods

| **Name**                | **Parameters**          | **ReturnType**     | **Description**                                                                                                                    |
| ----------------------- | ----------------------- | ------------------ | ---------------------------------------------------------------------------------------------------------------------------------- |
| CreateHTMLDialogElement | ElementReference dialog | IHTMLDialogElement | Takes a *ElementReference* of &lt;dialog&gt; and returns *IHTMLDialogElement* interface to interact with the given &lt;dialog&gt;. |


<br></br>
### IHTMLDialogElement

The *HTMLDialogElement* interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Properties

| **Name**    | **Type**                | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| ----------- | ----------------------- | ------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ClosedBy    | ValueTask&lt;string&gt; | get     | Indicates the types of user actions that can be used to close the associated &lt;dialog&gt; element. It sets or returns the dialog's closedby attribute value.<br></br>Possible values are:<br />- "any": The dialog can be dismissed with a light dismiss user action, a platform-specific user action, or a developer-specified mechanism.<br />- "closerequest": The dialog can be dismissed with a platform-specific user action or a developer-specified mechanism.<br />- "none": The dialog can only be dismissed with a developer-specified mechanism. |
| Open        | ValueTask&lt;bool&gt;   | get     | Reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| ReturnValue | ValueTask&lt;string&gt; | get     | Gets/Sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.                                                                                                                                                                                                                                                                                                                                                                                                                                              |

#### Methods

| **Name**       | **Parameters**                                                                | **ReturnType**                | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| -------------- | ----------------------------------------------------------------------------- | ----------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ToHTMLElement  | [CancellationToken cancellationToken = default]                               | ValueTask&lt;IHTMLElement&gt; | Creates a new JS object and a new C# object to represent the underlying html element as [HTMLElement](https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement).<br></br>Note: The original object as well as the returned result must be disposed manually. Do not forget to Dispose each object when you are done with it.                                                                                                                         |
| GetClosedBy    | CancellationToken cancellationToken                                           | ValueTask&lt;string&gt;       | see Property *ClosedBy*                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| SetClosedBy    | string value, [CancellationToken cancellationToken = default]                 | ValueTask                     | see Property *ClosedBy*                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| GetOpen        | CancellationToken cancellationToken                                           | ValueTask&lt;bool&gt;         | see Property *Open*                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| SetOpen        | bool value, [CancellationToken cancellationToken = default]                   | ValueTask                     | see Property *Open*                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| GetReturnValue | CancellationToken cancellationToken                                           | ValueTask&lt;string&gt;       | see Property *ReturnValue*                                                                                                                                                                                                                                                                                                                                                                                                                               |
| SetReturnValue | string value, [CancellationToken cancellationToken = default]                 | ValueTask                     | see Property *ReturnValue*                                                                                                                                                                                                                                                                                                                                                                                                                               |
| Show           | [CancellationToken cancellationToken = default]                               | ValueTask                     | Displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.                                                                                                                                                                                                                                                                                                                                                      |
| ShowModal      | [CancellationToken cancellationToken = default]                               | ValueTask                     | Displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert.                                                                                                                                                                                                   |
| Close          | [string? returnValue = null], [CancellationToken cancellationToken = default] | ValueTask                     | Closes the &lt;dialog&gt;.<br />An optional string may be passed as an argument, updating the returnValue of the dialog.                                                                                                                                                                                                                                                                                                                                 |
| RequestClose   | [string? returnValue = null], [CancellationToken cancellationToken = default] | ValueTask                     | Requests to close the &lt;dialog&gt;.<br />An optional string may be passed as an argument, updating the returnValue of the dialog.<br></br>This method differs from the *Close* method in that it fires a cancel event before firing the close event. Authors can call Event.preventDefault() in the handler for the cancel event to prevent the dialog from closing.<br/>This method exposes the same behavior as the dialog's internal close watcher. |

#### Events

| **Name** | **Type** | **Description**                                                                                                                                                                  |
| -------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnClose  | Action   | Is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.                                                                                   |
| OnCancel | Action   | Fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key. |



<br></br>
### IElementFactoryInProcess

An instance of this class takes a *ElementReference* and exposes an interface to interact with it.

This factory **does not dispose** the created onjects, they must disposed manually.
So do not forget to call Dispose() on a dialog-object when you are done with it.

#### Methods

| **Name**                | **Parameters**          | **ReturnType**              | **Description**                                                                                                                             |
| ----------------------- | ----------------------- | --------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| CreateHTMLDialogElement | ElementReference dialog | IHTMLDialogElementInProcess | Takes a *ElementReference* of &lt;dialog&gt; and returns *IHTMLDialogElementInProcess* interface to interact with the given &lt;dialog&gt;. |


<br></br>
### IHTMLDialogElementInProcess

The *HTMLDialogElement* interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Properties

| **Name**    | **Type** | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| ----------- | -------- | ------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ClosedBy    | string   | get/set | Indicates the types of user actions that can be used to close the associated &lt;dialog&gt; element. It sets or returns the dialog's closedby attribute value.<br></br>Possible values are:<br />- "any": The dialog can be dismissed with a light dismiss user action, a platform-specific user action, or a developer-specified mechanism.<br />- "closerequest": The dialog can be dismissed with a platform-specific user action or a developer-specified mechanism.<br />- "none": The dialog can only be dismissed with a developer-specified mechanism. |
| Open        | bool     | get/set | Reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| ReturnValue | string   | get/set | Gets/Sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.                                                                                                                                                                                                                                                                                                                                                                                                                                              |

#### Methods

| **Name**       | **Parameters**               | **ReturnType**        | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| -------------- | ---------------------------- | --------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ToHTMLElement  | *empty*                      | IHTMLElementInProcess | Creates a new JS object and a new C# object to represent the underlying html element as [HTMLElement](https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement).<br></br>Note: The original object as well as the returned result must be disposed manually. Do not forget to Dispose each object when you are done with it.                                                                                                                         |
| Show           | *empty*                      | void                  | Displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.                                                                                                                                                                                                                                                                                                                                                      |
| ShowModal      | *empty*                      | void                  | Displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert.                                                                                                                                                                                                   |
| Close          | [string? returnValue = null] | void                  | Closes the &lt;dialog&gt;.<br />An optional string may be passed as an argument, updating the returnValue of the dialog.                                                                                                                                                                                                                                                                                                                                 |
| RequestClose   | [string? returnValue = null] | void                  | Requests to close the &lt;dialog&gt;.<br />An optional string may be passed as an argument, updating the returnValue of the dialog.<br></br>This method differs from the *Close* method in that it fires a cancel event before firing the close event. Authors can call Event.preventDefault() in the handler for the cancel event to prevent the dialog from closing.<br/>This method exposes the same behavior as the dialog's internal close watcher. |

#### Events

| **Name** | **Type** | **Description**                                                                                                                                                                  |
| -------- | -------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnClose  | Action   | Is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.                                                                                   |
| OnCancel | Action   | Fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key. |
