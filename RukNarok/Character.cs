﻿using System.Collections.Generic;
using System.Drawing;

namespace RukNarok
{
    class Character
    {
        private string name;
        private int hp;
        private int level;
        private int exp;
        private int attackDamage;
        private Location position;
        private List<Image> skillList;

        internal string Name
        {
            get;
            set;
        }
        internal int HP
        {
            get;
            set;
        }
        internal int Level
        {
            get;
            set;
        }
        internal int EXP
        {
            get;
            set;
        }
        internal int AttackDamage
        {
            get;
            set;
        }
        internal Location Position
        {
            get;
            set;
        }
        internal List<Image> SkillList
        {
            get;
            set;
        }
        private Direction direction;
        internal Direction Direction
        {
            get;
            set;
        }
        private bool moving = true;
        internal bool Moving
        {
            get;
            set;
        }
        private bool animationChanging = true;
        internal bool AnimationChanging
        {
            get;
            set;
        }
        private bool attacking = false;
        internal bool Attacking
        {
            get;
            set;
        }
        private bool isAttacked = false;
        internal bool IsAttacked
        {
            get;
            set;
        }

        public Character()
        {
            Name = "Unknown";
            Level = 0;
            HP = -1;
            EXP = -1;
            AttackDamage = 0;
            //Position.X = 0;
            //Position.Y = 0;
            SkillList = new List<Image>();
        }
    }
}
