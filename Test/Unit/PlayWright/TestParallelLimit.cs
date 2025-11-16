using BrowserAPI.UnitTest;
using TUnit.Core.Interfaces;

[assembly: ParallelLimiter<TestParallelLimit>]

namespace BrowserAPI.UnitTest;

public readonly struct TestParallelLimit : IParallelLimit {
    /// <summary>
    /// <para>Depending on your available RAM you can increase this number to speed up the process.</para>
    /// <para>Or lower this number to lower the RAM usage for the sacrifice of speed.</para>
    /// </summary>
    public int Limit => 8;
}
