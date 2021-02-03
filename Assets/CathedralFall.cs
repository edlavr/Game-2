using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CathedralFall : MonoBehaviour
{
    private PostProcessVolume ppv;
    public GameObject head;
    private GameObject _camera;
    private bool isFalling = false;

    private void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
        _camera = GameObject.FindWithTag("MainCamera");
    }

    private void OnTriggerEnter(Collider other)
    {
        isFalling = true;
        _camera.transform.parent = head.transform;
        StartCoroutine(Fall());
    }

    private void Update()
    {
        if (isFalling)
        {
            // _camera.transform.position = head.transform.position + Vector3.forward * 1f;
            _camera.transform.localPosition = Vector3.zero;
        }
    }

    private IEnumerator Fall()
    {
        while (ppv.weight < 1)
        {
            yield return new WaitForSeconds(0.1f);
            ppv.weight += 0.01f;
        }

        Time.timeScale = 0.3f;

        Transform player = head.transform.root;
        
        // _camera.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        // head.transform.root.GetComponent<FirstPersonMovement>().enabled = false;
        player.GetComponent<AnimationStateController>().enabled = false;
        yield return new WaitForSeconds(.3f);
        player.GetComponent<Animator>().enabled = false;
        _camera.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<FirstPersonMovement>().enabled = false;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;

        StartCoroutine(GetComponent<LoadNextScene>().loadNextScene(3));
    }
}
