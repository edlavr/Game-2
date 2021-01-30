using System;
using UnityEngine.EventSystems;
using UnityEngine;


public class ThirdPersonMovement : MonoBehaviour
{
    private CharacterController controller;
    private Camera _camera;

    public float speed = 4;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    
    Vector3 velocity;
    bool isGrounded;

    public float groundDistance = 0.1f;
    public LayerMask groundMask;



    void Start()
    {
        // Cursor.visible = false;
        _camera = FindObjectOfType<Camera>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        //jump
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0.01)
        {
            velocity.y = -0.1f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        //gravity
        velocity.y += gravity * Time.deltaTime * 10;
        controller.Move(velocity * Time.deltaTime);

        Debug.Log((Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        //walk
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        

        bool runPressed = Input.GetKey("left shift");
        if (runPressed) {
            speed = 10;
        } else {
            speed = 4;
        }

        if(direction.magnitude >= 0.001f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * (speed * Time.deltaTime));
        }
    }
}