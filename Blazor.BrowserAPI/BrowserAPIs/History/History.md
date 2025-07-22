# History

The *History* interface of the [History API](https://developer.mozilla.org/en-US/docs/Web/API/History_API) allows manipulation of the browser session history, that is the pages visited in the tab or frame that the current page is loaded in.

There is only one instance of history (It is a singleton.) accessible via the global object history.


<br><br />
## Example

```csharp
public sealed partial class ExampleComponent : ComponentBase {
    [Inject]
    public required IHistory History { private get; init; }

    private async Task GoForward() => await History.Forward();
    
    private async Task GoBack() => await History.Back();

    private async Task RefreshPage() => await History.Go(0);
    
    private async Task AddHistoryEntry() => await History.PushState(data: null, title: "", url: "/siteURL");
}
```


<br><br />
## Members

### IHistory

#### Properties

| **Name**          | **Type**                      | get/set | **Description**                                                                                                                                                                          |
| ----------------- | ----------------------------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Length            | ValueTask&lt;int&gt;          | get     | Returns an Integer representing the number of elements in the session history, including the currently loaded page. For example, for a page loaded in a new tab this property returns 1. |
| ScrollRestoration | ValueTask&lt;string&gt;       | get     | Allows web applications to explicitly set default scroll restoration behavior on history navigation.<br />This property can be either "auto" or "manual".                                |
| State             | ValueTask&lt;JsonElement?&gt; | get     | Returns an *any* value representing the state at the top of the history stack. This is a way to look at the state without having to wait for a *popstate* event.                         |

#### Methods

| **Name**             | **Parameters**                                                                                    | **ReturnType**                | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| -------------------- | ------------------------------------------------------------------------------------------------- | ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GetLength            | CancellationToken cancellationToken                                                               | ValueTask&lt;int&gt;          | see Property *Length*                                                                                                                                                                                                                                                                                                                                                                                                                             |
| GetScrollRestoration | CancellationToken cancellationToken                                                               | ValueTask&lt;string&gt;       | see Property *ScrollRestoration*                                                                                                                                                                                                                                                                                                                                                                                                                  |
| SetScrollRestoration | string value, [CancellationToken cancellationToken = default]                                     | ValueTask                     | see Property *ScrollRestoration*                                                                                                                                                                                                                                                                                                                                                                                                                  |
| GetState             | CancellationToken cancellationToken                                                               | ValueTask&lt;JsonElement?&gt; | see Property *State*                                                                                                                                                                                                                                                                                                                                                                                                                              |
| Forward              | [CancellationToken cancellationToken = default]                                                   | ValueTask                     | This asynchronous method goes to the next page in session history, the same action as when the user clicks the browser's *Forward* button; this is equivalent to *history.go(1)*.<br />Calling this method to go forward beyond the most recent page in the session history has no effect and doesn't raise an exception.                                                                                                                         |
| Back                 | [CancellationToken cancellationToken = default]                                                   | ValueTask                     | This asynchronous method goes to the previous page in session history, the same action as when the user clicks the browser's *Back* button. Equivalent to *history.go(-1)*.<br />Calling this method to go forward beyond the most recent page in the session history has no effect and doesn't raise an exception.                                                                                                                               |
| Go                   | int delta, [CancellationToken cancellationToken = default]                                        | ValueTask                     | Asynchronously loads a page from the session history, identified by its relative location to the current page, for example -1 for the previous page or 1 for the next page. If you specify an out-of-bounds value (for instance, specifying -1 when there are no previously-visited pages in the session history), this method silently has no effect. Calling *go()* without parameters or a value of 0 reloads the current page.                |
| PushState            | object? data, string title, [string? url = null], [CancellationToken cancellationToken = default] | ValueTask                     | Pushes the given data onto the session history stack with the specified title (and, if provided, URL). The data is treated as opaque by the DOM; you may specify any JavaScript object that can be serialized. Note that all browsers but Safari currently ignore the title parameter. For more information, see [Working with the History API](https://developer.mozilla.org/en-US/docs/Web/API/History_API/Working_with_the_History_API).       |
| ReplaceState         | object? data, string title, [string? url = null], [CancellationToken cancellationToken = default] | ValueTask                     | Updates the most recent entry on the history stack to have the specified data, title, and, if provided, URL. The data is treated as opaque by the DOM; you may specify any JavaScript object that can be serialized. Note that all browsers but Safari currently ignore the title parameter. For more information, see [Working with the History API](https://developer.mozilla.org/en-US/docs/Web/API/History_API/Working_with_the_History_API). |

#### Events

| **Name**   | **Type**                   | **Description**                                                                                                                                                                                                                                                                                                                                                                                                      |
| ---------- | -------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnPopState | Action&lt;JsonElement?&gt; | Is fired when the active history entry changes while the user navigates the session history. It changes the current history entry to that of the last page the user visited or, if *history.pushState()* has been used to add a history entry to the history stack, that history entry is used instead.<br />Parameter is the [state](https://developer.mozilla.org/en-US/docs/Web/API/History/state) value as JSON. |


<br></br>
### IHistoryInProcess

#### Properties

| **Name**          | **Type**     | get/set | **Description**                                                                                                                                                                          |
| ----------------- | ------------ | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Length            | int          | get     | Returns an Integer representing the number of elements in the session history, including the currently loaded page. For example, for a page loaded in a new tab this property returns 1. |
| ScrollRestoration | string       | get/set | Allows web applications to explicitly set default scroll restoration behavior on history navigation.<br />This property can be either "auto" or "manual".                                |
| State             | JsonElement? | get     | Returns an *any* value representing the state at the top of the history stack. This is a way to look at the state without having to wait for a *popstate* event.                         |

#### Methods

| **Name**             | **Parameters**                                   | **ReturnType** | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| -------------------- | ------------------------------------------------ | -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Forward              | *empty*                                          | void           | This asynchronous method goes to the next page in session history, the same action as when the user clicks the browser's *Forward* button; this is equivalent to *history.go(1)*.<br />Calling this method to go forward beyond the most recent page in the session history has no effect and doesn't raise an exception.                                                                                                                         |
| Back                 | *empty*                                          | void           | This asynchronous method goes to the previous page in session history, the same action as when the user clicks the browser's *Back* button. Equivalent to *history.go(-1)*.<br />Calling this method to go forward beyond the most recent page in the session history has no effect and doesn't raise an exception.                                                                                                                               |
| Go                   | int delta                                        | void           | Asynchronously loads a page from the session history, identified by its relative location to the current page, for example -1 for the previous page or 1 for the next page. If you specify an out-of-bounds value (for instance, specifying -1 when there are no previously-visited pages in the session history), this method silently has no effect. Calling *go()* without parameters or a value of 0 reloads the current page.                |
| PushState            | object? data, string title, [string? url = null] | void           | Pushes the given data onto the session history stack with the specified title (and, if provided, URL). The data is treated as opaque by the DOM; you may specify any JavaScript object that can be serialized. Note that all browsers but Safari currently ignore the title parameter. For more information, see [Working with the History API](https://developer.mozilla.org/en-US/docs/Web/API/History_API/Working_with_the_History_API).       |
| ReplaceState         | object? data, string title, [string? url = null] | void           | Updates the most recent entry on the history stack to have the specified data, title, and, if provided, URL. The data is treated as opaque by the DOM; you may specify any JavaScript object that can be serialized. Note that all browsers but Safari currently ignore the title parameter. For more information, see [Working with the History API](https://developer.mozilla.org/en-US/docs/Web/API/History_API/Working_with_the_History_API). |

#### Events

| **Name**   | **Type**                   | **Description**                                                                                                                                                                                                                                                                                                                                                                                                      |
| ---------- | -------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| OnPopState | Action&lt;JsonElement?&gt; | Is fired when the active history entry changes while the user navigates the session history. It changes the current history entry to that of the last page the user visited or, if *history.pushState()* has been used to add a history entry to the history stack, that history entry is used instead.<br />Parameter is the [state](https://developer.mozilla.org/en-US/docs/Web/API/History/state) value as JSON. |
