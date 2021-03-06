﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace KlasserOgObjekter
{
    public class Player
    {
        // Fields
        private int id;
        private string name;
        private int health;
        private int strength;
        private int level;
        private double xp;
        private int mana;
        private int gold;
        Random rnd = new Random();

        // Cunstructor
        public Player(string name, int level, int xp, int mana, int gold)
        {
            Id = id;
            Name = name;
            Health = 100 + rnd.Next(level, level + 27);
            Strength = rnd.Next(4, (level + 1) * 2);
            Level = level;
            Xp = xp;
            Mana = mana;
            Gold = gold;
        }

        public Player()
        {
        }

        public Player(string name, int level, int strength, int health)
        {
            Name = name;
            Level = level;
            Strength = strength;
            Health = health;
        }

        // Properties
        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Level { get => level; set => level = value; }
        public double Xp { get => xp; set => xp = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Id { get => id; set => id = value; }

        // Player Basic attack 
        public int Attack(int wandDamage, string dir)
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri($@"{dir}\pew.mp3"));
            player.Play();
            if(Mana <= 100+(Level+26))
            {
                Mana += Level+7;
            }
            return (Strength + rnd.Next(1, 10)) + wandDamage;
        }

        // Player AnapneoAttack
        public int AnapneoAttack(int wandDamage, string dir)
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri($@"{dir}\pew.mp3"));
            player.Play();
            Mana -= Level+13;
            if(Mana <= 50)
            {
                
            }
            return (Strength + rnd.Next(50, 70)) + wandDamage;
        }

        // Tjekker hvis player har nok xp til at level op
        public virtual string LevelUp()
        {
            Xp *= 1.5;
            if (Xp >= Level * 2.5)
            {
                
                Level++;
                
                MessageBox.Show($"{name} {Level}");
            }
            return Level.ToString();
        }
    }
}
