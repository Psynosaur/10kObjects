using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TenKObjects
{
    public static class HelperFunctions
    {
        // C made functions, see sortandsum.c
        [DllImport(@"C:\git\10kObjects\10kObjects\bin\sortandsum.dll",
            CallingConvention = CallingConvention.StdCall, EntryPoint = "stringSortOut", CharSet = CharSet.Ansi)]
        private static extern uint stringSortOut(StringBuilder lpBuffer, uint uiSize, string szReturnString);

        [DllImport(@"C:\git\10kObjects\10kObjects\bin\sortandsum.dll",
            CallingConvention = CallingConvention.StdCall, EntryPoint = "sumOfDigits", CharSet = CharSet.Ansi)]
        internal static extern int sumOfDigitsDll(string str);

        [DllImport(@"C:\git\10kObjects\10kObjects\bin\sortandsum.dll",
            CallingConvention = CallingConvention.StdCall, EntryPoint = "sumOfDigits", CharSet = CharSet.Ansi)]
        internal static extern int sumOfDigitsCharDll(char[] str);

        internal static string SortString(ReadOnlySpan<char> guid)
        {
            StringBuilder sbBuffer = new StringBuilder(1);
            uint uiRequiredSize = stringSortOut(sbBuffer, (uint) sbBuffer.Capacity, guid.ToString());

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
        
        internal static Span<byte> SortGuidBytes(Guid bytes)
        {
            byte[] b = bytes.ToByteArray();
            Array.Sort(b);
            return b;
        }

        internal static byte[] SortGuidBytesOutBytes(Guid bytes)
        {
            byte[] b = bytes.ToByteArray();
            Array.Sort(b);
            return b;
        }

        internal static byte[] SortByteArray(byte[] buffer)
        {
            Array.Sort(buffer);
            return buffer;
        }

        internal static char[] SortCharArray(char[] buffer)
        {
            Array.Sort(buffer);
            return buffer;
        }

        internal static Span<char> SortSpanChar(Span<char> buffer, char temp = '0')
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

        internal static int SumOfDigitsForEach(ReadOnlySpan<char> str, int sum = 0)
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

        internal static int SumOfDigitsSwitch(ReadOnlySpan<char> str, int sum = 0)
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

        internal static int SumOfDigitsFor(ReadOnlySpan<char> str, int sum = 0)
        {
            for (int index = str.Length - 1; index >= 0; index--)
            {
                char c = str[index];
                if (c >= 49 && c <= 57)
                {
                    sum += c - '0';
                }
            }

            return sum;
        }

        internal static int SumOfDigitsForSwitch(in ReadOnlySpan<char> str, int sum = 0)
        {
            for (int index = str.Length - 1; index >= 0; index--)
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


        internal static int SumOfDigitsForSwitchSpan(in ReadOnlySpan<char> str, Span<int> sum)
        {
            return SumOfDigitsForSwitchSpan(str, sum, str.Length - 1);
        }

        internal static int SumOfDigitsForSwitchSpan(in ReadOnlySpan<char> str, Span<int> sum, int num)
        {
            while (num >= 0)
            {
                char c = str[num];
                if (c >= '1' && c <= '9')
                {
                    sum[0] += c - 48;
                }

                num--;
            }

            return sum[0];
        }

        internal static int SumOfDigitsGuidBytes(in Span<byte> bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            foreach (char c in new Guid(bytes).ToString())
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

        internal static int SumOfDigitsGuid2(in Guid bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            string str = bytes.ToString();
            foreach (char c in str)
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

        internal static int SumOfDigitsGuid(in Guid bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            foreach (char c in bytes.ToString())
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

        internal static int SumOfDigitsForEachSwitchSpan(in ReadOnlySpan<char> str, Span<int> sum)
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


        internal static int SumOfDigitsForSwitch(ReadOnlySpan<byte> str, int sum = 0)
        {
            for (int index = str.Length - 1; index >= 0; index--)
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