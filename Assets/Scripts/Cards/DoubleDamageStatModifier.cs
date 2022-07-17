namespace Cards
{
    public class DoubleDamageStatModifier : BaseStatModifier
    {
        public override int ApplyEffect(int rawAttackValue)
        {
            return rawAttackValue * 2;
        }
    }
}