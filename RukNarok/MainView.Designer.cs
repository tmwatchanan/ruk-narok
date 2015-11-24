namespace RukNarok
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.tmrCharacterWalking = new System.Windows.Forms.Timer(this.components);
            this.tmrCharacterAttacking = new System.Windows.Forms.Timer(this.components);
            this.tmrMenu = new System.Windows.Forms.Timer(this.components);
            this.tmrMonster1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMap = new System.Windows.Forms.Panel();
            this.lblHealthBar = new System.Windows.Forms.Label();
            this.boxStatus = new System.Windows.Forms.GroupBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.picQuestMenu = new System.Windows.Forms.PictureBox();
            this.picInventoryMenu = new System.Windows.Forms.PictureBox();
            this.picSkillMenu = new System.Windows.Forms.PictureBox();
            this.picStatusMenu = new System.Windows.Forms.PictureBox();
            this.picMonster1 = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.pnlMap.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventoryMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkillMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonster1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrCharacterWalking
            // 
            this.tmrCharacterWalking.Interval = 10;
            this.tmrCharacterWalking.Tick += new System.EventHandler(this.tmrCharacterWalking_Tick);
            // 
            // tmrCharacterAttacking
            // 
            this.tmrCharacterAttacking.Interval = 200;
            this.tmrCharacterAttacking.Tick += new System.EventHandler(this.tmrCharacterAttacking_Tick);
            // 
            // tmrMenu
            // 
            this.tmrMenu.Interval = 10;
            this.tmrMenu.Tick += new System.EventHandler(this.tmrMenu_Tick);
            // 
            // tmrMonster1
            // 
            this.tmrMonster1.Interval = 20;
            this.tmrMonster1.Tick += new System.EventHandler(this.tmrMonster1_Tick);
            // 
            // pnlMap
            // 
            this.pnlMap.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMap.BackgroundImage = global::RukNarok.Properties.Resources.GrassBG;
            this.pnlMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMap.Controls.Add(this.picAvatar);
            this.pnlMap.Controls.Add(this.lblHealthBar);
            this.pnlMap.Controls.Add(this.boxStatus);
            this.pnlMap.Controls.Add(this.pnlMenu);
            this.pnlMap.Controls.Add(this.picMonster1);
            this.pnlMap.Controls.Add(this.picPlayer);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(0, 0);
            this.pnlMap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(800, 600);
            this.pnlMap.TabIndex = 0;
            this.pnlMap.Visible = false;
            // 
            // lblHealthBar
            // 
            this.lblHealthBar.AutoSize = true;
            this.lblHealthBar.BackColor = System.Drawing.Color.Red;
            this.lblHealthBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHealthBar.Location = new System.Drawing.Point(355, 205);
            this.lblHealthBar.Name = "lblHealthBar";
            this.lblHealthBar.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.lblHealthBar.Size = new System.Drawing.Size(72, 13);
            this.lblHealthBar.TabIndex = 6;
            this.lblHealthBar.Text = "HP";
            this.lblHealthBar.Visible = false;
            // 
            // boxStatus
            // 
            this.boxStatus.Location = new System.Drawing.Point(769, 130);
            this.boxStatus.Name = "boxStatus";
            this.boxStatus.Size = new System.Drawing.Size(470, 308);
            this.boxStatus.TabIndex = 5;
            this.boxStatus.TabStop = false;
            this.boxStatus.Text = "Status";
            this.boxStatus.Visible = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.BackgroundImage = global::RukNarok.Properties.Resources.LegendMenu;
            this.pnlMenu.Controls.Add(this.picQuestMenu);
            this.pnlMenu.Controls.Add(this.picInventoryMenu);
            this.pnlMenu.Controls.Add(this.picSkillMenu);
            this.pnlMenu.Controls.Add(this.picStatusMenu);
            this.pnlMenu.Location = new System.Drawing.Point(72, 521);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(655, 79);
            this.pnlMenu.TabIndex = 1;
            // 
            // picQuestMenu
            // 
            this.picQuestMenu.Image = ((System.Drawing.Image)(resources.GetObject("picQuestMenu.Image")));
            this.picQuestMenu.Location = new System.Drawing.Point(442, 15);
            this.picQuestMenu.Name = "picQuestMenu";
            this.picQuestMenu.Size = new System.Drawing.Size(57, 61);
            this.picQuestMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuestMenu.TabIndex = 4;
            this.picQuestMenu.TabStop = false;
            this.picQuestMenu.Click += new System.EventHandler(this.picQuestMenu_Click);
            // 
            // picInventoryMenu
            // 
            this.picInventoryMenu.Image = global::RukNarok.Properties.Resources.InventoryMenu;
            this.picInventoryMenu.Location = new System.Drawing.Point(331, 8);
            this.picInventoryMenu.Name = "picInventoryMenu";
            this.picInventoryMenu.Size = new System.Drawing.Size(62, 79);
            this.picInventoryMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInventoryMenu.TabIndex = 3;
            this.picInventoryMenu.TabStop = false;
            this.picInventoryMenu.Click += new System.EventHandler(this.picInventoryMenu_Click);
            // 
            // picSkillMenu
            // 
            this.picSkillMenu.Image = global::RukNarok.Properties.Resources.SkillMenu;
            this.picSkillMenu.Location = new System.Drawing.Point(221, -1);
            this.picSkillMenu.Name = "picSkillMenu";
            this.picSkillMenu.Size = new System.Drawing.Size(75, 97);
            this.picSkillMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSkillMenu.TabIndex = 2;
            this.picSkillMenu.TabStop = false;
            this.picSkillMenu.Click += new System.EventHandler(this.picSkillMenu_Click);
            // 
            // picStatusMenu
            // 
            this.picStatusMenu.Image = global::RukNarok.Properties.Resources.StatusMenu;
            this.picStatusMenu.Location = new System.Drawing.Point(133, 9);
            this.picStatusMenu.Name = "picStatusMenu";
            this.picStatusMenu.Size = new System.Drawing.Size(67, 79);
            this.picStatusMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatusMenu.TabIndex = 0;
            this.picStatusMenu.TabStop = false;
            this.picStatusMenu.Click += new System.EventHandler(this.picStatusMenu_Click);
            // 
            // picMonster1
            // 
            this.picMonster1.BackColor = System.Drawing.Color.Transparent;
            this.picMonster1.Location = new System.Drawing.Point(501, 242);
            this.picMonster1.Name = "picMonster1";
            this.picMonster1.Size = new System.Drawing.Size(55, 55);
            this.picMonster1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMonster1.TabIndex = 7;
            this.picMonster1.TabStop = false;
            this.picMonster1.Visible = false;
            // 
            // picPlayer
            // 
            this.picPlayer.BackColor = System.Drawing.Color.Transparent;
            this.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picPlayer.Image = global::RukNarok.Properties.Resources.NoviceStandSouth;
            this.picPlayer.Location = new System.Drawing.Point(350, 227);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(80, 92);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            this.picPlayer.Visible = false;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.Image = global::RukNarok.Properties.Resources.LegendAvatar;
            this.picAvatar.Location = new System.Drawing.Point(0, 0);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(100, 100);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAvatar.TabIndex = 8;
            this.picAvatar.TabStop = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruk Narok v.0";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.MainView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyUp);
            this.pnlMap.ResumeLayout(false);
            this.pnlMap.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQuestMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventoryMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkillMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonster1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Timer tmrCharacterWalking;
        private System.Windows.Forms.Timer tmrCharacterAttacking;
        private System.Windows.Forms.Timer tmrMenu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox picQuestMenu;
        private System.Windows.Forms.PictureBox picInventoryMenu;
        private System.Windows.Forms.PictureBox picSkillMenu;
        private System.Windows.Forms.PictureBox picStatusMenu;
        private System.Windows.Forms.GroupBox boxStatus;
        private System.Windows.Forms.Label lblHealthBar;
        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.PictureBox picMonster1;
        private System.Windows.Forms.Timer tmrMonster1;
        private System.Windows.Forms.PictureBox picAvatar;
    }
}