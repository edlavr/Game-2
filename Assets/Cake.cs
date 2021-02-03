using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cake : MonoBehaviour
{

    void Update()
    {
        if (GetComponent<PhysicsObject>().pickedUp)
        {
            StartCoroutine(GetComponent<LoadNextScene>().loadNextScene(5));
            StartCoroutine(Cake());
        }

        IEnumerator Cake()
        {
            yield return new WaitForSeconds(10);
            SceneManager.LoadScene(0);
        }
    }
}
