using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerBase : MonoBehaviour
{
    public void OpenDoor(GameObject dr)
    {
        Vector3 doorPos = dr.transform.position;
        if (doorPos.x > -1.67f)
        {
            dr.transform.position = doorPos + Vector3.left * 0.03f;
        }
    }

    public void CloseDoor(GameObject dr)
    {
        Vector3 doorPos = dr.transform.position;
        if (doorPos.x < 0.33f)
        {
            dr.transform.position = doorPos + Vector3.right * 0.03f;
        }
    }

    public void Illuminate(GameObject obj, Material mat, bool decider)
    {
        mat.EnableKeyword("_EMISSION");
        DynamicGI.SetEmissive(obj.GetComponent<MeshRenderer>(), (decider ? Color.green: Color.red) * 3.5f);
        mat.SetColor("_EmissionColor", (decider ? Color.green: Color.red) * 3);
        mat.color = decider ? Color.green : Color.red;
    }
   
    public void Illuminate(GameButton obj, Material mat, bool decider)
    {
        mat.EnableKeyword("_EMISSION");
        DynamicGI.SetEmissive(obj.GetComponent<MeshRenderer>(), (decider ? Color.green: Color.red) * 3);
        mat.SetColor("_EmissionColor", (decider ? Color.green: Color.red) * 3);
        mat.color = decider ? Color.green : Color.red;
    }
    
    public void Illuminate(GameObject[] objs, List<Material> mats, bool decider)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            mats[i].EnableKeyword("_EMISSION");
            DynamicGI.SetEmissive(objs[i].GetComponent<MeshRenderer>(), (decider ? Color.green: Color.red) * 1f);
            mats[i].SetColor("_EmissionColor", (decider ? Color.green: Color.red) * 1);
            mats[i].color = decider ? Color.green : Color.red;
        }
    }
}
