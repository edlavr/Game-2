using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6Manager : LevelManagerBase
{
    public GameObject door;
    public GameButton button;
    
    private Material buttonMaterial;
    private Material doorMaterial;
    
     
    private bool isLineSaid = false;
    private AudioSource _audioSource;
    public AudioClip buttonLine;
    // public AudioClip[] voiceLines;
    private Vector3 doorPos = new Vector3();

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        doorPos = door.transform.position;
        buttonMaterial = Instantiate(button.GetComponent<MeshRenderer>().material);
        doorMaterial = Instantiate(door.GetComponent<MeshRenderer>().material);
         
        button.GetComponent<MeshRenderer>().materials[1] = buttonMaterial;
        door.GetComponent<MeshRenderer>().materials[0] = doorMaterial;
         
        buttonMaterial = button.GetComponent<MeshRenderer>().materials[1];
        doorMaterial = door.GetComponent<MeshRenderer>().materials[0];
        
        // StartCoroutine(VoiceLines(voiceLines));

    }

    // Update is called once per frame
    void Update()
    {
        Illuminate(button, buttonMaterial, button.active);
        Illuminate(door, doorMaterial, button.active);
         
        if (button.active)
        {
            OpenDoor(door, doorPos);
            if (!isLineSaid)
            {
                isLineSaid = true;
                _audioSource.clip = buttonLine;
                _audioSource.Play();
            }
        }
        else
        {
            CloseDoor(door, doorPos);
        }
    }
    
    // public IEnumerator VoiceLines(AudioClip[] voices)
    // {
    //     yield return new WaitForSeconds(1f);
    //     for (int i = 0; i < voices.Length; i++)
    //     {
    //         yield return new WaitForSeconds(10f);
    //         _audioSource.clip = voices[i];
    //         _audioSource.Play();
    //         yield return new WaitForSeconds(voices[i].length);
    //     }
    //
    //     yield return new WaitForSeconds(0.3f);
    //
    // }
}
