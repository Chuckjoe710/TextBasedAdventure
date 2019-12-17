using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextBasedAdventure
{
    class Plant : Enemy
    {
        public Plant()
        {
            string[] line = File.ReadAllLines("C:\\Users\\patva\\source\\repos\\TextBasedAdventure\\Names\\PlantNames.txt");
            int x = Globals.random.Next(0, line.Length);
            Health = Globals.random.Next(60, 70);
            ArmorThresh = 0;
            Name = line[x];
            NumberOfArms = 0;
            NumberOfLegs = 4;
            Weapon.GenerateRoots();
        }
    }
}
