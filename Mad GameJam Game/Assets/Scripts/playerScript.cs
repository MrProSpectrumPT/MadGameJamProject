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
<<<<<<< Updated upstream
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
=======

    //control Vida
    public Slider slider;
    public float maxVida = 100.0f;
    public static float vidaAtual;

    public float moveX;
    private bool facingRight;
    public bool isJumping;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Set Vida
        vidaAtual = maxVida;
        slider.maxValue = maxVida;
        slider.value = maxVida;
>>>>>>> Stashed changes
    }

   
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        groundCheck = Physics2D.OverlapCircle(groundPosCheck.position, 0.05f, ground);

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck && !isJumping && rb.velocity.y == 0)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJumping = true;
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
        }else if ()
        {

        }
        else if (groundCheck && isJumping)
        {
            isJumping = false;
        }

        if (moveX > 0 && facingRight) Flip();

        else if (moveX < 0 && !facingRight) Flip();
        

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

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
