using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReceiver : MonoBehaviour
{
    private float manaNumber = 0;
    [SerializeField]
    private float manaMax = 100;

    public void TriggerMagic(Magic magic)
    {
        manaNumber += magic.GetManaCost();
        if (manaNumber >= manaMax)
        {
            manaNumber = 0;
            //Trigger Magic
        }
        Debug.Log("Trigger Magic of type " + magic.GetMagicType() + " with mana " + magic.GetManaCost() + " and mana number " + manaNumber + " and mana max " + manaMax + "");

    }
}
