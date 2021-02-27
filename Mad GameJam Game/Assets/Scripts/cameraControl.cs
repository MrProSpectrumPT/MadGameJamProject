using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector3 relSmooth;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, 0f, 0f), new Vector3(target.position.x, 0f, 0f), ref relSmooth, 0.1f) + offset;
    }
}
