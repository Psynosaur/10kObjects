using System;
using System.Runtime.InteropServices;

namespace TenKObjects
{
    public static class ClassesAndStructs
    {
        // Do not change this class...
        // okay, make something else like it then...? 
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
        public ref struct WorkStructByteArray
        {
            // Guid 16 byte 128 bit unsigned integer representation
            internal byte[] Step1Result;

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
        public struct WorkStructByteArrayConstrFinal
        {
            internal WorkStructByteArrayConstrFinal(int mandatory)
            {
                Id = Guid.NewGuid().ToByteArray();
                Step1Result = null;
                Step2Result = mandatory;
            }

            internal byte[] Id;

            // Guid 16 byte 128 bit unsigned integer representation
            internal byte[] Step1Result;

            // Sum of string representation of above Guid bytes
            internal int Step2Result;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct WorkStructByteArrayConstrSorterFinal
        {
            internal WorkStructByteArrayConstrSorterFinal(int mandatory)
            {
                Id = Guid.NewGuid().ToByteArray();
                Step1Result = new byte[]
                    {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
                Array.Copy(Id, Step1Result, 16);
                Array.Sort(Step1Result);
                Step2Result = mandatory;
            }

            internal byte[] Id;

            // Guid 16 byte 128 bit unsigned integer representation
            internal byte[] Step1Result;

            // Sum of string representation of above Guid bytes
            internal int Step2Result;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct WorkStructCharArray
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
            public char[] Step1Result;

            [MarshalAs(UnmanagedType.U4, SizeConst = 3)]
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
                Guid id = Guid.NewGuid();
                Step1Result = SortGuidBytes(id);
                Step2Result = SumOfDigitsGuidBytes(Step1Result);
            }

            private static Span<byte> SortGuidBytes(Guid id)
            {
                byte[] b = id.ToByteArray();
                Array.Sort(b);
                return b;
            }

            private static int SumOfDigitsGuidBytes(in Span<byte> bytes, int sum = 0)
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
        public ref struct WorkStructSpanChar
        {
            public Span<char> Step1Result;
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
    }
}