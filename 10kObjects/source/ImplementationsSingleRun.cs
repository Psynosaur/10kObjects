using System;
using System.Linq;
using static System.String;
using static TenKObjects.HelperFunctions;
using static TenKObjects.ClassesAndStructs;

namespace TenKObjects
{
    public class ImplementationsSingleRun
    {
        // leaving the 'int n' input parameter so that we can easily switch our benchmark implementations
        public void Implementation1(int n)
        {
            Work work = new Work();
            // Step 1 - Order the Id, and set on Step1Result property
            work.Step1Result = SortString(work.Id.ToString());
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            work.Step2Result = sumOfDigitsDll(work.Step1Result).ToString();
        }

        // submitted one --
        public void Implementation2(int n)
        {
            Work work = new Work();
            // Step 1 - Order the Id, and set on Step1Result property
            work.Step1Result = Concat(work.Id.ToString().OrderBy(c => c));
            // extract digits for use in Step 2, I opted not to use Regex, since in this scenario its slower than LINQ
            // var digits = Regex.Match(work.Step1Result, @"\d+").Value;
            string digits = new string(work.Step1Result.Where(char.IsDigit).ToArray());
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            work.Step2Result = digits.Sum(c => c - '0').ToString();
        }

        public void Implementation3(int n)
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
        }

        public void Implementation4(int n)
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
        }

        public void Implementation5(int n)
        {
            Work work = new Work();
            char[] idchars = work.Id.ToString().ToCharArray();
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
            WorkStructStatic.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            WorkStructStatic.Step2Result = sumOfDigitsDll(WorkStructStatic.Step1Result);
        }

        // Winner so far
        public void Implementation7(int n)
        {
            WorkStruct wsArr = new WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = sumOfDigitsDll(wsArr.Step1Result);
        }

        public void Implementation8(int n)
        {
            WorkStructCharArray wsArr = new WorkStructCharArray();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = idchars;
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = sumOfDigitsCharDll(wsArr.Step1Result);
        }

        public void Implementation9(int n)
        {
            WorkStruct wsArr = new WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForEach(wsArr.Step1Result.ToCharArray());
        }

        public void Implementation10(int n)
        {
            WorkStruct wsArr = new WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForEach(wsArr.Step1Result);
        }

        public void Implementation11(int n)
        {
            WorkStruct wsArr = new WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsFor(wsArr.Step1Result);
        }

        public void Implementation12(int n)
        {
            WorkStruct wsArr = new WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsSwitch(wsArr.Step1Result);
        }

        public void Implementation13(int n)
        {
            WorkStruct wsArr = new WorkStruct();
            char[] idchars = Guid.NewGuid().ToString().ToCharArray();
            Array.Sort(idchars);
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = new string(idchars);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitch(wsArr.Step1Result);
        }

        public unsafe void Implementation14(int n)
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
        }

        public void Implementation15(int n)
        {
            WorkStructSpanByte wsArr = new WorkStructSpanByte();
            Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
            // Step 1 - Order the Id(guid) byte representation, and set (Span<byte>) Step1Result property
            wsArr.Step1Result = buffer;
            // Step 2 - Sum all numbers in the Id, and set (int) Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitch(new Guid(wsArr.Step1Result).ToString());
        }

        public void Implementation16(int n)
        {
            WorkStructSpanByte wsArr = new WorkStructSpanByte();
            Span<byte> buffer = SortByteArray(Guid.NewGuid().ToByteArray());
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = buffer;
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = sumOfDigitsDll(new Guid(wsArr.Step1Result).ToString());
        }

        public unsafe void Implementation17(int n)
        {
            WorkStructSpanByte wsArr = new WorkStructSpanByte();
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
            WorkStructByteArray wsArr;
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
            WorkStructSpanByte wsArr;
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = SortByteArray(Guid.NewGuid().ToByteArray());
            Span<int> numbers = stackalloc int[1];
            numbers.Fill(0);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers, 35);
        }

        public void Implementation20(int n)
        {
            WorkStructSpanByte wsArr;
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = SortByteArray(Guid.NewGuid().ToByteArray());
            Span<int> numbers = stackalloc int[1];
            numbers.Fill(0);
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsForSwitchSpan(new Guid(wsArr.Step1Result).ToString(), numbers);
        }

        public void Implementation21(int n)
        {
            WorkStructSpanByte wsArr;
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = SortGuidBytes(Guid.NewGuid());
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
        }

        public void Implementation22(int n)
        {
            WorkStructSpanByte wsArr;
            // Step 1 - Order the Id, and set on Step1Result property
            wsArr.Step1Result = SortGuidBytes(Guid.NewGuid());
            // Step 2 - Sum all numbers in the Id, and set on Step2Result property
            wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
        }

        public void Implementation23(int n)
        {
            new WorkStructSpanByteConstr(0);
        }

        public void Implementation24(int n)
        {
            new WorkStructSpanByteConstr(0);
        }

        public void Implementation25(int n)
        {
            WorkStructSpanByteConstr2 wsArr = new WorkStructSpanByteConstr2(0);
            wsArr.Step1Result = SortGuidBytes(wsArr.Id);
            wsArr.Step2Result = SumOfDigitsGuidBytes(wsArr.Step1Result);
        }

        public void Implementation26(WorkStruct[] list)
        {
            Guid tmp = new Guid(list[0].Id);
            list[0].Step1Result = new Guid(SortGuidBytes(tmp)).ToString();
            list[0].Step2Result = SumOfDigitsGuidBytes(tmp.ToByteArray());
        }

        public void Implementation27(WorkStructByteArrayConstr[] list)
        {
            list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
            list[0].Step2Result = SumOfDigitsGuidBytes(new Guid(list[0].Step1Result).ToByteArray());
        }

        public void Implementation28(WorkStructByteArrayConstr[] list)
        {
            list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
            list[0].Step2Result = SumOfDigitsGuid(list[0].Id);
        }

        public void Implementation29(WorkStructByteArrayConstr[] list)
        {
            list[0].Step1Result = SortGuidBytesOutBytes(list[0].Id);
            list[0].Step2Result = SumOfDigitsGuid2(list[0].Id);
        }

        public void Implementation30(WorkStructByteArrayConstr item)
        {
            item.Step1Result = SortGuidBytesOutBytes(item.Id);
            item.Step2Result = SumOfDigitsGuid(item.Id);
        }
        public void Implementation31(Work item)
        {
            item.Step1Result = new Guid(SortGuidBytesOutBytes(item.Id)).ToString();
            item.Step2Result = SumOfDigitsGuid(item.Id).ToString();
        }


        
    }
}