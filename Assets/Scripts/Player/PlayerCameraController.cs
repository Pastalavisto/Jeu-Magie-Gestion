using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _thirdPersonCamera;
    [SerializeField] private Camera _firstPersonCamera;
    private Camera currentCamera;

    void Start()
    {
        currentCamera = _thirdPersonCamera;
        OnCameraSwitch();
    }

    public void OnLook(InputValue value)
    {
        Vector2 mouseDelta = value.Get<Vector2>();
        if (mouseDelta != Vector2.zero)
        {
            _player.transform.Rotate(Vector3.up, mouseDelta.x * 0.2f, Space.World);
            if (currentCamera == _firstPersonCamera)
            {
            float verticalRotation = -mouseDelta.y * 0.2f;
            float currentAngle = currentCamera.transform.eulerAngles.x;

            float newAngle = currentAngle + verticalRotation;
            if (newAngle > 180f)
            {
                newAngle -= 360f;
            }
            newAngle = Mathf.Clamp(newAngle, -80f, 80f);
            verticalRotation = newAngle - currentAngle;
            currentCamera.transform.Rotate(Vector3.right, verticalRotation, Space.Self);
            }
        }
    }

    public void OnCameraSwitch(){
        if(currentCamera == _thirdPersonCamera){
            _thirdPersonCamera.enabled = false;
            _firstPersonCamera.enabled = true;
            currentCamera = _firstPersonCamera;
        }else{
            _thirdPersonCamera.enabled = true;
            _firstPersonCamera.enabled = false;
            currentCamera = _thirdPersonCamera;
        }
    }
}
