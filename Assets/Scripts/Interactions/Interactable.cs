using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public GameManager gameManager;

    private Collider playerCollider;
    
    // public float visibleRadius = 3;
    public float interactionRadius = 1.5f;
    private float distance;

    public bool isInteractable = true;
    private bool isOneInteraction;

    // public TextMeshProUGUI leftText;
    // public TextMeshProUGUI rightText;

    // public string leftAction;
    public string rightAction;

    // private Camera _camera;
    private Quaternion cameraRotation;
    // private Transform _canvas;
    // private CanvasGroup _canvasGroup;

    protected int i;
    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerCollider = gameManager._playerCollider;

        // _camera = FindObjectOfType<Camera>();
        // _canvas = gameObject.transform.Find("Canvas");

        // _canvasGroup = _canvas.GetComponent<CanvasGroup>();
        // _canvasGroup.alpha = 0;
        
        
        if (rightAction == "")
        {
            isOneInteraction = true;
        }
    }
    public virtual void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        // 0 when just enters, 1 when the closest, negative when outside radius
        distance = Vector3.Distance(playerCollider.transform.position, transform.position);
        
        // if (distance < visibleRadius)
        // {
        //     ChangeCanvas();
        // }
        
        if (distance < interactionRadius)
        {
            if (isInteractable)
            {
                if (isOneInteraction)
                {
                    // CanInteract(gameManager.interactKeyLeft);
                }
                else
                {
                    // CanInteract(gameManager.interactKeyLeft, gameManager.interactKeyRight);
                }
            }
        }
    }

    // private void ChangeCanvas()
    // {
    //     _canvasGroup.alpha = 1 - distance / visibleRadius;
    //     cameraRotation = _camera.transform.rotation;
    //     _canvas.rotation = cameraRotation;
    //     if (isInteractable)
    //     {
    //         leftText.text = gameManager.interactKeyLeft + " to " + leftAction;
    //         if (!isOneInteraction)
    //         {
    //             rightText.text = gameManager.interactKeyRight + " to " + rightAction;
    //         }
    //     }
    //     else
    //     {
    //         leftText.text = "";
    //         rightText.text = "";
    //     }
    // }

    private void CanInteract(KeyCode leftKey)
    {
        if (Input.GetKeyDown(leftKey))
        {
            Debug.Log("Pressed " + leftKey);
            InteractLeft();
        }
    }

    private void CanInteract(KeyCode leftKey, KeyCode rightKey)
    {
        if (Input.GetKeyDown(leftKey))
        {
            Debug.Log("Pressed " + leftKey);
            InteractLeft();

        } else if (Input.GetKeyDown(rightKey))
        {
            Debug.Log("Pressed " + rightKey);
            InteractRight();
        }
    }

    protected virtual void InteractLeft()
    {

    }
    
    protected virtual void InteractRight()
    {

    }
    
}
