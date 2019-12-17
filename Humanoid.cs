using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextBasedAdventure
{
    class Humanoid : Enemy
    {
        public Humanoid()
        {
            string[] line = File.ReadAllLines("C:\\Users\\patva\\source\\repos\\TextBasedAdventure\\Names\\HumanoidNames.txt");
            int x = Globals.random.Next(0, line.Length);
            Health = Globals.random.Next(20, 35);
            ArmorThresh = Globals.random.Next(3, 6);
            Name = line[x];
            NumberOfArms = 2;
            NumberOfLegs = 2;
            Weapon.GenerateWeapon();
        }
    }
}
