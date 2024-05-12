# Dialog

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
    private IDialog? dialog;

    protected override void OnAfterRender(bool firstRender) {
        if (firstRender)
            dialog = ElementFactory.CreateDialog(dialogElement);
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

| **Name**     | **Parameters**          | **ReturnType** | **Description**                                                                                                                   |
| ------------ | ----------------------- | -------------- | --------------------------------------------------------------------------------------------------------------------------------- |
| CreateDialog | ElementReference dialog | IDialog        | Takes a *ElementReference* of &lt;dialog&gt; and returns *IDialog"* interface to interact with the given &lt;dialog&gt;.          |


<br></br>
### IDialog

The *HTMLDialogElement* interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.

Objects of this class must disposed manually, so do not forget to call DisposeAsync() when you are done with it.

#### Properties

| **Name**    | **Type**                | get/set | **Description**                                                                                                                                                                    |
| ----------- | ----------------------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Open        | ValueTask&lt;bool&gt;   | get     | The *open* property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.  |
| ReturnValue | ValueTask&lt;string&gt; | get     | The *returnValue* property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it. |

#### Methods

| **Name**       | **Parameters**                                                      | **ReturnType**           | **Description**                                                                                                                                                                                                                                                                                                    |
| -------------- | ------------------------------------------------------------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| GetOpen        | CancellationToken cancellationToken                                 | ValueTask&lt;bool&gt;    | The *open* property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.                                                                                                                                  |
| SetOpen        | bool value, [CancellationToken cancellationToken = default]         | ValueTask                | The *open* property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.                                                                                                                                  |
| GetReturnValue | CancellationToken cancellationToken                                 | ValueTask&lt;string&gt;  | The *returnValue* property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.                                                                                                                                 |
| SetReturnValue | string returnValue, [CancellationToken cancellationToken = default] | ValueTask                | The *returnValue* property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it.                                                                                                                                 |
| Show           | [CancellationToken cancellationToken = default]                     | ValueTask                | The *show()* method of the HTMLDialogElement interface displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.                                                                                                                                                         |
| ShowModal      | [CancellationToken cancellationToken = default]                     | ValueTask                | The *showModal()* method of the HTMLDialogElement interface displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert. |
| Close          | [CancellationToken cancellationToken = default]                     | ValueTask                | The *close()* method of the HTMLDialogElement interface closes the &lt;dialog&gt;.                                                                                                                                                                                                                                 |
| Close          | string returnValue, [CancellationToken cancellationToken = default] | ValueTask                | The *close()* method of the HTMLDialogElement interface closes the &lt;dialog&gt; and updates the returnValue of the dialog.                                                                                                                                                                                       |

#### Events

| **Name** | **Type** | **Description**                                                                                                                                                                                     |
| -------- | -------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnCancel | Action   | The *cancel* event fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key. |
| OnClose  | Action   | The *close* event is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.                                                                                    |



<br></br>
### IElementFactoryInProcess

An instance of this class takes a *ElementReference* and exposes an interface to interact with it.

This factory **does not dispose** the created onjects, they must disposed manually.
So do not forget to call Dispose() on a dialog-object when you are done with it.

#### Methods

| **Name**     | **Parameters**          | **ReturnType**   | **Description**                                                                                                                   |
| ------------ | ----------------------- | ---------------- | --------------------------------------------------------------------------------------------------------------------------------- |
| CreateDialog | ElementReference dialog | IDialogInProcess | Takes a *ElementReference* of &lt;dialog&gt; and returns *IDialogInProcess"* interface to interact with the given &lt;dialog&gt;. |


<br></br>
### IDialogInProcess

The *HTMLDialogElement* interface provides methods to manipulate &lt;dialog&gt; elements. It inherits properties and methods from the HTMLElement interface.

Objects of this class must disposed manually, so do not forget to call Dispose() when you are done with it.

#### Properties

| **Name**    | **Type** | get/set | **Description**                                                                                                                                                                    |
| ----------- | -------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Open        | bool     | get/set | The *open* property of the HTMLDialogElement interface is a boolean value reflecting the open HTML attribute, indicating whether the &lt;dialog&gt; is available for interaction.  |
| ReturnValue | string   | get/set | The *returnValue* property of the HTMLDialogElement interface gets or sets the return value for the &lt;dialog&gt;, usually to indicate which button the user pressed to close it. |

#### Methods

| **Name**       | **Parameters**     | **ReturnType** | **Description**                                                                                                                                                                                                                                                                                                    |
| -------------- | ------------------ | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Show           | *empty*            | void           | The *show()* method of the HTMLDialogElement interface displays the dialog modelessly, i.e. still allowing interaction with content outside of the dialog.                                                                                                                                                         |
| ShowModal      | *empty*            | void           | The *showModal()* method of the HTMLDialogElement interface displays the dialog as a modal, over the top of any other dialogs that might be present. It displays in the top layer, along with a ::backdrop pseudo-element. Interaction outside the dialog is blocked and the content outside it is rendered inert. |
| Close          | *empty*            | void           | The *close()* method of the HTMLDialogElement interface closes the &lt;dialog&gt;.                                                                                                                                                                                                                                 |
| Close          | string returnValue | void           | The *close()* method of the HTMLDialogElement interface closes the &lt;dialog&gt; and updates the returnValue of the dialog.                                                                                                                                                                                       |

#### Events

| **Name** | **Type** | **Description**                                                                                                                                                                                     |
| -------- | -------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnCancel | Action   | The *cancel* event fires on a &lt;dialog&gt; when the user instructs the browser that they wish to dismiss the current open dialog. The browser fires this event when the user presses the Esc key. |
| OnClose  | Action   | The *close* event is fired on an HTMLDialogElement object when the &lt;dialog&gt; it represents has been closed.                                                                                    |
