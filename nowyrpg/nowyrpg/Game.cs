using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nowyrpg;

namespace nowyrpg
{
    public class Game
    {
        private Character player;
        private Shop shop;

        public Game()
        {
            player = null;
            shop = new Shop();
        }

        public void Start()
        {

            Console.WriteLine("Choose a character class:");
            Console.WriteLine("(1) Warrior");
            Console.WriteLine("(2) Mage");

            Sword sword = new Sword();
            Shield shield = new Shield();

            shop.AddEquipment(sword);
            shop.AddEquipment(shield);

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                player = new Warrior();
            }
            else if (choice == 2)
            {
                player = new Mage();
            }

            while (player.Health > 0)
            {
                Info.ShowCharacterStats(player);

                List<Monster> monsters = new List<Monster>
                {
                    new Monster("Goblin"),
                    new Monster("Orc"),
                    new Monster("Troll"),
                    new Monster("Dragon"),
                    new Monster("Lich"),
                    new Monster("Hydra")
                };

                Monster monster = monsters[new Random().Next(monsters.Count)];
                monster.Health += player.Level * 20;
                monster.Attack += player.Level * 10;
                
                Console.WriteLine("You encounter a {0}.", monster.Name);
                while (player.Health > 0 && monster.Health > 0)
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("(1) Attack");
                    Console.WriteLine("(2) Heal");
                    Console.WriteLine("(3) Suicide");
                    Console.WriteLine("(4) Check stats");
                    Console.WriteLine("(5) Check inventory");
                    Console.WriteLine("(6) Shop");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            player.Attack1(monster);
                            monster.Attack1(player);
                            break;
                        case 2:
                            Character.Heal(player);
                            player.ShowStats();
                            break;
                        case 3:
                            player.Suicide();
                            player.ShowStats();
                            break;
                        case 4:
                            player.ShowStats();
                            break;
                        case 5:
                            Inventory inventory = player.Inventory;

                            Console.WriteLine("==========================");
                            Console.WriteLine("Inventory:");
                            for (int i = 0; i < inventory.items.Count; i++)
                            {
                                Console.WriteLine("{0}. {1}", i , inventory.items[i].Name);
                            }
                            break;
                        case 6:
                            Console.WriteLine("===========================");
                            Console.WriteLine("Which item do you want to buy?");
                            Console.WriteLine("You have {0} gold", player.Gold);
                            for (int i = 0; i < shop.GetNumEquipment(); i++)
                            {
                                Console.WriteLine("{0}. {1}({2})", i , shop.GetEquipment(i).Name, shop.GetEquipment(i).Price);
                            }

                            choice = Convert.ToInt32(Console.ReadLine());

                            Equipment equipment = shop.GetEquipment(choice);

                            if (player.Gold >= equipment.Price)
                            {
                                player.Inventory.AddItem(equipment);
                                player.Gold -= equipment.Price;
                                Console.WriteLine("===========================");
                                Console.WriteLine("You succesfully bought {0}", equipment.Name);
                                Console.WriteLine("===========================");
                                shop.BoostStats(player, equipment);
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough gold to buy that item.");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                if (player.Health <= 0)
                {
                    Console.WriteLine("You have been defeated.");
                    break;
                }
                else if (monster.Health <= 0)
                {
                    Console.WriteLine("You have defeated the {0}.", monster.Name);
                    player.Gold += monster.Gold;
                    Character.GainXP(player,monster);
                    Console.WriteLine("Now you have {0}/100 XP", player.XP);
                }
            }
        }
    }
}
