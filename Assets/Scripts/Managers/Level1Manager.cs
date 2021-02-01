using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level1Manager : LevelManagerBase
{
   public GameObject[] door;
   public GameButton[] button;
   public GameObject[] paths;
   // private float doorX;
   private Material[] buttonMaterial = new Material[4];
   private Material[] doorMaterial = new Material[4];
   private List<Material> pathsMaterial = new List<Material>();
   
   private Vector3[] doorPos = new Vector3[4];

   private void Start()
   {
      for (int i = 0; i < door.Length; i++)
      {
         doorPos[i] = door[i].transform.position;
         
         buttonMaterial[i] = Instantiate(button[i].GetComponent<MeshRenderer>().material);
         doorMaterial[i] = Instantiate(door[i].GetComponent<MeshRenderer>().material);
         
         button[i].GetComponent<MeshRenderer>().materials[1] = buttonMaterial[i];
         door[i].GetComponent<MeshRenderer>().materials[0] = doorMaterial[i];
         
         buttonMaterial[i] = button[i].GetComponent<MeshRenderer>().materials[1];
         doorMaterial[i] = door[i].GetComponent<MeshRenderer>().materials[0];

      }
      
      for (int i = 0; i < paths.Length; i++)
      {
         pathsMaterial.Add(paths[i].GetComponent<MeshRenderer>().materials[2]);
         paths[i].GetComponent<MeshRenderer>().materials[2] = pathsMaterial[i];
      }
   }

   private void Update()
   {

      for (int i = 0; i < door.Length; i++)
      {
         Illuminate(button[i], buttonMaterial[i], button[i].active);
         Illuminate(door[i], doorMaterial[i], button[i].active);
         
         if (button[i].active)
         {
            OpenDoor(door[i], doorPos[i]);
         }
         else
         {
            CloseDoor(door[i], doorPos[i]);
         }
      }
      
      Illuminate(paths, pathsMaterial, button[2].active);


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
