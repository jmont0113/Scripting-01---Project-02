using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FPSInput))]
[RequireComponent(typeof(FPSMotor))]
public class PlayerController : MonoBehaviour
{
    FPSInput _input = null;
    FPSMotor _motor = null;

    [SerializeField] float _moveSpeed = 0.1f;
    [SerializeField] float _turnSpeed = 6f;
    [SerializeField] float _jumpStrength = 10f;
    [SerializeField] float _sprintSpeed = 0.5f;

    [SerializeField] ParticleSystem shotParticle;
    [SerializeField] AudioSource shotSound; 

    private void Awake()
    {
        _input = GetComponent<FPSInput>();
        _motor = GetComponent<FPSMotor>();
    }

    private void OnEnable()
    {
        _input.MoveInput += OnMove;
        _input.RotateInput += OnRotate;
        _input.JumpInput += OnJump;
        _input.FireInput += OnFire;
    }

    private void OnDisable()
    {
        _input.MoveInput -= OnMove;
        _input.RotateInput -= OnRotate;
        _input.JumpInput -= OnJump;
        _input.FireInput -= OnFire;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnMove(Vector3 movement)
    {
        // incorpate our move speed 
        _motor.Move(movement * _moveSpeed);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            _motor.Move(movement * _sprintSpeed);
        }
        else
        {
            _motor.Move(movement * _moveSpeed);
        }
    }

    void OnRotate(Vector3 rotation)
    {
        // camera looks vertical, body rotates left/right
        _motor.Turn(rotation.y * _turnSpeed);
        _motor.Look(rotation.x * _turnSpeed);
    }

    void OnJump()
    {
        // apply our jump force to our motor 
        _motor.Jump(_jumpStrength);
    }

    void OnFire()
    {
       shotParticle.Emit(10);
       shotSound.Play();
    }
}
