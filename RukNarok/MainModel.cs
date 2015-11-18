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
        
        private Player playerCharacter;
        internal Player PlayerCharacter
        {
            get;
            set;
        }
        private bool playerMoving = true;
        internal bool PlayerMoving
        {
            get;
            set;
        }
        private bool playerAnimationChanging = true;
        internal bool PlayerAnimationChanging
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
        private Direction playerDirection;
        internal Direction PlayerDirection
        {
            get;
            set;
        }
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

        public MainModel()
        {
            MenuStatus = true;
            MenuStatusChanging = false;

            PlayerDirection = Direction.South;//Direction.NULL
            PlayerMoving = true;
            PlayerAnimationChanging = true;
            PlayerMovingDirection = new bool[10];
            for (int i = 0; i < PlayerMovingDirection.Length; i++)
            {
                PlayerMovingDirection[i] = false;
            }
            PlayerPressedKeyUp = Keys.None;
            PlayerPressedKeyDown = Keys.None;
            CreatePlayerCharacter();
        }

        public void Update()
        {
            NotifyAll();
        }

        private void CreatePlayerCharacter()
        {
            PlayerCharacter = new Player();
            PlayerCharacter.ClassName = "Novice";
        }
    }
}
