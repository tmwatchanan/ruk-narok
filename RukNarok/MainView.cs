using System;
using System.Drawing;
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
        
        private bool PlayerPressKeyUp = false;
        private bool PlayerPressKeyDown = false;
        private bool PlayerPressKeyLeft = false;
        private bool PlayerPressKeyRight = false;
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
            Notify(mainModel);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            tmrCharacterWalking.Interval = 15;
            tmrCharacterWalking.Start();
            MenuInit();
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
                OnBackgroundChanged();
            }
            else if (model is MainModel)
            {
                if (mainModel.GameStatus == "Main")
                {
                    OnPlayerMain();
                    
                    if (mainModel.MenuStatusChanging) tmrMenu.Start();
                    if (mainModel.CharacterSpawned) OnCharacterSpawn();
                    if (mainModel.PlayerCharacter.Moving) OnPlayerMoved();
                    if (mainModel.PlayerCharacter.Attacking) tmrCharacterAttacking.Start();
                    else tmrCharacterAttacking.Stop();
                    if (mainModel.MonsterCharacter.IsAttacked) ShowCharacterHealthBar();
                }
                else if (mainModel.GameStatus == "Battle")
                {
                    OnPlayerBattle();
                }
            }
        }

        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (mainModel.GameStatus == "Main")
            {
                if (PrePlayerPressKeyDown != e.KeyCode)
                {
                    mainModel.PlayerCharacter.AnimationChanging = true;
                }
                if (PrePlayerPressKeyUp == e.KeyCode)
                {
                    mainModel.PlayerCharacter.AnimationChanging = true;
                    PrePlayerPressKeyUp = Keys.None;
                }

                if (e.KeyCode == Keys.Up)
                {
                    PlayerPressKeyUp = true;
                    PrePlayerPressKeyDown = Keys.Up;
                    mainModel.PlayerCharacter.Moving = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    PlayerPressKeyDown = true;
                    PrePlayerPressKeyDown = Keys.Down;
                    mainModel.PlayerCharacter.Moving = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    PlayerPressKeyLeft = true;
                    PrePlayerPressKeyDown = Keys.Left;
                    mainModel.PlayerCharacter.Moving = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    PlayerPressKeyRight = true;
                    PrePlayerPressKeyDown = Keys.Right;
                    mainModel.PlayerCharacter.Moving = true;
                }

                if (e.KeyCode == Keys.Space && !mainModel.PlayerCharacter.Attacking)
                {
                    mainController.PlayerStartAttack();
                    //lblHealthBar.Visible = true;
                }

                if (e.KeyCode == Keys.M)
                {
                    mainController.ToggleMenu();
                }
            }
            else if (mainModel.GameStatus == "Battle")
            {
                if (e.KeyCode == Keys.Space)
                {
                    mainController.PlayerStopBattle();
                    picPlayer.Location = new Point(250, 250);
                }
            }
        }

        private void MainView_KeyUp(object sender, KeyEventArgs e)
        {
            mainModel.PlayerCharacter.AnimationChanging = true;
            mainModel.PlayerCharacter.Moving = true;
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

            if (mainModel.GameStatus == "Main")
            {
                if (mainModel.PlayerCharacter.Moving && !mainModel.PlayerCharacter.Attacking)
                {
                    if ((IsPlayerOverAvatarRight) && (IsPlayerOverAvatarBottom))
                    {
                        picPlayer.Location = new Point(picPlayer.Left + MainModel.MoveDistance, picPlayer.Top + MainModel.MoveDistance);
                    }
                    else
                    {
                        picPlayer.Refresh();
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
                }
                if (mainModel.PlayerCharacter.AnimationChanging && !mainModel.PlayerCharacter.Attacking)
                {
                    if (PlayerPressKeyUp && PlayerPressKeyLeft)
                    {
                        mainModel.PlayerCharacter.Direction = Direction.NorthWest;
                        object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerCharacter.Direction));
                        if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                        mainModel.PlayerCharacter.AnimationChanging = false;
                    }
                    else if (PlayerPressKeyUp && PlayerPressKeyRight)
                    {
                        mainModel.PlayerCharacter.Direction = Direction.NorthEast;
                        object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerCharacter.Direction));
                        if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                        mainModel.PlayerCharacter.AnimationChanging = false;
                    }
                    else if (PlayerPressKeyDown && PlayerPressKeyLeft)
                    {
                        mainModel.PlayerCharacter.Direction = Direction.SouthWest;
                        object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerCharacter.Direction));
                        if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                        mainModel.PlayerCharacter.AnimationChanging = false;
                    }
                    else if (PlayerPressKeyDown && PlayerPressKeyRight)
                    {
                        mainModel.PlayerCharacter.Direction = Direction.SouthEast;
                        object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerCharacter.Direction));
                        if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                        mainModel.PlayerCharacter.AnimationChanging = false;
                    }
                    else if (PlayerPressKeyUp)
                    {
                        mainModel.PlayerCharacter.Direction = Direction.North;
                        object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerCharacter.Direction));
                        if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                        mainModel.PlayerCharacter.AnimationChanging = false;
                    }
                    else if (PlayerPressKeyDown)
                    {
                        mainModel.PlayerCharacter.Direction = Direction.South;
                        object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerCharacter.Direction));
                        if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                        mainModel.PlayerCharacter.AnimationChanging = false;
                    }
                    else if (PlayerPressKeyLeft)
                    {
                        mainModel.PlayerCharacter.Direction = Direction.West;
                        object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerCharacter.Direction));
                        if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                        mainModel.PlayerCharacter.AnimationChanging = false;
                    }
                    else if (PlayerPressKeyRight)
                    {
                        mainModel.PlayerCharacter.Direction = Direction.East;
                        object objPlayerWalking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Walk" + Convert.ToString(mainModel.PlayerCharacter.Direction));
                        if (picPlayer.Image != (Image)objPlayerWalking) picPlayer.Image = (Image)objPlayerWalking;
                        mainModel.PlayerCharacter.AnimationChanging = false;
                    }
                }
                if (!PlayerPressKeyUp && !PlayerPressKeyDown && !PlayerPressKeyLeft && !PlayerPressKeyRight && !mainModel.PlayerCharacter.Attacking)
                {
                    mainModel.PlayerCharacter.Moving = false;
                    if (!mainModel.PlayerCharacter.Moving)
                    {
                        PrePlayerPressKeyUp = Keys.None;
                        PrePlayerPressKeyDown = Keys.None;
                        OnPlayerStandStill(mainModel.PlayerCharacter.Direction);
                    }
                }

                if (picPlayer.Bounds.IntersectsWith(picMonster1.Bounds))
                {
                    lblGameStatus.Text = "Battle!";
                    mainController.PlayerStartBattle();
                }
            }
        }

        private void tmrCharacterAttacking_Tick(object sender, EventArgs e)
        {
            if (mainModel.PlayerCharacter.Attacking && attackingTime == 0)
            {
                if (mainModel.PlayerCharacter.Direction == Direction.NorthWest)
                {
                    object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.NorthWest));
                    if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
                }
                else if (mainModel.PlayerCharacter.Direction == Direction.North || mainModel.PlayerCharacter.Direction == Direction.NorthEast)
                {
                    object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.NorthEast));
                    if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
                }
                else if (mainModel.PlayerCharacter.Direction == Direction.West || mainModel.PlayerCharacter.Direction == Direction.SouthWest)
                {
                    object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.SouthWest));
                    if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
                }
                else if (mainModel.PlayerCharacter.Direction == Direction.East || mainModel.PlayerCharacter.Direction == Direction.SouthEast ||
                    mainModel.PlayerCharacter.Direction == Direction.South)
                {
                    object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.SouthEast));
                    if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
                }
            }
            ++attackingTime;
            OnPlayerAttack();
            if (attackingTime == 6)
            {
                mainController.PlayerStopAttack();
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

        private void OnBackgroundChanged()
        {
            if (mainModel.GameStatus == "Main")
            {
                pnlBG.BackgroundImage = mapModel.MapList[mapModel.CurrentMap].MainBG;
                //pnlBG.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (mainModel.GameStatus == "Battle")
            {
                pnlBG.BackgroundImage = mapModel.MapList[mapModel.CurrentMap].BattleBG;
                //pnlBG.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void OnGameStatusChanged()
        {
            OnMenuToggled();
            OnAvatarToggled();
        }

        private void OnMenuToggled()
        {
            if (mainModel.GameStatus == "Main") pnlMenu.Visible = true;
            else pnlMenu.Visible = false;

            if (mainModel.MenuStatusChanging)
            {
                if (mainModel.MenuStatus)
                {
                    if (pnlMenu.Bottom > pnlBG.Bottom) pnlMenu.Location = new Point(pnlMenu.Left, pnlMenu.Top - 2);
                    else
                    {
                        mainModel.MenuStatus = true;
                        mainModel.MenuStatusChanging = false;
                        tmrMenu.Stop();
                    }
                }
                else
                {
                    if (pnlMenu.Top < pnlBG.Bottom) pnlMenu.Location = new Point(pnlMenu.Left, pnlMenu.Top + 2);
                    else
                    {
                        mainModel.MenuStatus = false;
                        mainModel.MenuStatusChanging = false;
                        tmrMenu.Stop();
                    }
                }
            }
        }

        private void OnAvatarToggled()
        {
            if (mainModel.GameStatus == "Main") picAvatar.Visible = true;
            else if (mainModel.GameStatus == "Battle") picAvatar.Visible = false;

            //if (mainModel.AvatarStatus)
            //{
            //    picAvatar.Visible = false;
            //}
            //else
            //{
            //    picAvatar.Visible = true;
            //}
        }

        private void OnMapToggled()
        {
            pnlBG.Visible = (pnlBG.Visible ? false : true);
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
                return (picPlayer.Top - MainModel.MoveDistance >= pnlBG.Top) ? false : true;
            }
        }
        private bool IsPlayerOverBottom
        {
            get
            {
                return (picPlayer.Bottom + MainModel.MoveDistance <= pnlBG.Bottom) ? false : true;
            }
        }
        private bool IsPlayerOverLeft
        {
            get
            {
                return (picPlayer.Left - MainModel.MoveDistance >= pnlBG.Left) ? false : true;
            }
        }
        private bool IsPlayerOverRight
        {
            get
            {
                return (picPlayer.Right + MainModel.MoveDistance <= pnlBG.Right) ? false : true;
            }
        }
        private bool IsPlayerOverMenu
        {
            get
            {
                return (picPlayer.Bottom + MainModel.MoveDistance <= pnlMenu.Top) ? false : true;
            }
        }
        private bool IsPlayerOverAvatarRight
        {
            get
            {
                return (picPlayer.Left + MainModel.MoveDistance >= picAvatar.Right) ? false : true;
            }
        }
        private bool IsPlayerOverAvatarBottom
        {
            get
            {
                return (picPlayer.Top + MainModel.MoveDistance >= picAvatar.Bottom) ? false : true;
            }
        }

        private void ShowCharacterHealthBar()
        {
            lblHealthBar.Visible = true;
            lblHealthBar.Top = picMonster1.Top - 15;
            lblHealthBar.Left = picMonster1.Left + 5;
        }

        private void OnPlayerAttack()
        {
            if (picPlayer.Left - 5 >= picMonster1.Right)
            {
                mainController.Monster1IsAttacked();
                mainModel.MonsterCharacter.HP -= mainModel.PlayerCharacter.AttackDamage;
            }
        }

        private void OnCharacterSpawn()
        {
            picPlayer.Visible = true;
            picMonster1.Visible = true;
            OnMonster1Spawn();
        }

        private void tmrMonster1_Tick(object sender, EventArgs e)
        {
            if (reduce) size--;
            else size++;
            if (size > 500) reduce = true;
            else if (size < 1) reduce = false;
            this.Invalidate();

            if (mainModel.MonsterCharacter.Moving && !mainModel.MonsterCharacter.Attacking)
            {
                //if ((PlayerPressKeyUp) && (!IsPlayerOverTop))
                //{
                //    picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top - MainModel.MoveDistance);
                //}
                //if ((PlayerPressKeyDown))
                //{
                //    if ((MenuWindow) && (!IsPlayerOverMenu) || (!MenuWindow) && (!IsPlayerOverBottom))
                //        picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top + MainModel.MoveDistance);
                //}
                //if ((PlayerPressKeyLeft) && (!IsPlayerOverLeft))
                //{
                //    picPlayer.Location = new Point(picPlayer.Left - MainModel.MoveDistance, picPlayer.Top);
                //}
                //if ((PlayerPressKeyRight) && (!IsPlayerOverRight))
                //{
                //    picPlayer.Location = new Point(picPlayer.Left + MainModel.MoveDistance, picPlayer.Top);
                //}
            }
            if (mainModel.MonsterCharacter.AnimationChanging && !mainModel.MonsterCharacter.Attacking)
            {
                
            }
            if (!mainModel.MonsterCharacter.Moving && !mainModel.MonsterCharacter.Attacking)
            {
                //OnPlayerStandStill(mainModel.PlayerCharacter.Direction);
            }
        }

        private void OnMonster1Spawn()
        {
            object objMonster1Stand = Properties.Resources.ResourceManager.GetObject(mainModel.MonsterCharacter.Name + "East");
            if (picMonster1.Image != (Image)objMonster1Stand) picMonster1.Image = (Image)objMonster1Stand;
        }

        private void OnPlayerMain()
        {
            OnGameStatusChanged();
            OnBackgroundChanged();
            picPlayer.Visible = false;
            lblEXP.Visible = true;
            lblPlayerHealthBar.Visible = false;
            lblMonsterHealthBar.Visible = false;
        }

        private void OnPlayerBattle()
        {
            OnGameStatusChanged();
            OnPlayerStandStill(mainModel.PlayerCharacter.Direction);
            picPlayer.Visible = true;
            lblEXP.Visible = false;
            lblPlayerHealthBar.Visible = true;
            lblMonsterHealthBar.Visible = true;
        }

        private void MenuInit()
        {
            pnlMenu.Location = new Point(72, 521);
        }

        private void BattleLayoutInit()
        {
            picMonsterBattlePosition.Location = new Point(100, 230);
            picPlayerBattlePosition.Location = new Point(600, 230);
        }
    }

    public class TransparentPanel : System.Windows.Forms.Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do Nothing
        }
    }
}
