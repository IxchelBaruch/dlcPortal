using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    Vector3 velocity = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    float camRotationX = 0.0f;
    float currentCameraRotationX = 0.0f;
    Vector3 jumpForce = Vector3.zero;

    [SerializeField]
    float cameraRotationLimit = 85.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void FixedUpdate()
    {
        Movement();
        ApplyRotate();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    void Movement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if(jumpForce != Vector3.zero && isGrounded)
        {
            rb.AddForce(jumpForce * Time.fixedDeltaTime * 8.0f, ForceMode.Impulse);
        }
    }

    public void Rotation(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    void ApplyRotate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            currentCameraRotationX -= camRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0.0f, 0.0f);
        }
    }

    public void RotationCam(float _camRotationX)
    {
        camRotationX = _camRotationX;
    }

    public void AddJumpForce(Vector3 _jumpForce)
    {
        jumpForce = _jumpForce;
    }
}
