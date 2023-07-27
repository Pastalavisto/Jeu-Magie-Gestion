using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCaster : MonoBehaviour
{
    public GameObject magicPrefab;
    [SerializeField] private Mana mana;
    private Magic _spell;
    private bool _isCasting = false;
    [SerializeField] private float _delayBetweenManaConsume = 0;
    private float _delayBetweenManaConsumeCounter = 0;
    private bool _wantToCast = false;

    public void Cast()
    {
        _spell = magicPrefab.GetComponent<Magic>();
        if (CanCast()){
            _isCasting = true;
            mana.UseMana(_spell.GetManaCost());
            Instantiate(magicPrefab, transform);
        }
    }

    private void FixedUpdate()
    {
        if (_delayBetweenManaConsumeCounter < 0)
        {
            ConsumeMana();
            _delayBetweenManaConsumeCounter = _delayBetweenManaConsume;
        }
        else
        {
            _delayBetweenManaConsumeCounter--;
        }
    }

    public void WantToCast(bool wantToCast)
    {
        _wantToCast = wantToCast;
    }

    private bool CanCast()
    {
        return mana.GetMana() >= _spell.GetManaCost();
    }

    public void UnCast()
    {
        if (transform.childCount > 0)
        {
            _isCasting = false;
            transform.GetChild(transform.childCount-1).GetComponent<ParticleSystem>().Stop();
        }
    }

    public float getManaToCast()
    {
        return magicPrefab.GetComponent<Magic>().GetManaCost();
    }

    private void ConsumeMana()
    {
        if (_isCasting && CanCast())
        {
            mana.UseMana(_spell.GetManaCost());
        }
        else if (_isCasting == false && CanCast() && _wantToCast)
        {
            Cast();
        }
        else
        {
            UnCast();
        }
    }
}
