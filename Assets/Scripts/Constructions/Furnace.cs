using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MagicReceiver
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private GameObject _manaBar;
    [SerializeField] private List <MagicType> _magicTypeList;
    private ManaBar _manaBarScript;

    void Start()
    {
        _manaBarScript = _manaBar.GetComponent<ManaBar>();
    }

    public override void TriggerMagic(Magic magic)
    {
        if (!_magicTypeList.Contains(magic.GetMagicType()))
        {
            return;
        }
        _mana.AddMana(magic.GetPower());
        if (_mana.GetMana() >= _mana.GetMaxMana())
        {
            _mana.ResetMana();
            Instantiate(_itemPrefab, transform.position, Quaternion.identity);
        }
        Debug.Log("Trigger Magic of type " + magic.GetMagicType() + " with power of " + magic.GetPower() + " Current mana number " + _mana.GetMana() + " of " + _mana.GetMaxMana() + " max mana");
        _manaBar.SetActive(true);
        _manaBarScript.UpdateManaBar(_mana.GetMana() / _mana.GetMaxMana() * 100);
        _manaBarScript.ResetManaBarTimer();
    }
}
