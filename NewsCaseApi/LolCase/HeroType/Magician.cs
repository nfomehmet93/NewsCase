using LolCase.Base;
using LolCase.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LolCase.HeroType
{
    public class Magician : Hero
    {
        public override void AddItem(Item item)
        {
            Items.Add(item);
            if (ItemType.Hp == item.Type)
                Health += item.MagicianValue;
            else
                Damage += item.MagicianValue;
        }

        public override bool CheckItem()
        {
            if (Items.Any(x => x.Type == ItemType.Hp))
                return true;

            return false;
        }
    }
}
