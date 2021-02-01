using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Level4Manager : LevelManagerBase
{
   public GameObject[] door;
   public GameButton[] button;
   public GameObject[] path1;
   public GameObject[] pathL;
   public GameObject[] pathR;
   // private float doorX;
   private Material[] buttonMaterial = new Material[8];
   private Material[] doorMaterial = new Material[8];
   private List<Material> pathMaterial1 = new List<Material>();
   private List<Material> pathMaterialL = new List<Material>();
   private List<Material> pathMaterialR = new List<Material>();
   
   private Vector3[] doorPos = new Vector3[8];

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
      
      for (int i = 0; i < pathL.Length; i++)
      {
         pathMaterialL.Add(pathL[i].GetComponent<MeshRenderer>().materials[2]);
         pathL[i].GetComponent<MeshRenderer>().materials[2] = pathMaterialL[i];
      }
      
      for (int i = 0; i < pathR.Length; i++)
      {
         pathMaterialR.Add(pathR[i].GetComponent<MeshRenderer>().materials[2]);
         pathR[i].GetComponent<MeshRenderer>().materials[2] = pathMaterialR[i];
      }
      
      for (int i = 0; i < path1.Length; i++)
      {
         pathMaterial1.Add(path1[i].GetComponent<MeshRenderer>().materials[2]);
         path1[i].GetComponent<MeshRenderer>().materials[2] = pathMaterial1[i];
      }
   }

   private void Update()
   {
      button[3].active = button[2].active;
      button[4].active = button[2].active;
      button[5].active = button[6].active;

      for (int i = 0; i < door.Length; i++)
      {
         Illuminate(button[i], buttonMaterial[i], button[i].active);
         Illuminate(door[i], doorMaterial[i], button[i].active);
         
         if (button[i].active)
         {
            OpenDoor(door[i], doorPos[i], i < 2);
         }
         else
         {
            CloseDoor(door[i], doorPos[i], i < 2);
         }
         Illuminate(path1, pathMaterial1, button[1].active);

         Illuminate(pathL, pathMaterialL, button[2].active);
         Illuminate(pathR, pathMaterialR, button[6].active);

      }
   }
   
}