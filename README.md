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
    
    |           Method | N |       Mean |    Error |   StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    |----------------- |-- |-----------:|---------:|---------:|-----:|-------:|------:|------:|----------:|
    | Implementation28 | 1 |   133.9 ns |  0.72 ns |  0.67 ns |    1 | 0.0162 |     - |     - |     136 B |
    | Implementation30 | 1 |   134.8 ns |  0.90 ns |  0.85 ns |    1 | 0.0162 |     - |     - |     136 B |
    | Implementation27 | 1 |   146.0 ns |  0.84 ns |  0.78 ns |    2 | 0.0210 |     - |     - |     176 B |
    | Implementation29 | 1 |   152.0 ns |  0.61 ns |  0.57 ns |    3 | 0.0162 |     - |     - |     136 B |
    | Implementation26 | 1 |   290.1 ns |  1.62 ns |  1.52 ns |    4 | 0.0324 |     - |     - |     272 B |
    | Implementation24 | 1 |   401.5 ns |  0.83 ns |  0.77 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation23 | 1 |   403.4 ns |  1.27 ns |  1.12 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation21 | 1 |   406.2 ns |  0.90 ns |  0.84 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation15 | 1 |   407.3 ns |  0.92 ns |  0.86 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation22 | 1 |   407.6 ns |  1.01 ns |  0.90 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation25 | 1 |   410.0 ns |  0.71 ns |  0.67 ns |    5 | 0.0162 |     - |     - |     136 B |
    | Implementation18 | 1 |   416.2 ns |  0.91 ns |  0.85 ns |    6 | 0.0162 |     - |     - |     136 B |
    | Implementation19 | 1 |   416.4 ns |  2.19 ns |  2.04 ns |    6 | 0.0162 |     - |     - |     136 B |
    | Implementation17 | 1 |   417.2 ns |  0.94 ns |  0.88 ns |    6 | 0.0162 |     - |     - |     136 B |
    | Implementation20 | 1 |   417.4 ns |  0.96 ns |  0.90 ns |    6 | 0.0162 |     - |     - |     136 B |
    | Implementation16 | 1 |   517.2 ns |  1.86 ns |  1.74 ns |    7 | 0.0162 |     - |     - |     136 B |
    |  Implementation5 | 1 |   737.9 ns |  1.85 ns |  1.73 ns |    8 | 0.0401 |     - |     - |     336 B |
    | Implementation10 | 1 |   783.6 ns |  2.08 ns |  1.85 ns |    9 | 0.0343 |     - |     - |     288 B |
    | Implementation11 | 1 |   784.2 ns |  2.02 ns |  1.79 ns |    9 | 0.0343 |     - |     - |     288 B |
    | Implementation12 | 1 |   789.7 ns |  1.70 ns |  1.59 ns |    9 | 0.0343 |     - |     - |     288 B |
    |  Implementation9 | 1 |   792.2 ns |  2.81 ns |  2.63 ns |    9 | 0.0458 |     - |     - |     384 B |
    | Implementation13 | 1 |   793.6 ns |  2.50 ns |  2.34 ns |    9 | 0.0343 |     - |     - |     288 B |
    | Implementation14 | 1 |   801.5 ns |  1.57 ns |  1.47 ns |    9 | 0.0229 |     - |     - |     192 B |
    |  Implementation7 | 1 |   892.5 ns |  2.93 ns |  2.60 ns |   10 | 0.0343 |     - |     - |     288 B |
    |  Implementation6 | 1 |   901.6 ns |  2.92 ns |  2.59 ns |   10 | 0.0343 |     - |     - |     288 B |
    |  Implementation4 | 1 |   930.3 ns |  3.50 ns |  3.10 ns |   11 | 0.0553 |     - |     - |     464 B |
    |  Implementation8 | 1 | 1,011.4 ns |  6.46 ns |  6.04 ns |   12 | 0.0229 |     - |     - |     192 B |
    |  Implementation3 | 1 | 1,380.8 ns |  6.42 ns |  6.01 ns |   13 | 0.1068 |     - |     - |     900 B |
    |  Implementation2 | 1 | 3,122.0 ns | 13.76 ns | 12.87 ns |   14 | 0.2022 |     - |     - |    1708 B |
    |  Implementation1 | 1 | 4,726.5 ns |  6.44 ns |  6.02 ns |   15 | 0.0839 |     - |     - |     712 B |
    
    // * Hints *
    Outliers
    ImplementationBenchmarks.Implementation26: Runtime=.NET Core 5.0 -> 2 outliers were detected (288.03 ns, 289.57 ns)
    ImplementationBenchmarks.Implementation23: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (408.33 ns)
    ImplementationBenchmarks.Implementation15: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (406.95 ns)
    ImplementationBenchmarks.Implementation22: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (412.30 ns)
    ImplementationBenchmarks.Implementation19: Runtime=.NET Core 5.0 -> 1 outlier  was  detected (414.40 ns)
    ImplementationBenchmarks.Implementation10: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (789.90 ns)
    ImplementationBenchmarks.Implementation11: Runtime=.NET Core 5.0 -> 1 outlier  was  removed (794.26 ns)
    ImplementationBenchmarks.Implementation7: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (902.72 ns)
    ImplementationBenchmarks.Implementation6: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (914.83 ns)
    ImplementationBenchmarks.Implementation4: Runtime=.NET Core 5.0  -> 1 outlier  was  removed (941.68 ns)

