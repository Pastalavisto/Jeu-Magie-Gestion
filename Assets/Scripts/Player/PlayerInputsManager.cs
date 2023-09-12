using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class PlayerInputsManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private UIManager _uIManager;
    private Rigidbody _playerRigidbody;
    private Collider _playerCollider;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _jumpForce = 5f;
    private Vector2 _inputMovement;
    private MagicCaster _magicCaster;
    private PlayerInput _playerInput;
    // Start is called before the first frame update
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerRigidbody = _player.GetComponent<Rigidbody>();
        _playerCollider = _player.GetComponent<Collider>();
        _magicCaster = _player.GetComponentInChildren<MagicCaster>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public bool IsGrounded(){
        return Physics.Raycast(_player.transform.position, -Vector3.up, _playerCollider.bounds.extents.y + 0.01f);
    }

    void Move()
    {
        Vector3 playerVelocity = new Vector3(_inputMovement.x * _speed, _playerRigidbody.velocity.y, _inputMovement.y * _speed);
        _playerRigidbody.velocity = _player.transform.TransformDirection(playerVelocity);
    }

    public void OnMove(InputValue value)
    {
        _inputMovement = value.Get<Vector2>();
    }

    public void OnJump()
    {
        if (IsGrounded()){
            _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    public void OnCast(InputValue value)
    {
        bool cast = value.Get<float>() == 1;
        if (cast){
            _magicCaster.Cast();
            _magicCaster.WantToCast(true);
        }else{
            _magicCaster.UnCast();
            _magicCaster.WantToCast(false);
        }
    }

    public void OnOpenInventory() {
        print("Opening Inventory");
        _uIManager.SwitchUI();
        _playerInput.SwitchCurrentActionMap("Inventory");
    }

    public void OnCloseInventory() {
        print("Closing Inventory");
        _uIManager.SwitchUI();
        _playerInput.SwitchCurrentActionMap("Ground");
    }
}
