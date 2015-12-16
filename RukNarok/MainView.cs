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

        private bool playerAttacking;
        private int attackingTime;
        private int delayTime;
        private int loadingTime;

        private bool MenuWindow = true;
        
        private int monsterCount;
        PictureBox[] monsterBox;
        Random random;

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
            
            MonsterPictureBoxInit();
            random = new Random();

            Notify(mapModel);
            Notify(mainModel);

            monsterCount = mapModel.MapList[mapModel.CurrentMap].monsterList.Count;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            tmrCharacterWalking.Interval = 15;
            tmrCharacterWalking.Start();
            StartGameInit();
            MenuInit();
            BattleLayoutInit();
            mainController.StartGame();
            //mainModel.GameStatus = "Main";
            //OnPlayerMain();
            playerAttacking = false;
            attackingTime = 0;
            delayTime = 0;
            loadingTime = 0;
            mapModel.CurrentMap = 0;
        }

        private void MonsterPictureBoxInit()
        {
            monsterBox = new PictureBox[8]; //mapModel.MapList[mapModel.CurrentMap].monsterList.Count + 1
            monsterBox[0] = picMonster0;
            monsterBox[1] = picMonster1;
            monsterBox[2] = picMonster2;
            monsterBox[3] = picMonster3;
            monsterBox[4] = picMonster4;
            monsterBox[5] = picMonster5;
            monsterBox[6] = picMonster6;
            monsterBox[7] = picMonster7;
        }

        private void StartGameInit()
        {
            picStartGame.Location = new Point(90, 205);
            picStartGame.SizeMode = PictureBoxSizeMode.AutoSize;
            picStartGame.Image = Properties.Resources.PlayGame;
            picStartGame.Visible = true;

            picLoading.Location = new Point(350, 430);
            picLoading.Image = Properties.Resources.LoadingBar;
        }

        private void MenuInit()
        {
            pnlMenu.Location = new Point(72, 521 + 100);
        }

        private void BattleLayoutInit()
        {
            mainModel.BattleStatus = "Inactivity";
            picMonsterBattlePosition.Location = new Point(100, 230);
            picMonsterBattlePosition.SizeMode = PictureBoxSizeMode.CenterImage;
            picPlayerBattlePosition.Location = new Point(600, 230);
            picPlayerBattlePosition.SizeMode = PictureBoxSizeMode.CenterImage;
            picEffectBattlePosition.Location = new Point(250, 180);
            picEffectBattlePosition.SizeMode = PictureBoxSizeMode.Zoom;
            lblBattle.Location = new Point(300, 60);
            lblBattle.Text = "Fight!";

            picPlayerSkill1.Location = new Point(550, 30);
            picPlayerSkill1.SizeMode = PictureBoxSizeMode.AutoSize;
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
                if (mainModel.GameStatus == "Main") OnPlayerMain();
                if (mainModel.GameStatus == "Battle")
                {
                    object objMonsterBattle = Properties.Resources.ResourceManager.GetObject(mainModel.MonsterBattle.Name + "East");
                    picMonsterBattlePosition.Image = (Image)objMonsterBattle;
                }
            }
            else if (model is MainModel)
            {
                OnGameStatusChanged();
                if (mainModel.GameStatus == "StartGame")
                {
                    OnGameStart();
                }
                else if (mainModel.GameStatus == "Loading")
                {
                    OnGameLoading();
                }
                else if (mainModel.GameStatus == "Main" && mainModel.BattleStatus == "Inactivity")
                {
                    //if (mainModel.MenuStatusChanging) tmrMenu.Start();
                    if (mainModel.CharacterSpawned) OnCharacterSpawn();
                    if (mainModel.PlayerCharacter.Moving) OnPlayerMoved();
                    OnBackgroundChanged();
                    OnPlayerMain();
                }
                else if (mainModel.GameStatus == "Battle")
                {
                    if (mainModel.BattleStatus == "Inactivity")
                    {
                        OnPlayerBattle();
                    }
                    else if (mainModel.BattleStatus == "PlayerTurn" || mainModel.BattleStatus == "MonsterTurn")
                    {
                        OnUpdateHealthBar();
                    }
                    else if (mainModel.BattleStatus == "EndToMain")
                    {
                        mainModel.GameStatus = "Main";
                        mainModel.BattleStatus = "Inactivity";
                        OnPlayerMain();
                    }
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
                //if (e.KeyCode == Keys.M)
                //{
                //    mainController.ToggleMenu();
                //}
                if (e.KeyCode == Keys.U)
                {
                    mainModel.PlayerCharacter.EXP += 10;
                    CheckPlayerLevel();
                    OnPlayerUpdateEXP();
                }
            }
            else if (mainModel.GameStatus == "Battle")
            {
                if (mainModel.BattleStatus == "End")
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        mainController.PlayerStopBattle();
                    }
                }
                else if (mainModel.BattleStatus == "PlayerTurn" && !playerAttacking)
                {
                    if (e.KeyCode == Keys.Q || e.KeyCode == Keys.W || e.KeyCode == Keys.E || e.KeyCode == Keys.R)
                    {
                        PlayerSkillAttack(e.KeyCode);
                    }
                }
                else if (mainModel.BattleStatus == "MonsterTurn")
                {
                    lblGameStatus.Text = "NO This is Monster Turn";
                }
                else if (mainModel.BattleStatus == "Waiting")
                {
                    lblGameStatus.Text = "NO need Waiting";
                }
            }
        }

        private void PlayerSkillAttack(Keys attackKey)
        {
            if (!playerAttacking)
            {
                playerAttacking = true;
                lblGameStatus.Text = Convert.ToString(attackKey) + " Attack";
                int skillIndex = 0;
                switch (attackKey)
                {
                    case Keys.Q:
                        skillIndex = 0;
                        break;
                    case Keys.W:
                        skillIndex = 1;
                        break;
                    case Keys.E:
                        skillIndex = 2;
                        break;
                    case Keys.R:
                        skillIndex = 3;
                        break;
                    default:
                        break;
                }
                if (mainModel.PlayerCharacter.SkillList[skillIndex].Player != null)
                {
                    picPlayerBattlePosition.Image = Properties.Resources.NoviceAttackSouthWest;
                    picEffectBattlePosition.Image = mainModel.PlayerCharacter.SkillList[skillIndex].Player;
                    int dmg = mainModel.PlayerCharacter.AttackDamage + mainModel.PlayerCharacter.SkillList[skillIndex].Damage;
                    mainController.CharacterChangeHealth(mainModel.MonsterBattle, -dmg);
                    object objPlayerCast = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Cast");
                    if (picPlayerBattlePosition.Image != (Image)objPlayerCast) picPlayerBattlePosition.Image = (Image)objPlayerCast;
                }
                else
                {
                    lblGameStatus.Text = "No have this skill";
                }
                tmrCharacterAttacking.Start();
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
                            if ((MenuWindow) && (!IsPlayerOverBottom)/*(!IsPlayerOverMenu)*/ || (!MenuWindow) && (!IsPlayerOverBottom))
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

                if (IsPlayerIntersectMonster() != -1)
                {
                    lblGameStatus.Text = "Battle!";
                    mainController.PlayerStartBattle(mapModel.MapList[mapModel.CurrentMap].monsterList[IsPlayerIntersectMonster()]);
                    mainModel.monsterBattleIndex = IsPlayerIntersectMonster() - 1;
                }
                if (IsPlayerIntersectWarp() != 0)
                {
                    //mainController.PlayerWarp(IsPlayerIntersectWarp());
                    if (IsPlayerIntersectWarp() == MainController.Warp.RIGHT)
                        mainController.MapChanged(mapModel.CurrentMap + 1);
                    else if (IsPlayerIntersectWarp() == MainController.Warp.LEFT)
                        mainController.MapChanged(mapModel.CurrentMap - 1);
                }
            }
        }

        private MainController.Warp IsPlayerIntersectWarp()
        {
            if (picPlayer.Bounds.IntersectsWith(picWarpLeft.Bounds))
            {
                return MainController.Warp.LEFT;
            }
            else if (picPlayer.Bounds.IntersectsWith(picWarpRight.Bounds))
            {
                return MainController.Warp.RIGHT;
            }
            return 0;
        }

        private int IsPlayerIntersectMonster()
        {
            for (int i = 0; i < monsterCount; i++)
            {
                if (monsterBox[i] == null)
                {
                    return -1;
                }
                else if (picPlayer.Bounds.IntersectsWith(monsterBox[i].Bounds))
                {
                    return i;
                }
            }
            return -1;
        }

        private void tmrCharacterAttacking_Tick(object sender, EventArgs e)
        {
            //if (mainModel.PlayerCharacter.Attacking && attackingTime == 0)
            //{
            //    if (mainModel.PlayerCharacter.Direction == Direction.NorthWest)
            //    {
            //        object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.NorthWest));
            //        if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
            //    }
            //    else if (mainModel.PlayerCharacter.Direction == Direction.North || mainModel.PlayerCharacter.Direction == Direction.NorthEast)
            //    {
            //        object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.NorthEast));
            //        if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
            //    }
            //    else if (mainModel.PlayerCharacter.Direction == Direction.West || mainModel.PlayerCharacter.Direction == Direction.SouthWest)
            //    {
            //        object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.SouthWest));
            //        if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
            //    }
            //    else if (mainModel.PlayerCharacter.Direction == Direction.East || mainModel.PlayerCharacter.Direction == Direction.SouthEast ||
            //        mainModel.PlayerCharacter.Direction == Direction.South)
            //    {
            //        object objPlayerAttacking = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Attack" + Convert.ToString(Direction.SouthEast));
            //        if (picPlayer.Image != (Image)objPlayerAttacking) picPlayer.Image = (Image)objPlayerAttacking;
            //    }
            //}
            if (attackingTime >= 6)
            {
                //mainController.PlayerStopAttack();
                picEffectBattlePosition.Image = null;
                if (mainModel.BattleStatus == "PlayerTurn")
                {
                    tmrDelay.Start();
                }
                else if (mainModel.BattleStatus == "MonsterTurn")
                {
                    tmrDelay.Start();
                }
                attackingTime = 0;
                tmrCharacterAttacking.Stop();
                return;
            }
            ++attackingTime;
        }

        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            if (mainModel.GameStatus == "Battle")
            {
                if (mainModel.PlayerCharacter.HP <= 0)
                {
                    lblGameStatus.Text = "Player Lose";
                    mainModel.BattleStatus = "End";
                    OnPlayerLose();
                }
                else if (mainModel.MonsterBattle.HP <= 0)
                {
                    lblGameStatus.Text = "Player Win";
                    mainModel.BattleStatus = "End";
                    OnPlayerWin();
                }
            }
            if (delayTime < 3)
            {
                if (mainModel.BattleStatus == "PlayerTurn")
                {
                    mainModel.BattleStatus = "PlayerToMonster";
                }
                else if (mainModel.BattleStatus == "MonsterTurn")
                {
                    mainModel.BattleStatus = "MonsterToPlayer";
                }
            }
            else
            {
                if (mainModel.BattleStatus == "PlayerToMonster")
                {
                    mainModel.BattleStatus = "MonsterTurn";
                    PlayerStopAttackAnimation();
                    MonsterStartAttack();
                }
                else if (mainModel.BattleStatus == "MonsterToPlayer")
                {
                    mainModel.BattleStatus = "PlayerTurn";
                    playerAttacking = false;
                }
                delayTime = 0;
                tmrDelay.Stop();
                return;
            }
            ++delayTime;
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
                if (pnlBG.BackgroundImage != mapModel.MapList[mapModel.CurrentMap].MainBG)
                    pnlBG.BackgroundImage = mapModel.MapList[mapModel.CurrentMap].MainBG;
                //pnlBG.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (mainModel.GameStatus == "Battle")
            {
                if (pnlBG.BackgroundImage != mapModel.MapList[mapModel.CurrentMap].BattleBG)
                    pnlBG.BackgroundImage = mapModel.MapList[mapModel.CurrentMap].BattleBG;
                //pnlBG.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void OnGameStatusChanged()
        {
            if (mainModel.GameStatus == "Main" || mainModel.GameStatus == "Battle")
            {
                OnMenuToggled();
                OnAvatarToggled();
            }
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
            else picAvatar.Visible = false;

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
                return (picPlayer.Top - MainModel.MoveDistance >= pnlBG.Top + lblEXP.Height) ? false : true;
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
        }

        private void OnCharacterSpawn()
        {
            picPlayer.Visible = true;
            picMonster1.Visible = true;
            //OnMonster1Spawn();
        }

        private void tmrMonster1_Tick(object sender, EventArgs e)
        {
            if (reduce) size--;
            else size++;
            if (size > 500) reduce = true;
            else if (size < 1) reduce = false;
            this.Invalidate();

            //if (mainModel.MonsterCharacter.Moving && !mainModel.MonsterCharacter.Attacking)
            //{
            //    //if ((PlayerPressKeyUp) && (!IsPlayerOverTop))
            //    //{
            //    //    picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top - MainModel.MoveDistance);
            //    //}
            //    //if ((PlayerPressKeyDown))
            //    //{
            //    //    if ((MenuWindow) && (!IsPlayerOverMenu) || (!MenuWindow) && (!IsPlayerOverBottom))
            //    //        picPlayer.Location = new Point(picPlayer.Left, picPlayer.Top + MainModel.MoveDistance);
            //    //}
            //    //if ((PlayerPressKeyLeft) && (!IsPlayerOverLeft))
            //    //{
            //    //    picPlayer.Location = new Point(picPlayer.Left - MainModel.MoveDistance, picPlayer.Top);
            //    //}
            //    //if ((PlayerPressKeyRight) && (!IsPlayerOverRight))
            //    //{
            //    //    picPlayer.Location = new Point(picPlayer.Left + MainModel.MoveDistance, picPlayer.Top);
            //    //}
            //}
            //if (mainModel.MonsterCharacter.AnimationChanging && !mainModel.MonsterCharacter.Attacking)
            //{

            //}
            //if (!mainModel.MonsterCharacter.Moving && !mainModel.MonsterCharacter.Attacking)
            //{
            //    //OnPlayerStandStill(mainModel.PlayerCharacter.Direction);
            //}
        }

        //private void OnMonster1Spawn()
        //{
        //    object objMonster1Stand = Properties.Resources.ResourceManager.GetObject(mainModel.MonsterCharacter.Name + "East");
        //    if (picMonster1.Image != (Image)objMonster1Stand) picMonster1.Image = (Image)objMonster1Stand;
        //}

        private void CheckPlayerLevel()
        {
            if (mainModel.PlayerCharacter.EXP >= mainModel.PlayerCharacter.MaxEXP)
            {
                mainModel.PlayerCharacter.Level++;
                mainModel.PlayerCharacter.EXP = 0;
                mainModel.PlayerCharacter.MaxEXP = mainModel.PlayerCharacter.Level * 100;
            }
        }

        private void OnGameStart()
        {
            int rand = random.Next(1, 2);
            object objGameStartBG = Properties.Resources.ResourceManager.GetObject("StartGame" + rand);
            if (pnlBG.BackgroundImage != (Image)objGameStartBG) pnlBG.BackgroundImage = (Image)objGameStartBG;

            PlaySound("StartGame");

            InvisibleAllObjects();
        }

        private void InvisibleAllObjects()
        {
            picPlayer.Visible = false;
            MonsterVisible(false);
            picPlayerBattlePosition.Visible = false;
            picMonsterBattlePosition.Visible = false;
            picEffectBattlePosition.Visible = false;
            lblBattle.Visible = false;
            lblEXP.Visible = false;
            lblPlayerHealthBar.Visible = false;
            lblMonsterHealthBar.Visible = false;
            picAvatar.Visible = false;
            pnlMenu.Visible = false;
            picWarpLeft.Visible = false;
            picWarpRight.Visible = false;
            //picStartGame.Visible = false;

            picPlayerSkill1.Visible = false;
            pnlBattleStatus.Visible = false;
        }

        private void OnGameLoading()
        {
            pnlBG.BackgroundImage = Properties.Resources.LoadingBG;
            picStartGame.Visible = false;
            lblLoading.Visible = true;
            picLoading.Visible = true;
            tmrLoading.Start();
            mainModel.Player.Stop();

            InvisibleAllObjects();
        }

        private void OnPlayerMain()
        {
            OnMapInit();
            MonsterPictureBoxInit();
            OnBackgroundChanged();
            OnGameStatusChanged();
            picPlayer.Location = new Point(66, 300);
            picPlayer.Visible = true;
            MonsterVisible(true);
            if (mapModel.CurrentMap != 0) picWarpLeft.Visible = true;
            picWarpRight.Visible = true;
            picPlayerBattlePosition.Visible = false;
            picMonsterBattlePosition.Visible = false;
            picEffectBattlePosition.Visible = false;
            pnlBattleStatus.Visible = false;
            lblBattle.Visible = false;
            lblEXP.Visible = true;
            lblPlayerHealthBar.Visible = false;
            lblMonsterHealthBar.Visible = false;
            CheckPlayerLevel();
            OnPlayerUpdateEXP();
            tmrCharacterAttacking.Stop();
            tmrDelay.Stop();

            PlaySound("Main");

            picPlayerSkill1.Visible = false;
        }

        private void OnPlayerBattle()
        {
            mainModel.BattleStatus = "PlayerTurn";
            OnGameStatusChanged();
            lblGameStatus.Text = mainModel.BattleStatus;
            OnPlayerStandStill(mainModel.PlayerCharacter.Direction);
            picPlayer.Visible = false;
            MonsterVisible(false);
            picWarpLeft.Visible = false;
            picWarpRight.Visible = false;
            object objPlayerBattle = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Battle");
            if (picPlayerBattlePosition.Image != (Image)objPlayerBattle) picPlayerBattlePosition.Image = (Image)objPlayerBattle;
            picPlayerBattlePosition.Visible = true;
            picMonsterBattlePosition.Visible = true;
            picEffectBattlePosition.Visible = true;
            tmrCharacterAttacking.Stop();
            tmrDelay.Stop();
            playerAttacking = false;
            delayTime = 0;
            attackingTime = 0;
            lblBattle.Text = "Fight!";
            lblBattle.Visible = true;
            lblEXP.Visible = false;
            OnUpdateHealthBar();
            lblPlayerHealthBar.Visible = true;
            lblMonsterHealthBar.Visible = true;

            PlaySound("Battle");

            pnlBattleStatus.BackgroundImage = Properties.Resources.BattleMenuBG;
            pnlBattleStatus.Visible = true;
            picPlayerSkill1.Image = Properties.Resources.Portal;
            picPlayerSkill1.Visible = true;
        }

        private void OnPlayerUpdateEXP()
        {
            lblEXP.Text = "EXP : " + mainModel.PlayerCharacter.EXP + "/" + mainModel.PlayerCharacter.MaxEXP;
            lblEXP.Size = new Size(mainModel.PlayerCharacter.EXP * 800 / (mainModel.PlayerCharacter.MaxEXP), 13);
        }

        private void OnUpdateHealthBar()
        {
            lblPlayerHealthBar.Text = "HP : " + mainModel.PlayerCharacter.HP + "/" + mainModel.PlayerCharacter.MaxHP;
            lblMonsterHealthBar.Text = "HP : " + mainModel.MonsterBattle.HP + "/" + mainModel.MonsterBattle.MaxHP;
        }

        private void OnPlayerHit()
        {
        }

        private void OnMapInit()
        {
            monsterCount = mapModel.MapList[mapModel.CurrentMap].monsterList.Count;
            for (int i = 0; i < monsterCount; i++)
            {
                //lblGameStatus.Text = mapModel.MapList[currentMap].monsterList[i].Name;
                string[] directionMonster = new string[2];
                directionMonster[0] = "West";
                directionMonster[1] = "East";
                lblGameStatus.Text = Convert.ToString(mapModel.CurrentMap);
                object objMonster = Properties.Resources.ResourceManager.GetObject(mapModel.MapList[mapModel.CurrentMap].monsterList[i].Name + directionMonster[random.Next(2)]);
                if (monsterBox[i] != null) monsterBox[i].Image = (Image)objMonster;
                int randX, randY;
                do
                {
                    randX = random.Next(125, 780);
                    randY = random.Next(125, 500);
                } while (randX < 125 && randY < 125);
                if (monsterBox[i] != null)
                {
                    monsterBox[i].Location = new Point(randX, randY);
                    if (monsterBox[i].Bounds.IntersectsWith(picWarpLeft.Bounds) || monsterBox[i].Bounds.IntersectsWith(picWarpRight.Bounds))
                    {
                        --i;
                    }
                }
            }
            picWarpLeft.Location = new Point(-7, 300);
            picWarpLeft.Visible = false;
            picWarpRight.Location = new Point(755, 300);
            picWarpRight.Visible = false;
        }

        private void MonsterVisible(bool boolVar)
        {
            for (int i = 0; i < monsterCount; i++)
            {
                if (mapModel.MapList[mapModel.CurrentMap].monsterList[i].HP > 0)
                {
                    monsterBox[i].Visible = boolVar;
                }
            }
        }

        private void BattleWaiting()
        {
            if (mainModel.BattleStatus == "Waiting")
            {
                //tmrCharacterAttacking.Start();
            }
        }

        private void MonsterStartAttack()
        {
            if (mainModel.BattleStatus == "MonsterTurn")
            {
                int skillIndex = random.Next(2);
                int dmg = mainModel.MonsterBattle.AttackDamage + mainModel.MonsterBattle.SkillList[skillIndex].Damage;
                mainController.CharacterChangeHealth(mainModel.PlayerCharacter, -dmg);
                picEffectBattlePosition.Image = mainModel.MonsterBattle.SkillList[skillIndex].Monster;
                object objPlayerOnHit = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "OnHit");
                if (picPlayerBattlePosition.Image != (Image)objPlayerOnHit) picPlayerBattlePosition.Image = (Image)objPlayerOnHit;
                tmrCharacterAttacking.Start();
            }
        }

        private void OnPlayerWin()
        {
            lblBattle.Text = "You WIN";
            mainModel.PlayerCharacter.EXP += mainModel.MonsterBattle.EXP;
            object objPlayerBattle = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Battle");
            if (picPlayerBattlePosition.Image != (Image)objPlayerBattle) picPlayerBattlePosition.Image = (Image)objPlayerBattle;
            //mainModel.MonsterBattle.Death = true;
            //mapModel.MapList[currentMap].monsterList[mainModel.monsterBattleIndex].Death = true;
            //monsterBox[mainModel.monsterBattleIndex + 1] = null;
            tmrDelay.Start();
        }

        private void OnPlayerLose()
        {
            lblBattle.Text = "You LOSE";
            object objPlayerDead = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Dead");
            if (picPlayerBattlePosition.Image != (Image)objPlayerDead) picPlayerBattlePosition.Image = (Image)objPlayerDead;
            tmrDelay.Start();
        }

        private void tmrLoading_Tick(object sender, EventArgs e)
        {
            if (loadingTime == 4)
            {
                lblLoading.Text = ".Loading.";
                lblLoading.Left -= 2;
            }
            else if (loadingTime == 9)
            {
                lblLoading.Text = "..Loading..";
                lblLoading.Left -= 2;
            }
            else if (loadingTime == 14)
            {
                lblLoading.Text = "...Loading...";
                lblLoading.Left -= 2;
            }
            else if (loadingTime == 19)
            {
                lblLoading.Text = "....Loading....";
                lblLoading.Left -= 2;
            }
            else if (loadingTime >= 20)
            {
                lblLoading.Text = "Loading";
                lblLoading.Left += 8;
                lblLoading.Visible = false;
                picLoading.Visible = false;
                mainController.MainGame();
                tmrLoading.Stop();
                loadingTime = 0;
            }
            ++loadingTime;
        }

        private void picStartGame_Click(object sender, EventArgs e)
        {
            mainController.LoadingGame();
        }

        private void PlaySound(string titleSound)
        {
            switch (titleSound)
            {
                case "StartGame":
                    try
                    {
                        mainModel.Player = new System.Media.SoundPlayer(Properties.Resources.StartSound);
                        mainModel.Player.PlayLooping();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error playing start game sound");
                    }
                    break;
                case "Main":
                    try
                    {
                        mainModel.Player = new System.Media.SoundPlayer(Properties.Resources.MainSound);
                        mainModel.Player.PlayLooping();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error playing main sound");
                    }
                    break;
                case "Battle":
                    try
                    {
                        mainModel.Player = new System.Media.SoundPlayer(Properties.Resources.BattleSound);
                        mainModel.Player.PlayLooping();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error playing battle sound");
                    }
                    break;
                default:
                    break;
            }
        }

        private void PlayerStopAttackAnimation()
        {
            object objPlayerBattle = Properties.Resources.ResourceManager.GetObject(mainModel.PlayerCharacter.ClassName + "Battle");
            if (picPlayer.Image != (Image)objPlayerBattle) picPlayer.Image = (Image)objPlayerBattle;
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