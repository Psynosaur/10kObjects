using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static System.String;
using static System.Threading.Tasks.Parallel;
using static TenKObjects.HelperFunctions;
using static TenKObjects.ClassesAndStructs;

namespace TenKObjects
{
    public class ImplementationsForNTimes
    {
        public void Implementation1(int n)
        {
            For(0, n, _ =>
            {
                var work = new Work();
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = SortString(work.Id.ToString());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(work.Step1Result).ToString();
            });
        }

        // submitted one --
        public void Implementation2(int n)
        {
            For(0, n, _ =>
            {
                var work = new Work();
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = Concat(work.Id.ToString().OrderBy(c => c));
                // extract digits for use in Step 2, I opted not to use Regex, since in this scenario its slower than LINQ
                // var digits = Regex.Match(work.Step1Result, @"\d+").Value;
                var digits = new string(work.Step1Result.Where(char.IsDigit).ToArray());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = digits.Sum(c => c - '0').ToString();
            });
        }

        public void Implementation3(int n)
        {
            For(0, n, _ =>
            {
                var work = new Work();
                var idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // "Convert" it to writable Span<char>
                var span = new Span<char>(idchars);
                idchars.CopyTo(span.Slice(0, idchars.Length));
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = span.ToString();
                // extract digits for use in Step 2
                var digits = new string(work.Step1Result.Where(char.IsDigit).ToArray());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = digits.Sum(c => c - '0').ToString();
            });
        }

        public void Implementation4(int n)
        {
            For(0, n, _ =>
            {
                var work = new Work();
                var idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // "Convert" it to writable Span<char>
                var span = new Span<char>(idchars);
                idchars.CopyTo(span.Slice(0, idchars.Length));
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = span.ToString();
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(span.ToString()).ToString();
            });
        }

        public void Implementation5(int n)
        {
            For(0, n, _ =>
            {
                var work = new Work();
                var idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(idchars.ToString()).ToString();
            });
        }

        public void Implementation6(int n)
        {
            For(0, n, _ =>
            {
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                WorkStructStatic.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                WorkStructStatic.Step2Result = sumOfDigitsDll(WorkStructStatic.Step1Result);
            });
        }

        // Winner so far
        public void Implementation7(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = sumOfDigitsDll(wsArr.Step1Result);
            });
        }

        public void Implementation8(int n)
        {
            For(0, n, _ =>
            {
                WorkStructCharArray wsArr = new WorkStructCharArray();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = idchars;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = sumOfDigitsCharDll(wsArr.Step1Result);
            });
        }

        public void Implementation9(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForEach(wsArr.Step1Result.ToCharArray());
            });
        }

        public void Implementation10(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForEach(wsArr.Step1Result);
            });
        }

        public void Implementation11(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsFor(wsArr.Step1Result);
            });
        }

        public void Implementation12(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsSwitch(wsArr.Step1Result);
            });
        }

        public void Implementation13(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitch(wsArr.Step1Result);
            });
        }

        public unsafe void Implementation14(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStructSpanChar();
                var buffer = SortCharArray(Guid.NewGuid().ToString().ToCharArray());
                var data = stackalloc char[36];
                var destination = new Span<char>(data, 36);
                buffer.CopyTo(destination);
                Span<char> str = destination.Slice(0, buffer.Length);

                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = str;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitch(wsArr.Step1Result);
            });
        }

        public void Implementation15(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStructSpanByte();
                Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id(guid) byte representation, and set (Span<byte>) Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set (int) Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitch(new Guid(wsArr.Step1Result).ToString());
            });
        }

        public void Implementation16(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStructSpanByte();
                Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = sumOfDigitsDll(new Guid(wsArr.Step1Result).ToString());
            });
        }

        public unsafe void Implementation17(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStructSpanByte();
                Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                Span<int> numbers = stackalloc int[1];
                numbers.Fill(0);
                wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
            });
        }

        public unsafe void Implementation18(int n)
        {
            For(0, n, _ =>
            {
                WorkStructByteArray wsArr;
                byte[] buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                Span<int> numbers = stackalloc int[1];
                numbers.Fill(0);
                wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
            });
        }

        public unsafe void Implementation19(int n)
        {
            For(0, n, _ =>
            {
                WorkStructSpanByte wsArr;
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = SortByteArray(Guid.NewGuid().ToByteArray());
                Span<int> numbers = stackalloc int[1];
                numbers.Fill(0);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers, 35);
            });
        }

        public void Implementation20(int n)
        {
            var rangeSize = 2500;
            if (n == 1) rangeSize = 1;
            if (n == 10) rangeSize = 2;
            if (n == 100) rangeSize = 25;
            if (n == 1000) rangeSize = 250;
            var rangePartitioner = Partitioner.Create(0, n, rangeSize);
            ForEach(rangePartitioner, _ =>
            {
                For(0, rangeSize, _ =>
                {
                    WorkStructSpanByte wsArr;
                    // Step 1 - Order the Id, and set on Step1Result property
                    wsArr.Step1Result = SortByteArray(Guid.NewGuid().ToByteArray());
                    Span<int> numbers = stackalloc int[1];
                    numbers.Fill(0);
                    // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                    wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
                });
            });
        }

        public void Implementation21(int n)
        {
            For(0, n, _ =>
            {
                WorkStructSpanByte wsArr;
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = SortGuidBytes(Guid.NewGuid());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
            });
        }

        public void Implementation22(int n)
        {
            var rangeSize = 2500;
            if (n == 1) rangeSize = 1;
            if (n == 10) rangeSize = 2;
            if (n == 100) rangeSize = 25;
            if (n == 1000) rangeSize = 250;
            var rangePartitioner = Partitioner.Create(0, n, rangeSize);
            ForEach(rangePartitioner, _ =>
            {
                For(0, rangeSize, _ =>
                {
                    WorkStructSpanByte wsArr;
                    // Step 1 - Order the Id, and set on Step1Result property
                    wsArr.Step1Result = SortGuidBytes(Guid.NewGuid());
                    // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                    wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
                });
            });
        }

        public void Implementation23(int n)
        {
            int outer = 5000;
            var inner = 2;

            switch (n)
            {
                case 1:
                    outer = n;
                    inner = n;
                    break;
                case 10:
                    outer = n / 2;
                    inner = n / 5;
                    break;
                case 100:
                    outer = n / 2;
                    inner = n / 5;
                    break;
                case 1000:
                    outer = n / 2;
                    inner = n / 5;
                    break;
            }

            For(0, outer, _ =>
            {
                for (int j = 0; j < inner; j++)
                {
                    new WorkStructSpanByteConstr(0);
                }
            });
        }

        public void Implementation24(int n)
        {
            For(0, n, _ => { new WorkStructSpanByteConstr(0); });
        }

        public void Implementation25(int n)
        {
            For(0, n, _ =>
            {
                var wsArr = new WorkStructSpanByteConstr2(0);
                wsArr.Step1Result = SortGuidBytes(wsArr.Id);
                wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
            });
        }

        public void Implementation26(WorkStruct[] list)
        {
            ForEach(list, item =>
            {
                var tmp = new Guid(item.Id);
                item.Step1Result = new Guid(SortGuidBytes(tmp)).ToString();
                item.Step2Result = SumOfDigitsGuidBytes(tmp.ToByteArray());
            });
        }

        public void Implementation27(WorkStructByteArrayConstr[] list)
        {
            ForEach(list, item =>
            {
                item.Step1Result = SortGuidBytesOutBytes(item.Id);
                item.Step2Result = SumOfDigitsGuidBytes(new Guid(item.Step1Result).ToByteArray());
            });
        }

        public void Implementation28(WorkStructByteArrayConstr[] list)
        {
            switch (list.Length)
            {
                case 1:
                    list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
                    list[0].Step2Result = SumOfDigitsGuid(list[0].Id);
                    return;
                case 10:
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        list[i].Step1Result = SortGuidBytesOutBytes(list[i].Id);
                        list[i].Step2Result = SumOfDigitsGuid(list[i].Id);
                    }

                    return;
                }
                default:
                    ForEach(list, item =>
                    {
                        item.Step1Result = SortGuidBytesOutBytes(item.Id);
                        item.Step2Result = SumOfDigitsGuid(item.Id);
                    });
                    break;
            }
        }

        public void Implementation29(WorkStructByteArrayConstr[] list)
        {
            switch (list.Length)
            {
                case 1:
                    list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
                    list[0].Step2Result = SumOfDigitsGuid2(list[0].Id);
                    return;
                case 10:
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        list[i].Step1Result = SortGuidBytesOutBytes(list[i].Id);
                        list[i].Step2Result = SumOfDigitsGuid2(list[i].Id);
                    }

                    return;
                }
                default:
                    ForEach(list, item =>
                    {
                        item.Step1Result = SortGuidBytesOutBytes(item.Id);
                        item.Step2Result = SumOfDigitsGuid2(item.Id);
                    });
                    break;
            }
            
        }
        // They would not work since 30 and 31 where made with SingleRuns in mind
        public void Implementation30(WorkStructByteArrayConstr item)
        {
            
        }
        public void Implementation31(Work item)
        {
           
        }


    }
}