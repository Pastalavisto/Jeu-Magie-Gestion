using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReceiver : MonoBehaviour
{
    [SerializeField] private Mana _mana;
    [SerializeField] private GameObject itemPrefab;
    
    public void TriggerMagic(Magic magic)
    {
        _mana.AddMana(magic.GetManaCost());
        if (_mana.GetMana() >= _mana.GetMaxMana())
        {
            _mana.ResetMana();
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
        Debug.Log("Trigger Magic of type " + magic.GetMagicType() + " with mana " + magic.GetManaCost() + " and mana number " + _mana.GetMana() + " and mana max " + _mana.GetMaxMana() + "");

    }
}
