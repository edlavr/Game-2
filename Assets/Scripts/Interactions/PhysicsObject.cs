using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PhysicsObject : MonoBehaviour
{
    [HideInInspector] public GameManager gameManager;
    
    public float waitOnPickup = 0.2f;
    public float breakForce = 35f;
    private MeshRenderer _color;
    [HideInInspector] public bool pickedUp = false;
    [HideInInspector] public FirstPersonMovement playerInteractions;
    private bool isRewindable;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _color = GetComponent<MeshRenderer>();
        isRewindable = GetComponent<Rewindable>();
    }

    private void Update()
    {
        if (isRewindable)
        {
            if (pickedUp && !gameManager.isRecording)
            {
                gameManager.isRecording = true;
                _color.material.color = Color.red;

                gameObject.GetComponent<Rewindable>().pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
            }
        
            if (gameManager.isRecording)
            {
                _color.material.color = Color.red;
            }
        
            else if (gameManager.isRewinding)
            {
                _color.material.color = Color.yellow;
            }
        
            else if (!gameManager.isRecording && !gameManager.isRewinding)
            {
                _color.material.color = Color.blue;
            }
        }

        else
        {
            _color.material.color = Color.magenta;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(pickedUp)
        {
            if(collision.relativeVelocity.magnitude > breakForce)
            {
                playerInteractions.BreakConnection();
            }
 
        }
    }
 
    //this is used to prevent the connection from breaking when you just picked up the object as it sometimes fires a collision with the ground or whatever it is touching
    public IEnumerator PickUp()
    {
        yield return new WaitForSecondsRealtime(waitOnPickup);
        pickedUp = true;
 
    }
}

