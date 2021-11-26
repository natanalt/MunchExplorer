using System;
using System.IO;
using System.Text;

namespace MunchExplorer
{
    public static class Utils
    {
        public static int Read32LE(UnmanagedMemoryAccessor accessor, long position)
        {
            var bytes = new byte[4];
            accessor.ReadArray(position, bytes, 0, 4);

            int result = 0;
            result |= bytes[0] << 0;
            result |= bytes[1] << 8;
            result |= bytes[2] << 16;
            result |= bytes[3] << 24;
            return result;
        }

        public static bool VerifyAllASCII(byte[] arr)
        {
            return Array.TrueForAll(arr, x => x > 127);
        }

        public static bool IsLatinLetterOrDigitOrUnderscore(char c)
        {
            var isDigit = c >= '0' && c <= '9';
            var isLowercase = c >= 'a' && c <= 'z';
            var isUppercase = c >= 'A' && c <= 'Z';
            var isUnderscore = c == '_';
            return isDigit || isLowercase || isUppercase || isUnderscore;
        }

        public static string SafeBytesToString(byte[] data)
        {
            var result = new StringBuilder();

            foreach (var b in data)
            {
                if (IsLatinLetterOrDigitOrUnderscore((char)b))
                {
                    result.Append((char)b);
                }
                else
                {
                    result.Append("\\x");
                    result.Append(b.ToString("X2"));
                }
            }

            return result.ToString();
        }

        public static void SaveMapToStream(
            Stream target,
            UnmanagedMemoryAccessor memory,
            long offset,
            long size)
        {

        }
    }
}
