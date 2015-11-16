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
            this.pnlMap = new System.Windows.Forms.Panel();
            this.tmrCharacterWalking = new System.Windows.Forms.Timer(this.components);
            this.tmrCharacterAttacking = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.pnlMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMap
            // 
            this.pnlMap.BackgroundImage = global::RukNarok.Properties.Resources.GrassBG;
            this.pnlMap.Controls.Add(this.pnlMenu);
            this.pnlMap.Controls.Add(this.picPlayer);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(0, 0);
            this.pnlMap.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(624, 441);
            this.pnlMap.TabIndex = 0;
            // 
            // tmrCharacterWalking
            // 
            this.tmrCharacterWalking.Enabled = true;
            this.tmrCharacterWalking.Interval = 10;
            this.tmrCharacterWalking.Tick += new System.EventHandler(this.tmrCharacterWalking_Tick);
            // 
            // tmrCharacterAttacking
            // 
            this.tmrCharacterAttacking.Interval = 200;
            this.tmrCharacterAttacking.Tick += new System.EventHandler(this.tmrCharacterAttacking_Tick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoSize = true;
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.BackgroundImage = global::RukNarok.Properties.Resources.MenuBackground;
            this.pnlMenu.Location = new System.Drawing.Point(0, 324);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(624, 117);
            this.pnlMenu.TabIndex = 1;
            // 
            // picPlayer
            // 
            this.picPlayer.BackColor = System.Drawing.Color.Transparent;
            this.picPlayer.Image = global::RukNarok.Properties.Resources.NoviceStandFront;
            this.picPlayer.Location = new System.Drawing.Point(0, 0);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(80, 92);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.pnlMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruk Narok v.0";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyUp);
            this.pnlMap.ResumeLayout(false);
            this.pnlMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.Timer tmrCharacterWalking;
        private System.Windows.Forms.Timer tmrCharacterAttacking;
        private System.Windows.Forms.Panel pnlMenu;
    }
}