using UnityEngine;

public class FireBeam : FireMagic
{
    [SerializeField]
    private float mana = 10;
    [SerializeField]
    private GameObject magicParticlePrefab;
    [SerializeField] private float _delayBetweenManaConsume = 0;
    [SerializeField] private float _power = 1;

    public override GameObject GetMagicParticlePrefab()
    {
        return magicParticlePrefab;
    }

    public override float GetManaCost()
    {
        return mana;
    }

    public override float GetDelayBetweenManaConsume()
    {
        return _delayBetweenManaConsume;
    }

    public override float GetPower ()
    {
        return _power;
    }
}
