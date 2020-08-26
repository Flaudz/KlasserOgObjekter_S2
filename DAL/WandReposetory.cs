using System;
using System.Collections.Generic;
using System.Text;

namespace KlasserOgObjekter.DAL
{
    public class WandReposetory
    {

        public List<Wand> WandList()
        {
            List<Wand> wands = new List<Wand>();

            Wand theElderWand = new Wand(10, "theElderWand");
            Wand Fraxinus = new Wand(6, "Fraxinus");
            Wand Populus = new Wand(4, "Populus");
            Wand Juglans = new Wand(7, "Juglans nigra");

            wands.Add(theElderWand);
            wands.Add(Fraxinus);
            wands.Add(Populus);
            wands.Add(Juglans);


            return wands;
        }
    }
}
