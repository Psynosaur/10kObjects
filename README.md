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
    Job-NAJKOX : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
    
    Runtime=.NET Core 5.0
    
    |           Method | N |        Mean |     Error |    StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |----------------- |-- |------------:|----------:|----------:|-----:|-------:|------:|------:|----------:|
    | Implementation37 | 1 |    41.85 ns |  0.275 ns |  0.257 ns |    1 |      - |     - |     - |         - |
    | Implementation33 | 1 |    87.18 ns |  1.705 ns |  2.030 ns |    2 | 0.0048 |     - |     - |      40 B |
    | Implementation34 | 1 |    94.80 ns |  1.543 ns |  1.443 ns |    3 | 0.0048 |     - |     - |      40 B |
    | Implementation36 | 1 |    95.19 ns |  0.599 ns |  0.561 ns |    3 | 0.0048 |     - |     - |      40 B |
    | Implementation35 | 1 |    99.19 ns |  0.948 ns |  0.886 ns |    4 | 0.0048 |     - |     - |      40 B |
    | Implementation29 | 1 |   155.29 ns |  1.632 ns |  1.447 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation28 | 1 |   155.63 ns |  1.380 ns |  1.291 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation27 | 1 |   162.01 ns |  1.190 ns |  0.994 ns |    6 | 0.0210 |     - |     - |     176 B |
    | Implementation30 | 1 |   168.32 ns |  0.663 ns |  0.621 ns |    7 | 0.0162 |     - |     - |     136 B |
    | Implementation32 | 1 |   183.94 ns |  0.932 ns |  0.872 ns |    8 | 0.0162 |     - |     - |     136 B |
    | Implementation31 | 1 |   202.05 ns |  2.505 ns |  2.343 ns |    9 | 0.0315 |     - |     - |     264 B |
    | Implementation26 | 1 |   306.38 ns |  3.081 ns |  2.882 ns |   10 | 0.0324 |     - |     - |     272 B |
    | Implementation21 | 1 |   419.42 ns |  2.181 ns |  2.040 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation24 | 1 |   420.59 ns |  1.052 ns |  0.984 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation15 | 1 |   421.91 ns |  2.192 ns |  1.830 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation22 | 1 |   422.52 ns |  2.104 ns |  1.865 ns |   11 | 0.0191 |     - |     - |     160 B |
    | Implementation23 | 1 |   423.56 ns |  1.369 ns |  1.214 ns |   11 | 0.0191 |     - |     - |     160 B |
    | Implementation19 | 1 |   426.30 ns |  3.831 ns |  3.396 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation18 | 1 |   426.37 ns |  1.129 ns |  0.943 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation20 | 1 |   426.39 ns |  1.881 ns |  1.760 ns |   11 | 0.0191 |     - |     - |     160 B |
    | Implementation17 | 1 |   427.43 ns |  1.529 ns |  1.356 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation25 | 1 |   428.34 ns |  0.999 ns |  0.934 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation16 | 1 |   522.99 ns |  1.095 ns |  0.855 ns |   12 | 0.0162 |     - |     - |     136 B |
    | Implementation13 | 1 |   807.10 ns |  4.139 ns |  3.669 ns |   13 | 0.0343 |     - |     - |     288 B |
    | Implementation10 | 1 |   807.41 ns |  2.624 ns |  2.326 ns |   13 | 0.0343 |     - |     - |     288 B |
    | Implementation11 | 1 |   813.45 ns |  2.760 ns |  2.447 ns |   13 | 0.0343 |     - |     - |     288 B |
    |  Implementation9 | 1 |   818.95 ns |  7.309 ns |  6.479 ns |   13 | 0.0458 |     - |     - |     384 B |
    | Implementation12 | 1 |   820.46 ns | 16.275 ns | 15.984 ns |   13 | 0.0343 |     - |     - |     288 B |
    |  Implementation5 | 1 |   859.34 ns |  2.096 ns |  1.636 ns |   14 | 0.0401 |     - |     - |     336 B |
    |  Implementation7 | 1 |   909.90 ns |  3.235 ns |  3.026 ns |   15 | 0.0343 |     - |     - |     288 B |
    |  Implementation6 | 1 |   916.29 ns |  2.756 ns |  2.443 ns |   15 | 0.0343 |     - |     - |     288 B |
    | Implementation14 | 1 |   953.24 ns | 29.170 ns | 85.549 ns |   15 | 0.0229 |     - |     - |     192 B |
    |  Implementation4 | 1 |   981.76 ns |  4.830 ns |  4.033 ns |   15 | 0.0553 |     - |     - |     464 B |
    |  Implementation8 | 1 | 1,021.08 ns |  4.656 ns |  4.355 ns |   16 | 0.0229 |     - |     - |     192 B |
    |  Implementation3 | 1 | 1,476.76 ns |  7.141 ns |  6.330 ns |   17 | 0.1068 |     - |     - |     900 B |
    |  Implementation2 | 1 | 3,307.69 ns | 24.858 ns | 23.252 ns |   18 | 0.2022 |     - |     - |    1708 B |
    |  Implementation1 | 1 | 4,774.20 ns | 17.347 ns | 15.378 ns |   19 | 0.0839 |     - |     - |     712 B |
    
    // * Warnings *
    MultimodalDistribution
    ImplementationBenchmarks.Implementation14: Runtime=.NET Core 5.0 -> It seems that the distribution is multimodal (mValue = 4.8)
    
    // * Hints *
    Outliers
    ImplementationBenchmarks.Implementation33: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (83.12 ns)
    ImplementationBenchmarks.Implementation29: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (163.47 ns)
    ImplementationBenchmarks.Implementation27: Runtime=.NET Core 5.0 -> 2 outliers were removed (166.88 ns, 167.47 ns)
    ImplementationBenchmarks.Implementation15: Runtime=.NET Core 5.0 -> 2 outliers were removed (443.61 ns, 445.23 ns)
    ImplementationBenchmarks.Implementation22: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (431.21 ns)
    ImplementationBenchmarks.Implementation23: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (429.34 ns)
    ImplementationBenchmarks.Implementation19: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (468.66 ns)
    ImplementationBenchmarks.Implementation18: Runtime=.NET Core 5.0 -> 2 outliers were removed (431.62 ns, 445.87 ns)
    ImplementationBenchmarks.Implementation17: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (441.51 ns)
    ImplementationBenchmarks.Implementation25: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (428.28 ns)
    ImplementationBenchmarks.Implementation16: Runtime=.NET Core 5.0 -> 3 outliers were removed, 4 outliers were detected (522.69 ns, 528.38 ns..528.76 ns)
    ImplementationBenchmarks.Implementation13: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (821.12 ns)
    ImplementationBenchmarks.Implementation10: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (816.80 ns)
    ImplementationBenchmarks.Implementation11: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (840.54 ns)
    ImplementationBenchmarks.Implementation9: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (842.62 ns)
    ImplementationBenchmarks.Implementation5: Runtime=.NET Core 5.0  -> 3 outliers were removed, 5 outliers were detected (858.32 ns, 858.34 ns, 867.40 ns..872.12 ns)
    ImplementationBenchmarks.Implementation6: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (931.47 ns)
    ImplementationBenchmarks.Implementation14: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (1.26 us)
    ImplementationBenchmarks.Implementation4: Runtime=.NET Core 5.0  -> 2 outliers were removed (1.04 us, 1.06 us)
    ImplementationBenchmarks.Implementation3: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (1.50 us)
    ImplementationBenchmarks.Implementation1: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (4.99 us)
    
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



