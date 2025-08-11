/**
 * Invokes the specified .NET public method synchronously or asynchronously depending on the isSync parameter.
 *
 * @param isSync When set to true the invokation is synchronously, otherwise asynchronously.
 * @param assemblyName The short name (without key/version or .dll extension) of the .NET assembly containing the method.
 * @param methodIdentifier The identifier of the method to invoke. The method must have a [JSInvokable] attribute specifying this identifier.
 * @param args Arguments to pass to the method, each of which must be JSON-serializable.
 * @returns A promise representing the result of the operation.
 */
export function blazorInvokeStaticMethod<T>(isSync: boolean, assemblyName: string, methodIdentifier: string, ...args: any[]): T | Promise<T> {
    if (isSync)
        return DotNet.invokeMethod(assemblyName, methodIdentifier, ...args);
    else
        return DotNet.invokeMethodAsync(assemblyName, methodIdentifier, ...args);
}

/**
 * Invokes the specified .NET instance public method synchronously or asynchronously depending on the isSync parameter.
 *
 * @param isSync When set to true the invokation is synchronously, otherwise asynchronously.
 * @param dotnetObject The .NET instance passed by reference to JavaScript.
 * @param methodIdentifier The identifier of the method to invoke. The method must have a [JSInvokable] attribute specifying this identifier.
 * @param args Arguments to pass to the method, each of which must be JSON-serializable.
 * @returns A promise representing the result of the operation.
 */
export function blazorInvokeMethod<T>(dotnetObject: DotNet.DotNetObject, isSync: boolean, methodIdentifier: string, ...args: any[]): T | Promise<T> {
    if (isSync)
        return dotnetObject.invokeMethod(methodIdentifier, ...args);
    else
        return dotnetObject.invokeMethodAsync(methodIdentifier, ...args);
}
