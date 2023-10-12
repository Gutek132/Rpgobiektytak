using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using nowyrpg;

namespace nowyrpg
{
    public class Shop
    {
        private List<Equipment> equipment;

        public Shop()
        {
            equipment = new List<Equipment>();
        }

        public void AddEquipment(Equipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public Equipment GetEquipment(int index)
        {
            return this.equipment[index];
        }

        public int GetNumEquipment()
        {
            return this.equipment.Count;
        }
        public void BoostStats(Character player, Item item)
        {
            if (item is Equipment equipment)
            {
                player.Attack += equipment.AttackPower;
                player.Defense += equipment.DefensePower;
            }
        }
    }
}