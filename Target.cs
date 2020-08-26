using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KlasserOgObjekter
{
    public class Target : Player
    {
        public Target(string name, int level, int xp, int mana) : base(name, level, xp, mana)
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
