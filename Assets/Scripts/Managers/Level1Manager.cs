using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : LevelManagerBase
{
   public GameObject door;
   public GameButton button;
   private float doorX;
   private Material buttonMaterial;
   private Material doorMaterial;

   private void Start()
   {
      buttonMaterial = Instantiate(button.GetComponent<MeshRenderer>().material);
      doorMaterial = Instantiate(door.GetComponent<MeshRenderer>().material);
      button.GetComponent<MeshRenderer>().materials[1] = buttonMaterial;
      door.GetComponent<MeshRenderer>().materials[0] = doorMaterial;
      buttonMaterial = button.GetComponent<MeshRenderer>().materials[1];
      doorMaterial = door.GetComponent<MeshRenderer>().materials[0];

   }

   private void Update()
   {

      Illuminate(button, buttonMaterial, button.active);
      Illuminate(door, doorMaterial, button.active);
      if (button.active)
      {
         OpenDoor(door);
      }
      else
      {
         CloseDoor(door);
      }

   }


   // doorMaterial.SetColor("_EmissionColor", (button.active ? Color.green: Color.red) * 3);
   // buttonMaterial.SetColor("_EmissionColor", (button.active ? Color.green: Color.red) * 3);
   //
   // doorMaterial.color = button.active ? Color.green : Color.red;
   // buttonMaterial.color = button.active ? Color.green : Color.red;
   //
   // DynamicGI.SetEmissive(door.GetComponent<MeshRenderer>(), (button.active ? Color.green: Color.red) * 3);
   // DynamicGI.SetEmissive(button.GetComponent<MeshRenderer>(), (button.active ? Color.green : Color.red) * 3);
   //
   // doorMaterial.EnableKeyword("_EMISSION");
   // buttonMaterial.EnableKeyword("_EMISSION");
}
