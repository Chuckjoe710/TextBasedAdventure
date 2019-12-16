using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    public class Dagger : Weapon
    {
        public Dagger(double y)
        {
            Random random = new Random();
            Damage = random.Next(5, 6);
            Length = y;
            Durability = random.Next(20, 30);
            Name = "Dagger";
            Speed = random.Next(15, 20);
            Amount = random.Next(1, 2);
        }
        public void QuickSlash()
        {

        }
    }
}
