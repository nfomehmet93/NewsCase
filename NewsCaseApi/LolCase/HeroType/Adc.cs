using System;
using LolCase.Champions;
using System.Collections.Generic;
using System.Text;
using LolCase.Base;
using LolCase.Loot;
using System.Linq;

namespace LolCase.HeroType
{
    public class Adc : Hero
    {
        public override void AddItem(Item item)
        {
            Items.Add(item);
            if (ItemType.Hp == item.Type)
                Health += item.AdcValue;
            else
                Damage += item.AdcValue;
        }

        public override bool CheckItem()
        {
            if (Items.Any(x => x.Type == ItemType.Xp)&& Items.Any(x => x.Type == ItemType.Hp))
                return true;

            return false;
        }

      
    }
}
