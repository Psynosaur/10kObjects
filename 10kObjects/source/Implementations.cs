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

namespace TenKObjects
{
    // Do not change this class... okay, make something else like it then...? 
    public class Work
    {
        public Work()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public string Step1Result { get; set; }

        public string Step2Result { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WorkStructCharArray
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public char[] Step1Result;

        [MarshalAs(UnmanagedType.U4, SizeConst = 3)]
        public int Step2Result;
    }

    // works as array
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WorkStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Step1Result;

        [MarshalAs(UnmanagedType.U4, SizeConst = 3)]
        public int Step2Result;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public ref struct WorkStructSpanChar
    {
        public Span<char> Step1Result;
        public int Step2Result;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public ref struct WorkStructSpanByte
    {
        // Guid 16 byte 128 bit unsigned integer representation
        public Span<byte> Step1Result;

        // Sum of string representation of above Guid bytes
        public int Step2Result;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public ref struct WorkStructSpanByteConstr
    {
        internal WorkStructSpanByteConstr(int mandatory) : this()
        {
            Id = Guid.NewGuid();
            Step1Result = SortGuidBytes(Id);
            Step2Result = SumOfDigitsGuidBytes(Step1Result);
        }

        internal Span<byte> SortGuidBytes(Guid id)
        {
            var b = id.ToByteArray();
            Array.Sort(b);
            return b;
        }

        internal static int SumOfDigitsGuidBytes(in Span<byte> bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            foreach (var c in new Guid(bytes).ToString())
            {
                switch (c >= 49)
                {
                    case true when c <= 57:
                        sum += c - 48;
                        break;
                }
            }

            return sum;
        }

        internal Guid Id;

        // Guid 16 byte 128 bit unsigned integer representation
        internal Span<byte> Step1Result;

        // Sum of string representation of above Guid bytes
        internal int Step2Result;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public ref struct WorkStructSpanByteConstr2
    {
        internal WorkStructSpanByteConstr2(int mandatory) : this()
        {
            Id = Guid.NewGuid();
            Step1Result = null;
            Step2Result = mandatory;
        }

        internal Guid Id;

        // Guid 16 byte 128 bit unsigned integer representation
        internal Span<byte> Step1Result;

        // Sum of string representation of above Guid bytes
        internal int Step2Result;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WorkStructByteArrayConstr
    {
        internal WorkStructByteArrayConstr(int mandatory)
        {
            Id = Guid.NewGuid();
            Step1Result = null;
            Step2Result = mandatory;
        }

        internal Guid Id;

        // Guid 16 byte 128 bit unsigned integer representation
        internal byte[] Step1Result;

        // Sum of string representation of above Guid bytes
        internal int Step2Result;
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public ref struct WorkStructByteArray
    {
        // Guid 16 byte 128 bit unsigned integer representation
        public byte[] Step1Result;

        // Sum of string representation of above Guid bytes
        public int Step2Result;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WorkStructStatic
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        internal static string Step1Result;

        [MarshalAs(UnmanagedType.U4, SizeConst = 3)]
        internal static int Step2Result;
    }

    public class Implementations
    {
        private const int ObjectTotal = 10000;

        static string path = Directory.GetCurrentDirectory();

        // private static readonly List<Work> WorkList = new List<Work>(ObjectTotal);

        // This list will help us not call Console.WriteLine very many times . . .
        // private static readonly List<string> Output = new List<string>(ObjectTotal);
        [DllImport(@"C:\git\10kObjects\10kObjects\bin\sortandsum.dll",
            CallingConvention = CallingConvention.StdCall)]
        private static extern uint stringSortOut(StringBuilder lpBuffer, uint uiSize, string szReturnString);

        [DllImport(@"C:\git\10kObjects\10kObjects\bin\sortandsum.dll",
            CallingConvention = CallingConvention.StdCall, EntryPoint = "sumOfDigits")]
        public static extern int sumOfDigitsDll(string str);

        [DllImport(@"C:\git\10kObjects\10kObjects\bin\sortandsum.dll",
            CallingConvention = CallingConvention.StdCall, EntryPoint = "sumOfDigits")]
        public static extern int sumOfDigitsCharDll(char[] str);

        private static string Sortstring(ReadOnlySpan<char> guid)
        {
            var sbBuffer = new StringBuilder(1);
            var uiRequiredSize = stringSortOut(sbBuffer, (uint) sbBuffer.Capacity, guid.ToString());

            if (uiRequiredSize > sbBuffer.Capacity)
            {
                // sbBuffer needs to be of a greater size than current capacity.
                // This required size is the returned value in "uiRequiredSize"
                // (including the terminating NULL character).
                sbBuffer.Capacity = (int) uiRequiredSize;
                // Call the API again.
                stringSortOut(sbBuffer, (uint) sbBuffer.Capacity, guid.ToString());
            }

            return sbBuffer.ToString();
        }

        public void Implementation1(int n)
        {
            For(0, n, _ =>
            {
                var work = new Work();
                // Step 1 - Order the Id, and set on Step1Result property
                work.Step1Result = Sortstring(work.Id.ToString());
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
        }


        public static Span<byte> SortGuidBytes(Guid bytes)
        {
            var b = bytes.ToByteArray();
            Array.Sort(b);
            return b;
        }

        public static byte[] SortGuidBytesOutBytes(Guid bytes)
        {
            var b = bytes.ToByteArray();
            Array.Sort(b);
            return b;
        }

        private static byte[] SortByteArray(byte[] buffer)
        {
            Array.Sort(buffer);
            return buffer;
        }

        private static char[] SortCharArray(char[] buffer)
        {
            Array.Sort(buffer);
            return buffer;
        }

        private static Span<char> SortSpanChar(Span<char> buffer, char temp = '0')
        {
            int i, j;
            int n = buffer.Length;

            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (buffer[i] > buffer[j])
                    {
                        temp = buffer[i];
                        buffer[i] = buffer[j];
                        buffer[j] = temp;
                    }
                }
            }

            return buffer;
        }

        private static int SumOfDigitsForEach(ReadOnlySpan<char> str, int sum = 0)
        {
            foreach (char c in str)
            {
                if (c >= 49 && c <= 57)
                {
                    sum += c - '0';
                }
            }

            return sum;
        }

        private static int SumOfDigitsSwitch(ReadOnlySpan<char> str, int sum = 0)
        {
            foreach (char c in str)
            {
                switch (c >= 49)
                {
                    case true when c <= 57:
                        sum += c - '0';
                        break;
                }
            }

            return sum;
        }

        private static int SumOfDigitsFor(ReadOnlySpan<char> str, int sum = 0)
        {
            for (var index = str.Length - 1; index >= 0; index--)
            {
                char c = str[index];
                if (c >= 49 && c <= 57)
                {
                    sum += c - '0';
                }
            }

            return sum;
        }

        private static int SumOfDigitsForSwitch(in ReadOnlySpan<char> str, int sum = 0)
        {
            for (var index = str.Length - 1; index >= 0; index--)
            {
                char c = str[index];
                switch (c >= 49)
                {
                    case true when c <= 57:
                        sum += c - '0';
                        break;
                }
            }

            return sum;
        }


        private static int SumOfDigitsForSwitchSpan(in ReadOnlySpan<char> str, Span<int> sum)
        {
            return SumOfDigitsForSwitchSpan(str, sum, str.Length - 1);
        }

        private static int SumOfDigitsForSwitchSpan(in ReadOnlySpan<char> str, Span<int> sum, int num)
        {
            while (num >= 0)
            {
                var c = str[num];
                if (c >= '1' && c <= '9')
                {
                    sum[0] += c - 48;
                }

                num--;
            }

            return sum[0];
        }

        private static int SumOfDigitsGuidBytes(in Span<byte> bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            foreach (var c in new Guid(bytes).ToString())
            {
                switch (c >= 49)
                {
                    case true when c <= 57:
                        sum += c - 48;
                        break;
                }
            }

            return sum;
        }

        private static int SumOfDigitsGuid(in Guid bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            foreach (var c in bytes.ToString())
            {
                switch (c >= 49)
                {
                    case true when c <= 57:
                        sum += c - 48;
                        break;
                }
            }

            return sum;
        }
        private static int SumOfDigitsGuid2(in Guid bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            int cnt = bytes.ToString().Length;
            string str = bytes.ToString();
            for (var i = 0; i < cnt; i++)
            {
                var c = str[i];
                switch (c >= 49)
                {
                    case true when c <= 57:
                        sum += c - 48;
                        break;
                }
            }

            return sum;
        }

        private static int SumOfDigitsForEachSwitchSpan(in ReadOnlySpan<char> str, Span<int> sum)
        {
            foreach (char c in str)
            {
                switch (c >= 49)
                {
                    case true when c <= 57:
                        sum[0] += c - '0';
                        break;
                }
            }

            return sum[0];
        }


        private static int SumOfDigitsForSwitch(ReadOnlySpan<byte> str, int sum = 0)
        {
            for (var index = str.Length - 1; index >= 0; index--)
            {
                byte c = str[index];
                switch (c >= 49)
                {
                    case true when c <= 57:
                        sum += c - '0';
                        break;
                }
            }

            return sum;
        }
    }
}