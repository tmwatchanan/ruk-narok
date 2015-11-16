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
            this.tmrCharacterWalking = new System.Windows.Forms.Timer(this.components);
            this.tmrCharacterAttacking = new System.Windows.Forms.Timer(this.components);
            this.tmrMenu = new System.Windows.Forms.Timer(this.components);
            this.pnlMap = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.picQuestMenu = new System.Windows.Forms.PictureBox();
            this.picInventoryMenu = new System.Windows.Forms.PictureBox();
            this.picSkillMenu = new System.Windows.Forms.PictureBox();
            this.picStatusMenu = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMap.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventoryMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkillMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            this.panel1.SuspendLayout();
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
            // pnlMap
            // 
            this.pnlMap.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMap.BackgroundImage = global::RukNarok.Properties.Resources.GrassBG;
            this.pnlMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMap.Controls.Add(this.panel1);
            this.pnlMap.Controls.Add(this.pnlMenu);
            this.pnlMap.Controls.Add(this.picPlayer);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(0, 0);
            this.pnlMap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(800, 600);
            this.pnlMap.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.BackgroundImage = global::RukNarok.Properties.Resources.MenuBackground;
            this.pnlMenu.Controls.Add(this.picQuestMenu);
            this.pnlMenu.Controls.Add(this.picInventoryMenu);
            this.pnlMenu.Controls.Add(this.picSkillMenu);
            this.pnlMenu.Controls.Add(this.picStatusMenu);
            this.pnlMenu.Location = new System.Drawing.Point(88, 512);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(624, 88);
            this.pnlMenu.TabIndex = 1;
            // 
            // picQuestMenu
            // 
            this.picQuestMenu.Image = global::RukNarok.Properties.Resources.QuestMenu;
            this.picQuestMenu.Location = new System.Drawing.Point(441, 18);
            this.picQuestMenu.Name = "picQuestMenu";
            this.picQuestMenu.Size = new System.Drawing.Size(61, 70);
            this.picQuestMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuestMenu.TabIndex = 4;
            this.picQuestMenu.TabStop = false;
            this.picQuestMenu.Click += new System.EventHandler(this.picQuestMenu_Click);
            // 
            // picInventoryMenu
            // 
            this.picInventoryMenu.Image = global::RukNarok.Properties.Resources.InventoryMenu;
            this.picInventoryMenu.Location = new System.Drawing.Point(341, 9);
            this.picInventoryMenu.Name = "picInventoryMenu";
            this.picInventoryMenu.Size = new System.Drawing.Size(70, 88);
            this.picInventoryMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInventoryMenu.TabIndex = 3;
            this.picInventoryMenu.TabStop = false;
            this.picInventoryMenu.Click += new System.EventHandler(this.picInventoryMenu_Click);
            // 
            // picSkillMenu
            // 
            this.picSkillMenu.Image = global::RukNarok.Properties.Resources.SkillMenu;
            this.picSkillMenu.Location = new System.Drawing.Point(225, 3);
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
            // picPlayer
            // 
            this.picPlayer.BackColor = System.Drawing.Color.Transparent;
            this.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picPlayer.Image = global::RukNarok.Properties.Resources.NoviceStandFront;
            this.picPlayer.Location = new System.Drawing.Point(279, 150);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(80, 92);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.ForeColor = System.Drawing.Color.White;
            this.lblLevel.Location = new System.Drawing.Point(74, 8);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(13, 13);
            this.lblLevel.TabIndex = 3;
            this.lblLevel.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::RukNarok.Properties.Resources.StatusBar;
            this.panel1.Controls.Add(this.lblLevel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 75);
            this.panel1.TabIndex = 4;
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
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQuestMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventoryMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkillMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.Timer tmrCharacterWalking;
        private System.Windows.Forms.Timer tmrCharacterAttacking;
        private System.Windows.Forms.Timer tmrMenu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox picQuestMenu;
        private System.Windows.Forms.PictureBox picInventoryMenu;
        private System.Windows.Forms.PictureBox picSkillMenu;
        private System.Windows.Forms.PictureBox picStatusMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLevel;
    }
}