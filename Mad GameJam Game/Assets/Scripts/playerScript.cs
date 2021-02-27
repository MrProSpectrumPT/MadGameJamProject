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
    public int maxVida = 10;
    public static int vidaAtual;

    private bool isJumping;
    public bool facingRight;
    private Animator anim;
    private float moveX;

    public Transform attack1Pos;
    public Transform attack2Pos;
    private bool attacking;

    public bool inCutScene;
    public int weapon;

    public bool canAttack = false;

    public Scene1 scene1;

    private bool send2;
    public int dialogCount;

    //SONS
    public AudioSource hitSom;
    public AudioSource atacarSom;
    public AudioSource correrSom;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Set Vida
        vidaAtual = maxVida;

        canAttack = Travel.canAttack;
        weapon = Travel.weaponID;
        vidaAtual = Travel.vida;
    }

   
    void Update()
    {
        if (inCutScene) return;

        moveX = Input.GetAxis("Horizontal");
        groundCheck = Physics2D.OverlapCircle(groundPosCheck.position, 0.5f, ground);

        if(moveX > 0 || moveX < 0 && groundCheck)
        {
            anim.SetFloat("move", Mathf.Abs(moveX));

            if(correrSom.isPlaying == false){
                correrSom.volume = Random.Range(0.2f, 0.5f);
                correrSom.pitch = Random.Range(1.1f, 1.4f);
                correrSom.Play();
            }
        }
        else if(moveX == 0 && groundCheck)
        {
            correrSom.Stop();
            anim.SetFloat("move", Mathf.Abs(moveX));
        }
        else{
            correrSom.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck && !isJumping)
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
        else if(rb.velocity.y == 0 && groundCheck && isJumping)
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (canAttack)
        { 
            if (Input.GetMouseButtonDown(0) && !isJumping && !attacking)
            {
                correrSom.Stop();
                attacking = true;
                anim.SetBool(getAttack(weapon), true);      
            }
        }
        if (moveX > 0 && facingRight) Flip();
        else if (moveX < 0 && !facingRight) Flip();
        
        if(dialogCount >= 4)
        {
            if (!send2)
            {
                send2 = true;
                scene1.canGoToLevel2();
            }
        }


        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }


    private string getAttack(int indexWeapon)
    {
        string attack = "";
        if (indexWeapon == 1)
        {
            int index = Random.Range(1, 3);
            if (index == 1)
            {
                attack = "Attack1";
            }
            else if (index == 2)
            {
                attack = "Attack2";
            }
        }else if(indexWeapon == 2){
            attack = "attack3";
        }
        else if (indexWeapon == 3)
        {
            attack = "attack4";
        }
        return attack;
    }

    public void resetAttack(int index)
    {
        if(index == 1) anim.SetBool("Attack1", false);
        else if (index == 2) anim.SetBool("Attack2", false);
        else if (index == 3) anim.SetBool("attack3", false);
        else if (index == 4) anim.SetBool("attack4", false);
        Invoke("resetAttackingBool", 0.4f);
    }

    private void resetAttackingBool()
    {
        attacking = false;
    }

    public void Attack1()
    {
        atacarSom.pitch = Random.Range(1.8f, 2.4f);
        Collider2D[] cols = Physics2D.OverlapCircleAll(attack1Pos.position, 0.5f);
        CheckCircle(cols);
    }

    public void Attack2()
    {
        atacarSom.pitch = Random.Range(1f, 1.1f);
        Collider2D[] cols = Physics2D.OverlapCircleAll(attack2Pos.position, 0.7f);
        CheckCircle(cols);
    }

    private void CheckCircle(Collider2D[] cols)
    {
        atacarSom.Play();
        
        foreach (Collider2D col in cols)
        {
            if (col.gameObject.CompareTag("enemy"))
            {
                col.gameObject.GetComponent<inimigo>().TakeDamage(10);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            //GameManager.instance.GetComponent<GameManager>().instanceGroundColision(groundPosCheck);
        }
        if (col.gameObject.CompareTag("boundMax"))
        {
            if (scene1.canSwitch)
            {
                StartCoroutine(scene1.level.loadScene(2));
            }
        }
        else if (col.gameObject.CompareTag("boundMaxLevel2"))
        {
            if (GameObject.Find("Manager").GetComponent<KillStatus>().canSwitch)
            {
                StartCoroutine(GameObject.Find("LoadLevel").GetComponent<loadlevel>().loadScene(3));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("cutScene3"))
        {
            Debug.Log("hye");
            StartCoroutine(scene1.StartCutScene3());
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "trigger2")
        {
            if(Scene3.numKills >= 6){
                Scene3.primeiraSCENE = true;
            }
        }

        if (col.gameObject.name == "trigger1")
        {
            if(Scene3.primeiraSCENE == true){
                Scene3.segundaSCENE = true;
            }   
        }
        if (col.gameObject.name == "CameraDetachTrigger")
        {
            Debug.Log("Trigger");
            GameObject.Find("Main Camera").GetComponent<cameraControl>().detachCamera();
            
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void TakeDamage(int dano)
    {
        hitSom.Play();
        anim.SetTrigger("hit");
        vidaAtual -= dano;
        Travel.vida = vidaAtual;
    }

}
