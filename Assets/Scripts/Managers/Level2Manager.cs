using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : LevelManagerBase
{
   public GameObject door;
   public GameObject roomDoor;
   public GameButton button;
   private float doorX;
   private Material buttonMaterial;
   private Material doorMaterial;
   private Material roomDoorMaterial;
   private bool endMonologue = false;
   private bool isLineSaid = false;

   private Vector3 doorPos;
   private Vector3 roomDoorPos;

   private AudioSource _audioSource;
   public AudioClip beep;
   public AudioClip buttonLine;
   public AudioClip[] voiceLines;

   private void Start()
   {
      buttonMaterial = Instantiate(button.GetComponent<MeshRenderer>().material);
      doorMaterial = Instantiate(door.GetComponent<MeshRenderer>().material);
      roomDoorMaterial = Instantiate(roomDoor.GetComponent<MeshRenderer>().material);

      doorPos = door.transform.position;
      roomDoorPos = roomDoor.transform.position;

      _audioSource = GetComponent<AudioSource>();
      
      button.GetComponent<MeshRenderer>().materials[1] = buttonMaterial;
      door.GetComponent<MeshRenderer>().materials[0] = doorMaterial;
      roomDoor.GetComponent<MeshRenderer>().materials[0] = roomDoorMaterial;

      buttonMaterial = button.GetComponent<MeshRenderer>().materials[1];
      doorMaterial = door.GetComponent<MeshRenderer>().materials[0];
      roomDoorMaterial = roomDoor.GetComponent<MeshRenderer>().materials[0];

      StartCoroutine(VoiceLines(voiceLines));

   }

   private void Update()
   {

      Illuminate(button, buttonMaterial, button.active);
      Illuminate(door, doorMaterial, button.active);
      Illuminate(roomDoor, roomDoorMaterial, endMonologue);

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
      
      

      if (endMonologue)
      {
         OpenDoor(roomDoor, roomDoorPos, false);
      }
      else
      {
         CloseDoor(roomDoor, roomDoorPos, false);
      }

   }


   public IEnumerator VoiceLines(AudioClip[] voices)
   {
      yield return new WaitForSeconds(9f);
      for (int i = 0; i < voices.Length; i++)
      {
         yield return new WaitForSeconds(1);
         _audioSource.clip = voices[i];
         _audioSource.Play();
         yield return new WaitForSeconds(voices[i].length);
      }

      yield return new WaitForSeconds(0.3f);
      endMonologue = true;
      
      _audioSource.clip = beep;
      _audioSource.Play();

   }
   
}
