using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField]
    private float _mana = 0;
    [SerializeField]
    private float _maxMana = 0;

    public void UseMana(float mana)
    {
        _mana -= mana;
    }

    public void AddMana(float mana)
    {
        _mana += mana;
    }

    public float GetMana()
    {
        return _mana;
    }

    public float GetMaxMana(){
        return _maxMana;
    }

    public void ResetMana()
    {
        _mana = 0;
    }

    public override string ToString()
    {
        return "Mana : "+GetMana()+"/"+GetMaxMana();
    } 
}
