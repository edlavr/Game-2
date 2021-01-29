using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrop : MonoBehaviour
{
    public Transform dest;
    public GameManager _gameManager;
    [HideInInspector]
    public bool pickedUp = false;
    [HideInInspector]
    public int nOfE = 0;
    private float xRotation = 0f;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {

        if (pickedUp)
        {
            float mouseX = Input.GetAxis("Mouse X") * _gameManager.mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _gameManager.mouseSensitivity * Time.deltaTime;
            
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -60, 60);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
            transform.Rotate(Vector3.up * mouseX);
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
