using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private MTreeNode displayedNode;
        private bool displayFull;
        private DisplayType displayType;

        public MainWindow()
        {
            InitializeComponent();
            fileOpened = false;
            displayNodePosition = true;
            displayType = DisplayType.U8;
        }

        private void OpenFile(string path)
        {
            CloseFileIfOpen();

            statusLabel.Text = "Opening the file, this may take a while...";
            Refresh();

            var watch = new Stopwatch();
            watch.Start();

            var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            mappedFile = MemoryMappedFile.CreateFromFile(
                stream,
                mapName: null,
                capacity: 0,
                MemoryMappedFileAccess.Read,
                HandleInheritability.None,
                leaveOpen: false
            );
            accessor = mappedFile.CreateViewAccessor(offset: 0, size: 0, MemoryMappedFileAccess.Read);
            rootNode = MTreeNode.FromUnmanaged(accessor, 0);
            fileOpened = true;
            GenerateTreeViewNodes();
            watch.Stop();

            var split = path.Replace('\\', '/').Split('/');
            statusLabel.Text = string.Format(
                "Loaded {0}. ({1} nodes, took {2}s)",
                split[^1],
                rootNode.ChildrenCount + 1,
                watch.Elapsed.TotalSeconds.ToString("N3"));
            closeMenuItem.Enabled = true;

            Text = $"MunchExplorer - {path}";
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Open a data file",
                Filter = "All files (*.*)|*.*|.lvl files (*.lvl)|*.lvl"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            OpenFile(dialog.FileName);
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
                "MunchExplorer\nby Natalia Cholewa\n\nhttps://github.com/natanalt/MunchExplorer",
                "About MunchExplorer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void CloseFileIfOpen()
        {
            if (fileOpened)
            {
                fileOpened = false;
                displayedNode = null;
                accessor.Dispose();
                mappedFile.Dispose();
                rootNode = null;
                rawTreeView.BeginUpdate();
                rawTreeView.Nodes.Clear();
                rawTreeView.EndUpdate();
                statusLabel.Text = "File closed.";
                dataTextBox.Text = "Data view";
                closeMenuItem.Enabled = false;
                Text = "MunchExplorer";
                GC.Collect();
            }
        }

        private void CreateHexView(MTreeNode node, bool fullDump = true)
        {
            displayedNode = node;
            displayFull = fullDump;

            dataTextBox.Text = "";
            GC.Collect(); // In case a large hex dump was opened earlier

            var offset = node.DataOffset;
            var size = node.DataSize;

            var builder = new StringBuilder();

            builder.AppendLine(string.Format("Hex dump of '{0}':", node.Path));
            builder.AppendLine(string.Format(" Content size: {0} bytes", node.DataSize));
            builder.AppendLine(string.Format(" Content offset: 0x{0:x}", node.DataOffset));
            builder.AppendLine(string.Format(" Has hierarchy: {0}", node.Children.Count > 0 ? "yes" : "no"));
            builder.AppendLine();

            if (!fullDump)
            {
                builder.Append("*hex dump creation was cancelled because this node is quite large*");
                dataTextBox.Text = builder.ToString();
                return;
            }

            switch (displayType)
            {
                case DisplayType.U8:
                    const int u8PerRow = 16;

                    // Display header
                    builder.Append("Position  ");
                    for (int i = 0; i < u8PerRow; i++)
                        builder.Append(string.Format("{0:x2} ", i));
                    builder.AppendLine(" Decoded text");

                    // Display lines
                    for (long i = 0; i < size; i += u8PerRow)
                    {
                        builder.Append(string.Format("{0:X8}  ", i));

                        // Display value
                        var remaining = size - i;
                        var u8Count = Math.Min(u8PerRow, remaining);
                        for (int b = 0; b < u8Count; b++)
                        {
                            builder.Append(string.Format("{0:x2} ", accessor.ReadByte(offset + i + b)));
                        }

                        // Display decoded
                        builder.Append(' ', (int)(u8PerRow - u8Count) * 3 + 1);
                        for (int b = 0; b < u8Count; b++)
                        {
                            char c = (char)accessor.ReadByte(offset + i + b);
                            builder.Append(string.Format("{0}", char.IsControl(c) ? '.' : c));
                        }

                        builder.AppendLine();
                    }
                    break;
                case DisplayType.U16:
                    const int u16PerRow = 8;

                    // Display header
                    builder.Append("Position  ");
                    for (int i = 0; i < u16PerRow; i++)
                        builder.Append(string.Format("{0:x4} ", i * 2));
                    builder.AppendLine(" Decoded text");

                    // Display lines
                    for (long i = 0; i < size; i += u16PerRow * 2)
                    {
                        builder.Append(string.Format("{0:X8}  ", i));

                        // Display value
                        var remaining = size - i;
                        var u16Count = Math.Min(u16PerRow, remaining);
                        for (int b = 0; b < u16Count * 2; b += 2)
                        {
                            builder.Append(string.Format("{0:x4} ", accessor.ReadUInt16(offset + i + b)));
                        }

                        // Display decoded
                        builder.Append(' ', (int)(u16PerRow - u16Count) * 5 + 1);
                        for (int b = 0; b < u16Count * 2; b++)
                        {
                            char c = (char)accessor.ReadByte(offset + i + b);
                            builder.Append(string.Format("{0}", char.IsControl(c) ? '.' : c));
                        }

                        builder.AppendLine();
                    }
                    break;
                case DisplayType.U32:
                    const int u32PerRow = 4;

                    // Display header
                    builder.Append("Position  ");
                    for (int i = 0; i < u32PerRow; i++)
                        builder.Append(string.Format("{0:x8} ", i * 4));
                    builder.AppendLine(" Decoded text");

                    // Display lines
                    for (long i = 0; i < size; i += u32PerRow * 4)
                    {
                        builder.Append(string.Format("{0:X8}  ", i));

                        // Display value
                        var remaining = size - i;
                        var u32Count = Math.Min(u32PerRow, remaining);
                        for (int b = 0; b < u32Count * 4; b += 4)
                        {
                            builder.Append(string.Format("{0:x8} ", accessor.ReadUInt32(offset + i + b)));
                        }

                        // Display decoded
                        builder.Append(' ', (int)(u32PerRow - u32Count) * 5 + 1);
                        for (int b = 0; b < u32Count * 4; b++)
                        {
                            char c = (char)accessor.ReadByte(offset + i + b);
                            builder.Append(string.Format("{0}", char.IsControl(c) ? '.' : c));
                        }

                        builder.AppendLine();
                    }
                    break;
                case DisplayType.F32:
                    for (long i = 0; i < size; i += 4)
                    {
                        builder.Append(string.Format(
                            "{0:X8}  {1}",
                            i,
                            // what in the name of fuck C#
                            accessor.ReadSingle(offset + i).ToString("0." + new string('#', 339))
                        ));
                        builder.AppendLine();
                    }
                    break;
            }

            dataTextBox.Text = builder.ToString();
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
                    var rawContent = new byte[mnode.DataSize - 1];
                    accessor.ReadArray(mnode.DataOffset, rawContent, 0, rawContent.Length);
                    text += " - " + Utils.SafeBytesToString(rawContent);
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

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (paths.Length != 1)
            {
                _ = MessageBox.Show(
                    "Please drop one file at a time.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            OpenFile(paths[0]);
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void ShowNodeUI(MTreeNode node)
        {
            var doFullDump = true;
            if (node.DataSize > 100_000)
            {
                if (MessageBox.Show(
                    "The node you have selected is over 100 000 bytes long.\n" +
                        "Creating hex dumps of big nodes may take a lot of memory.\n\nGenerate the hex dump?",
                    $"Hex dump of `{node.Path}`",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    doFullDump = false;
                }
            }

            CreateHexView(node, doFullDump);
        }

        private void RawTreeView_DoubleClick(object sender, EventArgs e)
        {
            if (!fileOpened || rawTreeView.SelectedNode == null)
                return;

            var node = (MTreeNode)rawTreeView.SelectedNode.Tag;
            ShowNodeUI(node);
        }

        private void SaveNodeUI(bool withHeader)
        {
            if (rawTreeView.SelectedNode == null)
                return;

            var suffix = withHeader ? "(with header)" : "(without header)";
            var offset = withHeader ? 8 : 0;

            var node = (MTreeNode)rawTreeView.SelectedNode.Tag;
            var dialog = new SaveFileDialog
            {
                Title = $"Save node `{node.Path}` {suffix}",
                Filter = "All files (*.*)|*.*|.lvl files (*.lvl)|*.lvl"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var oldStatus = statusLabel.Text;
            statusLabel.Text = "Saving the node, please wait...";
            Refresh();

            using (var stream = dialog.OpenFile())
            {
                Utils.SaveMapToStream(
                    stream,
                    accessor,
                    node.DataOffset - offset,
                    node.DataSize + offset
                );
            }

            statusLabel.Text = oldStatus;
            Refresh();
        }

        private void SaveNodeWithHeader_Click(object sender, EventArgs e)
        {
            SaveNodeUI(withHeader: true);
        }

        private void SaveNodeWithoutHeader_Click(object sender, EventArgs e)
        {
            SaveNodeUI(withHeader: false);
        }

        enum DisplayType
        {
            U8, U16, U32, F32
        }

        private void DisplayAsU8_Click(object sender, EventArgs e)
        {
            displayType = DisplayType.U8;
            if (displayedNode != null)
                CreateHexView(displayedNode, displayFull);
        }

        private void DisplayAsU16_Click(object sender, EventArgs e)
        {
            displayType = DisplayType.U16;
            if (displayedNode != null)
                CreateHexView(displayedNode, displayFull);
        }

        private void DisplayAsU32_Click(object sender, EventArgs e)
        {
            displayType = DisplayType.U32;
            if (displayedNode != null)
                CreateHexView(displayedNode, displayFull);
        }

        private void DisplayAsF32_Click(object sender, EventArgs e)
        {
            displayType = DisplayType.F32;
            if (displayedNode != null)
                CreateHexView(displayedNode, displayFull);
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rawTreeView.SelectedNode == null)
                return;
            ShowNodeUI((MTreeNode)rawTreeView.SelectedNode.Tag);
        }
    }
}
