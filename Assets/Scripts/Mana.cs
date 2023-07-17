using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField]
    private float _mana = 0;
    [SerializeField]
    private float _maxMana = 0;
    [SerializeField]
    private float _manaRegen = 0;
    [SerializeField]
    private float _manaRegenDelay = 0;
    private float _manaRegenDelayCounter = 0;

    void Update()
    {
        if (_manaRegenDelayCounter < _manaRegenDelay)
        {
            _manaRegenDelayCounter++;
        }
        else
        {
            if (_mana < _maxMana)
            {
                _mana += _manaRegen;
                _manaRegenDelayCounter = 0;
            }
        }
    }

    public bool CanCast(float manaCost)
    {
        return _mana >= manaCost;
    }

    public void Cast(float manaCost)
    {
        _mana -= manaCost;
    }

    public override string ToString()
    {
        return "Mana : "+_mana+"/"+_maxMana;
    } 
}