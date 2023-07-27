using UnityEngine;

public class FireBeam : FireMagic
{
    [SerializeField]
    private float mana = 1;
    [SerializeField]
    private GameObject magicParticlePrefab;

    public override GameObject GetMagicParticlePrefab()
    {
        return magicParticlePrefab;
    }

    public override float GetManaCost()
    {
        return mana;
    }
}
