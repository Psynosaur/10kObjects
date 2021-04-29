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
    Job-TUPAEC : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
    
    Runtime=.NET Core 5.0
    
    |           Method | N |        Mean |     Error |    StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |----------------- |-- |------------:|----------:|----------:|-----:|-------:|------:|------:|----------:|
    | Implementation36 | 1 |    78.14 ns |  0.680 ns |  0.636 ns |    1 | 0.0048 |     - |     - |      40 B |
    | Implementation34 | 1 |    80.83 ns |  0.698 ns |  0.653 ns |    2 | 0.0048 |     - |     - |      40 B |
    | Implementation33 | 1 |    88.64 ns |  0.918 ns |  0.859 ns |    3 | 0.0048 |     - |     - |      40 B |
    | Implementation35 | 1 |    91.61 ns |  0.602 ns |  0.563 ns |    4 | 0.0048 |     - |     - |      40 B |
    | Implementation29 | 1 |   132.81 ns |  0.861 ns |  0.763 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation28 | 1 |   149.42 ns |  0.763 ns |  0.714 ns |    6 | 0.0162 |     - |     - |     136 B |
    | Implementation30 | 1 |   154.85 ns |  1.039 ns |  0.921 ns |    7 | 0.0162 |     - |     - |     136 B |
    | Implementation27 | 1 |   156.43 ns |  1.092 ns |  1.021 ns |    7 | 0.0210 |     - |     - |     176 B |
    | Implementation32 | 1 |   167.62 ns |  0.498 ns |  0.441 ns |    8 | 0.0162 |     - |     - |     136 B |
    | Implementation31 | 1 |   212.17 ns |  1.044 ns |  0.976 ns |    9 | 0.0315 |     - |     - |     264 B |
    | Implementation26 | 1 |   332.70 ns |  2.083 ns |  1.948 ns |   10 | 0.0324 |     - |     - |     272 B |
    | Implementation15 | 1 |   417.73 ns |  6.350 ns |  5.302 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation25 | 1 |   419.97 ns |  2.299 ns |  2.151 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation22 | 1 |   420.81 ns |  1.813 ns |  1.695 ns |   11 | 0.0191 |     - |     - |     160 B |
    | Implementation21 | 1 |   421.59 ns |  2.342 ns |  2.191 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation18 | 1 |   426.45 ns |  1.434 ns |  1.342 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation23 | 1 |   426.62 ns |  1.718 ns |  1.607 ns |   11 | 0.0191 |     - |     - |     160 B |
    | Implementation19 | 1 |   427.44 ns |  1.564 ns |  1.463 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation20 | 1 |   431.92 ns |  1.452 ns |  1.358 ns |   11 | 0.0191 |     - |     - |     160 B |
    | Implementation17 | 1 |   435.24 ns |  1.309 ns |  1.225 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation24 | 1 |   439.80 ns |  1.387 ns |  1.229 ns |   11 | 0.0162 |     - |     - |     136 B |
    | Implementation16 | 1 |   525.69 ns |  2.637 ns |  2.467 ns |   12 | 0.0162 |     - |     - |     136 B |
    | Implementation10 | 1 |   801.22 ns |  2.633 ns |  2.463 ns |   13 | 0.0343 |     - |     - |     288 B |
    | Implementation13 | 1 |   806.44 ns |  5.323 ns |  4.156 ns |   13 | 0.0343 |     - |     - |     288 B |
    |  Implementation9 | 1 |   807.80 ns |  6.383 ns |  5.659 ns |   13 | 0.0458 |     - |     - |     384 B |
    | Implementation11 | 1 |   811.73 ns |  2.095 ns |  1.858 ns |   13 | 0.0343 |     - |     - |     288 B |
    | Implementation12 | 1 |   831.44 ns | 14.185 ns | 13.268 ns |   14 | 0.0343 |     - |     - |     288 B |
    | Implementation14 | 1 |   831.61 ns | 16.375 ns | 14.516 ns |   14 | 0.0229 |     - |     - |     192 B |
    |  Implementation5 | 1 |   851.35 ns |  3.161 ns |  2.957 ns |   15 | 0.0401 |     - |     - |     336 B |
    |  Implementation7 | 1 |   912.32 ns |  2.918 ns |  2.730 ns |   16 | 0.0343 |     - |     - |     288 B |
    |  Implementation6 | 1 |   918.01 ns |  3.094 ns |  2.742 ns |   16 | 0.0343 |     - |     - |     288 B |
    |  Implementation4 | 1 |   969.32 ns |  3.019 ns |  2.676 ns |   17 | 0.0553 |     - |     - |     464 B |
    |  Implementation8 | 1 | 1,028.89 ns | 15.660 ns | 13.077 ns |   18 | 0.0229 |     - |     - |     192 B |
    |  Implementation3 | 1 | 1,460.03 ns |  7.039 ns |  6.585 ns |   19 | 0.1068 |     - |     - |     900 B |
    |  Implementation2 | 1 | 3,269.75 ns | 11.153 ns |  9.887 ns |   20 | 0.2022 |     - |     - |    1707 B |
    |  Implementation1 | 1 | 4,763.98 ns |  9.559 ns |  8.941 ns |   21 | 0.0839 |     - |     - |     712 B |
    
    // * Hints *
    Outliers
    ImplementationBenchmarks.Implementation29: Runtime=.NET Core 5.0 -> 1 outlier  was  removed, 2 outliers were detected (133.10 ns, 136.71 ns)
    ImplementationBenchmarks.Implementation30: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (159.54 ns)
    ImplementationBenchmarks.Implementation32: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (170.68 ns)
    ImplementationBenchmarks.Implementation15: Runtime=.NET Core 5.0 -> 2 outliers were removed (440.27 ns, 441.89 ns)
    ImplementationBenchmarks.Implementation21: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (418.81 ns)
    ImplementationBenchmarks.Implementation24: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (445.73 ns)
    ImplementationBenchmarks.Implementation13: Runtime=.NET Core 5.0 -> 3 outliers were removed (847.95 ns..850.44 ns)
    ImplementationBenchmarks.Implementation9: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (847.59 ns)
    ImplementationBenchmarks.Implementation11: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (825.80 ns)
    ImplementationBenchmarks.Implementation14: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (900.01 ns)
    ImplementationBenchmarks.Implementation5: Runtime=.NET Core 5.0  -> 2 outliers were detected (847.82 ns, 848.64 ns)
    ImplementationBenchmarks.Implementation6: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (929.45 ns)
    ImplementationBenchmarks.Implementation4: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (988.95 ns)
    ImplementationBenchmarks.Implementation8: Runtime=.NET Core 5.0  -> 2 outliers were removed (1.08 us, 1.09 us)
    ImplementationBenchmarks.Implementation2: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (3.31 us)


