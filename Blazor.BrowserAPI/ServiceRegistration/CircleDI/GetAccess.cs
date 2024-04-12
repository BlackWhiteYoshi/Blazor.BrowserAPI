namespace CircleDIAttributes;

/// <summary>
/// The type of the member to access the service.<br />
/// It can be either property or method.
/// </summary>
internal enum GetAccess {
    /// <summary>
    /// <para>The member will be a property with a get-accessor.</para>
    /// <para>The name of the property will be the same as the service name.</para>
    /// </summary>
    Property,

    /// <summary>
    /// <para>The member will be a method with no parameters.</para>
    /// <para>
    /// The name will be prefixed with "Get"<br />
    /// e.g. name "MyService" will generate member "GetMyService()".
    /// </para>
    /// </summary>
    Method
}
