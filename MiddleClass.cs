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
        
        // Her laver jeg target fra target klassen
        // Her laver jeg Harry fra target klassen
        Player harry = new Player();
        Target target = new Target();
        List<Target> targets = new List<Target>();
        // Her får jeg stien til den mappe som programmet ligger i med \Assets
        public string Dir = $@"{Environment.CurrentDirectory}\Assets";
        

        List<Wand> wands = new List<Wand>();

        db db = new db();
        public List<Wand> Wands { get => wands; set => wands = value; }
        public Player Harry { get => harry; set => harry = value; }

        public MiddleClass()
        {
            
        }
        public void addPlayers()
        {
            targets = db.GetTargets();
            harry = db.GetPlayers();
        }

        public void changeTarget()
        {

            if(Harry.Level < 8)
            {
                target = targets[0];
            }
            else if(Harry.Level >= 8 && Harry.Level < 21)
            {
                target = targets[1];
            }
            else if(Harry.Level >= 21)
            {
                target = targets[2];
            }
        }

        public void addWands()
        {
            wands = db.GetWands();
        }
        // Her laver jeg en HarryBasicAttack som kalde Harry.Attack, giver den skade til target og tjekker om han er død og hvis han er det skal den kalde Harry.LevelUp
        public string HarryBasicAttack()
        {
        
            int hDamage = Harry.Attack(1, Dir);
            target.Health -= hDamage;
            if (target.Health <= 0)
            {
                target.Health = 100 + rnd.Next(target.Level, target.Level + 27);

                Harry.Gold += 5 * target.Level;
                Harry.LevelUp();
                changeTarget();
            }
            return @"Health: "+target.Health;
        }

        // Det samme som over den her men der er noget der gør sådan at det skader mere
        public string HarryAnapneoAttack()
        {
            int hDamage = Harry.AnapneoAttack(1, Dir);
            target.Health -= hDamage;
            if (target.Health <= 0)
            {

                target.Health = 100 + rnd.Next(target.Level + 15, target.Level + 27);
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri($@"{Dir}\deadSouind.mp3"));
                player.Play();
                Harry.Gold += 5 * target.Level;
                Harry.LevelUp();
                changeTarget();
            }
            return @"Health: " + target.Health;
        }

        public void giveHarryStrenght(int amountOfStrenght)
        {
            foreach (Wand wand in wands)
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

        // Her laver jeg en return med targets Level sådan at jeg kan få det ind i guien
        public string vLvlCheck()
        {
            return $"{target.Level}";
        }
        // Her laver jeg en return med Harrys Level sådan at jeg kan få det ind i guien
        public string hLvlCheck()
        {
            return $"{Harry.Level}";
        }

        // Her angriber target
        public string targetAttack()
        {
            int vDamage = target.Attack(0, Dir);
            Harry.Health -= vDamage;
            if(Harry.Health <= 0)
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri($@"{Dir}\deadSound.mp3"));
                player.Play();
                Harry.Health = 100 + rnd.Next(Harry.Level+15, Harry.Level + 27);
                Harry.Mana = 100 + (Harry.Level + 26);
                target.LevelUp();
            }
            
            return "" + Harry.Health;
        }
    }
}
