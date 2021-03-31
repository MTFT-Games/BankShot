
namespace ExternalTool
{
    partial class Editor
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStatsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveUpgradesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSystem = new System.Windows.Forms.TabControl();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mapBox = new System.Windows.Forms.GroupBox();
            this.sizeablePictureBox1 = new ExternalTool.SizeablePictureBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabSystem.SuspendLayout();
            this.mapTab.SuspendLayout();
            this.mapBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeablePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.loadingBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1018, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(73, 19);
            this.statusLabel.Text = "statusLabel";
            // 
            // loadingBar
            // 
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(117, 18);
            this.loadingBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1018, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllMenuItem,
            this.saveMapMenuItem,
            this.saveStatsMenuItem,
            this.saveUpgradesMenuItem});
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveMenuItem.Text = "Save";
            // 
            // saveAllMenuItem
            // 
            this.saveAllMenuItem.Name = "saveAllMenuItem";
            this.saveAllMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveAllMenuItem.Text = "Save all";
            // 
            // saveMapMenuItem
            // 
            this.saveMapMenuItem.Name = "saveMapMenuItem";
            this.saveMapMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveMapMenuItem.Text = "Save map";
            // 
            // saveStatsMenuItem
            // 
            this.saveStatsMenuItem.Name = "saveStatsMenuItem";
            this.saveStatsMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveStatsMenuItem.Text = "Save character stats";
            // 
            // saveUpgradesMenuItem
            // 
            this.saveUpgradesMenuItem.Name = "saveUpgradesMenuItem";
            this.saveUpgradesMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveUpgradesMenuItem.Text = "Save upgrades";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // tabSystem
            // 
            this.tabSystem.Controls.Add(this.mapTab);
            this.tabSystem.Controls.Add(this.tabPage2);
            this.tabSystem.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSystem.Location = new System.Drawing.Point(0, 27);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.SelectedIndex = 0;
            this.tabSystem.Size = new System.Drawing.Size(1018, 522);
            this.tabSystem.TabIndex = 2;
            // 
            // mapTab
            // 
            this.mapTab.Controls.Add(this.mapBox);
            this.mapTab.Location = new System.Drawing.Point(4, 24);
            this.mapTab.Name = "mapTab";
            this.mapTab.Padding = new System.Windows.Forms.Padding(3);
            this.mapTab.Size = new System.Drawing.Size(1010, 494);
            this.mapTab.TabIndex = 0;
            this.mapTab.Text = "Map";
            this.mapTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(925, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mapBox
            // 
            this.mapBox.Controls.Add(this.sizeablePictureBox1);
            this.mapBox.Location = new System.Drawing.Point(202, 6);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(800, 480);
            this.mapBox.TabIndex = 0;
            this.mapBox.TabStop = false;
            this.mapBox.Text = "Map";
            // 
            // sizeablePictureBox1
            // 
            this.sizeablePictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.sizeablePictureBox1.Location = new System.Drawing.Point(109, 140);
            this.sizeablePictureBox1.Name = "sizeablePictureBox1";
            this.sizeablePictureBox1.Size = new System.Drawing.Size(211, 111);
            this.sizeablePictureBox1.TabIndex = 0;
            this.sizeablePictureBox1.TabStop = false;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 572);
            this.Controls.Add(this.tabSystem);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Editor";
            this.Text = "Editor";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabSystem.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.mapBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sizeablePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar loadingBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStatsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveUpgradesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.TabControl tabSystem;
        private System.Windows.Forms.TabPage mapTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox mapBox;
        private SizeablePictureBox sizeablePictureBox1;
    }
}