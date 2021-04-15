
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStatsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveUpgradesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSystem = new System.Windows.Forms.TabControl();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.mapDivider = new System.Windows.Forms.SplitContainer();
            this.tilesLabel = new System.Windows.Forms.Label();
            this.backgroundLabel = new System.Windows.Forms.Label();
            this.backgroundList = new System.Windows.Forms.ListView();
            this.backgroundImages = new System.Windows.Forms.ImageList(this.components);
            this.tileList = new System.Windows.Forms.ListView();
            this.thumbnailSet = new System.Windows.Forms.ImageList(this.components);
            this.mapBackground = new System.Windows.Forms.PictureBox();
            this.upgradesTab = new System.Windows.Forms.TabPage();
            this.tileSet = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabSystem.SuspendLayout();
            this.mapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapDivider)).BeginInit();
            this.mapDivider.Panel1.SuspendLayout();
            this.mapDivider.Panel2.SuspendLayout();
            this.mapDivider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.loadingBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 545);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip.Size = new System.Drawing.Size(1129, 24);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
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
            this.loadingBar.MarqueeAnimationSpeed = 1;
            this.loadingBar.Maximum = 110;
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(200, 18);
            this.loadingBar.Step = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1129, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
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
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
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
            this.saveMapMenuItem.Click += new System.EventHandler(this.saveMapMenuItem_Click);
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
            this.tabSystem.Controls.Add(this.upgradesTab);
            this.tabSystem.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSystem.Location = new System.Drawing.Point(0, 27);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.SelectedIndex = 0;
            this.tabSystem.Size = new System.Drawing.Size(1135, 520);
            this.tabSystem.TabIndex = 2;
            // 
            // mapTab
            // 
            this.mapTab.Controls.Add(this.mapDivider);
            this.mapTab.Location = new System.Drawing.Point(4, 24);
            this.mapTab.Name = "mapTab";
            this.mapTab.Padding = new System.Windows.Forms.Padding(3);
            this.mapTab.Size = new System.Drawing.Size(1127, 492);
            this.mapTab.TabIndex = 0;
            this.mapTab.Text = "Map";
            this.mapTab.UseVisualStyleBackColor = true;
            // 
            // mapDivider
            // 
            this.mapDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapDivider.Location = new System.Drawing.Point(3, 3);
            this.mapDivider.Margin = new System.Windows.Forms.Padding(0);
            this.mapDivider.Name = "mapDivider";
            // 
            // mapDivider.Panel1
            // 
            this.mapDivider.Panel1.Controls.Add(this.tilesLabel);
            this.mapDivider.Panel1.Controls.Add(this.backgroundLabel);
            this.mapDivider.Panel1.Controls.Add(this.backgroundList);
            this.mapDivider.Panel1.Controls.Add(this.tileList);
            // 
            // mapDivider.Panel2
            // 
            this.mapDivider.Panel2.Controls.Add(this.mapBackground);
            this.mapDivider.Size = new System.Drawing.Size(1121, 486);
            this.mapDivider.SplitterDistance = 311;
            this.mapDivider.TabIndex = 0;
            // 
            // tilesLabel
            // 
            this.tilesLabel.AutoSize = true;
            this.tilesLabel.Location = new System.Drawing.Point(5, 238);
            this.tilesLabel.Name = "tilesLabel";
            this.tilesLabel.Size = new System.Drawing.Size(35, 15);
            this.tilesLabel.TabIndex = 4;
            this.tilesLabel.Text = "Tiles:";
            // 
            // backgroundLabel
            // 
            this.backgroundLabel.AutoSize = true;
            this.backgroundLabel.Location = new System.Drawing.Point(5, 5);
            this.backgroundLabel.Name = "backgroundLabel";
            this.backgroundLabel.Size = new System.Drawing.Size(75, 15);
            this.backgroundLabel.TabIndex = 3;
            this.backgroundLabel.Text = "Backgrounds:";
            // 
            // backgroundList
            // 
            this.backgroundList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.backgroundList.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundList.ForeColor = System.Drawing.Color.Transparent;
            this.backgroundList.HideSelection = false;
            this.backgroundList.LabelWrap = false;
            this.backgroundList.LargeImageList = this.backgroundImages;
            this.backgroundList.Location = new System.Drawing.Point(3, 23);
            this.backgroundList.MultiSelect = false;
            this.backgroundList.Name = "backgroundList";
            this.backgroundList.RightToLeftLayout = true;
            this.backgroundList.Size = new System.Drawing.Size(234, 141);
            this.backgroundList.TabIndex = 2;
            this.backgroundList.TileSize = new System.Drawing.Size(110, 70);
            this.backgroundList.UseCompatibleStateImageBehavior = false;
            this.backgroundList.View = System.Windows.Forms.View.Tile;
            this.backgroundList.ItemActivate += new System.EventHandler(this.backgroundList_ItemActivate);
            // 
            // backgroundImages
            // 
            this.backgroundImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.backgroundImages.ImageSize = new System.Drawing.Size(100, 60);
            this.backgroundImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tileList
            // 
            this.tileList.Font = new System.Drawing.Font("Comic Sans MS", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tileList.ForeColor = System.Drawing.Color.Transparent;
            this.tileList.HideSelection = false;
            this.errorProvider.SetIconAlignment(this.tileList, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.tileList.LabelWrap = false;
            this.tileList.LargeImageList = this.thumbnailSet;
            this.tileList.Location = new System.Drawing.Point(5, 283);
            this.tileList.MultiSelect = false;
            this.tileList.Name = "tileList";
            this.tileList.Size = new System.Drawing.Size(266, 200);
            this.tileList.SmallImageList = this.thumbnailSet;
            this.tileList.TabIndex = 1;
            this.tileList.TileSize = new System.Drawing.Size(63, 63);
            this.tileList.UseCompatibleStateImageBehavior = false;
            this.tileList.View = System.Windows.Forms.View.Tile;
            // 
            // thumbnailSet
            // 
            this.thumbnailSet.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.thumbnailSet.ImageSize = new System.Drawing.Size(60, 60);
            this.thumbnailSet.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mapBackground
            // 
            this.mapBackground.BackColor = System.Drawing.Color.Gray;
            this.mapBackground.Location = new System.Drawing.Point(3, 3);
            this.mapBackground.Name = "mapBackground";
            this.mapBackground.Size = new System.Drawing.Size(800, 480);
            this.mapBackground.TabIndex = 0;
            this.mapBackground.TabStop = false;
            // 
            // upgradesTab
            // 
            this.upgradesTab.Location = new System.Drawing.Point(4, 24);
            this.upgradesTab.Name = "upgradesTab";
            this.upgradesTab.Padding = new System.Windows.Forms.Padding(3);
            this.upgradesTab.Size = new System.Drawing.Size(1127, 492);
            this.upgradesTab.TabIndex = 1;
            this.upgradesTab.Text = "Upgrades";
            this.upgradesTab.UseVisualStyleBackColor = true;
            // 
            // tileSet
            // 
            this.tileSet.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.tileSet.ImageSize = new System.Drawing.Size(256, 256);
            this.tileSet.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 569);
            this.Controls.Add(this.tabSystem);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Editor";
            this.Text = "Editor";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabSystem.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.mapDivider.Panel1.ResumeLayout(false);
            this.mapDivider.Panel1.PerformLayout();
            this.mapDivider.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapDivider)).EndInit();
            this.mapDivider.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar loadingBar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStatsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveUpgradesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.TabControl tabSystem;
        private System.Windows.Forms.TabPage mapTab;
        private System.Windows.Forms.TabPage upgradesTab;
        private System.Windows.Forms.SplitContainer mapDivider;
        private System.Windows.Forms.PictureBox mapBackground;
        private System.Windows.Forms.ListView tileList;
        private System.Windows.Forms.ImageList backgroundImages;
        private System.Windows.Forms.ListView backgroundList;
        private System.Windows.Forms.ImageList tileSet;
        private System.Windows.Forms.Label backgroundLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ImageList thumbnailSet;
        private System.Windows.Forms.Label tilesLabel;
    }
}