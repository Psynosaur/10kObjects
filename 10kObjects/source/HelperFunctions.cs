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

        // I phoned a friend, and he gave me the following few functions :D
        internal static unsafe int SumOfDigitsGuidP(byte* bytes, int sum = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            for (int i = 0; i < 16; i++)
            {
                switch (bytes[i] >= 49)
                {
                    case true when bytes[i] <= 57:
                        sum += bytes[i] - 48;
                        break;
                }
            }

            return sum;
        }

        internal static unsafe int SumOfDigitsGuidP2(byte* bytes, int sum = 0, int counter = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            for (int i = 0; i < 16; i++)
            {
                sum += bytes[i];
                counter += bytes[i] >= 49 ? 48 : 0;
            }

            return sum - counter;
        }

        // Winner winner chicken dinner
        internal static unsafe int SumOfDigitsGuidP3(byte* bytes, int sum = 0, int sum2 = 0)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            for (int i = 0; i < 16; i++)
            {
                int highNibble = bytes[i] >> 4;
                int lowNibble = bytes[i] & 0x0f;
                switch (highNibble < 10)
                {
                    case true:
                        sum += highNibble;
                        break;
                }

                switch (lowNibble < 10)
                {
                    case true:
                        sum2 += lowNibble;
                        break;
                }
            }

            return sum + sum2;
        }

        internal static unsafe int SumOfDigitsGuidP3Decompiled(byte* bytes, int sum = 0b0, int sum2 = 0b0)
        {
            int num = 0b0;
            while (num < 0b10000)
            {
                int num2 = bytes[num] >> 0b100;
                int num3 = bytes[num] & 0b1111;
                if (num2 < 0b1010)
                {
                    sum += num2;
                }

                if (num3 < 0b1010)
                {
                    sum2 += num3;
                }

                num++;
            }

            return sum + sum2;
        }

        // Sorcery !? 
        internal static unsafe int SumOfDigitsGuidP4(byte* bytes)
        {
            // iterate over each char in guid string representation, add digit value if char is between 1-9 
            int highNibble = bytes[0x0] >> 0x4;
            int lowNibble = bytes[0x0] & 0x0f;
            int highNibble2 = bytes[0x1] >> 0x4;
            int lowNibble2 = bytes[0x1] & 0x0f;
            int highNibble3 = bytes[0x2] >> 0x4;
            int lowNibble3 = bytes[0x2] & 0x0f;
            int highNibble4 = bytes[0x3] >> 0x4;
            int lowNibble4 = bytes[0x3] & 0x0f;
            int highNibble5 = bytes[0x4] >> 0x4;
            int lowNibble5 = bytes[0x4] & 0x0f;
            int highNibble6 = bytes[0x5] >> 0x4;
            int lowNibble6 = bytes[0x5] & 0x0f;
            int highNibble7 = bytes[0x6] >> 0x4;
            int lowNibble7 = bytes[0x6] & 0x0f;
            int highNibble8 = bytes[0x7] >> 0x4;
            int lowNibble8 = bytes[0x7] & 0x0f;
            int highNibble9 = bytes[0x8] >> 0x4;
            int lowNibble9 = bytes[0x8] & 0x0f;
            int highNibblea = bytes[0x9] >> 0x4;
            int lowNibblea = bytes[0x9] & 0x0f;
            int highNibbleb = bytes[0xA] >> 0x4;
            int lowNibbleb = bytes[0xA] & 0x0f;
            int highNibblec = bytes[0xB] >> 0x4;
            int lowNibblec = bytes[0xB] & 0x0f;
            int highNibbled = bytes[0xC] >> 0x4;
            int lowNibbled = bytes[0xC] & 0x0f;
            int highNibblee = bytes[0xD] >> 0x4;
            int lowNibblee = bytes[0xD] & 0xF;
            int highNibblef = bytes[0xE] >> 0x4;
            int lowNibblef = bytes[0xE] & 0x0f;
            int highNibble1 = bytes[0xF] >> 0x4;
            int lowNibble1 = bytes[0xF] & 0x0f;
            return
                highNibble - (highNibble < 0xA ? highNibble : 0x0)
                + highNibble1 - (highNibble1 < 0xA ? highNibble1 : 0x0)
                + highNibble2 - (highNibble2 < 0xA ? highNibble2 : 0x0)
                + highNibble3 - (highNibble3 < 0xA ? highNibble3 : 0x0)
                + highNibble4 - (highNibble4 < 0xA ? highNibble4 : 0x0)
                + highNibble5 - (highNibble5 < 0xA ? highNibble5 : 0x0)
                + highNibble6 - (highNibble6 < 0xA ? highNibble6 : 0x0)
                + highNibble7 - (highNibble7 < 0xA ? highNibble7 : 0x0)
                + highNibble8 - (highNibble8 < 0xA ? highNibble8 : 0x0)
                + highNibble9 - (highNibble9 < 0xA ? highNibble9 : 0x0)
                + highNibblea - (highNibblea < 0xA ? highNibblea : 0x0)
                + highNibbleb - (highNibbleb < 0xA ? highNibbleb : 0x0)
                + highNibblec - (highNibblec < 0xA ? highNibblec : 0x0)
                + highNibbled - (highNibbled < 0xA ? highNibbled : 0x0)
                + highNibblee - (highNibblee < 0xA ? highNibblee : 0x0)
                + highNibblef - (highNibblef < 0xA ? highNibblef : 0x0)
                + lowNibble - (lowNibble < 0xA ? lowNibble : 0x0)
                + lowNibble1 - (lowNibble1 < 0xA ? lowNibble1 : 0x0)
                + lowNibble2 - (lowNibble2 < 0xA ? lowNibble2 : 0x0)
                + lowNibble3 - (lowNibble3 < 0xA ? lowNibble3 : 0x0)
                + lowNibble4 - (lowNibble4 < 0xA ? lowNibble4 : 0x0)
                + lowNibble5 - (lowNibble5 < 0xA ? lowNibble5 : 0x0)
                + lowNibble6 - (lowNibble6 < 0xA ? lowNibble6 : 0x0)
                + lowNibble7 - (lowNibble7 < 0xA ? lowNibble7 : 0x0)
                + lowNibble8 - (lowNibble8 < 0xA ? lowNibble8 : 0x0)
                + lowNibble9 - (lowNibble9 < 0xA ? lowNibble9 : 0x0)
                + lowNibblea - (lowNibblea < 0xA ? lowNibblea : 0x0)
                + lowNibbleb - (lowNibbleb < 0xA ? lowNibbleb : 0x0)
                + lowNibblec - (lowNibblec < 0xA ? lowNibblec : 0x0)
                + lowNibbled - (lowNibbled < 0xA ? lowNibbled : 0x0)
                + lowNibblee - (lowNibblee < 0xA ? lowNibblee : 0x0)
                + lowNibblef - (lowNibblef < 0xA ? lowNibblef : 0x0);
        }

        internal static unsafe int SumOfDigitsGuidP4Decompiled(byte* bytes)
        {
            int num = *bytes >> 4;
            int num2 = *bytes & 0xF;
            int num3 = bytes[1] >> 4;
            int num4 = bytes[1] & 0xF;
            int num5 = bytes[2] >> 4;
            int num6 = bytes[2] & 0xF;
            int num7 = bytes[3] >> 4;
            int num8 = bytes[3] & 0xF;
            int num9 = bytes[4] >> 4;
            int num10 = bytes[4] & 0xF;
            int num11 = bytes[5] >> 4;
            int num12 = bytes[5] & 0xF;
            int num13 = bytes[6] >> 4;
            int num14 = bytes[6] & 0xF;
            int num15 = bytes[7] >> 4;
            int num16 = bytes[7] & 0xF;
            int num17 = bytes[8] >> 4;
            int num18 = bytes[8] & 0xF;
            int num19 = bytes[9] >> 4;
            int num20 = bytes[9] & 0xF;
            int num21 = bytes[10] >> 4;
            int num22 = bytes[10] & 0xF;
            int num23 = bytes[11] >> 4;
            int num24 = bytes[11] & 0xF;
            int num25 = bytes[12] >> 4;
            int num26 = bytes[12] & 0xF;
            int num27 = bytes[13] >> 4;
            int num28 = bytes[13] & 0xF;
            int num29 = bytes[14] >> 4;
            int num30 = bytes[14] & 0xF;
            int num31 = bytes[15] >> 4;
            int num32 = bytes[15] & 0xF;
            return num - ((num < 10) ? num : 0) + num31 - ((num31 < 10) ? num31 : 0) + num3 - ((num3 < 10) ? num3 : 0) +
                num5 - ((num5 < 10) ? num5 : 0) + num7 - ((num7 < 10) ? num7 : 0) + num9 - ((num9 < 10) ? num9 : 0) +
                num11 - ((num11 < 10) ? num11 : 0) + num13 - ((num13 < 10) ? num13 : 0) + num15 -
                ((num15 < 10) ? num15 : 0) + num17 - ((num17 < 10) ? num17 : 0) + num19 - ((num19 < 10) ? num19 : 0) +
                num21 - ((num21 < 10) ? num21 : 0) + num23 - ((num23 < 10) ? num23 : 0) + num25 -
                ((num25 < 10) ? num25 : 0) + num27 - ((num27 < 10) ? num27 : 0) + num29 - ((num29 < 10) ? num29 : 0) +
                num2 - ((num2 < 10) ? num2 : 0) + num32 - ((num32 < 10) ? num32 : 0) + num4 - ((num4 < 10) ? num4 : 0) +
                num6 - ((num6 < 10) ? num6 : 0) + num8 - ((num8 < 10) ? num8 : 0) + num10 - ((num10 < 10) ? num10 : 0) +
                num12 - ((num12 < 10) ? num12 : 0) + num14 - ((num14 < 10) ? num14 : 0) + num16 -
                ((num16 < 10) ? num16 : 0) + num18 - ((num18 < 10) ? num18 : 0) + num20 - ((num20 < 10) ? num20 : 0) +
                num22 - ((num22 < 10) ? num22 : 0) + num24 - ((num24 < 10) ? num24 : 0) + num26 -
                ((num26 < 10) ? num26 : 0) + num28 - ((num28 < 10) ? num28 : 0) + num30 - ((num30 < 10) ? num30 : 0);
        }
    }
}