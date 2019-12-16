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
        public void BasicAttack(Player player, Weapon weapon, Enemy enemy)
        {
            if (weapon.Durability > 0)
            {
                player.Attack(enemy, weapon.Damage, weapon.Amount);
                weapon.Durability--;
            }
            else
            {
                Console.WriteLine("The damage to your greatsword is so extensive that it deals half damage");
                player.Attack(enemy, weapon.Damage / 2, weapon.Amount);
            }
        }
        public void Smash(Player player, GreatSword weapon, Enemy enemy)
        {
            int dam;
            if (weapon.Durability > 0)
            {
                dam = Convert.ToInt32(Math.Floor(weapon.Damage * 1.5));
                player.Attack(enemy, dam, weapon.Amount);
                enemy.IsStunned = true;
                if (weapon.Durability >= 5)
                    weapon.Durability -= 5;
                else
                    weapon.Durability = 0;
            }
            else
            {
                Console.WriteLine("Due to the state of the weapon you are unable to properly smash with your greatsword");
                BasicAttack(player, weapon, enemy);
            }
        }
    }
}
