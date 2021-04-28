using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace Mobii
{
    // Untouchable code as per documentation . . .


    internal static class Program
    {
        private static readonly Implementations imp = new Implementations();
        private const string JitNoInline = "COMPlus_JitNoInline";
        private static void Main()
        {
            BenchmarkRunner.Run<ImplementationBenchmarks>(
                DefaultConfig.Instance
                    // .AddHardwareCounters(
                    //     HardwareCounter.BranchMispredictions,
                    //     HardwareCounter.BranchInstructions)
                    .AddJob(Job.Default.WithRuntime(CoreRuntime.Core50))
                    // .AddJob(Job.Default.WithRuntime(CoreRuntime.Core31))
                        .AddValidator(ExecutionValidator.FailOnError));
            // imp.Implementation24();

        }
    }
}