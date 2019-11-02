using LolCase.Loot;
using System;
using System.Collections.Generic;
using System.Text;

namespace LolCase.Base
{
   public abstract class Hero
    {
        public Hero()
        {
            Items = new List<Item>();
        }
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
        public int Healt { get; set; } = 0;
        public int Damage { get; set; } = 0;
        public List<Item> Items { get; set; }
        public  void WriteProperties()
        {
            Console.WriteLine("Tip : {0}",Type.ToString());
            Console.WriteLine("İsim : {0}",Name);
            Console.WriteLine("Sağlık Değeri : {0} {1}", Healt, ItemType.Hp.ToString());
            Console.WriteLine("Atak Gücü : {0} {1}", Damage, ItemType.Xp.ToString());
        }
        public abstract void AddItem(Item item);
        public abstract bool CheckItem();
    }
} 
