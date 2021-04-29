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
            if (n == 1)
            {
                Work work = new Work();
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = SortString(work.Id.ToString());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(work.Step1Result).ToString();
                return;
            }

            For(0, n, _ =>
            {
                Work work = new Work();
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = SortString(work.Id.ToString());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(work.Step1Result).ToString();
            });
        }

        // submitted one --
        public void Implementation2(int n)
        {
            if (n == 1)
            {
                Work work = new Work();
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = Concat(work.Id.ToString().OrderBy(c => c));
                // extract digits for use in Step 2, I opted not to use Regex, since in this scenario its slower than LINQ
                // var digits = Regex.Match(work.Step1Result, @"\d+").Value;
                string digits = new string(work.Step1Result.Where(char.IsDigit).ToArray());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = digits.Sum(c => c - '0').ToString();
                return;
            }

            For(0, n, _ =>
            {
                Work work = new Work();
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = Concat(work.Id.ToString().OrderBy(c => c));
                // extract digits for use in Step 2, I opted not to use Regex, since in this scenario its slower than LINQ
                // var digits = Regex.Match(work.Step1Result, @"\d+").Value;
                string digits = new string(work.Step1Result.Where(char.IsDigit).ToArray());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = digits.Sum(c => c - '0').ToString();
            });
        }

        public void Implementation3(int n)
        {
            if (n == 1)
            {
                Work work = new Work();
                char[] idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // "Convert" it to writable Span<char>
                Span<char> span = new Span<char>(idchars);
                idchars.CopyTo(span.Slice(0, idchars.Length));
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = span.ToString();
                // extract digits for use in Step 2
                string digits = new string(work.Step1Result.Where(char.IsDigit).ToArray());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = digits.Sum(c => c - '0').ToString();
                return;
            }

            For(0, n, _ =>
            {
                Work work = new Work();
                char[] idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // "Convert" it to writable Span<char>
                Span<char> span = new Span<char>(idchars);
                idchars.CopyTo(span.Slice(0, idchars.Length));
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = span.ToString();
                // extract digits for use in Step 2
                string digits = new string(work.Step1Result.Where(char.IsDigit).ToArray());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = digits.Sum(c => c - '0').ToString();
            });
        }

        public void Implementation4(int n)
        {
            if (n == 1)
            {
                Work work = new Work();
                char[] idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // "Convert" it to writable Span<char>
                Span<char> span = new Span<char>(idchars);
                idchars.CopyTo(span.Slice(0, idchars.Length));
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = span.ToString();
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(span.ToString()).ToString();
                return;
            }

            For(0, n, _ =>
            {
                Work work = new Work();
                char[] idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // "Convert" it to writable Span<char>
                Span<char> span = new Span<char>(idchars);
                idchars.CopyTo(span.Slice(0, idchars.Length));
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = span.ToString();
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(span.ToString()).ToString();
            });
        }

        public void Implementation5(int n)
        {
            if (n == 1)
            {
                Work work = new Work();
                char[] idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(idchars.ToString()).ToString();
                return;
            }

            For(0, n, _ =>
            {
                Work work = new Work();
                char[] idchars = work.Id.ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                work.Step2Result = sumOfDigitsDll(idchars.ToString()).ToString();
            });
        }

        public void Implementation6(int n)
        {
            if (n == 1)
            {
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                WorkStructStatic.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                WorkStructStatic.Step2Result = sumOfDigitsDll(WorkStructStatic.Step1Result);
                return;
            }

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
            if (n == 1)
            {
                WorkStruct wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = sumOfDigitsDll(wsArr.Step1Result);
                return;
            }

            For(0, n, _ =>
            {
                WorkStruct wsArr = new WorkStruct();
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
            if (n == 1)
            {
                WorkStructCharArray wsArr = new WorkStructCharArray();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = idchars;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = sumOfDigitsCharDll(wsArr.Step1Result);
                return;
            }

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
            if (n == 1)
            {
                WorkStruct wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForEach(wsArr.Step1Result.ToCharArray());
                return;
            }

            For(0, n, _ =>
            {
                WorkStruct wsArr = new WorkStruct();
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
            if (n == 1)
            {
                WorkStruct wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForEach(wsArr.Step1Result);
                return;
            }

            For(0, n, _ =>
            {
                WorkStruct wsArr = new WorkStruct();
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
            if (n == 1)
            {
                WorkStruct wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsFor(wsArr.Step1Result);
                return;
            }

            For(0, n, _ =>
            {
                WorkStruct wsArr = new WorkStruct();
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
            if (n == 1)
            {
                WorkStruct wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsSwitch(wsArr.Step1Result);
                return;
            }

            For(0, n, _ =>
            {
                WorkStruct wsArr = new WorkStruct();
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
            if (n == 1)
            {
                WorkStruct wsArr = new WorkStruct();
                char[] idchars = Guid.NewGuid().ToString().ToCharArray();
                Array.Sort(idchars);
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = new string(idchars);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitch(wsArr.Step1Result);
                return;
            }

            For(0, n, _ =>
            {
                WorkStruct wsArr = new WorkStruct();
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
            if (n == 1)
            {
                WorkStructSpanChar wsArr = new WorkStructSpanChar();
                char[] buffer = SortCharArray(Guid.NewGuid().ToString().ToCharArray());
                char* data = stackalloc char[36];
                Span<char> destination = new Span<char>(data, 36);
                buffer.CopyTo(destination);
                Span<char> str = destination.Slice(0, buffer.Length);

                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = str;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitch(wsArr.Step1Result);
                return;
            }

            For(0, n, _ =>
            {
                WorkStructSpanChar wsArr = new WorkStructSpanChar();
                char[] buffer = SortCharArray(Guid.NewGuid().ToString().ToCharArray());
                char* data = stackalloc char[36];
                Span<char> destination = new Span<char>(data, 36);
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
            if (n == 1)
            {
                WorkStructSpanByte wsArr = new WorkStructSpanByte();
                Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id(guid) byte representation, and set (Span<byte>) Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set (int) Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitch(new Guid(wsArr.Step1Result).ToString());
                return;
            }

            For(0, n, _ =>
            {
                WorkStructSpanByte wsArr = new WorkStructSpanByte();
                Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id(guid) byte representation, and set (Span<byte>) Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set (int) Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitch(new Guid(wsArr.Step1Result).ToString());
            });
        }

        public void Implementation16(int n)
        {
            if (n == 1)
            {
                WorkStructSpanByte wsArr = new WorkStructSpanByte();
                Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = sumOfDigitsDll(new Guid(wsArr.Step1Result).ToString());
                return;
            }

            For(0, n, _ =>
            {
                WorkStructSpanByte wsArr = new WorkStructSpanByte();
                Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = sumOfDigitsDll(new Guid(wsArr.Step1Result).ToString());
            });
        }

        public unsafe void Implementation17(int n)
        {
            if (n == 1)
            {
                WorkStructSpanByte wsArr = new WorkStructSpanByte();
                Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                Span<int> numbers = stackalloc int[1];
                numbers.Fill(0);
                wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
                return;
            }

            For(0, n, _ =>
            {
                WorkStructSpanByte wsArr = new WorkStructSpanByte();
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
            if (n == 1)
            {
                WorkStructByteArray wsArr;
                byte[] buffer = SortByteArray(Guid.NewGuid().ToByteArray());
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = buffer;
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                Span<int> numbers = stackalloc int[1];
                numbers.Fill(0);
                wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
                return;
            }

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
            if (n == 1)
            {
                WorkStructSpanByte wsArr;
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = SortByteArray(Guid.NewGuid().ToByteArray());
                Span<int> numbers = stackalloc int[1];
                numbers.Fill(0);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers, 35);
                return;
            }

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
            if (n == 1)
            {
                WorkStructSpanByte wsArr;
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = SortByteArray(Guid.NewGuid().ToByteArray());
                Span<int> numbers = stackalloc int[1];
                numbers.Fill(0);
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
                return;
            }

            int rangeSize = 2500;
            if (n == 10) rangeSize = 2;
            if (n == 100) rangeSize = 25;
            if (n == 1000) rangeSize = 250;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = Partitioner.Create(0, n, rangeSize);
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
            if (n == 1)
            {
                WorkStructSpanByte wsArr;
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = SortGuidBytes(Guid.NewGuid());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
                return;
            }

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
            if (n == 1)
            {
                WorkStructSpanByte wsArr;
                // Step 1 - Order the Id, and set on Step1Result property
                wsArr.Step1Result = SortGuidBytes(Guid.NewGuid());
                // Step 2 - Sum all numbers in the Id, and set on Step2Result property
                wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
                return;
            }

            int rangeSize = 2500;
            if (n == 10) rangeSize = 2;
            if (n == 100) rangeSize = 25;
            if (n == 1000) rangeSize = 250;
            OrderablePartitioner<Tuple<int, int>> rangePartitioner = Partitioner.Create(0, n, rangeSize);
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
            if (n == 1)
            {
                new WorkStructSpanByteConstr(0);
                return;
            }

            int outer = 5000;
            int inner = 2;

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
            if (n == 1)
            {
                new WorkStructSpanByteConstr(0);
                return;
            }

            For(0, n, _ => { new WorkStructSpanByteConstr(0); });
        }

        public void Implementation25(int n)
        {
            if (n == 1)
            {
                WorkStructSpanByteConstr2 wsArr = new WorkStructSpanByteConstr2(0);
                wsArr.Step1Result = SortGuidBytes(wsArr.Id);
                wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
                return;
            }

            For(0, n, _ =>
            {
                WorkStructSpanByteConstr2 wsArr = new WorkStructSpanByteConstr2(0);
                wsArr.Step1Result = SortGuidBytes(wsArr.Id);
                wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
            });
        }

        public void Implementation26(WorkStruct[] list)
        {
            if (list.Length == 1)
            {
                Guid tmp = new Guid(list[0].Id);
                list[0].Step1Result = new Guid(SortGuidBytes(tmp)).ToString();
                list[0].Step2Result = SumOfDigitsGuidBytes(tmp.ToByteArray());
                return;
            }

            ForEach(list, item =>
            {
                Guid tmp = new Guid(item.Id);
                item.Step1Result = new Guid(SortGuidBytes(tmp)).ToString();
                item.Step2Result = SumOfDigitsGuidBytes(tmp.ToByteArray());
            });
        }

        public void Implementation27(WorkStructByteArrayConstr[] list)
        {
            if (list.Length == 1)
            {
                list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
                list[0].Step2Result = SumOfDigitsGuidBytes(new Guid(list[0].Step1Result).ToByteArray());
                return;
            }

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

        public void Implementation30(WorkStructByteArrayConstr[] list)
        {
            if (list.Length == 1)
            {
                list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
                list[0].Step2Result = SumOfDigitsGuid(list[0].Id);
                return;
            }

            ForEach(list, item =>
            {
                item.Step1Result = SortGuidBytesOutBytes(item.Id);
                item.Step2Result = SumOfDigitsGuid(item.Id);
            });
        }

        public void Implementation31(Work[] list)
        {
            if (list.Length == 1)
            {
                list[0].Step1Result = new Guid(SortGuidBytesOutBytes(list[0].Id)).ToString();
                list[0].Step2Result = SumOfDigitsGuid(list[0].Id).ToString();
                return;
            }

            ForEach(list, item =>
            {
                item.Step1Result = new Guid(SortGuidBytesOutBytes(item.Id)).ToString();
                item.Step2Result = SumOfDigitsGuid(item.Id).ToString();
            });
        }

        public void Implementation32(WorkStructByteArrayConstr[] list)
        {
            if (list.Length == 1)
            {
                byte[] b = list[0].Id.ToByteArray();
                list[0].Step1Result = SortByteArray(b);
                byte[] c = list[0].Step1Result;
                list[0].Step2Result = SumOfDigitsGuidBytes(c);
                return;
            }

            ForEach(list, item =>
            {
                byte[] b = item.Id.ToByteArray();
                item.Step1Result = SortByteArray(b);
                byte[] c = item.Step1Result;
                item.Step2Result = SumOfDigitsGuidBytes(c);
            });
        }

        public unsafe void Implementation33(WorkStructByteArrayConstr[] list)
        {
            if (list.Length == 1)
            {
                byte[] data = list[0].Id.ToByteArray();
                fixed (byte* dataPtr = &data[0])
                {
                    list[0].Step1Result = SortByteArray(data);
                    list[0].Step2Result = SumOfDigitsGuidP3(dataPtr);
                }

                return;
            }

            ForEach(list, item =>
            {
                byte[] data = item.Id.ToByteArray();
                fixed (byte* dataPtr = &data[0])
                {
                    item.Step1Result = SortByteArray(data);
                    item.Step2Result = SumOfDigitsGuidP3(dataPtr);
                }
            });
        }

        public unsafe void Implementation34(WorkStructByteArrayConstr[] list)
        {
            if (list.Length == 1)
            {
                byte[] data = list[0].Id.ToByteArray();
                fixed (byte* dataPtr = &data[0])
                {
                    list[0].Step1Result = SortByteArray(data);
                    list[0].Step2Result = SumOfDigitsGuidP3Decompiled(dataPtr);
                }

                return;
            }

            ForEach(list, item =>
            {
                byte[] data = item.Id.ToByteArray();
                fixed (byte* dataPtr = &data[0])
                {
                    item.Step1Result = SortByteArray(data);
                    item.Step2Result = SumOfDigitsGuidP3Decompiled(dataPtr);
                }
            });
        }

        public unsafe void Implementation35(WorkStructByteArrayConstr[] list)
        {
            if (list.Length == 1)
            {
                byte[] data = list[0].Id.ToByteArray();
                fixed (byte* dataPtr = &data[0])
                {
                    list[0].Step1Result = SortByteArray(data);
                    list[0].Step2Result = SumOfDigitsGuidP4(dataPtr);
                }

                return;
            }

            ForEach(list, item =>
            {
                byte[] data = item.Id.ToByteArray();
                fixed (byte* dataPtr = &data[0])
                {
                    item.Step1Result = SortByteArray(data);
                    item.Step2Result = SumOfDigitsGuidP4(dataPtr);
                }
            });
        }

        public unsafe void Implementation36(WorkStructByteArrayConstr[] list)
        {
            if (list.Length == 1)
            {
                byte[] data = list[0].Id.ToByteArray();
                fixed (byte* dataPtr = &data[0])
                {
                    list[0].Step1Result = SortByteArray(data);
                    list[0].Step2Result = SumOfDigitsGuidP4Decompiled(dataPtr);
                }

                return;
            }

            ForEach(list, item =>
            {
                byte[] data = item.Id.ToByteArray();
                fixed (byte* dataPtr = &data[0])
                {
                    item.Step1Result = SortByteArray(data);
                    item.Step2Result = SumOfDigitsGuidP4Decompiled(dataPtr);
                }
            });
        }
        
        public unsafe void Implementation37(WorkStructByteArrayConstrFinal[] list)
        {
            if (list.Length == 1)
            {
                fixed (byte* dataPtr = &list[0].Id[0])
                {
                    list[0].Step1Result = SortByteArray(list[0].Id);
                    list[0].Step2Result = SumOfDigitsGuidP4Decompiled(dataPtr);
                }

                return;
            }

            ForEach(list, item =>
            {
                fixed (byte* dataPtr = &item.Id[0])
                {
                    item.Step1Result = SortByteArray(item.Id);
                    item.Step2Result = SumOfDigitsGuidP4Decompiled(dataPtr);
                }
            });
        }
        
        public unsafe void Implementation38(WorkStructByteArrayConstrFinal[] list)
        {
            if (list.Length == 1)
            {
                fixed (byte* dataPtr = &list[0].Id[0])
                {
                    list[0].Step1Result = SortByteArray(list[0].Id);
                    list[0].Step2Result = SumOfDigitsGuidP3(dataPtr);
                }

                return;
            }

            ForEach(list, item =>
            {
                fixed (byte* dataPtr = &item.Id[0])
                {
                    item.Step1Result = SortByteArray(item.Id);
                    item.Step2Result = SumOfDigitsGuidP3(dataPtr);
                }
            });
        }
    }
}