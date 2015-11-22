﻿using System;
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
        private Monster monsterCharacter;
        internal Monster MonsterCharacter
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

        public MainModel()
        {
            MenuStatus = true;
            MenuStatusChanging = false;

            CreatePlayerCharacter();
            PlayerCharacter.Direction = Direction.South;//Direction.NULL
            PlayerCharacter.Moving = true;
            PlayerCharacter.AnimationChanging = true;
            PlayerMovingDirection = new bool[10];
            for (int i = 0; i < PlayerMovingDirection.Length; i++)
            {
                PlayerMovingDirection[i] = false;
            }
            CreateMonsterCharacter();
            MonsterCharacter.Direction = Direction.South;
            MonsterCharacter.Moving = true;
            MonsterCharacter.AnimationChanging = true;

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
            PlayerCharacter.HP = 100;
            PlayerCharacter.EXP = 0;
            PlayerCharacter.AttackDamage = 10;
        }

        private void CreateMonsterCharacter()
        {
            MonsterCharacter = new Monster();
            MonsterCharacter.Name = "BabyDesertWolf";
            MonsterCharacter.HP = 100;
            MonsterCharacter.AttackDamage = 10;
        }
    }
}
