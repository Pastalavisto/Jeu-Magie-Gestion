using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCaster : MonoBehaviour
{
    public GameObject magicPrefab;
    
    public void Cast()
    {
        Instantiate(magicPrefab, transform);
    }

    public void UnCast()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(transform.childCount-1).GetComponent<ParticleSystem>().Stop();
        }
    }
}
