using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Transform _targetCamera;
    [SerializeField] private Mana _mana;    
    private Material _material;
    
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        _material = renderer.material;
    }

    void LateUpdate()
    {
        float mana = _material.GetFloat("_Mana");
        _material.SetFloat("_Mana", _mana.GetMana());
        transform.LookAt(_targetCamera);
        transform.forward = -transform.forward;
    }
}
