namespace BrowserAPI;

/// <summary>
/// Extensions for collections of <see cref="IDisposable">Disposable</see> objects, including Arrays, Enumerables or tuple of Enumerables.
/// </summary>
public static class EnumerableDisposeExtensions {
    /// <summary>
    /// Disposes all objects of the given collection.
    /// </summary>
    /// <param name="disposableList"></param>
    public static void Dispose(this IEnumerable<IDisposable> disposableList) {
        foreach (IDisposable disposable in disposableList)
            disposable.Dispose();
    }

    /// <summary>
    /// Disposes all objects in parallel of the given collection.
    /// </summary>
    /// <param name="asyncDisposableList"></param>
    /// <returns></returns>
    public static ValueTask DisposeAsync(this IEnumerable<IAsyncDisposable> asyncDisposableList) {
        switch (asyncDisposableList) {
            case ICollection<IAsyncDisposable> { Count: 0 }:
                return ValueTask.CompletedTask;

            case ICollection<IAsyncDisposable> { Count: 1 }:
                return asyncDisposableList.First().DisposeAsync();

            default:
                List<Task> taskList = asyncDisposableList is ICollection<IAsyncDisposable> collection ? new(collection.Count) : [];
                foreach (IAsyncDisposable asyncDisposable in asyncDisposableList) {
                    ValueTask disposeTask = asyncDisposable.DisposeAsync();
                    if (!disposeTask.IsCompleted)
                        taskList.Add(disposeTask.AsTask());
                }
                return new ValueTask(Task.WhenAll(taskList));
        }
    }


    /// <summary>
    /// Disposes all objects of both collections of the given tuple.
    /// </summary>
    /// <param name="tupleDisposableList"></param>
    public static void Dispose(this (IEnumerable<IDisposable>, IEnumerable<IDisposable>) tupleDisposableList) {
        tupleDisposableList.Item1.Dispose();
        tupleDisposableList.Item2.Dispose();
    }

    /// <summary>
    /// Disposes all objects in parallel of both collections of the given tuple.
    /// </summary>
    /// <param name="tupleAsyncDisposableList"></param>
    /// <returns></returns>
    public static ValueTask DisposeAsync(this (IEnumerable<IAsyncDisposable>, IEnumerable<IAsyncDisposable>) tupleAsyncDisposableList) {
        ValueTask asyncDisposableCollection1 = tupleAsyncDisposableList.Item1.DisposeAsync();
        ValueTask asyncDisposableCollection2 = tupleAsyncDisposableList.Item2.DisposeAsync();

        return (asyncDisposableCollection1.IsCompleted, asyncDisposableCollection2.IsCompleted) switch {
            (true, true) => ValueTask.CompletedTask,
            (true, false) => asyncDisposableCollection2,
            (false, true) => asyncDisposableCollection1,
            (false, false) => new ValueTask(Task.WhenAll([asyncDisposableCollection1.AsTask(), asyncDisposableCollection2.AsTask()]))
        };
    }
}
