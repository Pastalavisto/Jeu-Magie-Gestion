public abstract class FireMagic : Magic
{
    private MagicType magicType = MagicType.Fire;

    public override MagicType GetMagicType()
    {
        return magicType;
    }
}
