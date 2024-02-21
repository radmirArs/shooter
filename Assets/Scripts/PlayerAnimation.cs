using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        InitComponentLinks();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationPlayer();
    }
    void InitComponentLinks()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimationPlayer()
    {
        if (Input.GetKey(KeyCode.W))
            _animator.SetBool("Running_forward", true);
        else
            _animator.SetBool("Running_forward", false);

        if (Input.GetKey(KeyCode.D))
            _animator.SetBool("Running_right", true);
        else
            _animator.SetBool("Running_right", false);

        if (Input.GetKey(KeyCode.A))
            _animator.SetBool("Running_left", true);
        else
            _animator.SetBool("Running_left", false);

        if (Input.GetKey(KeyCode.S))
            _animator.SetBool("Running_back", true);
        else
            _animator.SetBool("Running_back", false);
    }
    }
