using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RukNarok
{
    public enum Direction
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

    class MainModel : Model
    {
        private string gameStatus;
        internal string GameStatus
        {
            get;
            set;
        }

        private string battleStatus;
        internal string BattleStatus
        {
            get;
            set;
        }

        private bool menuStatus;
        internal bool MenuStatus
        {
            get;
            set;
        }
        private bool menuStatusChanging;
        internal bool MenuStatusChanging
        {
            get;
            set;
        }

        private bool backgroundChanging;
        internal bool BackgroundChanging
        {
            get;
            set;
        }

        private bool avatarStatus;
        internal bool AvatarStatus
        {
            get;
            set;
        }

        private Player playerCharacter;
        internal Player PlayerCharacter
        {
            get;
            set;
        }
        private bool characterSpawned;
        internal bool CharacterSpawned
        {
            get;
            set;
        }

        private bool[] playerMovingDirection;
        internal bool[] PlayerMovingDirection
        {
            get;
            set;
        }
        public bool PressUp = false;
        public bool PressDown = false;
        public bool PressLeft = false;
        public bool PressRight = false;

        private Keys playerPressedKeyUp;
        internal Keys PlayerPressedKeyUp
        {
            get;
            set;
        }
        private Keys playerPressedKeyDown;
        internal Keys PlayerPressedKeyDown
        {
            get;
            set;
        }

        public const int MoveDistance = 3;
        public const int MoveDistanceOblique = 2;

        private Monster monsterBattle;
        internal Monster MonsterBattle
        {
            get;
            set;
        }

        public MainModel()
        {
            GameStatus = "Main";
            MenuStatus = false;
            MenuStatusChanging = false;
            AvatarStatus = false;
            BackgroundChanging = false;

            SkillInit();

            CreatePlayerCharacter();
            PlayerCharacter.Direction = Direction.South;//Direction.NULL
            PlayerCharacter.Moving = true;
            PlayerCharacter.AnimationChanging = true;
            PlayerMovingDirection = new bool[10];
            for (int i = 0; i < PlayerMovingDirection.Length; i++)
            {
                PlayerMovingDirection[i] = false;
            }

            CharacterSpawned = true;

            PlayerPressedKeyUp = Keys.None;
            PlayerPressedKeyDown = Keys.None;
        }

        public void Update()
        {
            NotifyAll();
        }

        private void CreatePlayerCharacter()
        {
            PlayerCharacter = new Player();
            PlayerCharacter.ClassName = "Novice";
            PlayerCharacter.MaxHP = PlayerCharacter.HP = 100;
            PlayerCharacter.Level = 1;
            PlayerCharacter.EXP = 0;
            PlayerCharacter.MaxEXP = PlayerCharacter.Level * 100;
            PlayerCharacter.AttackDamage = 10;
            for (int i = 0; i < 4; i++)
                PlayerCharacter.SkillList.Add(Punch);
            PlayerCharacter.SkillList[1] = Knife1;
            PlayerCharacter.SkillList[2] = Knife2;
        }

        internal Skill Arrow
        {
            get;
            set;
        }
        internal Skill Bite
        {
            get;
            set;
        }
        internal Skill Bomb
        {
            get;
            set;
        }
        internal Skill Cutmoon
        {
            get;
            set;
        }
        internal Skill Explosion
        {
            get;
            set;
        }
        internal Skill Fire
        {
            get;
            set;
        }
        internal Skill FireStab
        {
            get;
            set;
        }
        internal Skill Flash
        {
            get;
            set;
        }
        internal Skill Knife1
        {
            get;
            set;

        }
        internal Skill Knife2
        {
            get;
            set;
        }
        internal Skill Lightning
        {
            get;
            set;
        }
        internal Skill Magic
        {
            get;
            set;
        }
        internal Skill Poison
        {
            get;
            set;
        }
        internal Skill Punch
        {
            get;
            set;
        }
        internal Skill Scratch1
        {
            get;
            set;
        }
        internal Skill Scratch2
        {
            get;
            set;
        }
        internal Skill Slash1
        {
            get;
            set;
        }
        internal Skill Slash2
        {
            get;
            set;
        }
        internal Skill Spear
        {
            get;
            set;
        }
        internal Skill Stab1
        {
            get;
            set;
        }
        internal Skill Stab2
        {
            get;
            set;
        }
        internal Skill Tornado
        {
            get;
            set;
        }
        internal Skill Water1
        {
            get;
            set;
        }
        internal Skill Water2
        {
            get;
            set;
        }
        internal Skill Wave1
        {
            get;
            set;
        }
        internal Skill Wave2
        {
            get;
            set;
        }


        private void SkillInit()
        {
            Arrow = ArrowInit();
            Bite = BiteInit();
            Bomb = BombInit();
            Cutmoon = CutmoonInit();
            Explosion = ExplosionInit();
            Fire = FireInit();
            FireStab = FireStabInit();
            Flash = FlashInit();
            Knife1 = Knife1Init();
            Knife2 = Knife2Init();
            Lightning = LightningInit();
            Magic = MagicInit();
            Poison = PoisonInit();
            Scratch1 = Scratch1Init();
            Scratch2 = Scratch2Init();
            Slash1 = Slash1Init();
            Slash2 = Slash2Init();
            Spear = SpearInit();
            Stab1 = Stab1Init();
            Stab2 = Stab2Init();
            Tornado = TornadoInit();
            Water1 = Water1Init();
            Water2 = Water2Init();
            Wave1 = Wave1Init();
            Wave2 = Wave2Init();
            Punch = PunchInit();
        }

        private Skill ArrowInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.ArrowRight;
            objSkill.Monster = Properties.Resources.ArrowLeft;
            return objSkill;
        }
        private Skill BiteInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.BiteRight;
            objSkill.Monster = Properties.Resources.BiteLeft;
            return objSkill;
        }
        private Skill BombInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.BombRight;
            objSkill.Monster = Properties.Resources.BombLeft;
            return objSkill;
        }
        private Skill CutmoonInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.CutMoonRight;
            objSkill.Monster = Properties.Resources.CutMoonLeft;
            return objSkill;
        }
        private Skill ExplosionInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.ExplosionRight;
            objSkill.Monster = Properties.Resources.ExplosionLeft;
            return objSkill;
        }
        private Skill FireInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.FireRight;
            objSkill.Monster = Properties.Resources.FireLeft;
            return objSkill;
        }
        private Skill FireStabInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.FireStabRight;
            objSkill.Monster = Properties.Resources.FireStabLeft;
            return objSkill;
        }
        private Skill FlashInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.FlashRight;
            objSkill.Monster = Properties.Resources.FlashLeft;
            return objSkill;
        }
        private Skill Knife1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Knife1Right;
            objSkill.Monster = Properties.Resources.Knife1Left;
            return objSkill;
        }
        private Skill Knife2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Knife2Right;
            objSkill.Monster = Properties.Resources.Knife2Left;
            return objSkill;
        }
        private Skill LightningInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.LightningRight;
            objSkill.Monster = Properties.Resources.LightningLeft;
            return objSkill;
        }
        private Skill MagicInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.MagicRight;
            objSkill.Monster = Properties.Resources.MagicLeft;
            return objSkill;
        }
        private Skill PoisonInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.PoisonRight;
            objSkill.Monster = Properties.Resources.PoisonLeft;
            return objSkill;
        }
        private Skill PunchInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.PunchRight;
            objSkill.Monster = Properties.Resources.PunchLeft;
            return objSkill;
        }
        private Skill Scratch1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Scratch1Right;
            objSkill.Monster = Properties.Resources.Scratch1Left;
            return objSkill;
        }
        private Skill Scratch2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Scratch2Right;
            objSkill.Monster = Properties.Resources.Scratch2Left;
            return objSkill;
        }
        private Skill Slash1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Slash1Right;
            objSkill.Monster = Properties.Resources.Slash1Left;
            return objSkill;
        }
        private Skill Slash2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Slash2Right;
            objSkill.Monster = Properties.Resources.Slash2Left;
            return objSkill;
        }
        private Skill SpearInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.SpearRight;
            objSkill.Monster = Properties.Resources.SpearLeft;
            return objSkill;
        }
        private Skill Stab1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Stab1Right;
            objSkill.Monster = Properties.Resources.Stab1Left;
            return objSkill;
        }
        private Skill Stab2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Stab2Right;
            objSkill.Monster = Properties.Resources.Stab2Left;
            return objSkill;
        }
        private Skill TornadoInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.TornadoRight;
            objSkill.Monster = Properties.Resources.TornadoLeft;
            return objSkill;
        }
        private Skill Water1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Water1Right;
            objSkill.Monster = Properties.Resources.Water1Left;
            return objSkill;
        }
        private Skill Water2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Water2Right;
            objSkill.Monster = Properties.Resources.Water2Left;
            return objSkill;
        }
        private Skill Wave1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Wave1Right;
            objSkill.Monster = Properties.Resources.Wave1Left;
            return objSkill;
        }
        private Skill Wave2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Wave2Right;
            objSkill.Monster = Properties.Resources.Wave2Left;
            return objSkill;
        }
    }
}
