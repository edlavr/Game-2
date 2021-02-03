using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Collider _playerCollider;

    public KeyCode rewindKey = KeyCode.R;
    public KeyCode clearRewindKey = KeyCode.Q;
    public KeyCode interactKeyRight = KeyCode.E;

    
    public bool isRecording = false;
    public bool isRewinding = false;
    public bool pickedUp = false;

    public static bool isPaused = false;
    public GameObject pauseMenuUI;

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

        pauseMenuUI.SetActive(false);
        
        _playerCollider = GameObject.Find("Player First Person").GetComponent<CharacterController>();

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

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (isPaused)
            {
                AudioListener.pause = false;
                Cursor.visible = false;
                Resume();
            }
            else
            {
                AudioListener.pause = true;
                Cursor.visible = true;
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }


}
