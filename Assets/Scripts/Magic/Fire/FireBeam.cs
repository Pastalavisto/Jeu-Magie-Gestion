using UnityEngine;

public class FireBeam : FireMagic
{
    [SerializeField]
    private float mana = 10;

    public override float GetMana()
    {
        return mana;
    }
}
