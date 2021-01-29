using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public GameManager _gameManager;
    private Material _material;
    public bool active = false;
    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _material = GetComponent<MeshRenderer>().materials[1];
    }

    private void Update()
    {
        _material.color = active ? Color.green : Color.red;
        if (active)
        {
            Debug.Log("button");
        }
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
