using System;
using System.Collections.Generic;
using System.Text;

namespace KlasserOgObjekter.DAL
{
    public class WandReposetory
    {

        public static List<Wand> WandList()
        {
            List<Wand> wands = new List<Wand>();


            Wand theElderWand = new Wand(10, "theElderWand", 250);
            Wand Fraxinus = new Wand(6, "Fraxinus", 150);
            Wand Populus = new Wand(4, "Populus", 100);
            //Wand Juglans = new Wand(7, "Juglans nigra");
            //Wand Acacia = new Wand(1, "Acacia");


            wands.Add(theElderWand);
            wands.Add(Fraxinus);
            wands.Add(Populus);
            //wands.Add(Juglans);
            //wands.Add(Acacia);


            return wands;
        }
    }
}
