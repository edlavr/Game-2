using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level1Manager : LevelManagerBase
{
   public GameObject door;
   public GameButton button;
   public GameObject[] paths;
   private float doorX;
   private Material buttonMaterial;
   private Material doorMaterial;
   private List<Material> pathsMaterial = new List<Material>();
   
   private Vector3 doorPos;

   private void Start()
   {
      doorPos = door.transform.position;

      buttonMaterial = Instantiate(button.GetComponent<MeshRenderer>().material);
      doorMaterial = Instantiate(door.GetComponent<MeshRenderer>().material);
      
      button.GetComponent<MeshRenderer>().materials[1] = buttonMaterial;
      door.GetComponent<MeshRenderer>().materials[0] = doorMaterial;
      for (int i = 0; i < paths.Length; i++)
      {
         pathsMaterial.Add(paths[i].GetComponent<MeshRenderer>().materials[2]);
         paths[i].GetComponent<MeshRenderer>().materials[2] = pathsMaterial[i];
      }
      
      buttonMaterial = button.GetComponent<MeshRenderer>().materials[1];
      doorMaterial = door.GetComponent<MeshRenderer>().materials[0];
   }

   private void Update()
   {

      Illuminate(button, buttonMaterial, button.active);
      Illuminate(door, doorMaterial, button.active);
      Illuminate(paths, pathsMaterial, button.active);
      if (button.active)
      {
         OpenDoor(door, doorPos);
      }
      else
      {
         CloseDoor(door, doorPos);
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
