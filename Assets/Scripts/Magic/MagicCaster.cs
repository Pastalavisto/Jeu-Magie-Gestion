using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCaster : MonoBehaviour
{
    public GameObject magicPrefab;
    [SerializeField] private Mana mana;

    public void Cast()
    {
        if (mana.CanCast(getManaToCast())){
            mana.Cast(getManaToCast());
            Instantiate(magicPrefab, transform);
        }
    }

    public void UnCast()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(transform.childCount-1).GetComponent<ParticleSystem>().Stop();
        }
    }

    public float getManaToCast()
    {
        return magicPrefab.GetComponent<Magic>().GetManaCost();
    }
}
