using System;
using System.Collections.Generic;
using System.Text;

namespace LolCase.Loot
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int AdcValue { get; set; }
        public int MagicianValue { get; set; }
        public int SupportValue { get; set; }
    }
}
