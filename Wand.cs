using System;
using System.Collections.Generic;
using System.Text;

namespace KlasserOgObjekter
{
    public class Wand
    {
        private int wandDamage;
        private string name;
        private int cost;

        public int WandDamage { get => wandDamage; set => wandDamage = value; }
        public string Name { get => name; set => name = value; }
        public int Cost { get => cost; set => cost = value; }

        public Wand(int wandDamage, string name, int cost)
        {
            WandDamage = wandDamage;
            Name = name;
            Cost = cost;
        }
    }
}
