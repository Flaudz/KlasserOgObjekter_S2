using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KlasserOgObjekter
{
    public class Target : Player
    {
        public Target(string name, int level, int xp, int mana, int gold) : base(name, level, xp, mana, gold)
        {
        }

        public override string LevelUp()
        {
            Xp *= 15;
            base.LevelUp();
            return Level.ToString();
        }
    }
}
