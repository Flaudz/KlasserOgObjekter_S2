using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace KlasserOgObjekter
{
    class MiddleClass
    {
        // Her laver jeg Voldemort fra target klassen
        static Target Voldemort = new Target(100, 1, 1);
        // Her laver jeg Harry fra target klassen
        static Player Harry = new Player("Harry Potter", 100, 1, 1, 100);
        // Her får jeg stien til den mappe som programmet ligger i med \Assets
        public static string Dir = $@"{Environment.CurrentDirectory}\Assets";

        // Her laver jeg en HarryBasicAttack som kalde Harry.Attack, giver den skade til Voldemort og tjekker om han er død og hvis han er det skal den kalde Harry.LevelUp
        public static string HarryBasicAttack()
        {
            int hDamage = Harry.Attack();
            Voldemort.Health -= hDamage;
            if (Voldemort.Health <= 0)
            {
                Voldemort.Health = 100;
                Harry.LevelUp();
            }
            return @"Health: "+Voldemort.Health;
        }

        // Det samme som over den her men der er noget der gør sådan at det skader mere
        public static string HarryAnapneoAttack()
        {
            int hDamage = Harry.AnapneoAttack();
            Voldemort.Health -= hDamage;
            if (Voldemort.Health <= 0)
            {
                Voldemort.Health = 100;
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri($@"{Dir}\deadSound.mp3"));
                player.Play();
                Harry.LevelUp();
            }
            return @"Health: " + Voldemort.Health;
        }

        // Her tjekker den om manaen er mindre eller ligmed 50
        public static bool checkManaLow()
        {
            if(Harry.Mana <= 50)
            {
                return false;
            } else
            {
                return true;
            }
        }


        // Her angriber Voldemort
        public static string VoldemortAttack()
        {
            int vDamage = Voldemort.Attack(Harry);
            Harry.Health -= vDamage;
            if(Harry.Health <= 0)
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri($@"{Dir}\deadSound.mp3"));
                player.Play();
                Harry.Health = 100;
                Harry.Mana = 100 + (Harry.Level + 26);
                Voldemort.LevelUp();
            }
            
            
            return "" + Harry.Health;
        }
    }
}
