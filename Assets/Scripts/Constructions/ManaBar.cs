using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Camera _targetCamera;
    private Material _material;
    private Transform _targetCameraTransform;
    [SerializeField] private float _manaBarDuration = 1f;
    private float _manaBarTimer = 0f;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        _material = renderer.material;
        _targetCameraTransform = _targetCamera.transform;
    }

    void FixedUpdate()
    {
        if (_manaBarTimer > _manaBarDuration)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            LookAtCamera();
            _manaBarTimer ++;
        }
    }

    public void UpdateManaBar(float manaValue)
    {
        float mana = _material.GetFloat("_Mana");
        _material.SetFloat("_Mana", manaValue);
    }

    private void LookAtCamera()
    {
        transform.LookAt(_targetCameraTransform);
        transform.forward = -transform.forward;
    }
    
    public void ResetManaBarTimer()
    {
        _manaBarTimer = 0f;
    }
    
}
