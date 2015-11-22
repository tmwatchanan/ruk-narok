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
        
        private bool PlayerPressKeyUp = false;
        private bool PlayerPressKeyDown = false;
        private bool PlayerPressKeyLeft = false;
        private bool PlayerPressKeyRight = false;
        private bool PlayerMoving = true;
        private bool PlayerAnimationChanging = true;
        private Keys PrePlayerPressKeyUp = Keys.None;
        private Keys PrePlayerPressKeyDown = Keys.None;
        
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
            tmrCharacterWalking.Interval = 15;
            tmrCharacterWalking.Start();
        }

        public void SetController(MainController controller)
        {
            mainController = controller;
        }

        public event EventHandler PlayerWalking;
        public void Notify(Model model)
        {
            if (model is MapModel)
            {
                MapModel map = (MapModel)model;
                OnMapChanged();
            }
            else if (model is MainModel)
            {
                if (mainModel.MenuStatusChanging) tmrMenu.Start();
                if (mainModel.PlayerMoving) OnPlayerMoved();
                if (mainModel.PlayerPressAttack) tmrCharacterAttacking.Start();
            }
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
                mainController.PlayerPressAttack();
                //lblHealthBar.Visible = true;
            }

            if (e.KeyCode == Keys.M)
            {
                mainController.ToggleMenu();
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

            if (PlayerMoving && !mainModel.PlayerPressAttack)
            {
                if ((PlayerPressKeyUp) && (!IsPlayerOverTop))
                {
                    picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top - MainModel.MoveDistance);
                }
                if ((PlayerPressKeyDown))
                {
                    if ((MenuWindow) && (!IsPlayerOverMenu) || (!MenuWindow) && (!IsPlayerOverBottom))
                        picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top + MainModel.MoveDistance);
                }
                if ((PlayerPressKeyLeft) && (!IsPlayerOverLeft))
                {
                    picPlayer.Location = new Point(picPlayer.Left - MainModel.MoveDistance, picPlayer.Top);
                }
                if ((PlayerPressKeyRight) && (!IsPlayerOverRight))
                {
                    picPlayer.Location = new Point(picPlayer.Left + MainModel.MoveDistance, picPlayer.Top);
                }
            }
            if (PlayerAnimationChanging && !mainModel.PlayerPressAttack)
            {
                if (PlayerPressKeyUp && PlayerPressKeyLeft)
                {
                    mainModel.PlayerDirection = Direction.NorthWest;
                    object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerDirection));
                    if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp && PlayerPressKeyRight)
                {
                    mainModel.PlayerDirection = Direction.NorthEast;
                    object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerDirection));
                    if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyLeft)
                {
                    mainModel.PlayerDirection = Direction.SouthWest;
                    object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerDirection));
                    if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown && PlayerPressKeyRight)
                {
                    mainModel.PlayerDirection = Direction.SouthEast;
                    object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerDirection));
                    if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyUp)
                {
                    mainModel.PlayerDirection = Direction.North;
                    object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerDirection));
                    if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyDown)
                {
                    mainModel.PlayerDirection = Direction.South;
                    object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerDirection));
                    if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyLeft)
                {
                    mainModel.PlayerDirection = Direction.West;
                    object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerDirection));
                    if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                    PlayerAnimationChanging = false;
                }
                else if (PlayerPressKeyRight)
                {
                    mainModel.PlayerDirection = Direction.East;
                    object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerDirection));
                    if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                    PlayerAnimationChanging = false;
                }
            }
            if (!PlayerPressKeyUp && !PlayerPressKeyDown && !PlayerPressKeyLeft && !PlayerPressKeyRight && !mainModel.PlayerPressAttack)
            {
                PlayerMoving = false;
                if (!PlayerMoving)
                {
                    PrePlayerPressKeyUp = Keys.None;
                    PrePlayerPressKeyDown = Keys.None;
                    OnPlayerStandStill(mainModel.PlayerDirection);
                }
            }
        }

        private void tmrCharacterAttacking_Tick(object sender, EventArgs e)
        {
            if (mainModel.PlayerPressAttack && attackingTime == 0)
            {
                if (mainModel.PlayerDirection == Direction.NorthWest)
                {
                    object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.NorthWest));
                    if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
                }
                else if (mainModel.PlayerDirection == Direction.North || mainModel.PlayerDirection == Direction.NorthEast)
                {
                    object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.NorthEast));
                    if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
                }
                else if (mainModel.PlayerDirection == Direction.West || mainModel.PlayerDirection == Direction.SouthWest)
                {
                    object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.SouthWest));
                    if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
                }
                else if (mainModel.PlayerDirection == Direction.East || mainModel.PlayerDirection == Direction.SouthEast ||
                    mainModel.PlayerDirection == Direction.South)
                {
                    object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.SouthEast));
                    if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
                }
            }
            ++attackingTime;
            if (attackingTime == 6)
            {
                tmrCharacterAttacking.Stop();
                mainModel.PlayerPressAttack = false;
                attackingTime = 0;
            }
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

        private void OnMapChanged()
        {
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
                return (picPlayer.Top - MainModel.MoveDistance >= pnlMap.Top) ? false : true;
            }
        }
        private bool IsPlayerOverBottom
        {
            get
            {
                return (picPlayer.Bottom + MainModel.MoveDistance <= pnlMap.Bottom) ? false : true;
            }
        }
        private bool IsPlayerOverLeft
        {
            get
            {
                return (picPlayer.Left - MainModel.MoveDistance >= pnlMap.Left) ? false : true;
            }
        }
        private bool IsPlayerOverRight
        {
            get
            {
                return (picPlayer.Right + MainModel.MoveDistance <= pnlMap.Right) ? false : true;
            }
        }
        private bool IsPlayerOverMenu
        {
            get
            {
                return (picPlayer.Bottom + MainModel.MoveDistance <= pnlMenu.Top) ? false : true;
            }
        }

        private void ShowCharacterHealthBar()
        {
            lblHealthBar.Visible = true;
            lblHealthBar.Top = picPlayer.Top - 15;
            lblHealthBar.Left = picPlayer.Left + 5;
        }

        private void OnPlayerAttack()
        {

        }
    }
}
