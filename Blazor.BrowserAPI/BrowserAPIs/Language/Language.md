# Language

This interface is a collection of language related functionalities,
for example [navigator.language](https://developer.mozilla.org/en-US/docs/Web/API/Navigator/language)
or [document.documentElement.lang](https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Global_attributes/lang) attribute.  
It is not an official API.


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

| **Name**         | **Type**                  | get/set | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                    |
| ---------------- | ------------------------- | ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| BrowserLanguage  | ValueTask&lt;string&gt;   | get     | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc.                                                                                                                                                                       |
| BrowserLanguages | ValueTask&lt;string[]&gt; | get     | navigator.languages; Returns an array of strings representing the languages known to the user, by order of preference. The language is described using language tags according to RFC 5646: Tags for Identifying Languages (also known as BCP 47). In the returned array they are ordered by preference with the most preferred language first.<br />The value of *navigator.language* is the first element of the returned array. |
| HtmlLanguage     | ValueTask&lt;string&gt;   | get     | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                                                                                                                                                                                        |

#### Methods

| **Name**           | **Parameters**                                                   | **ReturnType**           | **Description**                                                                                                                                                                                                                                              |
| ------------------ | ---------------------------------------------------------------- | ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| GetBrowserLanguage | CancellationToken cancellationToken                              | ValueTask&lt;string&gt;  | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc. |
| GetHtmlLanguage    | CancellationToken cancellationToken                              | ValueTask&lt;string&gt;  | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                  |
| SetHtmlLanguage    | string language, [CancellationToken cancellationToken = default] | ValueTask                | document.documentElement.lang; Returns the content of the "lang" attribute on the html tag.                                                                                                                                                                  |


<br></br>
### ILanguageInProcess

#### Properties

| **Name**         | **Type** | get/set | **Description**                                                                                                                                                                                                                                              |
| ---------------- | -------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| BrowserLanguage  | string   | get     | navigator.language; The Navigator.language read-only property returns a string representing the preferred language of the user, usually the language of the browser UI. Examples of valid language codes include "en", "en-US", "fr", "fr-FR", "es-ES", etc. |
| BrowserLanguages | string[] | get     | navigator.languages; Returns an array of strings representing the languages known to the user, by order of preference. The language is described using language tags according to RFC 5646: Tags for Identifying Languages (also known as BCP 47). In the returned array they are ordered by preference with the most preferred language first.<br />The value of *navigator.language* is the first element of the returned array. |
| HtmlLanguage     | string   | get/set | document.documentElement.lang; The content of the "lang" attribute on the html tag.; language abbreviation: e.g. "en", "fr", "es", "de"
