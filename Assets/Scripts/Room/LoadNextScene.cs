using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour
{
    private GameManager gameManager;
    public Image canvasEndGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(loadNextScene());
    }

    IEnumerator loadNextScene()
    {
        while (canvasEndGamePanel.GetComponent<CanvasGroup>().alpha < 1)
        {
            yield return new WaitForSeconds(0.01f);
            canvasEndGamePanel.GetComponent<CanvasGroup>().alpha += 0.02f;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
