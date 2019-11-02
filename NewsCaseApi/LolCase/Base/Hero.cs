using System;
using System.Collections.Generic;
using System.Text;

namespace LolCase.Base
{
   public abstract class Hero
    {
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
        public int Healt { get; set; }
        public int Damage { get; set; }

        public abstract void HealtCalc();
        public abstract void DamageCalc();
    }
} 
