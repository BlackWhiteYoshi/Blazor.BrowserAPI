export {}

declare global {
    export namespace DotNet {
        /**
         * Invokes the specified .NET public method synchronously. Not all hosting scenarios support
         * synchronous invocation, so if possible use invokeMethodAsync instead.
         *
         * @param assemblyName The short name (without key/version or .dll extension) of the .NET assembly containing the method.
         * @param methodIdentifier The identifier of the method to invoke. The method must have a [JSInvokable] attribute specifying this identifier.
         * @param args Arguments to pass to the method, each of which must be JSON-serializable.
         * @returns The result of the operation.
         */
        function invokeMethod<T>(assemblyName: string, methodIdentifier: string, ...args: any[]): T;

        /**
         * Invokes the specified .NET public method asynchronously.
         *
         * @param assemblyName The short name (without key/version or .dll extension) of the .NET assembly containing the method.
         * @param methodIdentifier The identifier of the method to invoke. The method must have a [JSInvokable] attribute specifying this identifier.
         * @param args Arguments to pass to the method, each of which must be JSON-serializable.
         * @returns A promise representing the result of the operation.
         */
        function invokeMethodAsync<T>(assemblyName: string, methodIdentifier: string, ...args: any[]): Promise<T>;

        /**
         * Creates a JavaScript object reference that can be passed to .NET via interop calls.
         *
         * @param jsObject The JavaScript Object used to create the JavaScript object reference.
         * @returns The JavaScript object reference (this will be the same instance as the given object).
         * @throws Error if the given value is not an Object.
         */
        function createJSObjectReference(jsObject: any): any;

        /**
         * Disposes the given JavaScript object reference.
         *
         * @param jsObjectReference The JavaScript Object reference.
         */
        function disposeJSObjectReference(jsObjectReference: any): void;

        /**
         * Creates a JavaScript data reference that can be passed to .NET via interop calls.
         *
         * @param streamReference The ArrayBufferView or Blob used to create the JavaScript stream reference.
         * @returns The JavaScript data reference (this will be the same instance as the given object).
         * @throws Error if the given value is not an Object or doesn't have a valid byteLength.
         */
        function createJSStreamReference(streamReference: ArrayBuffer | ArrayBufferView | Blob | any): any;


        /**
         * Represents the .NET instance passed by reference to JavaScript.
         */
        interface DotNetObject {
            /**
            * Invokes the specified .NET instance public method synchronously. Not all hosting scenarios support
            * synchronous invocation, so if possible use invokeMethodAsync instead.
            *
            * @param methodIdentifier The identifier of the method to invoke. The method must have a [JSInvokable] attribute specifying this identifier.
            * @param args Arguments to pass to the method, each of which must be JSON-serializable.
            * @returns The result of the operation.
            */
            invokeMethod<T>(methodIdentifier: string, ...args: any[]): T;

            /**
             * Invokes the specified .NET instance public method asynchronously.
             *
             * @param methodIdentifier The identifier of the method to invoke. The method must have a [JSInvokable] attribute specifying this identifier.
             * @param args Arguments to pass to the method, each of which must be JSON-serializable.
             * @returns A promise representing the result of the operation.
             */
            invokeMethodAsync<T>(methodIdentifier: string, ...args: any[]): Promise<T>;
        }

        /**
         * Represents the reference to a .NET stream sent to JavaScript.
         */
        interface DotNetStreamReference {
            /**
             * Access underlying data as ArrayBuffer.
             *
             * @returns stream as ArrayBuffer
             */
            arrayBuffer(): Promise<ArrayBuffer>;

            /**
             * Access underlying data as ReadableStream.
             *
             * @returns stream as ReadableStream
             */
            stream(): ReadableStream;
        }
    }
}
