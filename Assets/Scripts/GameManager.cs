using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public Collider _playerCollider;
    public TextMeshProUGUI notifications;

    public KeyCode rewindKey = KeyCode.R;
    
    public KeyCode interactKeyLeft = KeyCode.Q;
    public KeyCode interactKeyRight = KeyCode.E;

    
    public bool isRecording = false;
    public bool isRewinding = false;
    public bool isRewindable = true;

    void Update()
    {
        if (Input.GetKeyDown(rewindKey))
        {
            isRewinding = true;
        }

    }

}
