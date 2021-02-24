using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject instance;

    public GameObject groundPrefabParticle;

    public LayerMask canDragLayer;
    private Vector3 currVel;
    private RaycastHit2D hit;
    private bool canDrag;
    private Vector2 mousePos;

    public float mouseForce = 10f;
    void Awake()
    {
        if(instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Debug.Log("Este script ja existe!");
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        GameObject[] tmp_obj = GameObject.FindGameObjectsWithTag("particles");
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (tmp_obj.Length > 0)
        {
            foreach (GameObject ps in tmp_obj)
            {
                if (ps.GetComponent<ParticleSystem>().isStopped)
                {
                    Destroy(ps);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 100f, canDragLayer);
            if(hit.collider.gameObject != null) canDrag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canDrag = false;
            hit.collider.GetComponent<Rigidbody2D>().AddForce((mousePos - (Vector2)hit.collider.gameObject.transform.position) * mouseForce, ForceMode2D.Impulse);
            hit.collider.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        }

        if (canDrag)
        {
            Debug.Log("hey");
            hit.collider.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            //hit.collider.GetComponent<Rigidbody2D>().velocity = 1f;
        }

    }

    public void instanceGroundColision(Transform pos)
    {
        Instantiate(groundPrefabParticle, pos.position, Quaternion.identity);
    }
}
