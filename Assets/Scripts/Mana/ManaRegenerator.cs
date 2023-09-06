using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegenerator : MonoBehaviour
{
    [SerializeField] private float _manaRegen = 0;
    [SerializeField] private float _manaRegenDelay = 0;
    [SerializeField] private Mana _mana;
    private float _manaRegenDelayCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RegenMana();
    }

    private void RegenMana()
    {
        if (_manaRegenDelayCounter < _manaRegenDelay)
        {
            _manaRegenDelayCounter++;
        }
        else
        {
            if (_mana.GetMana() < _mana.GetMaxMana())
            {
                _mana.AddMana(_manaRegen);
                _manaRegenDelayCounter = 0;
            }
        }
    }
}
