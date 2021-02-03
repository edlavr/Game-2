using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    [HideInInspector]
    public GameManager _gameManager;
    public bool active = false;
    private AudioSource _audio;
    private bool played = false;
    void Awake()
    {
        _gameManager = GetComponent<GameManager>();
        _audio = GetComponent<AudioSource>();
    }

    // private void Update()
    // {
    //     if (active)
    //     {
    //         Debug.Log("button");
    //     }
    // }
    
    private void OnCollisionEnter()
    {
        if (!played)
        {
            played = true;
            _audio.Play();
        }
    }

    private void OnCollisionStay()
    {
        played = true;
        active = true;
    }
    
    private void OnCollisionExit()
    {
        active = false;
        played = false;
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (!played)
        {
            played = true;
            _audio.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        played = true;
        active = true;
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
        played = false;
    }
}
