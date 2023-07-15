using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagic : Magic
{
    [SerializeField]
    private float mana = 10;
    public override float GetMana()
    {
        return mana;
    }
}
