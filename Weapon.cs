using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    class Weapon
    {
        #region fields
        private int _damage;
        private double _length;
        private int _durability;
        private string _name;
        private int _amount;
        private int _speed;
        public int Damage
        {
            get { return _damage; }
            protected set { _damage = value; }
        }
        public double Length
        {
            get { return _length; }
            protected set { _length = value; }
        }
        public int Durability
        {
            get { return _durability; }
            set { _durability = value; }
        }
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public int Speed
        {
            get { return _speed; }
            protected set { _speed = value; }
        }
        #endregion
        public Weapon()
        {
        }
        public Weapon(int dam, double len, int dura, string name, int amt, int spd)
        {
            Damage = dam;
            Length = len;
            Durability = dura;
            Name = name;
            Amount = amt;
            Speed = spd;
        }
        public Weapon(Weapon weapon)
        {
            Damage = weapon.Damage;
            Length = weapon.Length;
            Durability = weapon.Durability;
            Name = weapon.Name;
            Amount = weapon.Amount;
            Speed = weapon.Speed;
        }
        public void GenerateWeapon()
        {
            double x = Globals.random.Next(3, 60);
            if (x <= 6)
            {
                Damage = Globals.random.Next(5, 6);
                Length = x;
                Durability = Globals.random.Next(20, 30);
                Name = "Dagger";
                Speed = Globals.random.Next(15, 20);
                Amount = Globals.random.Next(1, 2);
            }
            else if (x <= 24 && x > 6)
            {
                Damage = Globals.random.Next(8, 10);
                Length = x;
                Durability = Globals.random.Next(35, 40);
                Name = "Short Sword";
                Speed = Globals.random.Next(12, 15);
                Amount = 1;
            }
            else if (x <= 48 && x > 24)
            {
                Damage = Globals.random.Next(12, 16);
                Length = x;
                Durability = Globals.random.Next(30, 50);
                Name = "Long Sword";
                Speed = Globals.random.Next(8, 12);
                Amount = 1;
            }
            else
            {
                Damage = Globals.random.Next(15, 20);
                Length = x;
                Durability = Globals.random.Next(25, 45);
                Name = "Great Sword";
                Speed = Globals.random.Next(5, 8);
                Amount = 1;
            }
        }
        public void BasicAttack(Player player, Enemy enemy)
        {
            if(Durability > 0)
            {
                player.Attack(enemy, Damage, Amount);
                Durability--;
            }
            else
            {
                Console.WriteLine("Your weapon is too damaged to do perform to its full potential. It does half damage.");
                player.Attack(enemy, Damage / 2, Amount);
            }
        }
        public void SpecialAttack(Player player, Enemy enemy)
        {
            if (Length <= 6)
            {
                if(Durability > 0)
                {
                    player.Attack(enemy, Damage, Amount);
                    player.Attack(enemy, Damage, Amount);
                    if (Durability >= 2)
                        Durability -= 2;
                    else
                        Durability = 0;
                }
                else
                {
                    Console.WriteLine("You are unsure if you did this attack if you would be able to retrive you dagger(s).");
                    this.BasicAttack(player, enemy);
                }
            }
            else if (Length <= 24 && Length > 6)
            {
                if (Durability > 0)
                {
                    player.Attack(enemy, Damage + enemy.ArmorThresh, Amount);
                    if (Durability >= 4)
                        Durability -= 4;
                    else
                        Durability = 0;
                }
                else
                {
                    Console.WriteLine("Upon looking at the shortsword lacks it the sharpness to properly penetrate the armor.");
                    this.BasicAttack(player, enemy);
                }
            }
            else if (Length <= 48 && Length > 24)
            {
                if (Durability > 0)
                {
                    player.Attack(enemy, Damage, Amount);
                    if (Durability >= 5)
                        Durability -= 5;
                    else
                        Durability = 0;
                    enemy.IsStunned = true;
                }
                else
                {
                    Console.WriteLine("Your longsword is no more useful than a metal stick.");
                    this.BasicAttack(player, enemy);
                }
            }
            else
            {
                if(Durability > 0)
                {
                    player.Attack(enemy, Convert.ToInt32(Math.Floor(Damage * 1.5)), Amount);
                    if (Durability >= 8)
                        Durability -= 8;
                    else
                        Durability = 0;
                }
                else
                {
                    Console.WriteLine("Damage to the greatsword prevents you from smash your opponent.");
                    this.BasicAttack(player, enemy);
                }
            }
        }
        public void GenerateDoubleLS()
        {
            Damage = Globals.random.Next(12, 16);
            Length = Globals.random.Next(25, 48);
            Durability = Globals.random.Next(30, 50);
            Name = "Long Sword";
            Speed = Globals.random.Next(8, 12);
            Amount = 2;
        }
        public void GenerateClub()
        {
            Damage = Globals.random.Next(25, 30);
            Length = Globals.random.Next(60, 84);
            Durability = Globals.random.Next(30, 50);
            Name = "Giant Club";
            Speed = 1;
            Amount = 1;
        }
        public void GenerateMouth()
        {
            Damage = Globals.random.Next(5, 10);
            Length = 0;
            Durability = int.MaxValue;
            Name = "Mouth";
            Speed = Globals.random.Next(20, 30);
            Amount = 1;
        }
        public void GenerateRoots()
        {
            Damage = Globals.random.Next(1, 2);
            Length = Globals.random.Next(20, 40);
            Durability = int.MaxValue;
            Name = "Roots";
            Speed = Globals.random.Next(12, 18);
        }
    }
}
