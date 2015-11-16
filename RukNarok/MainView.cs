using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;

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

        private const int moveDistance = 3;
        private bool PlayerPressKeyUp = false;
        private bool PlayerPressKeyDown = false;
        private bool PlayerPressKeyLeft = false;
        private bool PlayerPressKeyRight = false;
        private bool PlayerMoving = true;
        private bool PlayerAnimationChanging = true;
        private Keys PrePlayerPressKeyUp = Keys.None;
        private Keys PrePlayerPressKeyDown = Keys.None;
        private enum Direction
        {
            NULL = 0,
            NorthWest = 1,
            North = 2,
            NorthEast = 3,
            West = 4,
            Middle = 5,
            East = 6,
            SouthWest = 7,
            South = 8,
            SouthEast = 9
        };
        Direction CharacterMovingDirection = Direction.NULL;

        private bool PlayerPressAttack = false;
        private int attackingTime = 0;

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
            if (PrePlayerPressKeyDown != e.KeyCode)
            {
                PlayerAnimationChanging = true;
            }
            if (PrePlayerPressKeyUp == e.KeyCode)
            {
                PlayerAnimationChanging = true;
                PrePlayerPressKeyUp = Keys.None;
            }

            if (e.KeyCode == Keys.Up)
            {
                PlayerPressKeyUp = true;
                PrePlayerPressKeyDown = Keys.Up;
                PlayerMoving = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                PlayerPressKeyDown = true;
                PrePlayerPressKeyDown = Keys.Down;
                PlayerMoving = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                PlayerPressKeyLeft = true;
                PrePlayerPressKeyDown = Keys.Left;
                PlayerMoving = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                PlayerPressKeyRight = true;
                PrePlayerPressKeyDown = Keys.Right;
                PlayerMoving = true;
            }

            if (e.KeyCode == Keys.Space)
            {
                PlayerPressAttack = true;
                tmrCharacterAttacking.Start();
            }
        }

        private void MainView_KeyUp(object sender, KeyEventArgs e)
        {
            PlayerAnimationChanging = true;
            PlayerMoving = true;
            if (e.KeyCode == Keys.Up)
            {
                PlayerPressKeyUp = false;
                PrePlayerPressKeyUp = Keys.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                PlayerPressKeyDown = false;
                PrePlayerPressKeyUp = Keys.Down;
            }
            if (e.KeyCode == Keys.Left)
            {
                PlayerPressKeyLeft = false;
                PrePlayerPressKeyUp = Keys.Left;
            }
            if (e.KeyCode == Keys.Right)
            {
                PlayerPressKeyRight = false;
                PrePlayerPressKeyUp = Keys.Right;
            }
        }

        private void tmrCharacterWalking_Tick(object sender, EventArgs e)
        {
            //if ((PlayerPressKeyUp && PlayerPressKeyDown) || (PlayerPressKeyLeft && PlayerPressKeyRight))
            //{
            //    PlayerMoving = false;
            //    picPlayer.Image = Properties.Resources.NoviceStandFront;
            //}

            if (PlayerMoving && !PlayerPressAttack)
            {
                //if (CharacterMovingDirection == Direction.NorthWest || CharacterMovingDirection == Direction.NorthEast ||
                //    CharacterMovingDirection == Direction.SouthWest || CharacterMovingDirection == Direction.SouthEast)
                //{
                //    moveDistance = 3;
                //}
                //else
                //{
                //    moveDistance = 3;
                //}
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
            if (PlayerAnimationChanging && !PlayerPressAttack)
            {
                if (PlayerPressKeyUp && PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBackLeft) picPlayer.Image = Properties.Resources.NoviceWalkBackLeft;
                    CharacterMovingDirection = Direction.NorthWest;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp && PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBackRight) picPlayer.Image = Properties.Resources.NoviceWalkBackRight;
                    CharacterMovingDirection = Direction.NorthEast;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkFrontLeft) picPlayer.Image = Properties.Resources.NoviceWalkFrontLeft;
                    CharacterMovingDirection = Direction.SouthWest;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkFrontRight) picPlayer.Image = Properties.Resources.NoviceWalkFrontRight;
                    CharacterMovingDirection = Direction.SouthEast;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBack) picPlayer.Image = Properties.Resources.NoviceWalkBack;
                    CharacterMovingDirection = Direction.North;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkDown) picPlayer.Image = Properties.Resources.NoviceWalkDown;
                    CharacterMovingDirection = Direction.South;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkLeft) picPlayer.Image = Properties.Resources.NoviceWalkLeft;
                    CharacterMovingDirection = Direction.West;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkRight) picPlayer.Image = Properties.Resources.NoviceWalkRight;
                    CharacterMovingDirection = Direction.East;
                    PlayerAnimationChanging = false;
                }
            }
            if (!PlayerPressKeyUp && !PlayerPressKeyDown && !PlayerPressKeyLeft && !PlayerPressKeyRight && !PlayerPressAttack)
            {
                PlayerMoving = false;
                if (!PlayerMoving)
                {
                    PrePlayerPressKeyUp = Keys.None;
                    PrePlayerPressKeyDown = Keys.None;
                    if (CharacterMovingDirection == Direction.NorthWest)
                    {
                        if (picPlayer.Image != Properties.Resources.NoviceStandBackLeft) picPlayer.Image = Properties.Resources.NoviceStandBackLeft;
                    }
                    else if (CharacterMovingDirection == Direction.North)
                    {
                        if (picPlayer.Image != Properties.Resources.NoviceStandBack) picPlayer.Image = Properties.Resources.NoviceStandBack;
                    }
                    else if (CharacterMovingDirection == Direction.NorthEast)
                    {
                        if (picPlayer.Image != Properties.Resources.NoviceStandBackRight) picPlayer.Image = Properties.Resources.NoviceStandBackRight;
                    }
                    else if (CharacterMovingDirection == Direction.West)
                    {
                        if (picPlayer.Image != Properties.Resources.NoviceStandLeft) picPlayer.Image = Properties.Resources.NoviceStandLeft;
                    }
                    else if (CharacterMovingDirection == Direction.East)
                    {
                        if (picPlayer.Image != Properties.Resources.NoviceStandRight) picPlayer.Image = Properties.Resources.NoviceStandRight;
                    }
                    else if (CharacterMovingDirection == Direction.SouthWest)
                    {
                        if (picPlayer.Image != Properties.Resources.NoviceStandFrontLeft) picPlayer.Image = Properties.Resources.NoviceStandFrontLeft;
                    }
                    else if (CharacterMovingDirection == Direction.South)
                    {
                        if (picPlayer.Image != Properties.Resources.NoviceStandFront) picPlayer.Image = Properties.Resources.NoviceStandFront;
                    }
                    else if (CharacterMovingDirection == Direction.SouthEast)
                    {
                        if (picPlayer.Image != Properties.Resources.NoviceStandFrontRight) picPlayer.Image = Properties.Resources.NoviceStandFrontRight;
                    }
                }
            }
            if (PlayerPressAttack && attackingTime == 0)
            {
                if (CharacterMovingDirection == Direction.NorthWest)
                {
                    picPlayer.Image = Properties.Resources.NoviceAttackBackLeft;
                }
                else if (CharacterMovingDirection == Direction.North || CharacterMovingDirection == Direction.NorthEast)
                {
                    picPlayer.Image = Properties.Resources.NoviceAttackBackRight;
                }
                else if (CharacterMovingDirection == Direction.West || CharacterMovingDirection == Direction.SouthWest)
                {
                    picPlayer.Image = Properties.Resources.NoviceAttackFrontLeft;
                }
                else if (CharacterMovingDirection == Direction.East || CharacterMovingDirection == Direction.SouthEast ||
                    CharacterMovingDirection == Direction.South)
                {
                    picPlayer.Image = Properties.Resources.NoviceAttackFrontRight;
                }
                //if (WeaponShowingTime == 0)
                //{
                //    PlayerWeapon.Visible = true;
                //    PlayerWeapon.Top = (picPlayer.Top);
                //    PlayerWeapon.Left = picPlayer.Right;
                //    ++WeaponShowingTime;
                //}
                //else if (WeaponShowingTime > 0 && WeaponShowingTime < 15)
                //{
                //    PlayerWeapon.Left += attackDistance;
                //    ++WeaponShowingTime;
                //}
                //else if (WeaponShowingTime >= 15 && WeaponShowingTime < 30)
                //{
                //    PlayerWeapon.Left -= attackDistance;
                //    ++WeaponShowingTime;
                //}
                //else
                //{
                //    PlayerWeapon.Visible = false;
                //    WeaponShowingTime = 0;
                //}
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        // Paint background with underlying graphics from other controls
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;

            if (Parent != null)
            {
                // Take each control in turn
                int index = Parent.Controls.GetChildIndex(this);
                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];

                    // Check it's visible and overlaps this control
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        // Load appearance of underlying control and redraw it on this background
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);
                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
        }

        private void tmrCharacterAttacking_Tick(object sender, EventArgs e)
        {
            ++attackingTime;
            if (attackingTime == 8)
            {
                tmrCharacterAttacking.Stop();
                PlayerPressAttack = false;
                attackingTime = 0;
            }
        }
    }
}
