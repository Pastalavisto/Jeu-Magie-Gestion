using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mettre le nom de la classe dans l'inspecteur
public class MagicCaster : MonoBehaviour
{
    [SerializeField] private GameObject magicPrefab;
    [SerializeField] private Mana _mana;
    private Magic _spell;
    private bool _isCasting = false;
    private float _delayBetweenManaConsumeCounter = 0;
    private bool _wantToCast = false;

    public void Start()
    {
        _spell = magicPrefab.GetComponent<Magic>();
    }
    
    public void Cast()
    {
        _spell = magicPrefab.GetComponent<Magic>();
        if (CanCast()){
            _isCasting = true;
            _mana.UseMana(_spell.GetManaCost());
            Instantiate(magicPrefab, transform);
        }
    }

    private void FixedUpdate()
    {
        if (_delayBetweenManaConsumeCounter < 0)
        {
            ConsumeMana();
            _delayBetweenManaConsumeCounter = _spell.GetDelayBetweenManaConsume();
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
        return _mana.GetMana() >= _spell.GetManaCost();
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
            _mana.UseMana(_spell.GetManaCost());
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
