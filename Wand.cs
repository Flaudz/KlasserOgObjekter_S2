using System;
using System.Collections.Generic;
using System.Text;

namespace KlasserOgObjekter
{
    public class Wand
    {
        private int wandDamage;
        private string name;

        public int WandDamage { get => wandDamage; set => wandDamage = value; }
        public string Name { get => name; set => name = value; }

        public Wand(int wandDamage, string name)
        {
            WandDamage = wandDamage;
            Name = name;
        }
    }
}
