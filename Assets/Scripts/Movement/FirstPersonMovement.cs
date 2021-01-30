using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonMovement : MonoBehaviour
{
    [HideInInspector]public GameManager gameManager;
    private CharacterController controller;
    private Camera _camera;

    public float speed = 12f;

    public float gravity = 9.81f * 2f;
    public float jumpHeight = 4f;
    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public LayerMask pickable;

    [Header("InteractableInfo")]
    public float sphereCastRadius = 0.5f;
    private Vector3 raycastPos;
    public GameObject lookObject;
    private PhysicsObject physicsObject;
    private Camera mainCamera;
 
    [Header("Pickup")]
    public Transform pickupParent;
    public GameObject currentlyPickedUpObject;
    private Rigidbody pickupRB;
 
    [Header("ObjectFollow")]
    [SerializeField] private float minSpeed = 0;
    [SerializeField] private float maxSpeed = 300f;
    [SerializeField] private float maxDistance = 10f;
    private float currentSpeed = 0f;
    private float currentDist = 0f;
    private Vector3 direction;
 
    [Header("Rotation")]
    public float rotationSpeed = 100f;
    Quaternion lookRot;

    [Header("UI")] public Image crosshair;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Here we check if we're currently looking at an interactable object
        raycastPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));       
        RaycastHit hit;
        if (Physics.SphereCast(raycastPos, sphereCastRadius, mainCamera.transform.forward, out hit, maxDistance, pickable))
        {
            crosshair.color = new Color(1f,1f,1f,.6f);
            lookObject = hit.collider.transform.root.gameObject;
        }
        else
        {
            lookObject = null;
            crosshair.color = new Color(.5f,.5f,.5f,.6f);
        }
 
 
 
        //if we press the button of choice
        if (Input.GetKeyDown(gameManager.interactKeyRight))
        {
            //and we're not holding anything
            if (currentlyPickedUpObject == null)
            {
                //and we are looking an interactable object
                if (lookObject != null)
                {
                    PickUpObject();
                }
 
            }
            //if we press the pickup button and have something, we drop it
            else 
            {
                BreakConnection();
            }
        }
        
        
        
        // movement
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     isGrounded = true;
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     isGrounded = false;
    // }

    //Velocity movement toward pickup parent and rotation
    private void FixedUpdate()
    {
        if (currentlyPickedUpObject != null)
        {
            currentDist = Vector3.Distance(pickupParent.position, pickupRB.position);
            currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, currentDist / maxDistance);
            currentSpeed *= Time.fixedDeltaTime;
            direction = pickupParent.position - pickupRB.position;
            if (currentDist < 0.1)
            {
                currentSpeed = 0f;
                direction = Vector3.zero;
            }

            pickupRB.useGravity = false;
            pickupRB.velocity = direction.normalized * currentSpeed;
            //Rotation
            lookRot = Quaternion.LookRotation(mainCamera.transform.position - pickupRB.position);
            lookRot = Quaternion.Slerp(mainCamera.transform.rotation, lookRot, rotationSpeed * Time.fixedDeltaTime);
            pickupRB.MoveRotation(lookRot);
        }
 
    }
 
    //Release the object
    public void BreakConnection()
    {
        crosshair.enabled = true;
        pickupRB.useGravity = true;
        pickupRB.constraints = RigidbodyConstraints.None;
        currentlyPickedUpObject = null;
        physicsObject.pickedUp = false;
        currentDist = 0;
    }
 
    public void PickUpObject()
    {
        crosshair.enabled = false;
        physicsObject = lookObject.GetComponentInChildren<PhysicsObject>();
        currentlyPickedUpObject = lookObject;
        pickupRB = currentlyPickedUpObject.GetComponent<Rigidbody>();
        pickupRB.constraints = RigidbodyConstraints.FreezeRotation;
        physicsObject.playerInteractions = this;
        StartCoroutine(physicsObject.PickUp());
    }
}
