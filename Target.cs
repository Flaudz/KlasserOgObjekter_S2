using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KlasserOgObjekter
{
    public class Target
    {
        // Fields
        string Name = "Voldemort";
        private int health;
        private int strength;
        private int level;
        private double xp;
        Random rnd = new Random();

        // Properties
        public int Health { get => health; set => health = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Level { get => level; set => level = value; }
        public double Xp { get => xp; set => xp = value; }

        // Constructor
        public Target(int health, int level, double xp)
        {
            Health = health;
            Strength = rnd.Next(4, (level + 1) * 2);
            Level = level;
            Xp = xp;
        }

        // Hvor Target angriber
        public int Attack(Player player)
        {
            int damage = Strength + rnd.Next(1, 15);
            return damage;
        }

        // Hvor den tjekker om man har nok xp til at level op.
        public void LevelUp()
        {
            Xp *= 1.5;
            if (Xp >= Level * 2.5)
            {
                Level++;
                MessageBox.Show($"{Name} {Level}");
            }
        }
    }
}
