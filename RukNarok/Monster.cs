﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RukNarok
{
    public class Monster : Character
    {
        private bool healthBar = false;
        internal bool HealthBar
        {
            get;
            set;
        }

        public Monster()
        {
            for (int i = 0; i < 2; ++i)
                SkillList.Add(Skill.Bite);
        }
    }
}
