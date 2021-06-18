
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
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRaw = new System.Windows.Forms.TabPage();
            this.rawViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.rawTreeView = new System.Windows.Forms.TreeView();
            this.hexTextBox = new System.Windows.Forms.TextBox();
            this.tabPageDecoded = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageRaw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawViewSplitContainer)).BeginInit();
            this.rawViewSplitContainer.Panel1.SuspendLayout();
            this.rawViewSplitContainer.Panel2.SuspendLayout();
            this.rawViewSplitContainer.SuspendLayout();
            this.tabPageDecoded.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
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
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
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
            this.openMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openMenuItem.Text = "Open...";
            this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Enabled = false;
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(122, 22);
            this.closeMenuItem.Text = "Close file";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.Size = new System.Drawing.Size(122, 22);
            this.quitMenuItem.Text = "Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayPositionMenuItem});
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageRaw);
            this.tabControl.Controls.Add(this.tabPageDecoded);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 404);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageRaw
            // 
            this.tabPageRaw.Controls.Add(this.rawViewSplitContainer);
            this.tabPageRaw.Location = new System.Drawing.Point(4, 24);
            this.tabPageRaw.Name = "tabPageRaw";
            this.tabPageRaw.Size = new System.Drawing.Size(792, 376);
            this.tabPageRaw.TabIndex = 0;
            this.tabPageRaw.Text = "Raw View";
            this.tabPageRaw.UseVisualStyleBackColor = true;
            // 
            // rawViewSplitContainer
            // 
            this.rawViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawViewSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.rawViewSplitContainer.Name = "rawViewSplitContainer";
            // 
            // rawViewSplitContainer.Panel1
            // 
            this.rawViewSplitContainer.Panel1.Controls.Add(this.rawTreeView);
            // 
            // rawViewSplitContainer.Panel2
            // 
            this.rawViewSplitContainer.Panel2.Controls.Add(this.hexTextBox);
            this.rawViewSplitContainer.Size = new System.Drawing.Size(792, 376);
            this.rawViewSplitContainer.SplitterDistance = 264;
            this.rawViewSplitContainer.TabIndex = 0;
            // 
            // rawTreeView
            // 
            this.rawTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawTreeView.Location = new System.Drawing.Point(0, 0);
            this.rawTreeView.Name = "rawTreeView";
            this.rawTreeView.Size = new System.Drawing.Size(264, 376);
            this.rawTreeView.TabIndex = 0;
            this.rawTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RawTreeView_AfterSelect);
            // 
            // hexTextBox
            // 
            this.hexTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexTextBox.Font = new System.Drawing.Font("Source Code Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hexTextBox.Location = new System.Drawing.Point(0, 0);
            this.hexTextBox.Multiline = true;
            this.hexTextBox.Name = "hexTextBox";
            this.hexTextBox.ReadOnly = true;
            this.hexTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hexTextBox.Size = new System.Drawing.Size(524, 376);
            this.hexTextBox.TabIndex = 0;
            this.hexTextBox.Text = "Hex view";
            this.hexTextBox.WordWrap = false;
            // 
            // tabPageDecoded
            // 
            this.tabPageDecoded.Controls.Add(this.label1);
            this.tabPageDecoded.Location = new System.Drawing.Point(4, 24);
            this.tabPageDecoded.Name = "tabPageDecoded";
            this.tabPageDecoded.Size = new System.Drawing.Size(792, 376);
            this.tabPageDecoded.TabIndex = 1;
            this.tabPageDecoded.Text = "Decoded View";
            this.tabPageDecoded.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "TODO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "MunchExplorer";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageRaw.ResumeLayout(false);
            this.rawViewSplitContainer.Panel1.ResumeLayout(false);
            this.rawViewSplitContainer.Panel2.ResumeLayout(false);
            this.rawViewSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawViewSplitContainer)).EndInit();
            this.rawViewSplitContainer.ResumeLayout(false);
            this.tabPageDecoded.ResumeLayout(false);
            this.tabPageDecoded.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageRaw;
        private System.Windows.Forms.TabPage tabPageDecoded;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer rawViewSplitContainer;
        private System.Windows.Forms.TreeView rawTreeView;
        private System.Windows.Forms.TextBox hexTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem displayPositionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
    }
}