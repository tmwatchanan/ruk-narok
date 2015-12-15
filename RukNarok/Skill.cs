using System.Collections.Generic;
using System.Drawing;

namespace RukNarok
{
    class Skill
    {
        private Image player;
        internal Image Player
        {
            get;
            set;
        }
        private Image monster;
        internal Image Monster
        {
            get;
            set;
        }

        private int damage;
        internal int Damage
        {
            get;
            set;
        }

        internal static Skill Arrow
        {
            get;
            set;
        }
        internal static Skill Bite
        {
            get;
            set;
        }
        internal static Skill Bomb
        {
            get;
            set;
        }
        internal static Skill Cutmoon
        {
            get;
            set;
        }
        internal static Skill Explosion
        {
            get;
            set;
        }
        internal static Skill Fire
        {
            get;
            set;
        }
        internal static Skill FireStab
        {
            get;
            set;
        }
        internal static Skill Flash
        {
            get;
            set;
        }
        internal static Skill Knife1
        {
            get;
            set;

        }
        internal static Skill Knife2
        {
            get;
            set;
        }
        internal static Skill Lightning
        {
            get;
            set;
        }
        internal static Skill Magic
        {
            get;
            set;
        }
        internal static Skill Poison
        {
            get;
            set;
        }
        internal static Skill Punch
        {
            get;
            set;
        }
        internal static Skill Scratch1
        {
            get;
            set;
        }
        internal static Skill Scratch2
        {
            get;
            set;
        }
        internal static Skill Slash1
        {
            get;
            set;
        }
        internal static Skill Slash2
        {
            get;
            set;
        }
        internal static Skill Spear
        {
            get;
            set;
        }
        internal static Skill Stab1
        {
            get;
            set;
        }
        internal static Skill Stab2
        {
            get;
            set;
        }
        internal static Skill Tornado
        {
            get;
            set;
        }
        internal static Skill Water1
        {
            get;
            set;
        }
        internal static Skill Water2
        {
            get;
            set;
        }
        internal static Skill Wave1
        {
            get;
            set;
        }
        internal static Skill Wave2
        {
            get;
            set;
        }


        public static void SkillInit()
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

        private static Skill ArrowInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.ArrowRight;
            objSkill.Monster = Properties.Resources.ArrowLeft;
            return objSkill;
        }
        private static Skill BiteInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.BiteRight;
            objSkill.Monster = Properties.Resources.BiteLeft;
            return objSkill;
        }
        private static Skill BombInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.BombRight;
            objSkill.Monster = Properties.Resources.BombLeft;
            return objSkill;
        }
        private static Skill CutmoonInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.CutMoonRight;
            objSkill.Monster = Properties.Resources.CutMoonLeft;
            return objSkill;
        }
        private static Skill ExplosionInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.ExplosionRight;
            objSkill.Monster = Properties.Resources.ExplosionLeft;
            return objSkill;
        }
        private static Skill FireInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.FireRight;
            objSkill.Monster = Properties.Resources.FireLeft;
            return objSkill;
        }
        private static Skill FireStabInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.FireStabRight;
            objSkill.Monster = Properties.Resources.FireStabLeft;
            return objSkill;
        }
        private static Skill FlashInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.FlashRight;
            objSkill.Monster = Properties.Resources.FlashLeft;
            return objSkill;
        }
        private static Skill Knife1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Knife1Right;
            objSkill.Monster = Properties.Resources.Knife1Left;
            return objSkill;
        }
        private static Skill Knife2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Knife2Right;
            objSkill.Monster = Properties.Resources.Knife2Left;
            return objSkill;
        }
        private static Skill LightningInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.LightningRight;
            objSkill.Monster = Properties.Resources.LightningLeft;
            return objSkill;
        }
        private static Skill MagicInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.MagicRight;
            objSkill.Monster = Properties.Resources.MagicLeft;
            return objSkill;
        }
        private static Skill PoisonInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.PoisonRight;
            objSkill.Monster = Properties.Resources.PoisonLeft;
            return objSkill;
        }
        private static Skill PunchInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 50;
            objSkill.Player = Properties.Resources.PunchRight;
            objSkill.Monster = Properties.Resources.PunchLeft;
            return objSkill;
        }
        private static Skill Scratch1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Scratch1Right;
            objSkill.Monster = Properties.Resources.Scratch1Left;
            return objSkill;
        }
        private static Skill Scratch2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Scratch2Right;
            objSkill.Monster = Properties.Resources.Scratch2Left;
            return objSkill;
        }
        private static Skill Slash1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Slash1Right;
            objSkill.Monster = Properties.Resources.Slash1Left;
            return objSkill;
        }
        private static Skill Slash2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Slash2Right;
            objSkill.Monster = Properties.Resources.Slash2Left;
            return objSkill;
        }
        private static Skill SpearInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.SpearRight;
            objSkill.Monster = Properties.Resources.SpearLeft;
            return objSkill;
        }
        private static Skill Stab1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Stab1Right;
            objSkill.Monster = Properties.Resources.Stab1Left;
            return objSkill;
        }
        private static Skill Stab2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Stab2Right;
            objSkill.Monster = Properties.Resources.Stab2Left;
            return objSkill;
        }
        private static Skill TornadoInit()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.TornadoRight;
            objSkill.Monster = Properties.Resources.TornadoLeft;
            return objSkill;
        }
        private static Skill Water1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Water1Right;
            objSkill.Monster = Properties.Resources.Water1Left;
            return objSkill;
        }
        private static Skill Water2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Water2Right;
            objSkill.Monster = Properties.Resources.Water2Left;
            return objSkill;
        }
        private static Skill Wave1Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Wave1Right;
            objSkill.Monster = Properties.Resources.Wave1Left;
            return objSkill;
        }
        private static Skill Wave2Init()
        {
            Skill objSkill = new Skill();
            objSkill.Damage = 5;
            objSkill.Player = Properties.Resources.Wave2Right;
            objSkill.Monster = Properties.Resources.Wave2Left;
            return objSkill;
        }
    }
}
