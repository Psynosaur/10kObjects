using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using static System.Threading.Tasks.Parallel;

namespace Mobii
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ImplementationBenchmarks
    {
        private static readonly Implementations Implimentor = new Implementations();
        private WorkStruct[] _list;
        private WorkStructByteArrayConstr[] _list2;

        [Params(1,100)] public int N;

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
        // [Benchmark]
        // public void Implementation16()
        // {
        //     Implimentor.Implementation16();
        // }
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
            Implimentor.Implementation24();
        }
        [Benchmark]
        public void Implementation25()
        {
            Implimentor.Implementation25(N);
        }
        [Benchmark]
        public void Implementation26()
        {
            Implimentor.Implementation26(N);
        }
        [Benchmark]
        public void Implementation27()
        {
            Implimentor.Implementation27(N);
        }
        
        [GlobalSetup]
        public void Setup()
        {
            _list = WorkStructArrayMaker(N, out var arr);
            _list2 = ObjectsEnumerable2(N);
        }
        
        [Benchmark]
        public void Implementation28()
        {
            Implimentor.Implementation28(_list);
        }
        
        [Benchmark]
        public void Implementation29()
        {
            Implimentor.Implementation29(_list2);
        }
        
        [Benchmark]
        public void Implementation30()
        {
            Implimentor.Implementation30(_list2);
        }
        
        // [Benchmark]
        // public void Implementation31()
        // {
        //     Implimentor.Implementation31(_list2);
        // }
        private static WorkStruct[] WorkStructArrayMaker(int n, out WorkStruct[] arr)
        {
            arr = new WorkStruct[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new WorkStruct {Id = Guid.NewGuid().ToString()};
            }

            return arr;
        }

        private static WorkStructByteArrayConstr[] ObjectsEnumerable2(int n)
        {
            WorkStructByteArrayConstr[] arr = new WorkStructByteArrayConstr[n];
            For(0, n, i =>
            {
                arr[i] = new WorkStructByteArrayConstr(0);
            });

            return arr;
        }
    }
}