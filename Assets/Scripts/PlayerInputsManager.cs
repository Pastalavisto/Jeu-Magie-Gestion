using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsManager : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Collider playerCollider;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jumpForce = 5f;
    private Vector2 inputMovement;

    // Start is called before the first frame update
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, playerCollider.bounds.extents.y + 0.01f);
    }

    void Move()
    {
        //Vector3 movementDirection = Vector3.ProjectOnPlane(cam.transform.TransformDirection(new Vector3(inputMovement.x, 0, inputMovement.y)), playerRigidbody.transform.up).normalized;
        Vector3 playerVelocity = new Vector3(inputMovement.x * speed, playerRigidbody.velocity.y, inputMovement.y * speed);
        playerRigidbody.velocity = transform.TransformDirection(playerVelocity);
    }

    public void OnMove(InputValue value)
    {
        inputMovement = value.Get<Vector2>();
    }

    public void OnJump()
    {
        if (IsGrounded()){
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
