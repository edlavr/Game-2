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
        if (scene.buildIndex < 3)
        {
            Image crosshair = GetComponentInChildren<Image>();
            crosshair.enabled = false;
        }
        StartCoroutine(Appear());
    }

    public IEnumerator Appear()
    {
        Debug.Log("Appear!");
        black.alpha = 1;
        while (black.alpha > 0)
        {
            yield return new WaitForSeconds(0.01f);
            black.alpha -= 0.02f;
        }
    }

    public void BackToMenu()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(0);
    }
    
    public void Restart()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
