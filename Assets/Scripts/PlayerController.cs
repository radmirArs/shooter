using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _gravity = 9.8f;
    private float _fallVelocity = 0;
    private Vector3 _moveVector;
    private Animator _animator;

    [SerializeField] private float jumpForce;
    [SerializeField] private float speed = 1;
    private CharacterController _characterController;
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
            _animator.SetBool("Running_forward", false);
            _animator.SetBool("Running_right", false);
            _animator.SetBool("Running_left", false);
        
       
        _moveVector = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("Running_forward", true);
            _moveVector += transform.forward;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("Running_left", true);
            _moveVector += transform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("Running_right", true);
            _moveVector -= transform.right;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("Running_forward", true);
            _moveVector -= transform.forward;
        }
    }


    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Time.fixedDeltaTime * speed);

        if(_characterController.isGrounded )
        {
            _fallVelocity = 0;
        }
        _fallVelocity += _gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down *  _fallVelocity * Time.fixedDeltaTime);
    }
}
