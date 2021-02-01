using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenDoor : MonoBehaviour
{
    public LevelManagerBase levelManager;
    public GameObject door;
    private Vector3 doorPos;

    private void Start()
    {
        doorPos = door.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (door.transform.position.x > -1.67f)
        {
            levelManager.OpenDoor(door, doorPos);
        }
    }
}
