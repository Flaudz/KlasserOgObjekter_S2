﻿using KlasserOgObjekter.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace KlasserOgObjekter
{
    class MiddleClass
    {
        static Random rnd = new Random();
        
        // Her laver jeg Voldemort fra target klassen
        Target Voldemort = new Target("Voldemort", 1, 1, 100, 0);
        // Her laver jeg Harry fra target klassen
        Player Harry = new Player("Harry Potter", 1, 1, 100, 0);
        // Her får jeg stien til den mappe som programmet ligger i med \Assets
        public string Dir = $@"{Environment.CurrentDirectory}\Assets";

        WandReposetory wandReposetory = new WandReposetory();

        public WandReposetory WandReposetory { get => wandReposetory; set => wandReposetory = value; }

        public MiddleClass()
        {

        }

        // Her laver jeg en HarryBasicAttack som kalde Harry.Attack, giver den skade til Voldemort og tjekker om han er død og hvis han er det skal den kalde Harry.LevelUp
        public string HarryBasicAttack()
        {
        
            int hDamage = Harry.Attack(1, Dir);
            Voldemort.Health -= hDamage;
            if (Voldemort.Health <= 0)
            {
                Voldemort.Health = 100 + rnd.Next(Voldemort.Level, Voldemort.Level + 27);

                Harry.Gold += 5 * Voldemort.Level;
                Harry.LevelUp();
            }
            return @"Health: "+Voldemort.Health;
        }

        // Det samme som over den her men der er noget der gør sådan at det skader mere
        public string HarryAnapneoAttack()
        {
            int hDamage = Harry.AnapneoAttack(1, Dir);
            Voldemort.Health -= hDamage;
            if (Voldemort.Health <= 0)
            {

                Voldemort.Health = 100 + rnd.Next(Voldemort.Level + 15, Voldemort.Level + 27);
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri($@"{Dir}\deadSound.mp3"));
                player.Play();
                Harry.Gold += 5 * Voldemort.Level;
                
                Harry.LevelUp();
            }
            return @"Health: " + Voldemort.Health;
        }

        public void giveHarryStrenght(int amountOfStrenght)
        {
            foreach (Wand wand in WandReposetory.wands)
            {
                if(wand.WandDamage == amountOfStrenght && Harry.Gold >= wand.Cost)
                {
                    MessageBox.Show($"+ {wand.WandDamage}");
                    Harry.Strength += amountOfStrenght;
                    Harry.Gold -= wand.Cost;
                    wand.Cost *= 2;
                }
            }
        }

        public string returnGold()
        {
            return Harry.Gold.ToString();
        }

        // Her tjekker den om manaen er mindre eller ligmed 50
        public  bool checkManaLow()
        {
            if(Harry.Mana <= 50)
            {
                return false;
            } else
            {
                return true;
            }
        }

        // Her laver jeg en return med Voldemorts Level sådan at jeg kan få det ind i guien
        public string vLvlCheck()
        {
            return $"{Voldemort.Level}";
        }
        // Her laver jeg en return med Harrys Level sådan at jeg kan få det ind i guien
        public string hLvlCheck()
        {
            return $"{Harry.Level}";
        }

        // Her angriber Voldemort
        public string VoldemortAttack()
        {
            int vDamage = Voldemort.Attack(0, Dir);
            Harry.Health -= vDamage;
            if(Harry.Health <= 0)
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri($@"{Dir}\deadSound.mp3"));
                player.Play();
                Harry.Health = 100 + rnd.Next(Harry.Level+15, Harry.Level + 27);
                Harry.Mana = 100 + (Harry.Level + 26);
                Voldemort.LevelUp();
            }
            
            return "" + Harry.Health;
        }
    }
}
