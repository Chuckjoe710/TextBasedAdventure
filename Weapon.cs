using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedAdventure
{
    public class Weapon
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
            protected set { _durability = value; }
        }
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }
        public int Amount
        {
            get { return _amount; }
            protected set { _amount = value; }
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
        public static Weapon GenerateWeapon()
        {
            Random random = new Random();
            double x = random.Next(3, 60);
            Console.WriteLine("GenWep");
            if (x <= 6)
            {
                Console.WriteLine("Dagger");
                return new Dagger(x);
            }
            else if (x <= 24 && x > 6)
            {
                Console.WriteLine("ShortSword");
                return new ShortSword(x);
            }
            else if (x <= 48 && x > 24)
            {
                Console.WriteLine("LongSword");
                return new LongSword(x);
            }
            else
            {
                Console.WriteLine("GreatSword");
                return new GreatSword(x);
            }
        }
    }
}
