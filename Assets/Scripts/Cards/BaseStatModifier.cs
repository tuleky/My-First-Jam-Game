using UnityEngine;

namespace Cards
{
    public abstract class BaseStatModifier : MonoBehaviour
    {
        public abstract int ApplyEffect(int rawAttackValue);
    }
}