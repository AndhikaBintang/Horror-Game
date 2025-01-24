using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnfootActions Onfoot;

    private PlayerMotor motor;
    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        Onfoot = playerInput.Onfoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        Onfoot.Jump.performed += ctx => motor.Jump();
        Onfoot.Crouch.performed += ctx => motor.Crouch();
        Onfoot.Sprint.performed += ctx => motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(Onfoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(Onfoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        Onfoot.Enable();
    }
    private void OnDisable()
    {
        Onfoot.Disable();
    }
}
