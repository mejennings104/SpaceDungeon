using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class SpaceGoop : Monster
    {
        public bool HasTeeth { get; set; }

        public SpaceGoop(string name,
                         int life,
                         int maxLife,
                         int hitChance,
                         int block,
                         int minDamage,
                         int maxDamage,
                         string description,
                         bool hasTeeth) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HasTeeth = hasTeeth;
        }
        //public override int CalcDamage()
        //{
        //    int result = MinDamage;
        //    result = MaxDamage;
        //}
    }
}
