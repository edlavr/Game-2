using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    private CanvasGroup black;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        // Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
        black = GameObject.Find("Black").GetComponent<CanvasGroup>();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        while (black.alpha > 0)
        {
            yield return new WaitForSeconds(0.01f);
            black.alpha -= 0.02f;
        }
    }
}
