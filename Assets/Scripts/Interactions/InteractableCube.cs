using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCube : Interactable
{
    private Rigidbody rb;
    public float thrust = 1f;
    public Transform dest;
    public int nOfE = 0;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    protected override void InteractLeft()
    {
        if (!_gameManager.isRecording)
        {
            _gameManager.isRecording = true;
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
        if (!_gameManager.isRecording)
        {
            _gameManager.isRecording = true;
        }

        nOfE++;
        if (nOfE % 2 == 0)
        {
            _gameManager.pickedUp = false;
            transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            //GetComponent<BoxCollider>().enabled = true;
            GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            if (_gameManager.pickedUp == false)
            {
                _gameManager.pickedUp = true;
                transform.position = dest.position;
                transform.parent = GameObject.Find("Dest").transform;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                //GetComponent<BoxCollider>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
            }
        }
            
        // gameObject.GetComponent<Rewindable>().pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
        // StartCoroutine(StopInFive());
    }

    // private IEnumerator StopInFive()
    // {
    //     isCoroutineRunning = true;
    //     for (i = 5; i >= 0; i--)
    //     {
    //         if (!_gameManager.isRewinding)
    //         {
    //             _gameManager.notifications.text = "You have " + i + " seconds to rewind this action";
    //             yield return new WaitForSeconds(1f);
    //         }
    //     }
    //     isCoroutineRunning = false;
    //     _gameManager.notifications.text = "";
    //     _gameManager.isRecording = false;
    // }
    
