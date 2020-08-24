using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace KlasserOgObjekter
{
    class MiddleClass
    {
        static Target Voldemort = new Target(100, 1, 1);
        static Player Harry = new Player("Harry Potter", 100, 1, 1, 100);

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

        public static string HarryAnapneoAttack()
        {
            int hDamage = Harry.AnapneoAttack();
            Voldemort.Health -= hDamage;
            if (Voldemort.Health <= 0)
            {
                Voldemort.Health = 100;
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri(@"C:\Users\nico936d\Documents\S-2\Uge_34\Onsdag_KlasserOgObjeker\WPF_Gaming3\KlasserOgObjekter\deadSound.mp3"));
                player.Play();
                Harry.LevelUp();
            }
            return @"Health: " + Voldemort.Health;
        }

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



        public static string VoldemortAttack()
        {
            int vDamage = Voldemort.Attack(Harry);
            Harry.Health -= vDamage;
            if(Harry.Health <= 0)
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri(@"C:\Users\nico936d\Documents\S-2\Uge_34\Onsdag_KlasserOgObjeker\WPF_Gaming3\KlasserOgObjekter\deadSound.mp3"));
                player.Play();
                Harry.Health = 100;
                Harry.Mana = 100 + (Harry.Level + 26);
                Voldemort.LevelUp();
            }
            
            
            return "" + Harry.Health;
        }
    }
}
