namespace BrowserAPI;

/// <summary>
/// <i>SameSite</i> prevents the browser from sending this cookie along with cross-site requests. Possible values are <i>lax</i>, <i>strict</i> or <i>none</i>.
/// </summary>
public enum CookieSameSite {
    /// <summary>
    /// The <i>none</i> value explicitly states no restrictions will be applied.
    /// The cookie will be sent in all requests—both cross-site and same-site. 
    /// </summary>
    None,
    
    /// <summary>
    /// The <i>lax</i> value will send the cookie for all same-site requests and top-level navigation GET requests.
    /// This is sufficient for user tracking, but it will prevent many Cross-Site Request Forgery (CSRF) attacks.
    /// This is the default value in modern browsers. 
    /// </summary>
    Lax,

    /// <summary>
    /// The <i>strict</i> value will prevent the cookie from being sent by the browser to the target site in all cross-site browsing contexts, even when following a regular link.
    /// </summary>
    Strict
}
