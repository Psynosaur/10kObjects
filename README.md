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
    Job-HBAYZR : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
    
    Runtime=.NET Core 5.0
    
    |           Method | N |        Mean |     Error |    StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |----------------- |-- |------------:|----------:|----------:|-----:|-------:|------:|------:|----------:|
    | Implementation37 | 1 |    41.58 ns |  0.410 ns |  0.383 ns |    1 |      - |     - |     - |         - |
    | Implementation40 | 1 |    43.67 ns |  0.846 ns |  0.831 ns |    2 |      - |     - |     - |         - |
    | Implementation39 | 1 |    45.70 ns |  0.316 ns |  0.280 ns |    3 |      - |     - |     - |         - |
    | Implementation38 | 1 |    45.85 ns |  0.537 ns |  0.502 ns |    3 |      - |     - |     - |         - |
    | Implementation34 | 1 |    75.00 ns |  0.546 ns |  0.511 ns |    4 | 0.0048 |     - |     - |      40 B |
    | Implementation36 | 1 |    83.02 ns |  0.730 ns |  0.683 ns |    5 | 0.0048 |     - |     - |      40 B |
    | Implementation35 | 1 |    88.29 ns |  1.054 ns |  0.985 ns |    6 | 0.0048 |     - |     - |      40 B |
    | Implementation33 | 1 |    95.84 ns |  0.519 ns |  0.460 ns |    7 | 0.0048 |     - |     - |      40 B |
    | Implementation29 | 1 |   149.87 ns |  0.420 ns |  0.351 ns |    8 | 0.0162 |     - |     - |     136 B |
    | Implementation28 | 1 |   150.95 ns |  0.856 ns |  0.715 ns |    8 | 0.0162 |     - |     - |     136 B |
    | Implementation30 | 1 |   164.38 ns |  1.207 ns |  1.129 ns |    9 | 0.0162 |     - |     - |     136 B |
    | Implementation32 | 1 |   166.61 ns |  0.685 ns |  0.641 ns |    9 | 0.0162 |     - |     - |     136 B |
    | Implementation27 | 1 |   175.50 ns |  0.893 ns |  0.745 ns |   10 | 0.0210 |     - |     - |     176 B |
    | Implementation31 | 1 |   201.80 ns |  1.079 ns |  0.901 ns |   11 | 0.0315 |     - |     - |     264 B |
    | Implementation26 | 1 |   302.24 ns |  1.226 ns |  1.086 ns |   12 | 0.0324 |     - |     - |     272 B |
    | Implementation15 | 1 |   402.48 ns |  1.100 ns |  0.975 ns |   13 | 0.0162 |     - |     - |     136 B |
    | Implementation21 | 1 |   411.36 ns |  1.036 ns |  0.865 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation25 | 1 |   415.99 ns |  1.132 ns |  1.004 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation24 | 1 |   417.37 ns |  0.761 ns |  0.712 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation18 | 1 |   419.95 ns |  1.103 ns |  1.032 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation19 | 1 |   422.76 ns |  0.999 ns |  0.886 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation23 | 1 |   423.55 ns |  1.154 ns |  1.079 ns |   14 | 0.0191 |     - |     - |     160 B |
    | Implementation20 | 1 |   426.09 ns |  1.086 ns |  0.963 ns |   14 | 0.0191 |     - |     - |     160 B |
    | Implementation22 | 1 |   427.37 ns |  1.463 ns |  1.369 ns |   14 | 0.0191 |     - |     - |     160 B |
    | Implementation17 | 1 |   428.00 ns |  0.775 ns |  0.647 ns |   14 | 0.0162 |     - |     - |     136 B |
    | Implementation16 | 1 |   521.71 ns |  1.151 ns |  1.021 ns |   15 | 0.0162 |     - |     - |     136 B |
    | Implementation14 | 1 |   801.86 ns |  3.229 ns |  2.863 ns |   16 | 0.0229 |     - |     - |     192 B |
    | Implementation12 | 1 |   803.32 ns |  2.429 ns |  2.272 ns |   16 | 0.0343 |     - |     - |     288 B |
    | Implementation11 | 1 |   803.34 ns |  4.378 ns |  4.095 ns |   16 | 0.0343 |     - |     - |     288 B |
    | Implementation10 | 1 |   803.57 ns |  3.089 ns |  2.890 ns |   16 | 0.0343 |     - |     - |     288 B |
    | Implementation13 | 1 |   810.03 ns |  1.663 ns |  1.389 ns |   16 | 0.0343 |     - |     - |     288 B |
    |  Implementation9 | 1 |   820.26 ns |  3.261 ns |  3.051 ns |   17 | 0.0458 |     - |     - |     384 B |
    |  Implementation5 | 1 |   853.69 ns |  1.749 ns |  1.551 ns |   18 | 0.0401 |     - |     - |     336 B |
    |  Implementation7 | 1 |   907.57 ns |  1.127 ns |  0.999 ns |   19 | 0.0343 |     - |     - |     288 B |
    |  Implementation6 | 1 |   908.89 ns |  2.213 ns |  2.070 ns |   19 | 0.0343 |     - |     - |     288 B |
    |  Implementation4 | 1 |   963.48 ns |  1.987 ns |  1.659 ns |   20 | 0.0553 |     - |     - |     464 B |
    |  Implementation8 | 1 | 1,033.58 ns |  3.794 ns |  3.363 ns |   21 | 0.0229 |     - |     - |     192 B |
    |  Implementation3 | 1 | 1,464.65 ns |  6.315 ns |  5.907 ns |   22 | 0.1068 |     - |     - |     900 B |
    |  Implementation2 | 1 | 3,262.70 ns | 14.858 ns | 13.898 ns |   23 | 0.2022 |     - |     - |    1708 B |
    |  Implementation1 | 1 | 4,754.88 ns |  5.404 ns |  4.791 ns |   24 | 0.0839 |     - |     - |     712 B |
    
    // * Hints *
    Outliers
    ImplementationBenchmarks.Implementation39: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (48.52 ns)
    ImplementationBenchmarks.Implementation34: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (75.66 ns)
    ImplementationBenchmarks.Implementation36: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (83.24 ns)
    ImplementationBenchmarks.Implementation35: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (87.12 ns)
    ImplementationBenchmarks.Implementation33: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (99.67 ns)
    ImplementationBenchmarks.Implementation29: Runtime=.NET Core 5.0 -> 2 outliers were removed (153.34 ns, 155.04 ns)
    ImplementationBenchmarks.Implementation28: Runtime=.NET Core 5.0 -> 2 outliers were removed (155.27 ns, 155.87 ns)
    ImplementationBenchmarks.Implementation27: Runtime=.NET Core 5.0 -> 2 outliers were removed (179.62 ns, 179.73 ns)
    ImplementationBenchmarks.Implementation31: Runtime=.NET Core 5.0 -> 2 outliers were removed (209.18 ns, 212.12 ns)
    ImplementationBenchmarks.Implementation26: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (309.58 ns)
    ImplementationBenchmarks.Implementation15: Runtime=.NET Core 5.0 -> 1 outlier  was  removed, 2 outliers were detected (401.88 ns, 407.96 ns)
    ImplementationBenchmarks.Implementation21: Runtime=.NET Core 5.0 -> 2 outliers were removed (415.60 ns, 416.01 ns)
    ImplementationBenchmarks.Implementation25: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (420.39 ns)
    ImplementationBenchmarks.Implementation19: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (428.07 ns)
    ImplementationBenchmarks.Implementation20: Runtime=.NET Core 5.0 -> 1 outlier  was  removed, 2 outliers were detected (425.23 ns, 430.64 ns)
    ImplementationBenchmarks.Implementation17: Runtime=.NET Core 5.0 -> 2 outliers were removed (432.59 ns, 435.66 ns)
    ImplementationBenchmarks.Implementation16: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (527.45 ns)
    ImplementationBenchmarks.Implementation14: Runtime=.NET Core 5.0 -> 1 outlier  was  removed, 2 outliers were detected (795.83 ns, 812.91 ns)
    ImplementationBenchmarks.Implementation11: Runtime=.NET Core 5.0 -> 2 outliers were detected (795.77 ns, 797.70 ns)
    ImplementationBenchmarks.Implementation13: Runtime=.NET Core 5.0 -> 2 outliers were removed (818.56 ns, 819.31 ns)
    ImplementationBenchmarks.Implementation5: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (859.36 ns)
    ImplementationBenchmarks.Implementation7: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (914.24 ns)
    ImplementationBenchmarks.Implementation4: Runtime=.NET Core 5.0  -> 2 outliers were removed (972.17 ns, 977.08 ns)
    ImplementationBenchmarks.Implementation8: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (1.05 us)
    ImplementationBenchmarks.Implementation1: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (4.78 us)
    
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




