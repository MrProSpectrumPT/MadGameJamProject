using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inimigo : MonoBehaviour
{

    //JOGADOR
    GameObject player;
    bool playerAtacou;
    Vector3 posPlayer;

    //dist para inimigo n ficar cima player
    public float distParaAtacar; //distancia max para realizar o ataque 
    

    //CARACTERISTICAS
    public float vida;
    public float speed;
    public int ataque;
    public bool virado;
    public bool morreu;

    //ATAQUE
    public Transform ataquePosCheck;
    public LayerMask playerMask;
    public float tempAtaque;
    float tempo;


    ///
    Animator Animator;
    bool levouDano;
    public Transform groundPosCheck;
    public LayerMask ground;
    public bool groundCheck;
    float tempoDano;

    //SONS
    public AudioSource hitSom;
    public AudioSource atacarSom;
    public AudioSource correrSom;


    // Start is called before the first frame update
    void Start()
    {
        playerAtacou = true;
        player = GameObject.Find("Player");
        speed = Random.Range(speed - 0.1f, speed + 0.04f); //speed diferente

        virado = false;
        morreu = false;

        tempo = tempAtaque;

        Animator = GetComponent<Animator>();
        levouDano = false;
        groundCheck = false;
        tempoDano = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAtacou == true && Vector3.Distance(player.transform.position, transform.position) < 7 && morreu == false){   

            morreuCheck();

            //CENA DE FICAR VIRADO PARA O PLAYER 
            if(virado == true){
                if(transform.position.x > player.transform.position.x){
                    Flip();
                }
            }
            else{
                if(transform.position.x < player.transform.position.x){
                    Flip();
                }
            }
            
            //MOVIMENTO e ATAQUE
            if(levouDano == true){
                tempoDano += Time.deltaTime;

                if(tempoDano > 0.2f){
                    groundCheck = Physics2D.OverlapCircle(groundPosCheck.position, 0.5f, ground);
                    if(groundCheck == true){
                        Animator.SetInteger("anim", 0); //IDLE
                        levouDano = false;
                    }
                }
                
                
            }
            else if(Vector3.Distance(player.transform.position, transform.position) > distParaAtacar){

                posPlayer = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
                transform.position = Vector2.Lerp(transform.position, posPlayer, speed * Time.fixedDeltaTime);
                Animator.SetInteger("anim", 1); //correr
            }
            else{

                if(tempo >= tempAtaque && playerScript.vidaAtual > 0){
                    atacar();
                    tempo = 0;
                    Animator.SetInteger("anim", 2); //ataque
                }
                else{
                    Animator.SetInteger("anim", 0); //IDLE
                    tempo += Time.deltaTime;
                }
            }
        }
        else{
            //parado
            Animator.SetInteger("anim", 0); //IDLE
        }

    }

    void atacar(){

        atacarSom.Play();

        Collider2D[] cols = Physics2D.OverlapCircleAll(ataquePosCheck.position, 0.5f);
        
        foreach (Collider2D col in cols)
        {
            if (col.gameObject.name == "Player")
            {
                col.gameObject.GetComponent<playerScript>().TakeDamage(ataque);
            }
        }
    }

    public void TakeDamage(int dano){

        if(morreu == false){
            vida -= dano;
            Animator.SetInteger("anim", 3); //dano
            levouDano = true;
            groundCheck = false;
            tempoDano = 0;

            GetComponent<Rigidbody2D>().AddForce(transform.up * 180);
            GetComponent<Rigidbody2D>().AddForce(transform.right * 100);

            hitSom.Play();
        }
    }


    void Flip(){
        transform.Rotate(0, 180, 0);
        virado = !virado;
    }

    void morreuCheck(){
        if(vida < 0){
            if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
            {
                GameObject.Find("Manager").GetComponent<KillStatus>().countDeadEnemys += 1;
            }

            Animator.SetInteger("anim", 4); //morte
            morreu = true;

            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                GameObject.Find("Main Camera").transform.Find("GameControl").GetComponent<Scene1>().sendMissionSearch();
            }
        }
    }
}
