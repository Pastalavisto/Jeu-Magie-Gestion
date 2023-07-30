using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mana))]
public abstract class MagicReceiver : MonoBehaviour
{
    public Mana _mana { get; private set; }
    
    void Awake()
    {
        _mana = GetComponent<Mana>();
    }

    public abstract void TriggerMagic(Magic magic);
    
}
