using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector3 relSmooth;
    private Animator anim;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, 0f, 0f), new Vector3(target.position.x, 0f, 0f), ref relSmooth, 0.1f) + offset;
    }

    public void startCutscene()
    {
        StartCoroutine(transform.Find("GameControl").GetComponent<Scene1>().startAnimationRoubo());
    }
    public void detachCamera()
    {   
        GameObject.Find("BoundsMinCeleiro").GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("Ah e tal detach!");
        this.enabled = false;
    }
}


