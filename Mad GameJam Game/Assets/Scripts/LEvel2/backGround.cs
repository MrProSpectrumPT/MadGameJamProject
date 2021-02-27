using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{

    public Transform Cam;
    public float movespeed = 0.125f;
    public Vector3 offset;

    private Vector2 startPos;

    private float newXpos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     //   transform.Translate(Vector3.left * Time.deltaTime * smoothSpeed, Cam);
        //transform.position = Vector3.Lerp(transform.position, Cam.position + offset, smoothSpeed);
        transform.position = new Vector3(Cam.position.x, transform.position.y, 0) + offset;

       
    }
}
