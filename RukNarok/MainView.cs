using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RukNarok
{
    public partial class MainView : Form, View
    {
        //Making the immovable windows’ form
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }

        private MainController mainController;
        private MainModel mainModel;

        private bool IsPlayerHoldKeyUp = false;
        private bool IsPlayerHoldKeyDown = false;
        private bool IsPlayerHoldKeyLeft = false;
        private bool IsPlayerHoldKeyRight = false;
        private bool IsPlayerPressUp = false;
        private bool IsPlayerPressDown = false;
        private bool IsPlayerPressLeft = false;
        private bool IsPlayerPressRight = false;
        private bool IsPlayerMoveFrontLeft = false;
        private bool IsPlayerMoveFrontRight = false;
        private bool IsPlayerMoveBackLeft = false;
        private bool IsPlayerMoveBackRight = false;
        //private bool IsPlayerPressAttack = false;

        private const int moveDistance = 2;
        //private const int attackDistance = 2;
        //private int WeaponShowingTime = 0;

        public MainView()
        {
            InitializeComponent();
            mainController = new MainController();
            mainModel = new MainModel();
            mainController.AddModel(mainModel);
            mainModel.AttachObserver(this);
            this.SetController(mainController);
        }

        public void SetController(MainController controller)
        {
            mainController = controller;
        }

        public void Notify(Model m)
        {

        }

        private void tmrCharacter_Tick(object sender, EventArgs e)
        {
            if ((IsPlayerPressUp) && !IsPlayerHoldKeyUp)
            {
                if (picPlayer.Image != Properties.Resources.NoviceWalkBack) picPlayer.Image = Properties.Resources.NoviceWalkBack;
                IsPlayerHoldKeyUp = true;
            }
            if ((IsPlayerPressDown) && !IsPlayerHoldKeyDown)
            {
                if (picPlayer.Image != Properties.Resources.NoviceWalkDown && picPlayer.Image != Properties.Resources.NoviceWalkFrontLeft) picPlayer.Image = Properties.Resources.NoviceWalkDown;
                IsPlayerHoldKeyDown = true;
            }
            if (IsPlayerPressLeft && !IsPlayerHoldKeyLeft)
            {
                if (picPlayer.Image != Properties.Resources.NoviceWalkLeft && picPlayer.Image != Properties.Resources.NoviceWalkFrontLeft) picPlayer.Image = Properties.Resources.NoviceWalkLeft;
                IsPlayerHoldKeyLeft = true;
            }
            if (IsPlayerPressRight && !IsPlayerHoldKeyRight)
            {
                if (picPlayer.Image != Properties.Resources.NoviceWalkRight) picPlayer.Image = Properties.Resources.NoviceWalkRight;
                IsPlayerHoldKeyRight = true;
            }
        }
        
        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                IsPlayerPressUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (e.KeyCode == Keys.Left)
                {
                    IsPlayerMoveFrontLeft = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    IsPlayerMoveFrontRight = true;
                }
                else
                {
                    IsPlayerPressDown = true;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                IsPlayerPressLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                IsPlayerPressRight = true;
            }

            //if (e.KeyCode == Keys.Space && PlayerWeapon.Visible == false) IsPlayerPressAttack = true;
        }
        private void MainView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                IsPlayerPressUp = false;
                picPlayer.Image = Properties.Resources.NoviceStandBack;
                IsPlayerHoldKeyUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                IsPlayerPressDown = false;
                picPlayer.Image = Properties.Resources.NoviceStandFront;
                IsPlayerHoldKeyDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                IsPlayerPressLeft = false;
                picPlayer.Image = Properties.Resources.NoviceStandLeft;
                IsPlayerHoldKeyLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                IsPlayerPressRight = false;
                picPlayer.Image = Properties.Resources.NoviceStandRight;
                IsPlayerHoldKeyRight = false;
            }
            //if (e.KeyCode == Keys.Space) IsPlayerPressAttack = false;
        }
        private void tmrCharacterWalking_Tick(object sender, EventArgs e)
        {
            if ((IsPlayerPressUp) && (picPlayer.Top - moveDistance >= pnlMap.Top))
            {
                picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top - moveDistance);
            }
            if ((IsPlayerPressDown) && (picPlayer.Bottom + moveDistance <= pnlMap.Bottom))
            {
                picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top + moveDistance);
            }
            if ((IsPlayerPressLeft) && (picPlayer.Left - moveDistance >= pnlMap.Left))
            {
                picPlayer.Location = new Point(picPlayer.Left - moveDistance, picPlayer.Top);
            }
            if ((IsPlayerPressRight) && (picPlayer.Right + moveDistance <= pnlMap.Right))
            {
                picPlayer.Location = new Point(picPlayer.Left + moveDistance, picPlayer.Top);
            }
        }

        //if ((IsPlayerPressAttack))
        //{
        //    if (WeaponShowingTime == 0)
        //    {
        //        PlayerWeapon.Visible = true;
        //        PlayerWeapon.Top = (picPlayer.Top);
        //        PlayerWeapon.Left = picPlayer.Right;
        //        ++WeaponShowingTime;
        //    }
        //    else if (WeaponShowingTime > 0 && WeaponShowingTime < 15)
        //    {
        //        PlayerWeapon.Left += attackDistance;
        //        ++WeaponShowingTime;
        //    }
        //    else if (WeaponShowingTime >= 15 && WeaponShowingTime < 30)
        //    {
        //        PlayerWeapon.Left -= attackDistance;
        //        ++WeaponShowingTime;
        //    }
        //    else
        //    {
        //        PlayerWeapon.Visible = false;
        //        WeaponShowingTime = 0;
        //    }
        //}
        //else
        //{
        //    PlayerWeapon.Visible = false;
        //    WeaponShowingTime = 0;
        //}
    }
}
