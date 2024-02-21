using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _gravity = 9.8f;
    private float _fallVelocity = 0;
    private Vector3 _moveVector;
    

    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    private CharacterController _characterController;
    
    // Start is called before the first frame update
    void Start()
    {
        InitComponentLinks();
    }

    private void Update()
    {
        
        Move();
        Jump();
        
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

    void InitComponentLinks()
    {
        _characterController = GetComponent<CharacterController>();

    }

    public void Move()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            //speed = 50;
        }
 
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            //speed = 30;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            //speed = 30;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            //speed = 20;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
}
