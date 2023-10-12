using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nowyrpg;

namespace nowyrpg
{
    public class Item
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }
    }

    public class Equipment : Item
    {
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int Price { get; set; }

        public Equipment(string name, int attackPower, int defensePower, int price) : base(name)
        {
            AttackPower = attackPower;
            DefensePower = defensePower;
            Price = price;
        }
    }
    public class Sword : Equipment
    {
        public Sword() : base("Sword", 5, 0, 20)
        {
        }
    }
    public class Shield : Equipment
    {
        public Shield() : base("Shield", 0, 5, 40)
        {
        }
    }
}
