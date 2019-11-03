using LolCase.Base;
using LolCase.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LolCase.HeroType
{
    public class Support : Hero
    {
        public override void AddItem(Item item)
        {
            Items.Add(item);
            if (ItemType.Hp == item.Type)
                Health += item.SupportValue;
            else
                Damage += item.SupportValue;
        }

        public override bool CheckItem()
        {
            if (Items.Any(x=>x.Type==ItemType.Xp))
                return true;

            return false;
        }
    }
}
