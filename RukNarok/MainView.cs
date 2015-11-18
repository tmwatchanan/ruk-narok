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
        private MapModel mapModel;

        private const int moveDistance = 3;
        private bool PlayerPressKeyUp = false;
        private bool PlayerPressKeyDown = false;
        private bool PlayerPressKeyLeft = false;
        private bool PlayerPressKeyRight = false;
        private bool PlayerMoving = true;
        private bool PlayerAnimationChanging = true;
        private Keys PrePlayerPressKeyUp = Keys.None;
        private Keys PrePlayerPressKeyDown = Keys.None;

        private bool PlayerPressAttack = false;
        private int attackingTime = 0;
        
        private bool MenuWindow = true;

        public MainView()
        {
            InitializeComponent();

            mainController = new MainController();
            this.SetController(mainController);

            mainModel = new MainModel();
            mainController.AddModel(mainModel);
            mainModel.AttachObserver(this);

            mapModel = new MapModel();
            mainController.AddModel(mapModel);
            mapModel.AttachObserver(this);

            Notify(mapModel);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            tmrCharacterWalking.Interval = 10;
            tmrCharacterWalking.Start();
        }

        public void SetController(MainController controller)
        {
            mainController = controller;
        }

        public event EventHandler PlayerWalking;
        public void Notify(Model m)
        {
            MapModel map = (MapModel)m;
            OnMapChanged();
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
                lblHealthBar.Visible = true;
            }

            if (e.KeyCode == Keys.M)
            {
                if (!MenuWindow) MenuWindow = true;
                else MenuWindow = false;
                tmrMenu.Start();
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

        private bool reduce = false;
        private int size = 0;
        private void tmrCharacterWalking_Tick(object sender, EventArgs e)
        {
            if (reduce) size--;
            else size++;
            if (size > 500) reduce = true;
            else if (size < 1) reduce = false;
            this.Invalidate();

            if (PlayerMoving && !PlayerPressAttack)
            {
                if ((PlayerPressKeyUp) && (picPlayer.Top - moveDistance >= pnlMap.Top))
                {
                    picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top - moveDistance);
                }
                if ((PlayerPressKeyDown))
                {
                    if ((MenuWindow) && (picPlayer.Bottom + moveDistance <= pnlMenu.Top) ||
                        (!MenuWindow) && (picPlayer.Bottom + moveDistance <= pnlMap.Bottom))
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
                    mainModel.PlayerDirection = Direction.NorthWest;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp && PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBackRight) picPlayer.Image = Properties.Resources.NoviceWalkBackRight;
                    mainModel.PlayerDirection = Direction.NorthEast;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkFrontLeft) picPlayer.Image = Properties.Resources.NoviceWalkFrontLeft;
                    mainModel.PlayerDirection = Direction.SouthWest;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkFrontRight) picPlayer.Image = Properties.Resources.NoviceWalkFrontRight;
                    mainModel.PlayerDirection = Direction.SouthEast;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBack) picPlayer.Image = Properties.Resources.NoviceWalkBack;
                    mainModel.PlayerDirection = Direction.North;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkDown) picPlayer.Image = Properties.Resources.NoviceWalkDown;
                    mainModel.PlayerDirection = Direction.South;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkLeft) picPlayer.Image = Properties.Resources.NoviceWalkLeft;
                    mainModel.PlayerDirection = Direction.West;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkRight) picPlayer.Image = Properties.Resources.NoviceWalkRight;
                    mainModel.PlayerDirection = Direction.East;
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
                    OnPlayerStandStill(mainModel.PlayerDirection);
                }
            }
            if (PlayerPressAttack && attackingTime == 0)
            {
                if (mainModel.PlayerDirection == Direction.NorthWest)
                {
                    picPlayer.Image = Properties.Resources.NoviceAttackBackLeft;
                }
                else if (mainModel.PlayerDirection == Direction.North || mainModel.PlayerDirection == Direction.NorthEast)
                {
                    picPlayer.Image = Properties.Resources.NoviceAttackBackRight;
                }
                else if (mainModel.PlayerDirection == Direction.West || mainModel.PlayerDirection == Direction.SouthWest)
                {
                    picPlayer.Image = Properties.Resources.NoviceAttackFrontLeft;
                }
                else if (mainModel.PlayerDirection == Direction.East || mainModel.PlayerDirection == Direction.SouthEast ||
                    mainModel.PlayerDirection == Direction.South)
                {
                    picPlayer.Image = Properties.Resources.NoviceAttackFrontRight;
                }
            }

            lblHealthBar.Top = picPlayer.Top - 15;
            lblHealthBar.Left = picPlayer.Left + 5;
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
            SolidBrush myBrush = new SolidBrush(Color.Red);
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(50, 50, 200, 300));
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private void tmrMenu_Tick(object sender, EventArgs e)
        {
            if (MenuWindow)
            {
                if (pnlMenu.Bottom > pnlMap.Bottom) pnlMenu.Location = new Point(pnlMenu.Left, pnlMenu.Top - 2);
                else tmrMenu.Stop();
            }
            else
            {
                if (pnlMenu.Top < pnlMap.Bottom) pnlMenu.Location = new Point(pnlMenu.Left, pnlMenu.Top + 2);
                else tmrMenu.Stop();
            }
        }

        private void picStatusMenu_Click(object sender, EventArgs e)
        {
            if (boxStatus.Visible) boxStatus.Visible = false;
            else boxStatus.Visible = true;
        }

        private void picSkillMenu_Click(object sender, EventArgs e)
        {

        }

        private void picInventoryMenu_Click(object sender, EventArgs e)
        {

        }

        private void picQuestMenu_Click(object sender, EventArgs e)
        {

        }

        private void OnMapChanged()//(MapModel mModel)
        {
            //pnlMap.BackgroundImage = mModel.MapList[mModel.CurrentMap].Background;
            pnlMap.BackgroundImage = mapModel.MapList[mapModel.CurrentMap].Background;
        }

        private void OnMenuToggled()
        {
            if (mainModel.MenuStatus)
            {
                if (pnlMenu.Bottom > pnlMap.Bottom) pnlMenu.Location = new Point(pnlMenu.Left, pnlMenu.Top - 2);
                else
                {
                    mainModel.MenuStatus = true;
                    mainModel.MenuStatusChanging = false;
                    tmrMenu.Stop();
                }
            }
            else
            {
                if (pnlMenu.Top < pnlMap.Bottom) pnlMenu.Location = new Point(pnlMenu.Left, pnlMenu.Top + 2);
                else
                {
                    mainModel.MenuStatus = false;
                    mainModel.MenuStatusChanging = false;
                    tmrMenu.Stop();
                }
            }
        }

        private void OnPlayerStandStill(Direction direction)
        {
            object objPlayerStandStill = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Stand" + Convert.ToString(direction));
            if (picPlayer.Image != (Image)objPlayerStandStill) picPlayer.Image = (Image)objPlayerStandStill;
        }

        private void OnPlayerMoved()
        {

        }

        private bool IsPlayerOverTop
        {
            get
            {
                return (picPlayer.Top - mainModel.MoveDistance >= pnlMap.Top) ? false : true;
            }
        }
        private bool IsPlayerOverBottom
        {
            get
            {
                return (picPlayer.Bottom + mainModel.MoveDistance <= pnlMap.Bottom) ? false : true;
            }
        }
        private bool IsPlayerOverLeft
        {
            get
            {
                return (picPlayer.Left - mainModel.MoveDistance >= pnlMap.Left) ? false : true;
            }
        }
        private bool IsPlayerOverRight
        {
            get
            {
                return (picPlayer.Right + mainModel.MoveDistance <= pnlMap.Right) ? false : true;
            }
        }
        private bool IsPlayerOverMenu
        {
            get
            {
                return (picPlayer.Bottom + mainModel.MoveDistance <= pnlMenu.Top) ? false : true;
            }
        }
    }
}
