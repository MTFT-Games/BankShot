
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.backgroundLabel = new System.Windows.Forms.Label();
            this.tileList = new System.Windows.Forms.ListView();
            this.thumbnailSet = new System.Windows.Forms.ImageList(this.components);
            this.tilesLabel = new System.Windows.Forms.Label();
            this.backgroundList = new System.Windows.Forms.ListView();
            this.backgroundImages = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.enemySelect = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.waveCounter = new System.Windows.Forms.NumericUpDown();
            this.mapBackground = new System.Windows.Forms.PictureBox();
            this.upgradesTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.UpgradeCost = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.trackBar16 = new System.Windows.Forms.TrackBar();
            this.upgradeWeight = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.trackBar15 = new System.Windows.Forms.TrackBar();
            this.upgradeJump = new System.Windows.Forms.CheckBox();
            this.upgradeKnockResist = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.trackBar14 = new System.Windows.Forms.TrackBar();
            this.upgradeKnock = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.trackBar13 = new System.Windows.Forms.TrackBar();
            this.upgradeHealthRegen = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.trackBar12 = new System.Windows.Forms.TrackBar();
            this.upgradeHealth = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.trackBar11 = new System.Windows.Forms.TrackBar();
            this.upgradeShieldCool = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.trackBar10 = new System.Windows.Forms.TrackBar();
            this.upgradeShieldRegen = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.trackBar9 = new System.Windows.Forms.TrackBar();
            this.upgradeShieldHealth = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.upgradeProjHome = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.upgradeProjSpread = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.upgradeProjSize = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.upgradeProjSpeed = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.upgradeROF = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.upgradeProjCount = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.upgradeDmg = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpgradeDmgMult = new System.Windows.Forms.CheckBox();
            this.UpgradeDmgSlider = new System.Windows.Forms.TrackBar();
            this.newUpgradeBtn = new System.Windows.Forms.Button();
            this.upgradeDesc = new System.Windows.Forms.TextBox();
            this.upgradeName = new System.Windows.Forms.TextBox();
            this.upgradeImageDrop = new System.Windows.Forms.ComboBox();
            this.upgradeIcon = new System.Windows.Forms.PictureBox();
            this.upgradeList = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tileSet = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.upgradeIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.enemyIcons = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabSystem.SuspendLayout();
            this.mapTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapDivider)).BeginInit();
            this.mapDivider.Panel1.SuspendLayout();
            this.mapDivider.Panel2.SuspendLayout();
            this.mapDivider.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackground)).BeginInit();
            this.upgradesTab.SuspendLayout();
            this.UpgradeCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar16)).BeginInit();
            this.upgradeWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar15)).BeginInit();
            this.upgradeKnockResist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar14)).BeginInit();
            this.upgradeKnock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).BeginInit();
            this.upgradeHealthRegen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).BeginInit();
            this.upgradeHealth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).BeginInit();
            this.upgradeShieldCool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).BeginInit();
            this.upgradeShieldRegen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).BeginInit();
            this.upgradeShieldHealth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            this.upgradeProjHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            this.upgradeProjSpread.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            this.upgradeProjSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            this.upgradeProjSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.upgradeROF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.upgradeProjCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.upgradeDmg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpgradeDmgSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upgradeIcon)).BeginInit();
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
            this.mapDivider.Panel1.Controls.Add(this.tabControl1);
            // 
            // mapDivider.Panel2
            // 
            this.mapDivider.Panel2.Controls.Add(this.mapBackground);
            this.mapDivider.Size = new System.Drawing.Size(1121, 486);
            this.mapDivider.SplitterDistance = 311;
            this.mapDivider.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(303, 480);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.MapMode_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.backgroundLabel);
            this.tabPage1.Controls.Add(this.tileList);
            this.tabPage1.Controls.Add(this.tilesLabel);
            this.tabPage1.Controls.Add(this.backgroundList);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(295, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map controls";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // backgroundLabel
            // 
            this.backgroundLabel.AutoSize = true;
            this.backgroundLabel.Location = new System.Drawing.Point(6, 3);
            this.backgroundLabel.Name = "backgroundLabel";
            this.backgroundLabel.Size = new System.Drawing.Size(75, 15);
            this.backgroundLabel.TabIndex = 3;
            this.backgroundLabel.Text = "Backgrounds:";
            // 
            // tileList
            // 
            this.tileList.Font = new System.Drawing.Font("Comic Sans MS", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tileList.ForeColor = System.Drawing.Color.Transparent;
            this.tileList.HideSelection = false;
            this.errorProvider.SetIconAlignment(this.tileList, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.tileList.LabelWrap = false;
            this.tileList.LargeImageList = this.thumbnailSet;
            this.tileList.Location = new System.Drawing.Point(9, 199);
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
            // tilesLabel
            // 
            this.tilesLabel.AutoSize = true;
            this.tilesLabel.Location = new System.Drawing.Point(6, 181);
            this.tilesLabel.Name = "tilesLabel";
            this.tilesLabel.Size = new System.Drawing.Size(35, 15);
            this.tilesLabel.TabIndex = 4;
            this.tilesLabel.Text = "Tiles:";
            // 
            // backgroundList
            // 
            this.backgroundList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.backgroundList.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundList.ForeColor = System.Drawing.Color.Transparent;
            this.backgroundList.HideSelection = false;
            this.backgroundList.LabelWrap = false;
            this.backgroundList.LargeImageList = this.backgroundImages;
            this.backgroundList.Location = new System.Drawing.Point(9, 21);
            this.backgroundList.MultiSelect = false;
            this.backgroundList.Name = "backgroundList";
            this.backgroundList.RightToLeftLayout = true;
            this.backgroundList.Size = new System.Drawing.Size(251, 141);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.enemySelect);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.waveCounter);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(295, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wave controls";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // enemySelect
            // 
            this.enemySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enemySelect.FormattingEnabled = true;
            this.enemySelect.Items.AddRange(new object[] {
            "Ranged",
            "Chaser",
            "Pacer",
            "Flyer"});
            this.enemySelect.Location = new System.Drawing.Point(10, 76);
            this.enemySelect.Name = "enemySelect";
            this.enemySelect.Size = new System.Drawing.Size(168, 23);
            this.enemySelect.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "Wave";
            // 
            // waveCounter
            // 
            this.waveCounter.Location = new System.Drawing.Point(6, 30);
            this.waveCounter.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.waveCounter.Name = "waveCounter";
            this.waveCounter.ReadOnly = true;
            this.waveCounter.Size = new System.Drawing.Size(44, 23);
            this.waveCounter.TabIndex = 0;
            this.waveCounter.ValueChanged += new System.EventHandler(this.waveCounter_ValueChanged);
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
            this.upgradesTab.Controls.Add(this.button1);
            this.upgradesTab.Controls.Add(this.UpgradeCost);
            this.upgradesTab.Controls.Add(this.upgradeWeight);
            this.upgradesTab.Controls.Add(this.upgradeJump);
            this.upgradesTab.Controls.Add(this.upgradeKnockResist);
            this.upgradesTab.Controls.Add(this.upgradeKnock);
            this.upgradesTab.Controls.Add(this.upgradeHealthRegen);
            this.upgradesTab.Controls.Add(this.upgradeHealth);
            this.upgradesTab.Controls.Add(this.upgradeShieldCool);
            this.upgradesTab.Controls.Add(this.upgradeShieldRegen);
            this.upgradesTab.Controls.Add(this.upgradeShieldHealth);
            this.upgradesTab.Controls.Add(this.upgradeProjHome);
            this.upgradesTab.Controls.Add(this.upgradeProjSpread);
            this.upgradesTab.Controls.Add(this.upgradeProjSize);
            this.upgradesTab.Controls.Add(this.upgradeProjSpeed);
            this.upgradesTab.Controls.Add(this.upgradeROF);
            this.upgradesTab.Controls.Add(this.upgradeProjCount);
            this.upgradesTab.Controls.Add(this.upgradeDmg);
            this.upgradesTab.Controls.Add(this.newUpgradeBtn);
            this.upgradesTab.Controls.Add(this.upgradeDesc);
            this.upgradesTab.Controls.Add(this.upgradeName);
            this.upgradesTab.Controls.Add(this.upgradeImageDrop);
            this.upgradesTab.Controls.Add(this.upgradeIcon);
            this.upgradesTab.Controls.Add(this.upgradeList);
            this.upgradesTab.Location = new System.Drawing.Point(4, 24);
            this.upgradesTab.Name = "upgradesTab";
            this.upgradesTab.Padding = new System.Windows.Forms.Padding(3);
            this.upgradesTab.Size = new System.Drawing.Size(1127, 492);
            this.upgradesTab.TabIndex = 1;
            this.upgradesTab.Text = "Upgrades";
            this.upgradesTab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(929, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 40);
            this.button1.TabIndex = 40;
            this.button1.Text = "Delete upgrade";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.DeleteUpgrade);
            // 
            // UpgradeCost
            // 
            this.UpgradeCost.Controls.Add(this.label16);
            this.UpgradeCost.Controls.Add(this.trackBar16);
            this.UpgradeCost.Location = new System.Drawing.Point(867, 255);
            this.UpgradeCost.Name = "UpgradeCost";
            this.UpgradeCost.Size = new System.Drawing.Size(156, 75);
            this.UpgradeCost.TabIndex = 39;
            this.UpgradeCost.TabStop = false;
            this.UpgradeCost.Text = "Cost";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(120, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 15);
            this.label16.TabIndex = 24;
            this.label16.Text = "1";
            // 
            // trackBar16
            // 
            this.trackBar16.LargeChange = 10;
            this.trackBar16.Location = new System.Drawing.Point(6, 20);
            this.trackBar16.Maximum = 1000;
            this.trackBar16.Name = "trackBar16";
            this.trackBar16.Size = new System.Drawing.Size(142, 45);
            this.trackBar16.TabIndex = 23;
            this.trackBar16.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar16.Value = 1;
            this.trackBar16.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar16.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeWeight
            // 
            this.upgradeWeight.Controls.Add(this.label15);
            this.upgradeWeight.Controls.Add(this.trackBar15);
            this.upgradeWeight.Location = new System.Drawing.Point(626, 367);
            this.upgradeWeight.Name = "upgradeWeight";
            this.upgradeWeight.Size = new System.Drawing.Size(156, 75);
            this.upgradeWeight.TabIndex = 38;
            this.upgradeWeight.TabStop = false;
            this.upgradeWeight.Text = "Weight in random pool";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(120, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(12, 15);
            this.label15.TabIndex = 24;
            this.label15.Text = "1";
            // 
            // trackBar15
            // 
            this.trackBar15.LargeChange = 10;
            this.trackBar15.Location = new System.Drawing.Point(6, 20);
            this.trackBar15.Name = "trackBar15";
            this.trackBar15.Size = new System.Drawing.Size(142, 45);
            this.trackBar15.TabIndex = 23;
            this.trackBar15.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar15.Value = 1;
            this.trackBar15.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar15.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeJump
            // 
            this.upgradeJump.AutoSize = true;
            this.upgradeJump.Location = new System.Drawing.Point(504, 448);
            this.upgradeJump.Name = "upgradeJump";
            this.upgradeJump.Size = new System.Drawing.Size(73, 19);
            this.upgradeJump.TabIndex = 37;
            this.upgradeJump.Text = "Add jump";
            this.upgradeJump.UseVisualStyleBackColor = true;
            this.upgradeJump.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeKnockResist
            // 
            this.upgradeKnockResist.Controls.Add(this.label14);
            this.upgradeKnockResist.Controls.Add(this.checkBox14);
            this.upgradeKnockResist.Controls.Add(this.trackBar14);
            this.upgradeKnockResist.Location = new System.Drawing.Point(464, 367);
            this.upgradeKnockResist.Name = "upgradeKnockResist";
            this.upgradeKnockResist.Size = new System.Drawing.Size(156, 75);
            this.upgradeKnockResist.TabIndex = 36;
            this.upgradeKnockResist.TabStop = false;
            this.upgradeKnockResist.Text = "Knockback resist modifier";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(120, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "0";
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox14.Location = new System.Drawing.Point(6, 46);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(77, 19);
            this.checkBox14.TabIndex = 22;
            this.checkBox14.Text = "Multiplier";
            this.checkBox14.UseVisualStyleBackColor = false;
            this.checkBox14.CheckedChanged += new System.EventHandler(this.multiplier_CheckedChanged);
            // 
            // trackBar14
            // 
            this.trackBar14.LargeChange = 10;
            this.trackBar14.Location = new System.Drawing.Point(6, 20);
            this.trackBar14.Maximum = 20;
            this.trackBar14.Minimum = -20;
            this.trackBar14.Name = "trackBar14";
            this.trackBar14.Size = new System.Drawing.Size(142, 45);
            this.trackBar14.TabIndex = 23;
            this.trackBar14.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar14.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar14.DragLeave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeKnock
            // 
            this.upgradeKnock.Controls.Add(this.label13);
            this.upgradeKnock.Controls.Add(this.checkBox13);
            this.upgradeKnock.Controls.Add(this.trackBar13);
            this.upgradeKnock.Location = new System.Drawing.Point(302, 367);
            this.upgradeKnock.Name = "upgradeKnock";
            this.upgradeKnock.Size = new System.Drawing.Size(156, 75);
            this.upgradeKnock.TabIndex = 35;
            this.upgradeKnock.TabStop = false;
            this.upgradeKnock.Text = "Knockback modifier";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(120, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "0";
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox13.Location = new System.Drawing.Point(6, 46);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(77, 19);
            this.checkBox13.TabIndex = 22;
            this.checkBox13.Text = "Multiplier";
            this.checkBox13.UseVisualStyleBackColor = false;
            this.checkBox13.CheckedChanged += new System.EventHandler(this.multiplier_CheckedChanged);
            // 
            // trackBar13
            // 
            this.trackBar13.LargeChange = 10;
            this.trackBar13.Location = new System.Drawing.Point(6, 20);
            this.trackBar13.Maximum = 20;
            this.trackBar13.Minimum = -20;
            this.trackBar13.Name = "trackBar13";
            this.trackBar13.Size = new System.Drawing.Size(142, 45);
            this.trackBar13.TabIndex = 23;
            this.trackBar13.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar13.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar13.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeHealthRegen
            // 
            this.upgradeHealthRegen.Controls.Add(this.label12);
            this.upgradeHealthRegen.Controls.Add(this.checkBox12);
            this.upgradeHealthRegen.Controls.Add(this.trackBar12);
            this.upgradeHealthRegen.Location = new System.Drawing.Point(626, 286);
            this.upgradeHealthRegen.Name = "upgradeHealthRegen";
            this.upgradeHealthRegen.Size = new System.Drawing.Size(156, 75);
            this.upgradeHealthRegen.TabIndex = 34;
            this.upgradeHealthRegen.TabStop = false;
            this.upgradeHealthRegen.Text = "Health regen modifier";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(120, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "0";
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox12.Location = new System.Drawing.Point(6, 46);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(77, 19);
            this.checkBox12.TabIndex = 22;
            this.checkBox12.Text = "Multiplier";
            this.checkBox12.UseVisualStyleBackColor = false;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.multiplier_DecCheckedChanged);
            // 
            // trackBar12
            // 
            this.trackBar12.LargeChange = 10;
            this.trackBar12.Location = new System.Drawing.Point(6, 20);
            this.trackBar12.Maximum = 2000;
            this.trackBar12.Minimum = -2000;
            this.trackBar12.Name = "trackBar12";
            this.trackBar12.Size = new System.Drawing.Size(142, 45);
            this.trackBar12.TabIndex = 23;
            this.trackBar12.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar12.ValueChanged += new System.EventHandler(this.trackBar_DecScroll);
            this.trackBar12.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeHealth
            // 
            this.upgradeHealth.Controls.Add(this.label11);
            this.upgradeHealth.Controls.Add(this.checkBox11);
            this.upgradeHealth.Controls.Add(this.trackBar11);
            this.upgradeHealth.Location = new System.Drawing.Point(464, 286);
            this.upgradeHealth.Name = "upgradeHealth";
            this.upgradeHealth.Size = new System.Drawing.Size(156, 75);
            this.upgradeHealth.TabIndex = 33;
            this.upgradeHealth.TabStop = false;
            this.upgradeHealth.Text = "Health modifier";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(120, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "0";
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox11.Location = new System.Drawing.Point(6, 46);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(77, 19);
            this.checkBox11.TabIndex = 22;
            this.checkBox11.Text = "Multiplier";
            this.checkBox11.UseVisualStyleBackColor = false;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.multiplier_CheckedChanged);
            // 
            // trackBar11
            // 
            this.trackBar11.LargeChange = 10;
            this.trackBar11.Location = new System.Drawing.Point(6, 20);
            this.trackBar11.Maximum = 20;
            this.trackBar11.Minimum = -20;
            this.trackBar11.Name = "trackBar11";
            this.trackBar11.Size = new System.Drawing.Size(142, 45);
            this.trackBar11.TabIndex = 23;
            this.trackBar11.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar11.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar11.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeShieldCool
            // 
            this.upgradeShieldCool.Controls.Add(this.label10);
            this.upgradeShieldCool.Controls.Add(this.checkBox10);
            this.upgradeShieldCool.Controls.Add(this.trackBar10);
            this.upgradeShieldCool.Location = new System.Drawing.Point(302, 286);
            this.upgradeShieldCool.Name = "upgradeShieldCool";
            this.upgradeShieldCool.Size = new System.Drawing.Size(156, 75);
            this.upgradeShieldCool.TabIndex = 32;
            this.upgradeShieldCool.TabStop = false;
            this.upgradeShieldCool.Text = "Shield cooldown modifier";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(120, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "0";
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox10.Location = new System.Drawing.Point(6, 46);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(77, 19);
            this.checkBox10.TabIndex = 22;
            this.checkBox10.Text = "Multiplier";
            this.checkBox10.UseVisualStyleBackColor = false;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.multiplier_DecCheckedChanged);
            // 
            // trackBar10
            // 
            this.trackBar10.LargeChange = 10;
            this.trackBar10.Location = new System.Drawing.Point(6, 20);
            this.trackBar10.Maximum = 2000;
            this.trackBar10.Minimum = -2000;
            this.trackBar10.Name = "trackBar10";
            this.trackBar10.Size = new System.Drawing.Size(142, 45);
            this.trackBar10.TabIndex = 23;
            this.trackBar10.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar10.Value = 1;
            this.trackBar10.ValueChanged += new System.EventHandler(this.trackBar_DecScroll);
            this.trackBar10.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeShieldRegen
            // 
            this.upgradeShieldRegen.Controls.Add(this.label9);
            this.upgradeShieldRegen.Controls.Add(this.checkBox9);
            this.upgradeShieldRegen.Controls.Add(this.trackBar9);
            this.upgradeShieldRegen.Location = new System.Drawing.Point(626, 205);
            this.upgradeShieldRegen.Name = "upgradeShieldRegen";
            this.upgradeShieldRegen.Size = new System.Drawing.Size(156, 75);
            this.upgradeShieldRegen.TabIndex = 31;
            this.upgradeShieldRegen.TabStop = false;
            this.upgradeShieldRegen.Text = "Shield regen modifier";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(120, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "0";
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox9.Location = new System.Drawing.Point(6, 46);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(77, 19);
            this.checkBox9.TabIndex = 22;
            this.checkBox9.Text = "Multiplier";
            this.checkBox9.UseVisualStyleBackColor = false;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.multiplier_DecCheckedChanged);
            // 
            // trackBar9
            // 
            this.trackBar9.LargeChange = 10;
            this.trackBar9.Location = new System.Drawing.Point(6, 20);
            this.trackBar9.Maximum = 2000;
            this.trackBar9.Minimum = -2000;
            this.trackBar9.Name = "trackBar9";
            this.trackBar9.Size = new System.Drawing.Size(142, 45);
            this.trackBar9.TabIndex = 23;
            this.trackBar9.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar9.ValueChanged += new System.EventHandler(this.trackBar_DecScroll);
            this.trackBar9.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeShieldHealth
            // 
            this.upgradeShieldHealth.Controls.Add(this.label8);
            this.upgradeShieldHealth.Controls.Add(this.checkBox8);
            this.upgradeShieldHealth.Controls.Add(this.trackBar8);
            this.upgradeShieldHealth.Location = new System.Drawing.Point(464, 205);
            this.upgradeShieldHealth.Name = "upgradeShieldHealth";
            this.upgradeShieldHealth.Size = new System.Drawing.Size(156, 75);
            this.upgradeShieldHealth.TabIndex = 30;
            this.upgradeShieldHealth.TabStop = false;
            this.upgradeShieldHealth.Text = "Shield health modifier";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(120, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "0";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox8.Location = new System.Drawing.Point(6, 46);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(77, 19);
            this.checkBox8.TabIndex = 22;
            this.checkBox8.Text = "Multiplier";
            this.checkBox8.UseVisualStyleBackColor = false;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.multiplier_CheckedChanged);
            // 
            // trackBar8
            // 
            this.trackBar8.LargeChange = 10;
            this.trackBar8.Location = new System.Drawing.Point(6, 20);
            this.trackBar8.Maximum = 20;
            this.trackBar8.Minimum = -20;
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Size = new System.Drawing.Size(142, 45);
            this.trackBar8.TabIndex = 23;
            this.trackBar8.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar8.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar8.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeProjHome
            // 
            this.upgradeProjHome.Controls.Add(this.label7);
            this.upgradeProjHome.Controls.Add(this.checkBox7);
            this.upgradeProjHome.Controls.Add(this.trackBar7);
            this.upgradeProjHome.Font = new System.Drawing.Font("Comic Sans MS", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgradeProjHome.Location = new System.Drawing.Point(302, 205);
            this.upgradeProjHome.Name = "upgradeProjHome";
            this.upgradeProjHome.Size = new System.Drawing.Size(156, 75);
            this.upgradeProjHome.TabIndex = 29;
            this.upgradeProjHome.TabStop = false;
            this.upgradeProjHome.Text = "Projectile homing modifier";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(120, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 14);
            this.label7.TabIndex = 24;
            this.label7.Text = "0";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox7.Location = new System.Drawing.Point(6, 46);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(73, 18);
            this.checkBox7.TabIndex = 22;
            this.checkBox7.Text = "Multiplier";
            this.checkBox7.UseVisualStyleBackColor = false;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.multiplier_DecCheckedChanged);
            // 
            // trackBar7
            // 
            this.trackBar7.LargeChange = 10;
            this.trackBar7.Location = new System.Drawing.Point(6, 20);
            this.trackBar7.Maximum = 2000;
            this.trackBar7.Minimum = -2000;
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Size = new System.Drawing.Size(142, 45);
            this.trackBar7.TabIndex = 23;
            this.trackBar7.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar7.ValueChanged += new System.EventHandler(this.trackBar_DecScroll);
            this.trackBar7.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeProjSpread
            // 
            this.upgradeProjSpread.Controls.Add(this.label6);
            this.upgradeProjSpread.Controls.Add(this.checkBox6);
            this.upgradeProjSpread.Controls.Add(this.trackBar6);
            this.upgradeProjSpread.Location = new System.Drawing.Point(626, 124);
            this.upgradeProjSpread.Name = "upgradeProjSpread";
            this.upgradeProjSpread.Size = new System.Drawing.Size(156, 75);
            this.upgradeProjSpread.TabIndex = 28;
            this.upgradeProjSpread.TabStop = false;
            this.upgradeProjSpread.Text = "Projectile spread modifier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(120, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "0";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox6.Location = new System.Drawing.Point(6, 46);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(77, 19);
            this.checkBox6.TabIndex = 22;
            this.checkBox6.Text = "Multiplier";
            this.checkBox6.UseVisualStyleBackColor = false;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.multiplier_DecCheckedChanged);
            // 
            // trackBar6
            // 
            this.trackBar6.LargeChange = 10;
            this.trackBar6.Location = new System.Drawing.Point(6, 20);
            this.trackBar6.Maximum = 2000;
            this.trackBar6.Minimum = -2000;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(142, 45);
            this.trackBar6.TabIndex = 23;
            this.trackBar6.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar6.ValueChanged += new System.EventHandler(this.trackBar_DecScroll);
            this.trackBar6.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeProjSize
            // 
            this.upgradeProjSize.Controls.Add(this.label5);
            this.upgradeProjSize.Controls.Add(this.checkBox5);
            this.upgradeProjSize.Controls.Add(this.trackBar5);
            this.upgradeProjSize.Location = new System.Drawing.Point(464, 124);
            this.upgradeProjSize.Name = "upgradeProjSize";
            this.upgradeProjSize.Size = new System.Drawing.Size(156, 75);
            this.upgradeProjSize.TabIndex = 27;
            this.upgradeProjSize.TabStop = false;
            this.upgradeProjSize.Text = "Projectle size modifier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(120, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "1.0";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoCheck = false;
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(6, 46);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(77, 19);
            this.checkBox5.TabIndex = 22;
            this.checkBox5.Text = "Multiplier";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // trackBar5
            // 
            this.trackBar5.LargeChange = 10;
            this.trackBar5.Location = new System.Drawing.Point(6, 20);
            this.trackBar5.Maximum = 300;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(142, 45);
            this.trackBar5.TabIndex = 23;
            this.trackBar5.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar5.Value = 1;
            this.trackBar5.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar5.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeProjSpeed
            // 
            this.upgradeProjSpeed.Controls.Add(this.label4);
            this.upgradeProjSpeed.Controls.Add(this.checkBox4);
            this.upgradeProjSpeed.Controls.Add(this.trackBar4);
            this.upgradeProjSpeed.Location = new System.Drawing.Point(302, 124);
            this.upgradeProjSpeed.Name = "upgradeProjSpeed";
            this.upgradeProjSpeed.Size = new System.Drawing.Size(156, 75);
            this.upgradeProjSpeed.TabIndex = 26;
            this.upgradeProjSpeed.TabStop = false;
            this.upgradeProjSpeed.Text = "Projectile speed modifier";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(120, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "0";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox4.Location = new System.Drawing.Point(6, 46);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(77, 19);
            this.checkBox4.TabIndex = 22;
            this.checkBox4.Text = "Multiplier";
            this.checkBox4.UseVisualStyleBackColor = false;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.multiplier_CheckedChanged);
            // 
            // trackBar4
            // 
            this.trackBar4.LargeChange = 10;
            this.trackBar4.Location = new System.Drawing.Point(6, 20);
            this.trackBar4.Maximum = 20;
            this.trackBar4.Minimum = -20;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(142, 45);
            this.trackBar4.TabIndex = 23;
            this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar4.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar4.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeROF
            // 
            this.upgradeROF.Controls.Add(this.label3);
            this.upgradeROF.Controls.Add(this.checkBox3);
            this.upgradeROF.Controls.Add(this.trackBar3);
            this.upgradeROF.Location = new System.Drawing.Point(626, 43);
            this.upgradeROF.Name = "upgradeROF";
            this.upgradeROF.Size = new System.Drawing.Size(156, 75);
            this.upgradeROF.TabIndex = 25;
            this.upgradeROF.TabStop = false;
            this.upgradeROF.Text = "Rate of fire modifier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(120, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "0";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox3.Location = new System.Drawing.Point(6, 46);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(77, 19);
            this.checkBox3.TabIndex = 22;
            this.checkBox3.Text = "Multiplier";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.multiplier_DecCheckedChanged);
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 10;
            this.trackBar3.Location = new System.Drawing.Point(6, 20);
            this.trackBar3.Maximum = 2000;
            this.trackBar3.Minimum = -2000;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(142, 45);
            this.trackBar3.TabIndex = 23;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar_DecScroll);
            this.trackBar3.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeProjCount
            // 
            this.upgradeProjCount.Controls.Add(this.label1);
            this.upgradeProjCount.Controls.Add(this.checkBox2);
            this.upgradeProjCount.Controls.Add(this.trackBar2);
            this.upgradeProjCount.Location = new System.Drawing.Point(464, 43);
            this.upgradeProjCount.Name = "upgradeProjCount";
            this.upgradeProjCount.Size = new System.Drawing.Size(156, 75);
            this.upgradeProjCount.TabIndex = 25;
            this.upgradeProjCount.TabStop = false;
            this.upgradeProjCount.Text = "Projectile count modifier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(120, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "0";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox2.Location = new System.Drawing.Point(6, 46);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(77, 19);
            this.checkBox2.TabIndex = 22;
            this.checkBox2.Text = "Multiplier";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.multiplier_CheckedChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 10;
            this.trackBar2.Location = new System.Drawing.Point(6, 20);
            this.trackBar2.Maximum = 20;
            this.trackBar2.Minimum = -20;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(142, 45);
            this.trackBar2.TabIndex = 23;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar2.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeDmg
            // 
            this.upgradeDmg.Controls.Add(this.label2);
            this.upgradeDmg.Controls.Add(this.UpgradeDmgMult);
            this.upgradeDmg.Controls.Add(this.UpgradeDmgSlider);
            this.upgradeDmg.Location = new System.Drawing.Point(302, 43);
            this.upgradeDmg.Name = "upgradeDmg";
            this.upgradeDmg.Size = new System.Drawing.Size(156, 75);
            this.upgradeDmg.TabIndex = 22;
            this.upgradeDmg.TabStop = false;
            this.upgradeDmg.Text = "Damage modifier";
            this.toolTip1.SetToolTip(this.upgradeDmg, "Adds to, subtracts from, or multiplies the damage value of the players current we" +
        "apon.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(120, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "0";
            // 
            // UpgradeDmgMult
            // 
            this.UpgradeDmgMult.AutoSize = true;
            this.UpgradeDmgMult.BackColor = System.Drawing.SystemColors.Control;
            this.UpgradeDmgMult.Location = new System.Drawing.Point(6, 46);
            this.UpgradeDmgMult.Name = "UpgradeDmgMult";
            this.UpgradeDmgMult.Size = new System.Drawing.Size(77, 19);
            this.UpgradeDmgMult.TabIndex = 22;
            this.UpgradeDmgMult.Text = "Multiplier";
            this.UpgradeDmgMult.UseVisualStyleBackColor = false;
            this.UpgradeDmgMult.CheckedChanged += new System.EventHandler(this.multiplier_CheckedChanged);
            // 
            // UpgradeDmgSlider
            // 
            this.UpgradeDmgSlider.LargeChange = 10;
            this.UpgradeDmgSlider.Location = new System.Drawing.Point(6, 20);
            this.UpgradeDmgSlider.Maximum = 20;
            this.UpgradeDmgSlider.Minimum = -20;
            this.UpgradeDmgSlider.Name = "UpgradeDmgSlider";
            this.UpgradeDmgSlider.Size = new System.Drawing.Size(142, 45);
            this.UpgradeDmgSlider.TabIndex = 23;
            this.UpgradeDmgSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.UpgradeDmgSlider.ValueChanged += new System.EventHandler(this.trackBar_Scroll);
            this.UpgradeDmgSlider.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // newUpgradeBtn
            // 
            this.newUpgradeBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUpgradeBtn.Location = new System.Drawing.Point(6, 446);
            this.newUpgradeBtn.Name = "newUpgradeBtn";
            this.newUpgradeBtn.Size = new System.Drawing.Size(145, 40);
            this.newUpgradeBtn.TabIndex = 17;
            this.newUpgradeBtn.Text = "New upgrade";
            this.newUpgradeBtn.UseVisualStyleBackColor = true;
            this.newUpgradeBtn.Click += new System.EventHandler(this.newUpgradeBtn_Click);
            // 
            // upgradeDesc
            // 
            this.upgradeDesc.AcceptsReturn = true;
            this.upgradeDesc.Location = new System.Drawing.Point(808, 86);
            this.upgradeDesc.Multiline = true;
            this.upgradeDesc.Name = "upgradeDesc";
            this.upgradeDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.upgradeDesc.Size = new System.Drawing.Size(266, 159);
            this.upgradeDesc.TabIndex = 16;
            this.upgradeDesc.Text = "Select an upgrade to edit its description.";
            this.upgradeDesc.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeName
            // 
            this.upgradeName.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgradeName.Location = new System.Drawing.Point(853, 43);
            this.upgradeName.Name = "upgradeName";
            this.upgradeName.Size = new System.Drawing.Size(182, 30);
            this.upgradeName.TabIndex = 15;
            this.upgradeName.Text = "Select an upgrade";
            this.upgradeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.upgradeName.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeImageDrop
            // 
            this.upgradeImageDrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.upgradeImageDrop.DropDownWidth = 150;
            this.upgradeImageDrop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.upgradeImageDrop.FormattingEnabled = true;
            this.upgradeImageDrop.Location = new System.Drawing.Point(157, 112);
            this.upgradeImageDrop.Name = "upgradeImageDrop";
            this.upgradeImageDrop.Size = new System.Drawing.Size(100, 23);
            this.upgradeImageDrop.TabIndex = 2;
            this.upgradeImageDrop.SelectedIndexChanged += new System.EventHandler(this.upgradeImageDrop_SelectedIndexChanged);
            this.upgradeImageDrop.Leave += new System.EventHandler(this.UpdateUpgrade);
            // 
            // upgradeIcon
            // 
            this.upgradeIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.upgradeIcon.Image = ((System.Drawing.Image)(resources.GetObject("upgradeIcon.Image")));
            this.upgradeIcon.Location = new System.Drawing.Point(157, 6);
            this.upgradeIcon.Name = "upgradeIcon";
            this.upgradeIcon.Size = new System.Drawing.Size(100, 100);
            this.upgradeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.upgradeIcon.TabIndex = 1;
            this.upgradeIcon.TabStop = false;
            // 
            // upgradeList
            // 
            this.upgradeList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.upgradeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader});
            this.upgradeList.HideSelection = false;
            this.upgradeList.LabelEdit = true;
            this.upgradeList.Location = new System.Drawing.Point(6, 6);
            this.upgradeList.MultiSelect = false;
            this.upgradeList.Name = "upgradeList";
            this.upgradeList.Size = new System.Drawing.Size(145, 480);
            this.upgradeList.TabIndex = 0;
            this.upgradeList.UseCompatibleStateImageBehavior = false;
            this.upgradeList.View = System.Windows.Forms.View.Details;
            this.upgradeList.ItemActivate += new System.EventHandler(this.upgradeList_SelectedIndexChanged);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Upgrade name";
            this.nameHeader.Width = 140;
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
            // upgradeIcons
            // 
            this.upgradeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.upgradeIcons.ImageSize = new System.Drawing.Size(100, 100);
            this.upgradeIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // enemyIcons
            // 
            this.enemyIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("enemyIcons.ImageStream")));
            this.enemyIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.enemyIcons.Images.SetKeyName(0, "GoldSlime.png");
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabSystem.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.mapDivider.Panel1.ResumeLayout(false);
            this.mapDivider.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapDivider)).EndInit();
            this.mapDivider.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBackground)).EndInit();
            this.upgradesTab.ResumeLayout(false);
            this.upgradesTab.PerformLayout();
            this.UpgradeCost.ResumeLayout(false);
            this.UpgradeCost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar16)).EndInit();
            this.upgradeWeight.ResumeLayout(false);
            this.upgradeWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar15)).EndInit();
            this.upgradeKnockResist.ResumeLayout(false);
            this.upgradeKnockResist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar14)).EndInit();
            this.upgradeKnock.ResumeLayout(false);
            this.upgradeKnock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar13)).EndInit();
            this.upgradeHealthRegen.ResumeLayout(false);
            this.upgradeHealthRegen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar12)).EndInit();
            this.upgradeHealth.ResumeLayout(false);
            this.upgradeHealth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar11)).EndInit();
            this.upgradeShieldCool.ResumeLayout(false);
            this.upgradeShieldCool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).EndInit();
            this.upgradeShieldRegen.ResumeLayout(false);
            this.upgradeShieldRegen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).EndInit();
            this.upgradeShieldHealth.ResumeLayout(false);
            this.upgradeShieldHealth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            this.upgradeProjHome.ResumeLayout(false);
            this.upgradeProjHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            this.upgradeProjSpread.ResumeLayout(false);
            this.upgradeProjSpread.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            this.upgradeProjSize.ResumeLayout(false);
            this.upgradeProjSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            this.upgradeProjSpeed.ResumeLayout(false);
            this.upgradeProjSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.upgradeROF.ResumeLayout(false);
            this.upgradeROF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.upgradeProjCount.ResumeLayout(false);
            this.upgradeProjCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.upgradeDmg.ResumeLayout(false);
            this.upgradeDmg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpgradeDmgSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upgradeIcon)).EndInit();
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
        private System.Windows.Forms.ListView upgradeList;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ComboBox upgradeImageDrop;
        private System.Windows.Forms.PictureBox upgradeIcon;
        private System.Windows.Forms.GroupBox upgradeDmg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox UpgradeDmgMult;
        private System.Windows.Forms.TrackBar UpgradeDmgSlider;
        private System.Windows.Forms.Button newUpgradeBtn;
        private System.Windows.Forms.TextBox upgradeDesc;
        private System.Windows.Forms.TextBox upgradeName;
        private System.Windows.Forms.GroupBox upgradeROF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.GroupBox upgradeProjCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.GroupBox upgradeProjHome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.GroupBox upgradeProjSpread;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.GroupBox upgradeProjSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.GroupBox upgradeProjSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.GroupBox upgradeShieldHealth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.GroupBox upgradeShieldRegen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.TrackBar trackBar9;
        private System.Windows.Forms.GroupBox upgradeShieldCool;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.TrackBar trackBar10;
        private System.Windows.Forms.GroupBox upgradeHealthRegen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.TrackBar trackBar12;
        private System.Windows.Forms.GroupBox upgradeHealth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.TrackBar trackBar11;
        private System.Windows.Forms.GroupBox upgradeKnockResist;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.TrackBar trackBar14;
        private System.Windows.Forms.GroupBox upgradeKnock;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.TrackBar trackBar13;
        private System.Windows.Forms.GroupBox UpgradeCost;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar trackBar16;
        private System.Windows.Forms.GroupBox upgradeWeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar trackBar15;
        private System.Windows.Forms.CheckBox upgradeJump;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList upgradeIcons;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown waveCounter;
        private System.Windows.Forms.ImageList enemyIcons;
        private System.Windows.Forms.ComboBox enemySelect;
    }
}