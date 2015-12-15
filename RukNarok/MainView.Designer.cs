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
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.pnlBG = new System.Windows.Forms.Panel();
            this.lblBattle = new System.Windows.Forms.Label();
            this.picEffectBattlePosition = new System.Windows.Forms.PictureBox();
            this.picMonster2 = new System.Windows.Forms.PictureBox();
            this.picPlayerBattlePosition = new System.Windows.Forms.PictureBox();
            this.picMonsterBattlePosition = new System.Windows.Forms.PictureBox();
            this.lblEXP = new System.Windows.Forms.Label();
            this.lblPlayerHealthBar = new System.Windows.Forms.Label();
            this.lblMonsterHealthBar = new System.Windows.Forms.Label();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblHealthBar = new System.Windows.Forms.Label();
            this.boxStatus = new System.Windows.Forms.GroupBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.picQuestMenu = new System.Windows.Forms.PictureBox();
            this.picInventoryMenu = new System.Windows.Forms.PictureBox();
            this.picSkillMenu = new System.Windows.Forms.PictureBox();
            this.picStatusMenu = new System.Windows.Forms.PictureBox();
            this.picMonster1 = new System.Windows.Forms.PictureBox();
            this.pnlBattleStatus = new System.Windows.Forms.Panel();
            this.picPlayerSkill1 = new System.Windows.Forms.PictureBox();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.tmrLoading = new System.Windows.Forms.Timer(this.components);
            this.pnlBG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEffectBattlePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonster2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerBattlePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonsterBattlePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventoryMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkillMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonster1)).BeginInit();
            this.pnlBattleStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerSkill1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
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
            // tmrDelay
            // 
            this.tmrDelay.Interval = 200;
            this.tmrDelay.Tick += new System.EventHandler(this.tmrDelay_Tick);
            // 
            // pnlBG
            // 
            this.pnlBG.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBG.BackgroundImage = global::RukNarok.Properties.Resources.MainBG0;
            this.pnlBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBG.Controls.Add(this.picLoading);
            this.pnlBG.Controls.Add(this.lblBattle);
            this.pnlBG.Controls.Add(this.picEffectBattlePosition);
            this.pnlBG.Controls.Add(this.picMonster2);
            this.pnlBG.Controls.Add(this.picPlayerBattlePosition);
            this.pnlBG.Controls.Add(this.picMonsterBattlePosition);
            this.pnlBG.Controls.Add(this.lblEXP);
            this.pnlBG.Controls.Add(this.lblPlayerHealthBar);
            this.pnlBG.Controls.Add(this.lblMonsterHealthBar);
            this.pnlBG.Controls.Add(this.picPlayer);
            this.pnlBG.Controls.Add(this.lblGameStatus);
            this.pnlBG.Controls.Add(this.picAvatar);
            this.pnlBG.Controls.Add(this.lblHealthBar);
            this.pnlBG.Controls.Add(this.boxStatus);
            this.pnlBG.Controls.Add(this.pnlMenu);
            this.pnlBG.Controls.Add(this.picMonster1);
            this.pnlBG.Controls.Add(this.pnlBattleStatus);
            this.pnlBG.Location = new System.Drawing.Point(0, 0);
            this.pnlBG.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBG.Name = "pnlBG";
            this.pnlBG.Size = new System.Drawing.Size(800, 600);
            this.pnlBG.TabIndex = 0;
            // 
            // lblBattle
            // 
            this.lblBattle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBattle.AutoSize = true;
            this.lblBattle.BackColor = System.Drawing.Color.Transparent;
            this.lblBattle.Font = new System.Drawing.Font("Mistral", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBattle.Location = new System.Drawing.Point(400, 60);
            this.lblBattle.Name = "lblBattle";
            this.lblBattle.Size = new System.Drawing.Size(0, 114);
            this.lblBattle.TabIndex = 19;
            this.lblBattle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBattle.Visible = false;
            // 
            // picEffectBattlePosition
            // 
            this.picEffectBattlePosition.BackColor = System.Drawing.Color.Transparent;
            this.picEffectBattlePosition.Location = new System.Drawing.Point(800, 600);
            this.picEffectBattlePosition.Name = "picEffectBattlePosition";
            this.picEffectBattlePosition.Size = new System.Drawing.Size(300, 200);
            this.picEffectBattlePosition.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEffectBattlePosition.TabIndex = 12;
            this.picEffectBattlePosition.TabStop = false;
            this.picEffectBattlePosition.Visible = false;
            // 
            // picMonster2
            // 
            this.picMonster2.BackColor = System.Drawing.Color.Transparent;
            this.picMonster2.Location = new System.Drawing.Point(187, 77);
            this.picMonster2.Name = "picMonster2";
            this.picMonster2.Size = new System.Drawing.Size(55, 55);
            this.picMonster2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMonster2.TabIndex = 18;
            this.picMonster2.TabStop = false;
            this.picMonster2.Visible = false;
            // 
            // picPlayerBattlePosition
            // 
            this.picPlayerBattlePosition.BackColor = System.Drawing.Color.Transparent;
            this.picPlayerBattlePosition.Image = global::RukNarok.Properties.Resources.NoviceBattle;
            this.picPlayerBattlePosition.Location = new System.Drawing.Point(800, 600);
            this.picPlayerBattlePosition.Name = "picPlayerBattlePosition";
            this.picPlayerBattlePosition.Size = new System.Drawing.Size(100, 100);
            this.picPlayerBattlePosition.TabIndex = 11;
            this.picPlayerBattlePosition.TabStop = false;
            this.picPlayerBattlePosition.Visible = false;
            // 
            // picMonsterBattlePosition
            // 
            this.picMonsterBattlePosition.BackColor = System.Drawing.Color.Transparent;
            this.picMonsterBattlePosition.Location = new System.Drawing.Point(800, 600);
            this.picMonsterBattlePosition.Name = "picMonsterBattlePosition";
            this.picMonsterBattlePosition.Size = new System.Drawing.Size(100, 100);
            this.picMonsterBattlePosition.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMonsterBattlePosition.TabIndex = 10;
            this.picMonsterBattlePosition.TabStop = false;
            // 
            // lblEXP
            // 
            this.lblEXP.BackColor = System.Drawing.Color.Gold;
            this.lblEXP.Location = new System.Drawing.Point(0, 0);
            this.lblEXP.Name = "lblEXP";
            this.lblEXP.Size = new System.Drawing.Size(48, 13);
            this.lblEXP.TabIndex = 17;
            this.lblEXP.Text = "EXP : -/-";
            this.lblEXP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerHealthBar
            // 
            this.lblPlayerHealthBar.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerHealthBar.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerHealthBar.Location = new System.Drawing.Point(500, 430);
            this.lblPlayerHealthBar.Name = "lblPlayerHealthBar";
            this.lblPlayerHealthBar.Size = new System.Drawing.Size(300, 50);
            this.lblPlayerHealthBar.TabIndex = 16;
            this.lblPlayerHealthBar.Text = "HP : -/-";
            this.lblPlayerHealthBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlayerHealthBar.Visible = false;
            // 
            // lblMonsterHealthBar
            // 
            this.lblMonsterHealthBar.BackColor = System.Drawing.Color.Transparent;
            this.lblMonsterHealthBar.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonsterHealthBar.Location = new System.Drawing.Point(0, 430);
            this.lblMonsterHealthBar.Name = "lblMonsterHealthBar";
            this.lblMonsterHealthBar.Size = new System.Drawing.Size(300, 50);
            this.lblMonsterHealthBar.TabIndex = 15;
            this.lblMonsterHealthBar.Text = "HP : -/-";
            this.lblMonsterHealthBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMonsterHealthBar.Visible = false;
            // 
            // picPlayer
            // 
            this.picPlayer.BackColor = System.Drawing.Color.Transparent;
            this.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picPlayer.Image = global::RukNarok.Properties.Resources.NoviceStandSouth;
            this.picPlayer.Location = new System.Drawing.Point(348, 241);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(80, 92);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            this.picPlayer.Visible = false;
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Location = new System.Drawing.Point(32, 119);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(35, 13);
            this.lblGameStatus.TabIndex = 9;
            this.lblGameStatus.Text = "label1";
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.Image = global::RukNarok.Properties.Resources.LegendAvatar;
            this.picAvatar.Location = new System.Drawing.Point(0, 12);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(100, 100);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAvatar.TabIndex = 8;
            this.picAvatar.TabStop = false;
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
            this.boxStatus.Location = new System.Drawing.Point(803, 120);
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
            this.pnlMenu.Location = new System.Drawing.Point(66, 600);
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
            this.picMonster1.Location = new System.Drawing.Point(25, 145);
            this.picMonster1.Name = "picMonster1";
            this.picMonster1.Size = new System.Drawing.Size(55, 55);
            this.picMonster1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMonster1.TabIndex = 7;
            this.picMonster1.TabStop = false;
            this.picMonster1.Visible = false;
            // 
            // pnlBattleStatus
            // 
            this.pnlBattleStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBattleStatus.Controls.Add(this.picPlayerSkill1);
            this.pnlBattleStatus.Location = new System.Drawing.Point(0, 480);
            this.pnlBattleStatus.Name = "pnlBattleStatus";
            this.pnlBattleStatus.Size = new System.Drawing.Size(800, 120);
            this.pnlBattleStatus.TabIndex = 14;
            this.pnlBattleStatus.Visible = false;
            // 
            // picPlayerSkill1
            // 
            this.picPlayerSkill1.BackColor = System.Drawing.Color.Transparent;
            this.picPlayerSkill1.Location = new System.Drawing.Point(550, 30);
            this.picPlayerSkill1.Name = "picPlayerSkill1";
            this.picPlayerSkill1.Size = new System.Drawing.Size(50, 50);
            this.picPlayerSkill1.TabIndex = 0;
            this.picPlayerSkill1.TabStop = false;
            this.picPlayerSkill1.Visible = false;
            // 
            // picLoading
            // 
            this.picLoading.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Location = new System.Drawing.Point(328, 430);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(100, 50);
            this.picLoading.TabIndex = 20;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // tmrLoading
            // 
            this.tmrLoading.Tick += new System.EventHandler(this.tmrLoading_Tick);
            // 
            // MainView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlBG);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruk Narok v1.1";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyUp);
            this.pnlBG.ResumeLayout(false);
            this.pnlBG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEffectBattlePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonster2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerBattlePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonsterBattlePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQuestMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventoryMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSkillMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonster1)).EndInit();
            this.pnlBattleStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerSkill1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBG;
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
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.PictureBox picPlayerBattlePosition;
        private System.Windows.Forms.PictureBox picMonsterBattlePosition;
        private System.Windows.Forms.Label lblPlayerHealthBar;
        private System.Windows.Forms.Label lblMonsterHealthBar;
        private System.Windows.Forms.Panel pnlBattleStatus;
        private System.Windows.Forms.Label lblEXP;
        private System.Windows.Forms.PictureBox picMonster2;
        private System.Windows.Forms.PictureBox picPlayerSkill1;
        private System.Windows.Forms.PictureBox picEffectBattlePosition;
        private System.Windows.Forms.Timer tmrDelay;
        private System.Windows.Forms.Label lblBattle;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Timer tmrLoading;
    }
}