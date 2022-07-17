using UnityEngine;

namespace Cards
{
    public class DamageAddStatModifier : BaseStatModifier
    {
        [SerializeField] int _damageAddAmount;

        public override int ApplyEffect(int rawAttackValue)
        {
            return rawAttackValue + _damageAddAmount;
        }
    }
}