using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Collider _playerCollider;

    public KeyCode rewindKey = KeyCode.R;
    public KeyCode clearRewindKey = KeyCode.Q;
    public KeyCode interactKeyRight = KeyCode.E;

    
    public bool isRecording = false;
    public bool isRewinding = false;
    public bool pickedUp = false;
    
    public float mouseSensitivity;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.buildIndex);
        _playerCollider = GameObject.Find("Player First Person").GetComponent<CharacterController>();
        isRecording = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(rewindKey))
        {
            if (_playerCollider.GetComponent<FirstPersonMovement>().currentlyPickedUpObject != null && _playerCollider.GetComponent<FirstPersonMovement>().currentlyPickedUpObject.GetComponent<Rewindable>() != null)
            {
                _playerCollider.GetComponent<FirstPersonMovement>().BreakConnection();
            }
            isRewinding = true;
        }
        
        if (Input.GetKeyDown(clearRewindKey))
        {
            if (isRecording)
            {
                _playerCollider.GetComponent<FirstPersonMovement>().BreakConnection();
            }
            isRecording = false;
        }
    }
}
