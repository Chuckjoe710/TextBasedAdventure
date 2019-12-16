using System;

namespace TextBasedAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Charles = new Player("Charles", 50, 10);

            Weapon weapon = new Weapon(Weapon.GenerateWeapon());
            Charles.AddWeapon(weapon);
            new Room(Charles);

            Console.ReadKey();
        }
    }
}
