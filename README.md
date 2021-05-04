The task will be to perform a task a quickly as possible.

There are 10 000 objects in a list.

Each object must have 2 steps performed on it.

### The object:

    public class Work
    {
        public Guid Id { get; }

        public string Step1Result { get; set; }

        public string Step2Result { get; set; }

        public Work()
        {
            Id = Guid.NewGuid();
        }
    }

### The first step:

-	Order the Id, and set on Step1Result property
### The second step:

-	Sum all numbers in the Id, and set on Step2Result property

### Additional Requirements:

-	The Work class cannot be modified.
-	The Work results need to be written to a UI/Console once it is complete, this is to validate the results.
  - The writing to UI/Console should not be timed.


Simple right? . . . ¯\\\_(ツ)\_/¯

    // * Summary *

    BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
    AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
    .NET Core SDK=5.0.202
    [Host]     : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
    Job-CWCMVV : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
    
    Runtime=.NET Core 5.0
    
    |           Method | N |        Mean |     Error |    StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |----------------- |-- |------------:|----------:|----------:|-----:|-------:|------:|------:|----------:|
    | Implementation41 | 1 |    16.88 ns |  0.361 ns |  0.481 ns |    1 |      - |     - |     - |         - |
    | Implementation37 | 1 |    35.28 ns |  0.435 ns |  0.407 ns |    2 |      - |     - |     - |         - |
    | Implementation40 | 1 |    35.62 ns |  0.391 ns |  0.366 ns |    2 |      - |     - |     - |         - |
    | Implementation38 | 1 |    39.34 ns |  0.544 ns |  0.509 ns |    3 |      - |     - |     - |         - |
    | Implementation39 | 1 |    42.69 ns |  0.463 ns |  0.433 ns |    4 |      - |     - |     - |         - |
    | Implementation35 | 1 |    94.73 ns |  0.293 ns |  0.259 ns |    5 | 0.0048 |     - |     - |      40 B |
    | Implementation36 | 1 |    95.88 ns |  0.552 ns |  0.517 ns |    5 | 0.0048 |     - |     - |      40 B |
    | Implementation33 | 1 |    95.91 ns |  0.743 ns |  0.695 ns |    5 | 0.0048 |     - |     - |      40 B |
    | Implementation34 | 1 |    99.37 ns |  1.914 ns |  1.790 ns |    6 | 0.0048 |     - |     - |      40 B |
    | Implementation27 | 1 |   150.37 ns |  1.131 ns |  1.058 ns |    7 | 0.0210 |     - |     - |     176 B |
    | Implementation32 | 1 |   151.39 ns |  0.663 ns |  0.588 ns |    7 | 0.0162 |     - |     - |     136 B |
    | Implementation28 | 1 |   154.43 ns |  2.410 ns |  2.254 ns |    8 | 0.0162 |     - |     - |     136 B |
    | Implementation29 | 1 |   157.67 ns |  1.077 ns |  1.007 ns |    9 | 0.0162 |     - |     - |     136 B |
    | Implementation30 | 1 |   162.49 ns |  0.994 ns |  0.929 ns |   10 | 0.0162 |     - |     - |     136 B |
    | Implementation31 | 1 |   210.41 ns |  1.315 ns |  1.230 ns |   11 | 0.0315 |     - |     - |     264 B |
    | Implementation26 | 1 |   274.51 ns |  2.192 ns |  2.050 ns |   12 | 0.0324 |     - |     - |     272 B |
    | Implementation22 | 1 |   402.15 ns |  1.815 ns |  1.698 ns |   13 | 0.0191 |     - |     - |     160 B |
    | Implementation21 | 1 |   408.97 ns |  1.595 ns |  1.492 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation23 | 1 |   409.35 ns |  0.618 ns |  0.548 ns |   14 | 0.0191 |     - |     - |     160 B |
    | Implementation25 | 1 |   411.78 ns |  1.025 ns |  0.909 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation15 | 1 |   413.19 ns |  1.081 ns |  0.958 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation19 | 1 |   415.50 ns |  1.105 ns |  1.033 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation18 | 1 |   416.10 ns |  1.806 ns |  1.601 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation24 | 1 |   416.14 ns |  1.561 ns |  1.460 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation20 | 1 |   419.93 ns |  1.222 ns |  1.143 ns |   14 | 0.0191 |     - |     - |     160 B |
    | Implementation17 | 1 |   420.23 ns |  1.154 ns |  1.023 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation16 | 1 |   519.28 ns |  1.990 ns |  1.861 ns |   15 | 0.0162 |     - |     - |     136 B |
    | Implementation14 | 1 |   786.80 ns |  3.343 ns |  3.127 ns |   16 | 0.0229 |     - |     - |     192 B |
    | Implementation13 | 1 |   791.99 ns |  3.025 ns |  2.830 ns |   16 | 0.0343 |     - |     - |     288 B |
    | Implementation10 | 1 |   798.68 ns |  3.924 ns |  3.671 ns |   16 | 0.0343 |     - |     - |     288 B |
    |  Implementation9 | 1 |   801.51 ns |  2.462 ns |  2.183 ns |   16 | 0.0458 |     - |     - |     384 B |
    | Implementation11 | 1 |   805.44 ns |  3.691 ns |  3.453 ns |   16 | 0.0343 |     - |     - |     288 B |
    | Implementation12 | 1 |   808.05 ns |  4.232 ns |  3.959 ns |   16 | 0.0343 |     - |     - |     288 B |
    |  Implementation5 | 1 |   826.23 ns |  3.888 ns |  3.637 ns |   17 | 0.0401 |     - |     - |     336 B |
    |  Implementation7 | 1 |   890.81 ns |  3.239 ns |  3.030 ns |   18 | 0.0343 |     - |     - |     288 B |
    |  Implementation6 | 1 |   892.56 ns |  5.204 ns |  4.868 ns |   18 | 0.0343 |     - |     - |     288 B |
    |  Implementation4 | 1 |   931.41 ns |  3.428 ns |  3.206 ns |   19 | 0.0553 |     - |     - |     464 B |
    |  Implementation8 | 1 | 1,022.26 ns |  3.937 ns |  3.683 ns |   20 | 0.0229 |     - |     - |     192 B |
    |  Implementation3 | 1 | 1,437.78 ns | 12.376 ns | 11.577 ns |   21 | 0.1068 |     - |     - |     899 B |
    |  Implementation2 | 1 | 3,153.67 ns | 18.268 ns | 17.088 ns |   22 | 0.2022 |     - |     - |    1708 B |
    |  Implementation1 | 1 | 4,704.16 ns | 11.638 ns | 10.886 ns |   23 | 0.0839 |     - |     - |     712 B |
    
    // * Hints *
    Outliers
    ImplementationBenchmarks.Implementation37: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (35.79 ns)
    ImplementationBenchmarks.Implementation35: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (97.92 ns)
    ImplementationBenchmarks.Implementation36: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (96.64 ns)
    ImplementationBenchmarks.Implementation32: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (156.33 ns)
    ImplementationBenchmarks.Implementation23: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (412.84 ns)
    ImplementationBenchmarks.Implementation25: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (416.83 ns)
    ImplementationBenchmarks.Implementation15: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (418.57 ns)
    ImplementationBenchmarks.Implementation18: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (423.13 ns)
    ImplementationBenchmarks.Implementation17: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (425.15 ns)
    ImplementationBenchmarks.Implementation9: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (811.32 ns)
    
    // * Legends *
    N         : Value of the 'N' parameter
    Mean      : Arithmetic mean of all measurements
    Error     : Half of 99.9% confidence interval
    StdDev    : Standard deviation of all measurements
    Rank      : Relative position of current benchmark mean among all benchmarks (Arabic style)
    Gen 0     : GC Generation 0 collects per 1000 operations
    Gen 1     : GC Generation 1 collects per 1000 operations
    Gen 2     : GC Generation 2 collects per 1000 operations
    Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
    1 ns      : 1 Nanosecond (0.000000001 sec)
    
    // * Diagnostic Output - MemoryDiagnoser *
    
    
    // ***** BenchmarkRunner: End *****
    // ** Remained 0 benchmark(s) to run **
    Run time: 00:14:14 (854.03 sec), executed benchmarks: 41
    
    Global total time: 00:14:17 (857.36 sec), executed benchmarks: 41
    // * Artifacts cleanup *





