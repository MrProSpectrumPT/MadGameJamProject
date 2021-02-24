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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Set Vida
        vidaAtual = maxVida;
        slider.maxValue = maxVida;
        slider.value = maxVida;
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


    public void AtualizarVida(float vida){
        slider.value = vida;
    }



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
}
