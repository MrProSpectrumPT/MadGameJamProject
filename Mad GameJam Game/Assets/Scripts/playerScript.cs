    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 4f;

    public Transform groundPosCheck;
    public LayerMask ground;

    public bool groundCheck;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        groundCheck = Physics2D.OverlapCircle(groundPosCheck.position, 0.5f, ground);

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("enter");
        if (col.gameObject.layer == 6)
        {
            Debug.Log("enter");
            GameManager.instance.GetComponent<GameManager>().instanceGroundColision(groundPosCheck);
        }
    }
}
