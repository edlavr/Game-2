using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    private Material _material;
    public bool active = false;
    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        _material.color = active ? Color.green : Color.red;
    }

    private void OnCollisionStay()
    {
        active = true;
    }
    
    private void OnCollisionExit()
    {
        active = false;
    }

    private void OnTriggerStay(Collider other)
    {
        active = true;
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
    }
}
