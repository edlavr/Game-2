using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCube : Interactable
{
    protected override void InteractLeft()
    {
        if (!_gameManager.isRecording)
        {
            _gameManager.isRecording = true;
            gameObject.GetComponent<Rewindable>().pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
        gameObject.transform.position += Vector3.forward;
        StartCoroutine(StopInFive());
    }
    
    protected override void InteractRight()
    {
        if (!_gameManager.isRecording)
        {
            _gameManager.isRecording = true;
            gameObject.GetComponent<Rewindable>().pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
        gameObject.transform.position += Vector3.back;
        StartCoroutine(StopInFive());
    }

    private IEnumerator StopInFive()
    {
        for (int i = 5; i >= 0; i--)
        {
            if (!_gameManager.isRewinding)
            {
                _gameManager.notifications.text = "You have " + i + " seconds to rewind this action";
                yield return new WaitForSeconds(1f);
            }
        }
        _gameManager.notifications.text = "";
        _gameManager.isRecording = false;
    }
    
}
