using System.Collections.Generic;
using UnityEngine;

public abstract class Magic : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        if (other.tag == "MagicReceiver")
        {
            other.GetComponent<MagicReceiver>().TriggerMagic(this);
        }
        else if (GetMagicParticlePrefab() != null)
        {
            Instantiate(GetMagicParticlePrefab(), collisionEvents[0].intersection, Quaternion.identity);
        }
    }

    public abstract float GetManaCost();
    public abstract MagicType GetMagicType();
    public abstract GameObject GetMagicParticlePrefab();
    public abstract float GetDelayBetweenManaConsume();
    public abstract float GetPower();
}
