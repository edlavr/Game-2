using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCube : Interactable
{
    private Rigidbody rb;
    public float thrust = 1f;
    public GameObject dest;
    public int nOfE = 0;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        dest = GameObject.Find("Dest");
    }

    protected override void InteractLeft()
    {
        if (!gameManager.isRecording)
        {
            gameManager.isRecording = true;
            gameObject.GetComponent<Rewindable>().pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
        rb.AddRelativeForce(transform.forward * thrust);
        // i = 5;
        // if (isCoroutineRunning)
        // {
        //     StopCoroutine(StopInFive());
        // }
        // else
        // {
        //     StartCoroutine(StopInFive());
        // }
    }
    
    protected override void InteractRight()
    {
        if (!gameManager.isRecording)
        {
            gameManager.isRecording = true;
        }

        nOfE++;
        if (nOfE % 2 == 0)
        {
            gameManager.pickedUp = false;
            transform.parent = null;
            // GetComponent<Rigidbody>().useGravity = true;
            // GetComponent<Rigidbody>().isKinematic = false;
            //GetComponent<BoxCollider>().enabled = true;
            GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            if (gameManager.pickedUp == false)
            {
                gameManager.pickedUp = true;
                transform.parent = dest.transform;
                // GetComponent<Rigidbody>().useGravity = true;
                // GetComponent<Rigidbody>().isKinematic = true;
                //GetComponent<BoxCollider>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
            }
        }
            
        // gameObject.GetComponent<Rewindable>().pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
        // StartCoroutine(StopInFive());

        public void FixedUpdate()
        {
            if (gameManager.pickedUp)
            {
                transform.position = dest.transform.position;
            }
        }
}



    // private IEnumerator StopInFive()
    // {
    //     isCoroutineRunning = true;
    //     for (i = 5; i >= 0; i--)
    //     {
    //         if (!gameManager.isRewinding)
    //         {
    //             gameManager.notifications.text = "You have " + i + " seconds to rewind this action";
    //             yield return new WaitForSeconds(1f);
    //         }
    //     }
    //     isCoroutineRunning = false;
    //     gameManager.notifications.text = "";
    //     gameManager.isRecording = false;
    // }
    
