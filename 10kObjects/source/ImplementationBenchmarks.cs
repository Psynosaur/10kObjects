using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using static System.Threading.Tasks.Parallel;

namespace TenKObjects
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ImplementationBenchmarks
    {
        private static readonly Implementations Implimentor = new Implementations();
        private WorkStruct[] _list;
        private WorkStructByteArrayConstr[] _list2;

        [Params(1,100, 1000, 10000)] public int N;
        
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
        [GlobalSetup]
        public void Setup()
        {
            _list = WorkStructArrayMaker(N);
            _list2 = WorkStructArrayMaker2(N);
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
            Implimentor.Implementation28(_list2);
        }
        
        
        
        
        // [Benchmark]
        // public void Implementation30()
        // {
        //     Implimentor.Implementation30(_list2);
        // }
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
            For(0, n, i =>
            {
                arr[i] = new WorkStructByteArrayConstr(0);
            });

            return arr;
        }
        
        // [Benchmark]
        // [ArgumentsSource(nameof(ObjectsEnumerable3))]
        // public void Implementation31(WorkStructByteArrayConstr[] arr)
        // {
        //     Implimentor.Implementation31(arr);
        // }
        
        // public IEnumerable<object> ObjectsEnumerable3()
        // {
        //     var arr = new WorkStructByteArrayConstr[10000];
        //     For(0, 10000, i =>
        //     {
        //         arr[i] = new WorkStructByteArrayConstr(0);
        //     });
        //
        //     yield return arr.ToList();
        // }
    }
}