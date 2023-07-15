using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "MagicReceiver")
        {
            other.GetComponent<MagicReceiver>().TriggerMagic(this);
        }
    }

    public abstract float GetMana();
}
