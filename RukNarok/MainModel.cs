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
            GameStatus = "StartGame";
            MenuStatus = false;
            MenuStatusChanging = false;
            AvatarStatus = false;
            BackgroundChanging = false;

            Skill.SkillInit();
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
                PlayerCharacter.SkillList.Add(Skill.Punch);
            PlayerCharacter.SkillList[1] = Skill.Knife1;
            PlayerCharacter.SkillList[2] = Skill.Knife2;
        }
    }
}
