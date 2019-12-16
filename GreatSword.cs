using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    class GreatSword : Weapon
    {
        public GreatSword(double y)
        {
            Random random = new Random();
            Damage = random.Next(15, 20);
            Length = y;
            Durability = random.Next(20, 30);
            Name = "Great Sword";
            Speed = random.Next(5, 8);
            Amount = 1;
        }
    }
}
