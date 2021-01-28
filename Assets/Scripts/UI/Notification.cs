using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    private TextMeshProUGUI notification;
    // private bool alreadyNotified = false;
    private void Start()
    {
        notification = GetComponent<TextMeshProUGUI>();
    }

    // private void Update()
    // {
        // if (_gameManager.isRewinding && !alreadyNotified)
        // {
        //     alreadyNotified = true;
        //     StartCoroutine(SetNotification("Rewinding..."));
        // }
        
        // if (!_gameManager.isRecording && !_gameManager.isRewinding)
        // {
        //     alreadyNotified = false;
        // }
        //
        // if (!_gameManager.isRecording && _gameManager.isRewinding)
        // {
        //     alreadyNotified = true;
        // }
        
        // if (_gameManager.isRecording && !alreadyNotified)
        // {
        //     alreadyNotified = true;
        //     StartCoroutine(SetNotification("This action can be undone"));
        // }
    // }

    // public IEnumerator SetNotification(string text)
    // {
    //     notification.text = "";
    //     while (notification.text.Length != text.Length - 1)
    //     {
    //         notification.text = text.Substring(0, notification.text.Length + 1);
    //         yield return new WaitForSeconds(0.05f);
    //     }
    //     notification.text = text;
    //     
    //     yield return new WaitForSeconds(1f);
    //     
    //     while (notification.text.Length != 2)
    //     {
    //         notification.text = notification.text.Substring(0, notification.text.Length - 1);
    //         yield return new WaitForSeconds(0.05f);
    //     }
    //     notification.text = "";
    // }

    // IEnumerator ClearNotification(float wait)
    // {
    //     yield return new WaitForSeconds(wait);
    //     
    //     while (notification.text.Length != 2)
    //     {
    //         notification.text = notification.text.Substring(0, notification.text.Length - 1);
    //         yield return new WaitForSeconds(0.05f);
    //     }
    //     notification.text = "";
    // }
}
