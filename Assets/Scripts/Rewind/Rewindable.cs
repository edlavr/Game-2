using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Rewindable : MonoBehaviour
{
    private GameManager _gameManager;

    public List<PointInTime> pointsInTime;
    private Rigidbody rb;
    private bool _isrbNotNull;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        _isrbNotNull = rb != null;
        _gameManager = FindObjectOfType<GameManager>();
        pointsInTime = new List<PointInTime>();
        foreach (Transform child in transform){
            child.gameObject.AddComponent<Rewindable>();
        }
    }
    
    private void FixedUpdate()
    {
        if (_gameManager.isRewinding)
        {
            _gameManager.isRecording = false;
            Rewind();
        }

        if (_gameManager.isRecording)
        {
            Record();
        }

    }
    
    void Update()
    {
        if (!_gameManager.isRecording && !_gameManager.isRewinding)
        {
            pointsInTime.Clear();
        }
    }

    public void StopRewind()
    {
        Time.timeScale = 1f;
        _gameManager.isRewinding = false;
        _gameManager.isRecording = false;
    }

    public virtual void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            if (_isrbNotNull)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            Time.timeScale = 2f;
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
            _gameManager.notifications.text = "";
        }
        else
        {
            StopRewind();
        }
    }
    
    public void Record()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.lockState = CursorLockMode.None;

        if (_gameManager.isRewindable)
        {
            pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
    }
    
}
