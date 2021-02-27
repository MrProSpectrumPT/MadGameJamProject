using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector3 relSmooth;
    private Animator anim;

    public Transform boundInicio, boundFim;

    public Animator roubo;

    public Transform move1, move2;
    private bool movePlayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(StartCinematicScene());
    }
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, 0f, 0f), new Vector3(target.position.x, 0f, 0f), ref relSmooth, 0.1f) + offset;
        
        if(transform.position.x == boundInicio.position.x)
        {
            Debug.Log("dead");
            transform.position = new Vector3(boundInicio.position.x, transform.position.y, transform.position.z);
        }

        if (movePlayer)
        {
            if(target.position == move2.position)
            {
                movePlayer = false;
            }
            target.position = Vector3.Lerp(target.position, move2.position, 0.03f);
        }
    }

    public IEnumerator startAnimationRoubo()
    {
        yield return new WaitForSeconds(1f);
        roubo.SetTrigger("move");

        target.position = move1.position;
        yield return new WaitForSeconds(3f);
        target.GetComponent<Animator>().SetTrigger("cutScene");
        movePlayer = true;
    }

    private IEnumerator StartCinematicScene()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("grito!");
        yield return new WaitForSeconds(0.5f);
        target.GetComponent<SpriteRenderer>().transform.Rotate(0, 180f, 0);
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("cut");
    }
}


