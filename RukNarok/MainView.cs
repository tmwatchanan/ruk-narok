using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

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
        
        private Keys PrePlayerPressKeyUp = Keys.None;
        private Keys PrePlayerPressKeyDown = Keys.None;

        private bool PlayerPressAttack = false;
        private int attackingTime = 0;

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
    
        public void Notify(Model model)
        {
            if (model is MapModel)
            {
                MapModel map = (MapModel)model;
                OnMapChanged(/*map*/);
            }
            else if (model is MainModel)
            {
                if (mainModel.MenuStatusChanging) tmrMenu.Start();
                if (mainModel.PlayerMoving) OnPlayerMoved();
            }
        }

        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (mainModel.PlayerPressedKeyDown != e.KeyCode)
            {
                mainModel.PlayerAnimationChanging = true;
            }
            if (mainModel.PlayerPressedKeyDown == e.KeyCode)
            {
                mainModel.PlayerAnimationChanging = true;
                mainModel.PlayerPressedKeyDown = Keys.None;
            }

            if (e.KeyCode == Keys.Up)
            {
                mainModel.PressUp = true;
                mainController.PlayerWalkingPressed(e.KeyCode);
            }
            if (e.KeyCode == Keys.Down)
            {
                mainModel.PressDown = true;
                mainController.PlayerWalkingPressed(e.KeyCode);
            }
            if (e.KeyCode == Keys.Left)
            {
                mainModel.PressLeft = true;
                mainController.PlayerWalkingPressed(e.KeyCode);
            }
            if (e.KeyCode == Keys.Right)
            {
                mainModel.PressRight = true;
                mainController.PlayerWalkingPressed(e.KeyCode);
            }

            if (e.KeyCode == Keys.Space)
            {
                PlayerPressAttack = true;
                tmrCharacterAttacking.Start();
                lblHealthBar.Visible = true;
            }

            if (e.KeyCode == Keys.M)
            {
                mainController.ToggleMenu();
            }

            if (e.KeyCode == Keys.NumPad0)
            {
                mainController.MapChanged(MainController.MapZero);
            }
            else if (e.KeyCode == Keys.NumPad1)
            {
                mainController.MapChanged(MainController.MapOne);
            }
        }
        
        private void MainView_KeyUp(object sender, KeyEventArgs e)
        {
            mainModel.PlayerAnimationChanging = true;
            mainModel.PlayerMoving = true;
            if (e.KeyCode == Keys.Up)
            {
                mainModel.PressUp = false;
                mainController.PlayerWalkingReleased(e.KeyCode);
            }
            if (e.KeyCode == Keys.Down)
            {
                mainModel.PressDown = false;
                mainController.PlayerWalkingReleased(e.KeyCode);
            }
            if (e.KeyCode == Keys.Left)
            {
                mainModel.PressLeft = false;
                mainController.PlayerWalkingReleased(e.KeyCode);
            }
            if (e.KeyCode == Keys.Right)
            {
                mainModel.PressRight = false;
                mainController.PlayerWalkingReleased(e.KeyCode);
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

            bool PlayerPressKeyUp = mainModel.PlayerMovingDirection[2];
            bool PlayerPressKeyDown = mainModel.PlayerMovingDirection[8];
            bool PlayerPressKeyLeft = mainModel.PlayerMovingDirection[4];
            bool PlayerPressKeyRight = mainModel.PlayerMovingDirection[6];

            if (mainModel.PlayerMoving && !PlayerPressAttack)
            {
                
                if ((mainModel.PressUp) && (!IsPlayerOverTop))
                {
                    mainController.PlayerMoved(Direction.North);
                    picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top - mainModel.MoveDistance);
                }
                if ((mainModel.PressDown))
                {
                    mainController.PlayerMoved(Direction.South);
                    if ((mainModel.MenuStatus) && (!IsPlayerOverMenu) || (!mainModel.MenuStatus) && (!IsPlayerOverBottom))
                    {
                        picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top + mainModel.MoveDistance);
                    }
                }
                if ((mainModel.PressLeft) && (!IsPlayerOverLeft))
                {
                    mainController.PlayerMoved(Direction.West);
                    picPlayer.Location = new Point(picPlayer.Left - mainModel.MoveDistance, picPlayer.Top);
                }
                if ((mainModel.PressRight) && (!IsPlayerOverRight))
                {
                    mainController.PlayerMoved(Direction.East);
                    picPlayer.Location = new Point(picPlayer.Left + mainModel.MoveDistance, picPlayer.Top);
                }
            }
            if (mainModel.PlayerAnimationChanging && !PlayerPressAttack)
            {
                if (PlayerPressKeyUp && PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBackLeft) picPlayer.Image = Properties.Resources.NoviceWalkBackLeft;
                    mainController.PlayerDirectionChanged(Direction.NorthWest);
                    mainModel.PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp && PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBackRight) picPlayer.Image = Properties.Resources.NoviceWalkBackRight;
                    mainController.PlayerDirectionChanged(Direction.NorthEast);
                    mainModel.PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkFrontLeft) picPlayer.Image = Properties.Resources.NoviceWalkFrontLeft;
                    mainController.PlayerDirectionChanged(Direction.SouthWest);
                    mainModel.PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkFrontRight) picPlayer.Image = Properties.Resources.NoviceWalkFrontRight;
                    mainController.PlayerDirectionChanged(Direction.SouthEast);
                    mainModel.PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkBack) picPlayer.Image = Properties.Resources.NoviceWalkBack;
                    mainController.PlayerDirectionChanged(Direction.North);
                    mainModel.PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkDown) picPlayer.Image = Properties.Resources.NoviceWalkDown;
                    mainController.PlayerDirectionChanged(Direction.South);
                    mainModel.PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyLeft)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkLeft) picPlayer.Image = Properties.Resources.NoviceWalkLeft;
                    mainController.PlayerDirectionChanged(Direction.West);
                    mainModel.PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyRight)
                {
                    if (picPlayer.Image != Properties.Resources.NoviceWalkRight) picPlayer.Image = Properties.Resources.NoviceWalkRight;
                    mainController.PlayerDirectionChanged(Direction.East);
                    mainModel.PlayerAnimationChanging = false;
                }
            }
            if (!PlayerPressKeyUp && !PlayerPressKeyDown && !PlayerPressKeyLeft && !PlayerPressKeyRight && !PlayerPressAttack)
            {
                mainModel.PlayerMoving = false;
                if (!mainModel.PlayerMoving)
                {
                    mainModel.PlayerPressedKeyUp = Keys.None;
                    mainModel.PlayerPressedKeyDown = Keys.None;
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
            OnMenuToggled();
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
