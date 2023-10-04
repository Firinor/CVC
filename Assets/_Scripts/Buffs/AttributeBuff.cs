using System.Collections.Generic;
using UnityEngine;

namespace Buffs
{
    [CreateAssetMenu(fileName = "AttributeBuff", menuName = "Buffs/AttributeBuff")]
    public class AttributeBuff : BuffCore
    {
        public UnitAttribute[] attributes;

        public override void OnStart(BasicUnit unit)
        {
            foreach (var attribute in attributes)
            {
                unit.AddToAttribute(new KeyValuePair<EUnitAttribute, float>(attribute.Attribute, attribute.Value));
            }
        }

        public override void OnEnd(BasicUnit unit)
        {
            foreach (var attribute in attributes)
            {
                unit.RemoveFromAttribute(new KeyValuePair<EUnitAttribute, float>(attribute.Attribute, attribute.Value));
            }
        }
    }
}

