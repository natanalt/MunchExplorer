using System.IO;

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
            foreach (var b in arr)
            {
                if (b > 127)
                    return false;
            }
            return true;
        }
    }
}
