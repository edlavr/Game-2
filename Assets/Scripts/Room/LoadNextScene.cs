using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour
{
    public CanvasGroup black;
    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        black = GameObject.Find("Black").GetComponent<CanvasGroup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(loadNextScene(timer));
    }

    IEnumerator loadNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        
        while (black.alpha < 1)
        {
            yield return new WaitForSeconds(0.01f);
            black.alpha += 0.02f;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
