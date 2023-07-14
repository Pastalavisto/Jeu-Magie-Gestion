using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    private Camera thirdPersonCamera;
    [SerializeField]
    private Camera firstPersonCamera;
    private Camera currentCamera;
    // Start is called before the first frame update
    void Start()
    {
        currentCamera = thirdPersonCamera;
        OnCameraSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLook(InputValue value)
    {
        Vector2 mouseDelta = value.Get<Vector2>();
        if (mouseDelta != Vector2.zero)
        {
            transform.Rotate(Vector3.up, mouseDelta.x * 0.2f, Space.World);
            if (currentCamera == firstPersonCamera)
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
        if(currentCamera == thirdPersonCamera){
            thirdPersonCamera.enabled = false;
            firstPersonCamera.enabled = true;
            currentCamera = firstPersonCamera;
        }else{
            thirdPersonCamera.enabled = true;
            firstPersonCamera.enabled = false;
            currentCamera = thirdPersonCamera;
        }
    }
}
