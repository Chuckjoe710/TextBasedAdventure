using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextBasedAdventure
{
    class Animal : Enemy
    {
        public Animal()
        {
            string[] line = File.ReadAllLines(@"../../../Names/AnimalNames.txt");
            int x = Globals.random.Next(0, line.Length);
            Health = Globals.random.Next(20, 25);
            ArmorThresh = 0;
            Name = line[x];
            NumberOfArms = 0;
            NumberOfLegs = 4;
            Weapon.GenerateRoots();
        }
    }
}
