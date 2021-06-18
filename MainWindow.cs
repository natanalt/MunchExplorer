using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Windows.Forms;

namespace MunchExplorer
{
    public partial class MainWindow : Form
    {
        private bool displayNodePosition;

        private bool fileOpened;
        private MemoryMappedFile mappedFile;
        private MemoryMappedViewAccessor accessor;
        private MTreeNode rootNode;

        public MainWindow()
        {
            InitializeComponent();
            fileOpened = false;
            displayNodePosition = true;
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Open a LVL file",
                Filter = "LVL files (*.lvl)|*.lvl|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            CloseFileIfOpen();

            statusLabel.Text = "Opening the file, this may take a while...";
            Refresh();

            var watch = new Stopwatch();
            watch.Start();
            mappedFile = MemoryMappedFile.CreateFromFile(dialog.FileName);
            accessor = mappedFile.CreateViewAccessor();
            rootNode = MTreeNode.FromUnmanaged(accessor, 0);
            fileOpened = true;
            GenerateTreeViewNodes();
            watch.Stop();

            var split = dialog.FileName.Replace('\\', '/').Split('/');
            statusLabel.Text = string.Format(
                "Loaded {0}. ({1} nodes, took {2}s)",
                split[split.Length - 1],
                rootNode.ChildrenCount + 1,
                watch.Elapsed.TotalSeconds.ToString("N3"));
            closeMenuItem.Enabled = true;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            CloseFileIfOpen();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            if (fileOpened)
            {
                if (MessageBox.Show(
                    "Are you sure?",
                    "Quit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }
            CloseFileIfOpen();
            Close();
        }

        private void DisplayPositionMenuItem_Click(object sender, EventArgs e)
        {
            displayNodePosition = !displayNodePosition;
            displayPositionMenuItem.Checked = displayNodePosition;

            if (fileOpened)
                GenerateTreeViewNodes();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show(
                "MunchExplorer\nby Natalia Cholewa",
                "About MunchExplorer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void RawTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!fileOpened)
                return;
            var node = (MTreeNode)e.Node.Tag;

            var doFullDump = true;
            if (node.DataSize > 100_000)
            {
                if (MessageBox.Show(
                    "The node you have selected is over 100,000 bytes long.\n" + 
                        "Creating hex dumps of big nodes may take a lot of memory.\n\nGenerate the hex dump?",
                    "Hex dump",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                    doFullDump = false;
            }

            CreateHexView(node, doFullDump);
        }

        private void CloseFileIfOpen()
        {
            if (fileOpened)
            {
                fileOpened = false;
                accessor.Dispose();
                mappedFile.Dispose();
                rootNode = null;
                rawTreeView.BeginUpdate();
                rawTreeView.Nodes.Clear();
                rawTreeView.EndUpdate();
                statusLabel.Text = "File closed.";
                closeMenuItem.Enabled = false;
                GC.Collect();
            }
        }

        private void CreateHexView(MTreeNode node, bool fullDump = true)
        {
            const int bytesPerRow = 16;

            hexTextBox.Text = "";
            GC.Collect(); // In case a large hex dump was opened earlier

            var offset = node.DataOffset;
            var size = node.DataSize;

            var builder = new StringBuilder();

            builder.AppendLine(string.Format("Hex dump of '{0}':", node.Path));
            builder.AppendLine(string.Format(" Content size: {0} bytes", node.DataSize));
            builder.AppendLine(string.Format(" Content offset: 0x{0:x}", node.DataOffset));
            builder.AppendLine(string.Format(" Has hierarchy: {0}", node.Children.Count > 0 ? "yes" : "no"));
            builder.AppendLine();

            if (fullDump)
            {
                builder.Append("Position  ");
                for (int i = 0; i < bytesPerRow; i++)
                    builder.Append(string.Format("{0:x2} ", i));
                builder.AppendLine(" Decoded text");

                for (long i = 0; i < size; i += bytesPerRow)
                {
                    var remaining = size - i;
                    builder.Append(string.Format("{0:X8}  ", i));

                    var bytes = remaining > bytesPerRow ? bytesPerRow : remaining;
                    for (int b = 0; b < bytes; b++)
                    {
                        builder.Append(string.Format("{0:x2} ", accessor.ReadByte(offset + i + b)));
                    }
                    builder.Append(' ', (int)(bytesPerRow - bytes) * 3 + 1);
                    for (int b = 0; b < bytes; b++)
                    {
                        char c = (char)accessor.ReadByte(offset + i + b);
                        builder.Append(string.Format("{0}", char.IsControl(c) ? '.' : c));
                    }
                    builder.AppendLine();
                }
            }
            else
            {
                builder.Append("*hex dump creation was cancelled because this node is quite large*");
            }

            hexTextBox.Text = builder.ToString();
        }

        private void GenerateTreeViewNodes()
        {
            if (!fileOpened)
                return;

            TreeNode MakeTreeNode(MTreeNode mnode)
            {
                string text;
                if (displayNodePosition)
                {
                    text = string.Format(
                        "{0} ({1} bytes @ 0x{2:x})",
                        mnode.Name,
                        mnode.DataSize,
                        mnode.DataOffset - 8);
                }
                else
                {
                    text = mnode.Name;
                }

                if (mnode.Name == "NAME")
                {
                    var rawContent = new byte[mnode.DataSize];
                    accessor.ReadArray(mnode.DataOffset, rawContent, 0, rawContent.Length);
                    text += " - " + Encoding.ASCII.GetString(rawContent);
                }

                var result = new TreeNode
                {
                    Tag = mnode,
                    Text = text,
                };
                foreach (var child in mnode.Children)
                    result.Nodes.Add(MakeTreeNode(child));

                return result;
            }

            rawTreeView.BeginUpdate();
            var nodes = rawTreeView.Nodes;
            nodes.Clear();
            nodes.Add(MakeTreeNode(rootNode));
            rawTreeView.EndUpdate();

            GC.Collect(); // In case of a big tree view being opened earlier
        }
    }
}
