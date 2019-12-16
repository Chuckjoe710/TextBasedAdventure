using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    public class ShortSword : Weapon
    {
        public ShortSword(double y)
        {
            Random random = new Random();
            Damage = random.Next(8, 10);
            Length = y;
            Durability = random.Next(35, 40);
            Name = "Short Sword";
            Speed = random.Next(12, 15);
            Amount = 1;
        }
    }
}
