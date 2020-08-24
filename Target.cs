using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KlasserOgObjekter
{
    public class Target
    {
        string Name = "Voldemort";
        private int health;
        private int strength;
        private int level;
        private double xp;
        Random rnd = new Random();

        public int Health { get => health; set => health = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Level { get => level; set => level = value; }
        public double Xp { get => xp; set => xp = value; }

        public Target(int health, int level, double xp)
        {
            Health = health;
            Strength = rnd.Next(4, (level + 1) * 2);
            Level = level;
            Xp = xp;
        }
        public void TakeDamage(int dmgReceived)
        {
            Health = Health - dmgReceived;
        }
        public int Attack(Player player)
        {
            Random rnd = new Random();
            int damage = Strength + rnd.Next(1, 15);
            return damage;
        }

        public void LevelUp()
        {
            Xp *= 2;
            if (Xp >= Level * 2)
            {
                Level++;
                MessageBox.Show($"{Name} {Level}");
            }
        }
    }
}
