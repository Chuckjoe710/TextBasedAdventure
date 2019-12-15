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
        public int Damage
        {
            get { return _damage; }
            private set { _damage = value; }
        }
        public double Length
        {
            get { return _length; }
            private set { _length = value; }
        }
        public int Durability
        {
            get { return _durability; }
            private set { _durability = value; }
        }
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public int Amount
        {
            get { return _amount; }
            private set { _amount = value; }
        }
        #endregion
        public Weapon(int dam, double len, int dura, string name, int amt)
        {
            Damage = dam;
            Length = len;
            Durability = dura;
            Name = name;
            Amount = amt;
        }
    }
}
