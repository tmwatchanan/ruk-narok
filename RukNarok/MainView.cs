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
        private bool IsPlayerHoldKeyFrontLeft = false;
        private bool IsPlayerHoldKeyFrontRight = false;
        private bool IsPlayerHoldKeyBackLeft = false;
        private bool IsPlayerHoldKeyBackRight = false;
        private bool IsPlayerPressUp = false;
        private bool IsPlayerPressDown = false;
        private bool IsPlayerPressLeft = false;
        private bool IsPlayerPressRight = false;
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
            if (IsPlayerPressUp && IsPlayerPressLeft && !IsPlayerHoldKeyBackLeft)
            {
                picPlayer.Image = Properties.Resources.NoviceWalkBackLeft;
                IsPlayerHoldKeyBackLeft = true;
            }
            if (IsPlayerPressUp && IsPlayerPressRight && !IsPlayerHoldKeyBackRight)
            {
                picPlayer.Image = Properties.Resources.NoviceWalkBackRight;
                IsPlayerHoldKeyBackRight = true;
            }
            if (IsPlayerPressDown && IsPlayerPressLeft && !IsPlayerHoldKeyFrontLeft)
            {
                picPlayer.Image = Properties.Resources.NoviceWalkFrontLeft;
                IsPlayerHoldKeyFrontLeft = true;
            }
            if (IsPlayerPressDown && IsPlayerPressRight && !IsPlayerHoldKeyFrontRight)
            {
                picPlayer.Image = Properties.Resources.NoviceWalkFrontRight;
                IsPlayerHoldKeyFrontRight = true;
            }

            if ((IsPlayerPressUp) && !IsPlayerHoldKeyUp && !IsPlayerHoldKeyBackLeft && !IsPlayerHoldKeyBackRight)
            {
                if (picPlayer.Image != Properties.Resources.NoviceWalkBack) picPlayer.Image = Properties.Resources.NoviceWalkBack;
                IsPlayerHoldKeyUp = true;
            }
            if ((IsPlayerPressDown) && !IsPlayerHoldKeyDown && !IsPlayerHoldKeyFrontLeft && !IsPlayerHoldKeyFrontRight)
            {
                if (picPlayer.Image != Properties.Resources.NoviceWalkDown && picPlayer.Image != Properties.Resources.NoviceWalkFrontLeft) picPlayer.Image = Properties.Resources.NoviceWalkDown;
                IsPlayerHoldKeyDown = true;
            }
            if (IsPlayerPressLeft && !IsPlayerHoldKeyLeft && !IsPlayerHoldKeyFrontLeft && !IsPlayerHoldKeyBackLeft)
            {
                if (picPlayer.Image != Properties.Resources.NoviceWalkLeft && picPlayer.Image != Properties.Resources.NoviceWalkFrontLeft) picPlayer.Image = Properties.Resources.NoviceWalkLeft;
                IsPlayerHoldKeyLeft = true;
            }
            if (IsPlayerPressRight && !IsPlayerHoldKeyRight && !IsPlayerHoldKeyFrontRight && !IsPlayerHoldKeyBackRight)
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
                IsPlayerPressDown = true;
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
                if (IsPlayerHoldKeyBackLeft)
                {
                    //picPlayer.Image = Properties.Resources.NoveSt;
                }
                else if (IsPlayerHoldKeyBackRight)
                {
                    picPlayer.Image = Properties.Resources.NoviceStandBackRight;
                }
                else
                {
                    picPlayer.Image = Properties.Resources.NoviceStandBack;
                }
                IsPlayerPressUp = false;
                IsPlayerHoldKeyUp = false;
                IsPlayerHoldKeyBackLeft = false;
                IsPlayerHoldKeyBackRight = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (IsPlayerHoldKeyFrontLeft)
                {
                    picPlayer.Image = Properties.Resources.NoviceStandFrontLeft;
                }
                else if (IsPlayerHoldKeyFrontRight)
                {
                    picPlayer.Image = Properties.Resources.NoviceStandFrontRight;
                }
                else
                {
                    picPlayer.Image = Properties.Resources.NoviceStandFront;
                }
                IsPlayerPressDown = false;
                IsPlayerHoldKeyDown = false;
                IsPlayerHoldKeyFrontLeft = false;
                IsPlayerHoldKeyFrontRight = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                if (IsPlayerHoldKeyBackLeft)
                {
                    //picPlayer.Image = Properties.Resources.NoviceStandBackLeft;
                }
                else if (IsPlayerHoldKeyFrontLeft)
                {
                    picPlayer.Image = Properties.Resources.NoviceStandFrontLeft;
                }
                else
                {
                    picPlayer.Image = Properties.Resources.NoviceStandLeft;
                }
                IsPlayerPressLeft = false;
                IsPlayerHoldKeyLeft = false;
                IsPlayerHoldKeyFrontLeft = false;
                IsPlayerHoldKeyBackLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (IsPlayerHoldKeyBackRight)
                {
                    picPlayer.Image = Properties.Resources.NoviceStandBackRight;
                }
                else if (IsPlayerHoldKeyFrontRight)
                {
                    picPlayer.Image = Properties.Resources.NoviceStandFrontRight;
                }
                else
                {
                    picPlayer.Image = Properties.Resources.NoviceStandRight;
                }
                IsPlayerPressRight = false;
                IsPlayerHoldKeyRight = false;
                IsPlayerHoldKeyFrontRight = false;
                IsPlayerHoldKeyBackRight = false;
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
