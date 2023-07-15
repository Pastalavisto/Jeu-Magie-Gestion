using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReceiver : MonoBehaviour
{
    private float manaNumber = 0;
    [SerializeField]
    private float manaMax = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerMagic(Magic magic)
    {
        manaNumber += magic.GetMana();
        if (manaNumber >= manaMax)
        {
            manaNumber = 0;
            //Trigger Magic
        }
        Debug.Log("Magic Triggered of "+ magic.GetType().Name + " on " + gameObject.name + " with manaNumber " + manaNumber + " and manaMax " + manaMax + "");

    }
}
