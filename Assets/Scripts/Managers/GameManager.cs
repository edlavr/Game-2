using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Collider _playerCollider;
    public TextMeshProUGUI notifications;

    public KeyCode rewindKey = KeyCode.R;
    public KeyCode clearRewindKey = KeyCode.Q;
    public KeyCode interactKeyRight = KeyCode.E;

    public float mouseSensitivity = 150f;
    
    public bool isRecording = false;
    public bool isRewinding = false;
    public bool pickedUp = false;

    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    
    // public int nOfE = 0;

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Cursor.visible = true;
                Resume();
            }
            else
            {
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
    
    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
