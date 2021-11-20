using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float mouseSensitivity = 3.0f;
    [SerializeField]
    float jumpForce = 5.0f;

    /*[SerializeField]
    Animator animator;*/

    PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();

        //Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Movement
        float _xMov = Input.GetAxis("Horizontal");
        float _zMov = Input.GetAxis("Vertical");
        bool jump = Input.GetButton("Jump");



        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        //animator.SetFloat("ForwardVelocity", _zMov);
        //animator.SetFloat("RightVelocity", _xMov);

        motor.Move(_velocity);

        //Rotation
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0.0f, _yRot, 0.0f) * mouseSensitivity;

        motor.Rotation(_rotation);

        //Camera rotation
        float _xRot = Input.GetAxisRaw("Mouse Y");
        float _camRotationX = _xRot * mouseSensitivity;

        motor.RotationCam(_camRotationX);

        Vector3 _jumpForce = Vector3.zero;

        //Jump
        if(Input.GetButton("Jump"))
        {
            _jumpForce = Vector3.up * jumpForce;
        }

        motor.AddJumpForce(_jumpForce);
    }
}
