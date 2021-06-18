using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MunchExplorer
{
    public class MTreeNode
    {
        public MTreeNode Parent;
        public string Name;
        public long DataSize;
        public long DataOffset;
        public List<MTreeNode> Children;

        private string cachedPath;
        public string Path
        {
            get
            {
                // This doesn't sound super efficient. Too bad!
                if (cachedPath != null)
                    return cachedPath;

                var hierarchy = new List<MTreeNode>();
                var current = this;
                while (current != null)
                {
                    hierarchy.Add(current);
                    current = current.Parent;
                }

                var builder = new StringBuilder();
                for (int i = hierarchy.Count - 1; i >= 0; i--)
                {
                    builder.Append(hierarchy[i].Name);
                    if (i != 0)
                        builder.Append('/');
                }

                cachedPath = builder.ToString();
                return cachedPath;
            }
        }

        public int ChildrenCount
        {
            get
            {
                int result = 0;
                foreach (var node in Children)
                    result += 1 + node.ChildrenCount;
                return result;
            }
        }

        public static MTreeNode FromUnmanaged(UnmanagedMemoryAccessor accessor, long offset)
        {
            var result = new MTreeNode();
            var rawName = new byte[4];
            accessor.ReadArray(offset, rawName, 0, 4);
            result.Parent = null;
            result.Name = Encoding.ASCII.GetString(rawName);
            result.DataSize = Utils.Read32LE(accessor, offset + 4);
            result.DataOffset = offset + 8;
            result.Children = new List<MTreeNode>();
            _ = ProcessHierarchy(accessor, result);
            return result;
        }

        public static bool ProcessHierarchy(UnmanagedMemoryAccessor accessor, MTreeNode output)
        {
            long current = output.DataOffset;
            long remaining = output.DataSize;

            bool SkipPadding()
            {
                while (remaining > 0 && accessor.ReadByte(current) == 0)
                {
                    current++;
                    remaining--;
                }
                return remaining > 0;
            }

            bool isValid = true;
            while (remaining > 0)
            {
                if (!SkipPadding())
                    break;

                var nameRaw = new byte[4];
                accessor.ReadArray(current, nameRaw, 0, 4);
                var name = Encoding.ASCII.GetString(nameRaw);

                var chunkSize = Utils.Read32LE(accessor, current + 4);
                current += 8;
                remaining -= 8;
                if (chunkSize < 0 || chunkSize > remaining)
                {
                    isValid = false;
                    break;
                }

                var newChild = new MTreeNode
                {
                    Parent = output,
                    Name = name,
                    DataOffset = current,
                    DataSize = chunkSize,
                    Children = new List<MTreeNode>(),
                };
                _ = ProcessHierarchy(accessor, newChild);
                output.Children.Add(newChild);

                remaining -= chunkSize;
                current += chunkSize;
            }

            if (!isValid)
                output.Children.Clear();
            return isValid;
        }
    }
}
