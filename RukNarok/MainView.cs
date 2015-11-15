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

        private bool PlayerPressKeyUp = false;
        private bool PlayerPressKeyDown = false;
        private bool PlayerPressKeyLeft = false;
        private bool PlayerPressKeyRight = false;
        private bool PlayerMoving = true;
        private bool PlayerMovingOblique = true;
        private bool PlayerAnimationChanging = true;
        Keys[] PreMovingDirection = new Keys[2];

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
        
        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != PreMovingDirection[0])
            {
                PlayerAnimationChanging = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                PlayerPressKeyUp = true;
                PreMovingDirection[1] = PreMovingDirection[0];
                PreMovingDirection[0] = Keys.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                PlayerPressKeyDown = true;
                PreMovingDirection[1] = PreMovingDirection[0];
                PreMovingDirection[0] = Keys.Down;
            }
            if (e.KeyCode == Keys.Left)
            {
                PlayerPressKeyLeft = true;
                PreMovingDirection[1] = PreMovingDirection[0];
                PreMovingDirection[0] = Keys.Left;
            }
            if (e.KeyCode == Keys.Right)
            {
                PlayerPressKeyRight = true;
                PreMovingDirection[1] = PreMovingDirection[0];
                PreMovingDirection[0] = Keys.Right;
            }

            //if (e.KeyCode == Keys.Space && PlayerWeapon.Visible == false) IsPlayerPressAttack = true;
        }
        private void MainView_KeyUp(object sender, KeyEventArgs e)
        {
            PlayerAnimationChanging = true;
            PlayerMoving = true;
            PlayerMovingOblique = true;
            //if (PlayerMovingOblique)
            {
                if (PlayerMovingOblique && PreMovingDirection[0] == Keys.Up && PreMovingDirection[1] == Keys.Left
                    || PlayerMovingOblique && PreMovingDirection[1] == Keys.Up && PreMovingDirection[0] == Keys.Left)
                {
                    PlayerPressKeyUp = false;
                    PlayerPressKeyLeft = false;
                    picPlayer.Image = Properties.Resources.NoviceStandBackRight; // BackLeft
                }
                else if (PlayerMovingOblique && PreMovingDirection[0] == Keys.Up && PreMovingDirection[1] == Keys.Right
                    || PlayerMovingOblique && PreMovingDirection[1] == Keys.Up && PreMovingDirection[0] == Keys.Right)
                {
                    PlayerPressKeyUp = false;
                    PlayerPressKeyRight = false;
                    picPlayer.Image = Properties.Resources.NoviceStandBackRight;
                }
                else if (PlayerMovingOblique && PreMovingDirection[0] == Keys.Down && PreMovingDirection[1] == Keys.Left
                    || PlayerMovingOblique && PreMovingDirection[1] == Keys.Down && PreMovingDirection[0] == Keys.Left)
                {
                    PlayerPressKeyDown = false;
                    PlayerPressKeyLeft = false;
                    picPlayer.Image = Properties.Resources.NoviceStandFrontLeft;
                }
                else if (PlayerMovingOblique && PreMovingDirection[0] == Keys.Down && PreMovingDirection[1] == Keys.Right
                    || PlayerMovingOblique && PreMovingDirection[1] == Keys.Down && PreMovingDirection[0] == Keys.Right)
                {
                    PlayerPressKeyDown = false;
                    PlayerPressKeyRight = false;
                    picPlayer.Image = Properties.Resources.NoviceStandFrontRight;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    PlayerPressKeyUp = false;
                    picPlayer.Image = Properties.Resources.NoviceStandBack;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    PlayerPressKeyDown = false;
                    picPlayer.Image = Properties.Resources.NoviceStandFront;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    PlayerPressKeyLeft = false;
                    picPlayer.Image = Properties.Resources.NoviceStandLeft;

                }
                else if (e.KeyCode == Keys.Right)
                {
                    PlayerPressKeyRight = false;
                    picPlayer.Image = Properties.Resources.NoviceStandRight;
                }
            }
        }

        private void tmrCharacterWalking_Tick(object sender, EventArgs e)
        {
            if ((PlayerPressKeyUp && PlayerPressKeyDown) || (PlayerPressKeyLeft && PlayerPressKeyRight))
            {
                PlayerMoving = false;
                picPlayer.Image = Properties.Resources.NoviceStandFront;
            }

            if (PlayerMoving)
            {
                if ((PlayerPressKeyUp) && (picPlayer.Top - moveDistance >= pnlMap.Top))
                {
                    picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top - moveDistance);
                }
                if ((PlayerPressKeyDown) && (picPlayer.Bottom + moveDistance <= pnlMap.Bottom))
                {
                    picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top + moveDistance);
                }
                if ((PlayerPressKeyLeft) && (picPlayer.Left - moveDistance >= pnlMap.Left))
                {
                    picPlayer.Location = new Point(picPlayer.Left - moveDistance, picPlayer.Top);
                }
                if ((PlayerPressKeyRight) && (picPlayer.Right + moveDistance <= pnlMap.Right))
                {
                    picPlayer.Location = new Point(picPlayer.Left + moveDistance, picPlayer.Top);
                }
            }
            if (PlayerAnimationChanging)
            {
                if (PlayerPressKeyUp && PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBackLeft) picPlayer.Image = Properties.Resources.NoviceWalkBackLeft;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp && PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBackRight) picPlayer.Image = Properties.Resources.NoviceWalkBackRight;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkFrontLeft) picPlayer.Image = Properties.Resources.NoviceWalkFrontLeft;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkFrontRight) picPlayer.Image = Properties.Resources.NoviceWalkFrontRight;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBack) picPlayer.Image = Properties.Resources.NoviceWalkBack;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkDown) picPlayer.Image = Properties.Resources.NoviceWalkDown;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkLeft) picPlayer.Image = Properties.Resources.NoviceWalkLeft;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkRight) picPlayer.Image = Properties.Resources.NoviceWalkRight;
                    PlayerAnimationChanging = false;
                }
            }

            if (PlayerPressKeyUp && PlayerPressKeyLeft || PlayerPressKeyUp && PlayerPressKeyRight || PlayerPressKeyDown && PlayerPressKeyLeft || PlayerPressKeyDown && PlayerPressKeyRight)
            {
                PlayerMovingOblique = true;
            }
            else
            {
                PlayerMovingOblique = false;
            }
        }

        private void tmrCharacterWalkingStatus_Tick(object sender, EventArgs e)
        {
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
