using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl2 : MonoBehaviour
{

    public float MaxPositionX;
    public float MinPositionX;
    public Transform target;

    public GameObject BoundsMax;
    public GameObject BoundsMin;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x >= MaxPositionX)
        {
            BoundsMax.SetActive(true);
            BoundsMin.SetActive(true);
            transform.position = new Vector3(MaxPositionX, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= MinPositionX)
        {
            BoundsMax.SetActive(true);
            BoundsMin.SetActive(true);
            transform.position = new Vector3(MinPositionX, transform.position.y, transform.position.z);
        }
        else
        {
            BoundsMax.SetActive(false);
            BoundsMin.SetActive(false);
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        } 
    }
}


