using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace TenKObjects
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<ImplementationBenchmarks>(
                DefaultConfig.Instance
                    // .AddHardwareCounters(
                    //     HardwareCounter.BranchMispredictions,
                    //     HardwareCounter.BranchInstructions,
                    //     HardwareCounter.Timer)
                    .AddJob(Job.Default.WithRuntime(CoreRuntime.Core50))
                    // .AddJob(Job.Default.WithRuntime(CoreRuntime.Core31))
                    .AddValidator(ExecutionValidator.FailOnError));
        }
    }
}