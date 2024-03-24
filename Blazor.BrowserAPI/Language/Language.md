# Language

The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI.  
The document.documentElement.lang attribute sets the language of the content in the HTML page.


<br><br />
## Example

```csharp
public sealed class ExampleComponent : ComponentBase {
    [Inject]
    public required ILanguage Language { private get; init; }

    private async Task Example() {
        string browserLanguage = await Language.BrowserLanguage;
    }
}
```


<br><br />
## Members

### ILanguage

#### Properties

| **Name**        | **Type**                | get/set | **Description**                                                                                                                                                                                                                                              |
| --------------- | ----------------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| BrowserLanguage | ValueTask&lt;string&gt; | get     | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc. |
| HtmlLanguage    | ValueTask&lt;string&gt; | get     | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                  |

#### Methods

| **Name**           | **Parameters**                                                   | **ReturnType**           | **Description**                                                                                                                                                                                                                                              |
| ------------------ | ---------------------------------------------------------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| GetBrowserLanguage | CancellationToken cancellationToken                              | ValueTask&lt;string&gt;  | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc. |
| GetHtmlLanguage    | CancellationToken cancellationToken                              | ValueTask&lt;string&gt;  | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                  |
| SetHtmlLanguage    | string language, [CancellationToken cancellationToken = default] | ValueTask                | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                  |


<br></br>
### ILanguageInProcess

#### Properties

| **Name**        | **Type** | get/set | **Description**                                                                                                                                                                                                                                              |
| --------------- | -------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| BrowserLanguage | string   | get     | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc. |
| HtmlLanguage    | string   | get/set | document.documentElement.lang; The content of the "lang" attribute on the html tag.; language abbreviation: e.g. "en", "fr", "es", "de"
