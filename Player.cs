using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace KlasserOgObjekter
{
    public class Player
    {
        private string name;
        private int health;
        private int strength;
        private int level;
        private double xp;
        private int mana;
        Random rnd = new Random();
        public Player(string name, int health, int level, int xp, int mana)
        {
            Name = name;
            Health = health;
            Strength = rnd.Next(4, (level + 1) * 2);
            Level = level;
            Xp = xp;
            Mana = mana;
        }

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Level { get => level; set => level = value; }
        public double Xp { get => xp; set => xp = value; }
        public int Mana { get => mana; set => mana = value; }

        public int Attack()
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri($@"{MiddleClass.Dir}\pew.mp3"));
            player.Play();
            Random rnd = new Random();
            if(Mana <= 100+(Level+26))
            {
                Mana += Level+7;
            }
            return Strength + rnd.Next(1, 10);
        }

        public int AnapneoAttack()
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri($@"{MiddleClass.Dir}\pew.mp3"));
            player.Play();
            Random rnd = new Random();
            Mana -= Level+13;
            if(Mana <= 50)
            {
                
            }
            return Strength + rnd.Next(10, 20);
        }

        public int TakeDamage(int dmgReceived)
        {
            Health -= dmgReceived;
            return Health;
        }
        public void LevelUp()
        {
            Xp *= 1.5;
            if (Xp >= Level * 2.5)
            {
                Level++;
                MessageBox.Show($"{name} {Level}");
            }
        }
    }
}
