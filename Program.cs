using System;

namespace TextBasedAdventure
{
    class Program
    {
        static void Main()
        {
            Player Charles = new Player("Charles", 100, 0);
            Console.WriteLine("You awake as you always do. Nothing special you put your pants on with both legs at the same time however.");
            Console.WriteLine("After leaving you turn arount to lock the door to your house and it's not there");
            Console.WriteLine("Like the whole thing... Gone. Unsure what to do you decide that you should don some armor and a weapon");
            Console.WriteLine("You think to yourself \"Man Am I happy I always carry a dagger with me\"");
            Charles.AddWeapon(new Weapon(5, 3, 20, "Dagger", 1, 15));
            Console.WriteLine("You notice 3 sets of armor each being having a focuse on defense or offense.");
            Console.WriteLine("The first set has platemetal armor and a shortsword");
            Console.WriteLine("Set number two is chainmail with a longsword");
            Console.WriteLine("The third and final set is leather armor and a greatsword that would make Havel blush");
            Console.WriteLine("Which set will you take?");
            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1:
                    Charles.ArmorThresh = 15;
                    Charles.AddWeapon(new Weapon(8, 7, 35, "Shortsword", 1, 12));
                    break;
                case 2:
                    Charles.ArmorThresh = 10;
                    Charles.AddWeapon(new Weapon(12, 25, 30, "Longsword", 1, 8));
                    break;
                case 3:
                    Charles.ArmorThresh = 5;
                    Charles.AddWeapon(new Weapon(15, 49, 25, "Greatsword", 1, 5));
                    break;
                default:
                    break;
            }
            Console.WriteLine("You set out on your quest and open the first door");
            for(int k = 0; k < 21; k++)
            {
                if(k == 5 || k == 10 || k == 15 || k == 20)
                {
                    Console.WriteLine("You enter an area that looks safe to rest");
                    Charles.Health += 40;
                    if (Charles.Health > 100)
                        Charles.Health = 100;
                    for(int i = 0; i < Charles.AmountWeapons; i++)
                    {
                        Charles.Weapons[i].Durability += 20;
                    }
                }
                else if(k == 11)
                {
                    new Room(Charles, 2);
                }
                else if(k == 21)
                {
                    new Room(Charles, 3);
                }
                else
                {
                    new Room(Charles, 1);
                }
            }
            Console.WriteLine("You Win... that wasn't supposed to happen.");
            Console.ReadKey();
        }
    }
}
