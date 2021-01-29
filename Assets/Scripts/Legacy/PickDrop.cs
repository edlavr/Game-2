using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrop : MonoBehaviour
{
    public Transform dest;
    [HideInInspector]
    public bool pickedUp = false;
    [HideInInspector]
    public int nOfE = 0;


    private void Update()
    {

        if (pickedUp)
        {
            transform.position = dest.position;
            transform.parent = GameObject.Find("PlayerPickUp").transform;
            GetComponent<SphereCollider>().enabled = false;
            //GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && pickedUp)
        {
            nOfE++;
            if (nOfE % 2 == 0)
            {
                pickedUp = false;
                transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                //GetComponent<BoxCollider>().enabled = true;
                GetComponent<SphereCollider>().enabled = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }



    private void OnMouseUp()
    {
        
    }
}
