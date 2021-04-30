using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using static System.Threading.Tasks.Parallel;
using static TenKObjects.ClassesAndStructs;

namespace TenKObjects
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [RPlotExporter]
    public class ImplementationBenchmarks
    {
        // Second version after reading benchmarkdotnet setup guides.
        // https://github.com/dotnet/performance/blob/main/docs/microbenchmark-design-guidelines.md
        private static readonly ImplementationsForNTimes Implimentor = new ImplementationsForNTimes();
        [Params(1)] public int N;
        private WorkStruct[] _list;
        private WorkStructByteArrayConstr[] _list2,_list3, _list4,_list5,_list6,_list7,_list8,_list9,_list10;
        private WorkStructByteArrayConstrFinal[] _list11, _list12;
        private Work[] _work;

        [GlobalSetup]
        public void Setup()
        {
            // each benchmark should have its own list, or the next benchmark gets a sorted list...
            _list = WorkStructArrayMaker(N);
            _list2 = WorkStructArrayMaker2(N);
            _list3 = WorkStructArrayMaker2(N);
            _list4 = WorkStructArrayMaker2(N);
            _list5 = WorkStructArrayMaker2(N);
            _list6 = WorkStructArrayMaker2(N);
            _list7 = WorkStructArrayMaker2(N);
            _list8 = WorkStructArrayMaker2(N);
            _list9 = WorkStructArrayMaker2(N);
            _list10 = WorkStructArrayMaker2(N);
            _list11 = WorkStructArrayMaker3(N);
            _list12 = WorkStructArrayMaker3(N);
            _work = WorkClassArrayMaker(N);
        }

        [Benchmark]
        public void Implementation1()
        {
            Implimentor.Implementation1(N);
        }
        
        [Benchmark(Baseline = default)]
        public void Implementation2()
        {
            Implimentor.Implementation2(N);
        }
        
        [Benchmark]
        public void Implementation3()
        {
            Implimentor.Implementation3(N);
        }
        
        [Benchmark]
        public void Implementation4()
        {
            Implimentor.Implementation4(N);
        }
        
        [Benchmark]
        public void Implementation5()
        {
            Implimentor.Implementation5(N);
        }
        
        [Benchmark]
        public void Implementation6()
        {
            Implimentor.Implementation6(N);
        }
        
        [Benchmark]
        public void Implementation7()
        {
            Implimentor.Implementation7(N);
        }
        
        [Benchmark]
        public void Implementation8()
        {
            Implimentor.Implementation8(N);
        }
        
        [Benchmark]
        public void Implementation9()
        {
            Implimentor.Implementation9(N);
        }
        
        [Benchmark]
        public void Implementation10()
        {
            Implimentor.Implementation10(N);
        }
        
        [Benchmark]
        public void Implementation11()
        {
            Implimentor.Implementation11(N);
        }
        
        [Benchmark]
        public void Implementation12()
        {
            Implimentor.Implementation12(N);
        }
        
        [Benchmark]
        public void Implementation13()
        {
            Implimentor.Implementation13(N);
        }
        
        [Benchmark]
        public void Implementation14()
        {
            Implimentor.Implementation14(N);
        }
        
        [Benchmark]
        public void Implementation15()
        {
            Implimentor.Implementation15(N);
        }
        
        [Benchmark]
        public void Implementation16()
        {
            Implimentor.Implementation16(N);
        }
        
        [Benchmark]
        public void Implementation17()
        {
            Implimentor.Implementation17(N);
        }
        
        [Benchmark]
        public void Implementation18()
        {
            Implimentor.Implementation18(N);
        }
        
        [Benchmark]
        public void Implementation19()
        {
            Implimentor.Implementation19(N);
        }
        
        [Benchmark]
        public void Implementation20()
        {
            Implimentor.Implementation20(N);
        }
        
        [Benchmark]
        public void Implementation21()
        {
            Implimentor.Implementation21(N);
        }
        
        [Benchmark]
        public void Implementation22()
        {
            Implimentor.Implementation22(N);
        }
        
        [Benchmark]
        public void Implementation23()
        {
            Implimentor.Implementation23(N);
        }
        
        [Benchmark]
        public void Implementation24()
        {
            Implimentor.Implementation24(N);
        }
        
        [Benchmark]
        public void Implementation25()
        {
            Implimentor.Implementation25(N);
        }
        
        [Benchmark]
        public void Implementation26()
        {
            Implimentor.Implementation26(_list);
        }
        
        [Benchmark]
        public void Implementation27()
        {
            Implimentor.Implementation27(_list2);
        }
        
        [Benchmark]
        public void Implementation28()
        {
            Implimentor.Implementation28(_list3);
        }
        
        [Benchmark]
        public void Implementation29()
        {
            Implimentor.Implementation29(_list4);
        }
        
        [Benchmark]
        public void Implementation30()
        {
            Implimentor.Implementation30(_list5);
        }
        
        [Benchmark]
        public void Implementation31()
        {
            Implimentor.Implementation31(_work);
        }
        
        [Benchmark]
        public void Implementation32()
        {
            Implimentor.Implementation32(_list6);
        }
        
        [Benchmark]
        public void Implementation33()
        {
            Implimentor.Implementation33(_list7);
        }
        
        [Benchmark]
        public void Implementation34()
        {
            Implimentor.Implementation34(_list8);
        }
        
        [Benchmark]
        public void Implementation35()
        {
            Implimentor.Implementation35(_list9);
        }

        [Benchmark]
        public void Implementation36()
        {
            Implimentor.Implementation36(_list10);
        }
        [Benchmark]
        public void Implementation37()
        {
            Implimentor.Implementation37(_list11);
        }
        [Benchmark]
        public void Implementation38()
        {
            Implimentor.Implementation38(_list12);
        }

        private static WorkStruct[] WorkStructArrayMaker(int n)
        {
            var arr = new WorkStruct[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new WorkStruct {Id = Guid.NewGuid().ToString()};
            }

            return arr;
        }

        private static WorkStructByteArrayConstr[] WorkStructArrayMaker2(int n)
        {
            WorkStructByteArrayConstr[] arr = new WorkStructByteArrayConstr[n];
            For(0, n, i => { arr[i] = new WorkStructByteArrayConstr(0); });

            return arr;
        }
        
        private static WorkStructByteArrayConstrFinal[] WorkStructArrayMaker3(int n)
        {
            WorkStructByteArrayConstrFinal[] arr = new WorkStructByteArrayConstrFinal[n];
            For(0, n, i => { arr[i] = new WorkStructByteArrayConstrFinal(0); });

            return arr;
        }

        private static Work[] WorkClassArrayMaker(int n)
        {
            Work[] arr = new Work[n];
            For(0, n, i => { arr[i] = new Work(); });

            return arr;
        }


        [GlobalCleanup]
        public void Clean()
        {
            _list = null;
            _list2 = null;
            _list3 = null;
            _list4 = null;
            _list5 = null;
            _list6 = null;
            _list7 = null;
            _list8 = null;
            _list9 = null;
            _list10 = null;
            _list11 = null;
            _list12 = null;
            _work = null;
        }
        // Array as params, but I get Failed to execute benchmark - exception was: 'Parameter count mismatch.'

        // System.InvalidOperationException: Method may only be called on a Type for which Type.IsGenericParameter is true.
        // at System.RuntimeType.get_DeclaringMethod()

        // [Benchmark]
        // [ArgumentsSource(nameof(ObjectsEnumerable66))]
        // public void Implementation66(WorkStructByteArrayConstr[] arr)
        // {
        //     Implimentor.Implementation66(arr);
        // }
        //
        // public IEnumerable<object> ObjectsEnumerable3()
        // {
        //     var arr = new WorkStructByteArrayConstr[10000];
        //     For(0, 10000, i =>
        //     {
        //         arr[i] = new WorkStructByteArrayConstr(0);
        //     });
        //
        //     return new[] {arr};
        // }
    }
}