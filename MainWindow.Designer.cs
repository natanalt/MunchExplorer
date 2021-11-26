
namespace MunchExplorer
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.displayPositionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayedDataTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayAsU8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diplayAsU16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayAsU32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayAsF32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.rawTreeView = new System.Windows.Forms.TreeView();
            this.treeContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveNodeContentswithHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNodeContentswithoutHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawViewSplitContainer)).BeginInit();
            this.rawViewSplitContainer.Panel1.SuspendLayout();
            this.rawViewSplitContainer.Panel2.SuspendLayout();
            this.rawViewSplitContainer.SuspendLayout();
            this.treeContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 589);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1004, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(193, 17);
            this.statusLabel.Text = "MunchExplorer by Natalia Cholewa";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip.TabIndex = 1;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.closeMenuItem,
            this.toolStripSeparator1,
            this.quitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeyDisplayString = "";
            this.openMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openMenuItem.Text = "Open...";
            this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Enabled = false;
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeMenuItem.Text = "Close file";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitMenuItem.Text = "Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayPositionMenuItem,
            this.displayedDataTypeToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(44, 20);
            this.viewMenu.Text = "View";
            // 
            // displayPositionMenuItem
            // 
            this.displayPositionMenuItem.Checked = true;
            this.displayPositionMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayPositionMenuItem.Name = "displayPositionMenuItem";
            this.displayPositionMenuItem.Size = new System.Drawing.Size(190, 22);
            this.displayPositionMenuItem.Text = "Display size and offset";
            this.displayPositionMenuItem.Click += new System.EventHandler(this.DisplayPositionMenuItem_Click);
            // 
            // displayedDataTypeToolStripMenuItem
            // 
            this.displayedDataTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayAsU8ToolStripMenuItem,
            this.diplayAsU16ToolStripMenuItem,
            this.displayAsU32ToolStripMenuItem,
            this.displayAsF32ToolStripMenuItem});
            this.displayedDataTypeToolStripMenuItem.Name = "displayedDataTypeToolStripMenuItem";
            this.displayedDataTypeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.displayedDataTypeToolStripMenuItem.Text = "Displayed data type";
            // 
            // displayAsU8ToolStripMenuItem
            // 
            this.displayAsU8ToolStripMenuItem.Name = "displayAsU8ToolStripMenuItem";
            this.displayAsU8ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.displayAsU8ToolStripMenuItem.Text = "Display as u8";
            this.displayAsU8ToolStripMenuItem.Click += new System.EventHandler(this.DisplayAsU8_Click);
            // 
            // diplayAsU16ToolStripMenuItem
            // 
            this.diplayAsU16ToolStripMenuItem.Name = "diplayAsU16ToolStripMenuItem";
            this.diplayAsU16ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.diplayAsU16ToolStripMenuItem.Text = "Diplay as u16";
            this.diplayAsU16ToolStripMenuItem.Click += new System.EventHandler(this.DisplayAsU16_Click);
            // 
            // displayAsU32ToolStripMenuItem
            // 
            this.displayAsU32ToolStripMenuItem.Name = "displayAsU32ToolStripMenuItem";
            this.displayAsU32ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.displayAsU32ToolStripMenuItem.Text = "Display as u32";
            this.displayAsU32ToolStripMenuItem.Click += new System.EventHandler(this.DisplayAsU32_Click);
            // 
            // displayAsF32ToolStripMenuItem
            // 
            this.displayAsF32ToolStripMenuItem.Name = "displayAsF32ToolStripMenuItem";
            this.displayAsF32ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.displayAsF32ToolStripMenuItem.Text = "Display as f32";
            this.displayAsF32ToolStripMenuItem.Click += new System.EventHandler(this.DisplayAsF32_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // rawViewSplitContainer
            // 
            this.rawViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawViewSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.rawViewSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.rawViewSplitContainer.Name = "rawViewSplitContainer";
            // 
            // rawViewSplitContainer.Panel1
            // 
            this.rawViewSplitContainer.Panel1.Controls.Add(this.rawTreeView);
            // 
            // rawViewSplitContainer.Panel2
            // 
            this.rawViewSplitContainer.Panel2.Controls.Add(this.dataTextBox);
            this.rawViewSplitContainer.Size = new System.Drawing.Size(1004, 565);
            this.rawViewSplitContainer.SplitterDistance = 266;
            this.rawViewSplitContainer.TabIndex = 0;
            // 
            // rawTreeView
            // 
            this.rawTreeView.ContextMenuStrip = this.treeContextStrip;
            this.rawTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawTreeView.Location = new System.Drawing.Point(0, 0);
            this.rawTreeView.Name = "rawTreeView";
            this.rawTreeView.Size = new System.Drawing.Size(266, 565);
            this.rawTreeView.TabIndex = 0;
            this.rawTreeView.DoubleClick += new System.EventHandler(this.RawTreeView_DoubleClick);
            // 
            // treeContextStrip
            // 
            this.treeContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.saveNodeContentswithHeaderToolStripMenuItem,
            this.saveNodeContentswithoutHeaderToolStripMenuItem});
            this.treeContextStrip.Name = "treeContextStrip";
            this.treeContextStrip.Size = new System.Drawing.Size(269, 92);
            // 
            // saveNodeContentswithHeaderToolStripMenuItem
            // 
            this.saveNodeContentswithHeaderToolStripMenuItem.Name = "saveNodeContentswithHeaderToolStripMenuItem";
            this.saveNodeContentswithHeaderToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.saveNodeContentswithHeaderToolStripMenuItem.Text = "Save node contents (with header)";
            this.saveNodeContentswithHeaderToolStripMenuItem.Click += new System.EventHandler(this.SaveNodeWithHeader_Click);
            // 
            // saveNodeContentswithoutHeaderToolStripMenuItem
            // 
            this.saveNodeContentswithoutHeaderToolStripMenuItem.Name = "saveNodeContentswithoutHeaderToolStripMenuItem";
            this.saveNodeContentswithoutHeaderToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.saveNodeContentswithoutHeaderToolStripMenuItem.Text = "Save node contents (without header)";
            this.saveNodeContentswithoutHeaderToolStripMenuItem.Click += new System.EventHandler(this.SaveNodeWithoutHeader_Click);
            // 
            // dataTextBox
            // 
            this.dataTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTextBox.Font = new System.Drawing.Font("Source Code Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataTextBox.Location = new System.Drawing.Point(0, 0);
            this.dataTextBox.Multiline = true;
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ReadOnly = true;
            this.dataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dataTextBox.Size = new System.Drawing.Size(734, 565);
            this.dataTextBox.TabIndex = 0;
            this.dataTextBox.Text = "Data view";
            this.dataTextBox.WordWrap = false;
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 611);
            this.Controls.Add(this.rawViewSplitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "MunchExplorer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.rawViewSplitContainer.Panel1.ResumeLayout(false);
            this.rawViewSplitContainer.Panel2.ResumeLayout(false);
            this.rawViewSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawViewSplitContainer)).EndInit();
            this.rawViewSplitContainer.ResumeLayout(false);
            this.treeContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer rawViewSplitContainer;
        private System.Windows.Forms.TreeView rawTreeView;
        private System.Windows.Forms.TextBox dataTextBox;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem displayPositionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ContextMenuStrip treeContextStrip;
        private System.Windows.Forms.ToolStripMenuItem saveNodeContentswithHeaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNodeContentswithoutHeaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayedDataTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayAsU8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diplayAsU16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayAsU32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayAsF32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
    }
}