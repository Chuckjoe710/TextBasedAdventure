using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    class Humanoid:Enemy
    {
        public Humanoid(int hp, int at, string nme) :base (hp, at, 2, 2, nme)
        {
            Weapon weapon = new Weapon(Weapon.GenerateWeapon());
            EquipWeapon(weapon);
        }
    }
}
