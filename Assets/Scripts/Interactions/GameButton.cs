using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    [HideInInspector]
    public GameManager _gameManager;
    public bool active = false;
    void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
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
