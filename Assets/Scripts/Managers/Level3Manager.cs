using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Level3Manager : LevelManagerBase
{
   public GameObject[] door;
   public GameButton[] button;
   public GameObject[] pathL;
   public GameObject[] pathR;
   // private float doorX;
   private Material[] buttonMaterial = new Material[5];
   private Material[] doorMaterial = new Material[5];
   private List<Material> pathMaterialL = new List<Material>();
   private List<Material> pathMaterialR = new List<Material>();
   
   private Vector3[] doorPos = new Vector3[5];

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
   }

   private void Update()
   {
      button[2].active = button[1].active;
      button[1].active = button[2].active;

      for (int i = 0; i < door.Length; i++)
      {
         Illuminate(button[i], buttonMaterial[i], button[i].active);
         Illuminate(door[i], doorMaterial[i], button[i].active);
         
         if (button[i].active)
         {
            OpenDoor(door[i], doorPos[i], !(i == 3 || i == 4));
         }
         else
         {
            CloseDoor(door[i], doorPos[i], !(i == 3 || i == 4));
         }
         
         Illuminate(pathL, pathMaterialL, button[1].active);
         Illuminate(pathR, pathMaterialR, button[3].active);

      }
   }
   
}