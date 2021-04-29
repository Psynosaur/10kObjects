using System;
using System.Linq;
using static System.String;

namespace TenKObjects
{
    public class ImplementationsSingleRun
    {
        public void Implementation1(int n)
        {
            var work = new Obj.Work();
            // Step 1 - Order the Id, and set on Step1Result property
            work.Step1Result = Implementations.Sortstring(work.Id.ToString());
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            work.Step2Result = Implementations.sumOfDigitsDll(work.Step1Result).ToString();
        }

        // submitted one --
        public void Implementation2(int n)
        {
            var work = new Obj.Work();
            // Step 1 - Order the Id, and set on Step1Result property
            work.Step1Result = Concat(work.Id.ToString().OrderBy(c => c));
            // extract digits for use in Step 2, I opted not to use Regex, since in this scenario its slower than LINQ
            // var digits = Regex.Match(work.Step1Result, @"\d+").Value;
            var digits = new string(work.Step1Result.Where(char.IsDigit).ToArray());
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            work.Step2Result = digits.Sum(c => c - '0').ToString();
        }

        public void Implementation3(int n)
        {
            var work = new Obj.Work();
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
        }

        public void Implementation4(int n)
        {
            var work = new Obj.Work();
            var idchars = work.Id.ToString().ToCharArray();
            Array.Sort(idchars);
            // "Convert" it to writable Span<char>
            var span = new Span<char>(idchars);
            idchars.CopyTo(span.Slice(0, idchars.Length));
            // Step 1 - Order the Id, and set on Step1Result property
            work.Step1Result = span.ToString();
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            work.Step2Result = Implementations.sumOfDigitsDll(span.ToString()).ToString();
        }

        public void Implementation5(int n)
        {
            var work = new Obj.Work();
            var idchars = work.Id.ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            work.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
        }

        public void Implementation6(int n)
        {
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            Obj.WorkStructStatic.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            Obj.WorkStructStatic.Step2Result = Implementations.sumOfDigitsDll(Obj.WorkStructStatic.Step1Result);
        }

        // Winner so far
        public void Implementation7(int n)
        {
            var wsArr = new Obj.WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = Implementations.sumOfDigitsDll(wsArr.Step1Result);
        }

        public void Implementation8(int n)
        {
            Obj.WorkStructCharArray wsArr = new Obj.WorkStructCharArray();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = idchars;
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = Implementations.sumOfDigitsCharDll(wsArr.Step1Result);
        }

        public void Implementation9(int n)
        {
            var wsArr = new Obj.WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForEach(wsArr.Step1Result.ToCharArray());
        }

        public void Implementation10(int n)
        {
            var wsArr = new Obj.WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForEach(wsArr.Step1Result);
        }

        public void Implementation11(int n)
        {
            var wsArr = new Obj.WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsFor(wsArr.Step1Result);
        }

        public void Implementation12(int n)
        {
            var wsArr = new Obj.WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsSwitch(wsArr.Step1Result);
        }

        public void Implementation13(int n)
        {
            var wsArr = new Obj.WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitch(wsArr.Step1Result);
        }

        public unsafe void Implementation14(int n)
        {
            var wsArr = new Obj.WorkStructSpanChar();
            var buffer = SortCharArray(Guid.NewGuid().ToString().ToCharArray());
            var data = stackalloc char[36];
            var destination = new Span<char>(data, 36);
            buffer.CopyTo(destination);
            Span<char> str = destination.Slice(0, buffer.Length);

            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = str;
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitch(wsArr.Step1Result);
        }

        public void Implementation15(int n)
        {
            var wsArr = new Obj.WorkStructSpanByte();
            Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
            // Step 1 - Order the Id(guid) byte representation, and set (Span<byte>) Step1Result property
            wsArr.Step1Result = buffer;
            // Step 2 - Sum all numbers in the Id, and set (int) Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitch(new Guid(wsArr.Step1Result).ToString());
        }

        public void Implementation16(int n)
        {
            var wsArr = new Obj.WorkStructSpanByte();
            Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = buffer;
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = Implementations.sumOfDigitsDll(new Guid(wsArr.Step1Result).ToString());
        }

        public unsafe void Implementation17(int n)
        {
            var wsArr = new Obj.WorkStructSpanByte();
            Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = buffer;
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            Span<int> numbers = stackalloc int[1];
            numbers.Fill(0);
            wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
        }

        public unsafe void Implementation18(int n)
        {
            Obj.WorkStructByteArray wsArr;
            byte[] buffer = SortByteArray(Guid.NewGuid().ToByteArray());
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = buffer;
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            Span<int> numbers = stackalloc int[1];
            numbers.Fill(0);
            wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
        }

        public unsafe void Implementation19(int n)
        {
            Obj.WorkStructSpanByte wsArr;
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = SortByteArray(Guid.NewGuid().ToByteArray());
            Span<int> numbers = stackalloc int[1];
            numbers.Fill(0);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers, 35);
        }

        public void Implementation20(int n)
        {
            Obj.WorkStructSpanByte wsArr;
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = SortByteArray(Guid.NewGuid().ToByteArray());
            Span<int> numbers = stackalloc int[1];
            numbers.Fill(0);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
        }

        public void Implementation21(int n)
        {
            Obj.WorkStructSpanByte wsArr;
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = SortGuidBytes(Guid.NewGuid());
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
        }

        public void Implementation22(int n)
        {
            Obj.WorkStructSpanByte wsArr;
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = SortGuidBytes(Guid.NewGuid());
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
        }

        public void Implementation23(int n)
        {
            new Obj.WorkStructSpanByteConstr(0);
        }

        public void Implementation24(int n)
        {
            new Obj.WorkStructSpanByteConstr(0);
        }

        public void Implementation25(int n)
        {
            var wsArr = new Obj.WorkStructSpanByteConstr2(0);
            wsArr.Step1Result = SortGuidBytes(wsArr.Id);
            wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
        }

        public void Implementation26(Obj.WorkStruct[] list)
        {
            var tmp = new Guid(list[0].Id);
            list[0].Step1Result = new Guid(SortGuidBytes(tmp)).ToString();
            list[0].Step2Result = SumOfDigitsGuidBytes(tmp.ToByteArray());
        }

        public void Implementation27(Obj.WorkStructByteArrayConstr[] list)
        {
            list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
            list[0].Step2Result = SumOfDigitsGuidBytes(new Guid(list[0].Step1Result).ToByteArray());
        }

        public void Implementation28(Obj.WorkStructByteArrayConstr[] list)
        {
            list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
            list[0].Step2Result = SumOfDigitsGuid(list[0].Id);
        }

        public void Implementation29(Obj.WorkStructByteArrayConstr[] list)
        {
            list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
            list[0].Step2Result = SumOfDigitsGuid2(list[0].Id);
        }

        public void Implementation30(Obj.WorkStructByteArrayConstr item)
        {
            item.Step1Result = SortGuidBytesOutBytes(item.Id);
            item.Step2Result = SumOfDigitsGuid(item.Id);
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

        private static int SumOfDigitsGuid2(in Guid bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            var str = bytes.ToString();
            foreach (var c in str)
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