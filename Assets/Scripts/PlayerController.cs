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
    private string stayAnimation = "stay";//тег для анимации стойки
    [SerializeField] private float speed = 1;
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
        _animator = GetComponent<Animator>();
    }
    public void Move()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("Running_forward", true);
            _moveVector += transform.forward;
            speed = 5;
        }
        else
        {
            _animator.SetBool("Running_forward", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("Running_left", true);
            _moveVector += transform.right;
            speed = 3;
        }
        else
        {
            _animator.SetBool("Running_left", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("Running_right", true);
            _moveVector -= transform.right;
            speed = 3;
        }
        else
        {
            _animator.SetBool("Running_right", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("Running_back", true);
            _moveVector -= transform.forward;
            speed = 2;
        }
        else
        {
            _animator.SetBool("Running_back", false);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            //проверка стоит ли персонаж или нет
            if (IsAnimationPlayingByTag(stayAnimation))
            {
                _animator.SetTrigger("JumpStay");
            }
        }
        
    }

    bool IsAnimationPlayingByTag(string tag)
    {
        // Проверяем состояние всех слоев анимаций
        for (int i = 0; i < _animator.layerCount; i++)
        {
            // Получаем информацию о текущем состоянии аниматора
            AnimatorStateInfo currentState = _animator.GetCurrentAnimatorStateInfo(i);
            // Проверяем, соответствует ли текущая анимация тегу
            if (currentState.IsTag(tag))
            {
                return true; // Проигрывается анимация с заданным тегом на текущем слое
            }
        }
        return false; // На игроке не проигрывается анимация с заданным тегом
    }

}
