using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 4f;

    public Transform groundPosCheck;
    public LayerMask ground;

    public bool groundCheck;

    private Rigidbody2D rb;

    //control Vida
    public Slider slider;
    public float maxVida = 100.0f;
    public static float vidaAtual;

    private bool isJumping;
    private bool facingRight;
    private Animator anim;
    private float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Set Vida
        vidaAtual = maxVida;
        slider.maxValue = maxVida;
        slider.value = maxVida;
    }

   
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        groundCheck = Physics2D.OverlapCircle(groundPosCheck.position, 0.5f, ground);

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck && !isJumping && rb.velocity.y == 0)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJumping = true;
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
        }
        else if (rb.velocity.y < 0 && isJumping)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        else if (groundCheck && isJumping)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            isJumping = false;
        }

        if (moveX > 0 && facingRight) Flip();

        else if (moveX < 0 && !facingRight) Flip();


        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }


    public void AtualizarVida(float vida){
        slider.value = vida;
    }

<<<<<<< Updated upstream
=======
    private string getAttack()
    {
        int index = Random.Range(1, 3);
        string attack = "";
        if(index == 1)
        {
            attack = "Attack1";
        }
        else if(index == 2)
        {
            attack = "Attack2";
        }
        return attack;
    }

    public void resetAttack(int index)
    {
        if(index == 1) anim.SetBool("Attack1", false);
        else if (index == 2) anim.SetBool("Attack2", false);
        Invoke("resetAttackingBool", 0.4f);
    }

    private void resetAttackingBool()
    {
        attacking = false;
    }

    public void Attack1()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(attack1Pos.position, 0.5f);
        CheckCircle(cols);
    }

    public void Attack2()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(attack2Pos.position, 0.5f);
        CheckCircle(cols);
    }

    private void CheckCircle(Collider2D[] cols)
    {
        foreach (Collider2D col in cols)
        {
            if (col.gameObject.CompareTag("enemy"))
            {
                //MELHORAR A FORCA REPULSIVA
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(col.gameObject.transform.up * 300);
                col.gameObject.GetComponent<inimigo>().TakeDamage(10);
            }
        }
    }
>>>>>>> Stashed changes


    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("enter");
        if (col.gameObject.layer == 6)
        {
            Debug.Log("enter");
            GameManager.instance.GetComponent<GameManager>().instanceGroundColision(groundPosCheck);
        }


        if(col.gameObject.tag == "inimigo"){
            //perde vida
            vidaAtual -= 10;
            AtualizarVida(vidaAtual);

            //forças aplicadas à toa
            Vector3 dir = col.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
            dir = -dir.normalized;
            rb.AddForce(dir * 300);

            GameManager.instance.GetComponent<GameManager>().instanceGroundColision(groundPosCheck);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
<<<<<<< Updated upstream
=======

    public void TakeDamage(int dano)
    {
        vidaAtual -= dano;
    }
>>>>>>> Stashed changes
}
