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
    Job-PWPYBZ : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
    
    Runtime=.NET Core 5.0
    
    |           Method | N |        Mean |     Error |    StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |----------------- |-- |------------:|----------:|----------:|-----:|-------:|------:|------:|----------:|
    | Implementation37 | 1 |    37.36 ns |  0.751 ns |  0.702 ns |    1 |      - |     - |     - |         - |
    | Implementation38 | 1 |    38.83 ns |  0.608 ns |  0.569 ns |    2 |      - |     - |     - |         - |
    | Implementation33 | 1 |    92.92 ns |  0.502 ns |  0.470 ns |    3 | 0.0048 |     - |     - |      40 B |
    | Implementation34 | 1 |    94.21 ns |  0.852 ns |  0.797 ns |    3 | 0.0048 |     - |     - |      40 B |
    | Implementation36 | 1 |    96.30 ns |  1.135 ns |  1.061 ns |    4 | 0.0048 |     - |     - |      40 B |
    | Implementation35 | 1 |   111.55 ns |  0.498 ns |  0.466 ns |    5 | 0.0048 |     - |     - |      40 B |
    | Implementation30 | 1 |   143.05 ns |  0.832 ns |  0.779 ns |    6 | 0.0162 |     - |     - |     136 B |
    | Implementation32 | 1 |   147.83 ns |  1.180 ns |  1.046 ns |    7 | 0.0162 |     - |     - |     136 B |
    | Implementation28 | 1 |   147.94 ns |  1.418 ns |  1.327 ns |    7 | 0.0162 |     - |     - |     136 B |
    | Implementation29 | 1 |   149.59 ns |  1.538 ns |  1.439 ns |    7 | 0.0162 |     - |     - |     136 B |
    | Implementation27 | 1 |   153.78 ns |  1.254 ns |  1.173 ns |    8 | 0.0210 |     - |     - |     176 B |
    | Implementation31 | 1 |   197.42 ns |  1.242 ns |  1.161 ns |    9 | 0.0315 |     - |     - |     264 B |
    | Implementation26 | 1 |   305.82 ns |  3.064 ns |  2.866 ns |   10 | 0.0324 |     - |     - |     272 B |
    | Implementation21 | 1 |   403.53 ns |  1.690 ns |  1.581 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation24 | 1 |   409.33 ns |  1.675 ns |  1.566 ns |   12 | 0.0162 |     - |     - |     136 B |
    | Implementation25 | 1 |   410.08 ns |  0.696 ns |  0.651 ns |   12 | 0.0162 |     - |     - |     136 B |
    | Implementation23 | 1 |   410.67 ns |  1.579 ns |  1.477 ns |   12 | 0.0191 |     - |     - |     160 B |
    | Implementation22 | 1 |   411.06 ns |  1.536 ns |  1.361 ns |   12 | 0.0191 |     - |     - |     160 B |
    | Implementation19 | 1 |   414.05 ns |  0.843 ns |  0.747 ns |   12 | 0.0162 |     - |     - |     136 B |
    | Implementation15 | 1 |   415.91 ns |  1.613 ns |  1.509 ns |   12 | 0.0162 |     - |     - |     136 B |
    | Implementation17 | 1 |   416.56 ns |  0.811 ns |  0.677 ns |   12 | 0.0162 |     - |     - |     136 B |
    | Implementation20 | 1 |   418.33 ns |  1.652 ns |  1.545 ns |   12 | 0.0191 |     - |     - |     160 B |
    | Implementation18 | 1 |   421.11 ns |  1.177 ns |  0.983 ns |   12 | 0.0162 |     - |     - |     136 B |
    | Implementation16 | 1 |   516.90 ns |  1.410 ns |  1.177 ns |   13 | 0.0162 |     - |     - |     136 B |
    | Implementation10 | 1 |   774.30 ns |  3.377 ns |  2.993 ns |   14 | 0.0343 |     - |     - |     288 B |
    | Implementation12 | 1 |   784.70 ns |  3.463 ns |  3.239 ns |   15 | 0.0343 |     - |     - |     288 B |
    | Implementation11 | 1 |   784.96 ns |  3.248 ns |  3.038 ns |   15 | 0.0343 |     - |     - |     288 B |
    | Implementation14 | 1 |   794.28 ns |  2.266 ns |  2.120 ns |   15 | 0.0229 |     - |     - |     192 B |
    |  Implementation9 | 1 |   795.14 ns |  2.098 ns |  1.963 ns |   15 | 0.0458 |     - |     - |     384 B |
    | Implementation13 | 1 |   799.14 ns |  2.054 ns |  1.715 ns |   15 | 0.0343 |     - |     - |     288 B |
    |  Implementation5 | 1 |   830.19 ns |  1.770 ns |  1.655 ns |   16 | 0.0401 |     - |     - |     336 B |
    |  Implementation7 | 1 |   888.96 ns |  3.124 ns |  2.922 ns |   17 | 0.0343 |     - |     - |     288 B |
    |  Implementation6 | 1 |   896.30 ns |  2.635 ns |  2.465 ns |   17 | 0.0343 |     - |     - |     288 B |
    |  Implementation4 | 1 |   932.17 ns |  2.834 ns |  2.512 ns |   18 | 0.0553 |     - |     - |     464 B |
    |  Implementation8 | 1 | 1,003.97 ns |  3.534 ns |  3.133 ns |   19 | 0.0229 |     - |     - |     192 B |
    |  Implementation3 | 1 | 1,398.88 ns |  7.654 ns |  6.785 ns |   20 | 0.1068 |     - |     - |     900 B |
    |  Implementation2 | 1 | 3,192.00 ns | 14.295 ns | 12.672 ns |   21 | 0.2022 |     - |     - |    1708 B |
    |  Implementation1 | 1 | 4,715.46 ns | 11.060 ns |  9.804 ns |   22 | 0.0839 |     - |     - |     712 B |
    
    // * Hints *
    Outliers
    ImplementationBenchmarks.Implementation35: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (112.42 ns)
    ImplementationBenchmarks.Implementation32: Runtime=.NET Core 5.0 -> 1 outlier  was  removed, 2 outliers were detected (147.21 ns, 153.05 ns)
    ImplementationBenchmarks.Implementation29: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (147.65 ns)
    ImplementationBenchmarks.Implementation25: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (410.49 ns)
    ImplementationBenchmarks.Implementation22: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (417.67 ns)
    ImplementationBenchmarks.Implementation19: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (420.69 ns)
    ImplementationBenchmarks.Implementation17: Runtime=.NET Core 5.0 -> 2 outliers were removed (422.60 ns, 423.52 ns)
    ImplementationBenchmarks.Implementation18: Runtime=.NET Core 5.0 -> 2 outliers were removed (425.56 ns, 425.95 ns)
    ImplementationBenchmarks.Implementation16: Runtime=.NET Core 5.0 -> 2 outliers were removed (526.52 ns, 526.76 ns)
    ImplementationBenchmarks.Implementation10: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (788.03 ns)
    ImplementationBenchmarks.Implementation14: Runtime=.NET Core 5.0 -> 2 outliers were detected (791.70 ns, 792.35 ns)
    ImplementationBenchmarks.Implementation13: Runtime=.NET Core 5.0 -> 2 outliers were removed, 3 outliers were detected (796.47 ns, 806.83 ns, 810.67 ns)
    ImplementationBenchmarks.Implementation6: Runtime=.NET Core 5.0  -> 1 outlier  was  detected (893.44 ns)
    ImplementationBenchmarks.Implementation4: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (944.95 ns)
    ImplementationBenchmarks.Implementation8: Runtime=.NET Core 5.0  -> 1 outlier  was  removed, 2 outliers were detected (998.20 ns, 1.01 μs)
    ImplementationBenchmarks.Implementation3: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (1.42 μs)
    ImplementationBenchmarks.Implementation2: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (3.25 μs)
    ImplementationBenchmarks.Implementation1: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (4.76 μs)
    
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




