using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenDoor : MonoBehaviour
{
    public PlayableDirector pd;
    public bool open = false;
    private void OnTriggerEnter(Collider other)
    {
        if (open)
        {
            pd.Play();
        }
    }
}
