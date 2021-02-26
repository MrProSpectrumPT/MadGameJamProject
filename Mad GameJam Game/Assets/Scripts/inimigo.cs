using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int ataque;
    bool virado;

    //ATAQUE
    public Transform ataquePosCheck;
    public LayerMask playerMask;
    public float tempAtaque;
    float tempo;


    ///
    Animator Animator;


    // Start is called before the first frame update
    void Start()
    {
        playerAtacou = true;
        player = GameObject.Find("Player");

        virado = false;

        tempo = tempAtaque;

        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAtacou == true && Vector3.Distance(player.transform.position, transform.position) < 5){   


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
            
<<<<<<< Updated upstream
            //MOVIMENTO e ATAQUE
=======
>>>>>>> Stashed changes
            if(Vector3.Distance(player.transform.position, transform.position) > distParaAtacar){

                posPlayer = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector2.Lerp(transform.position, posPlayer, speed * Time.fixedDeltaTime);
                Animator.SetInteger("anim", 1); //correr
            }
            else{

                if(tempo >= tempAtaque){
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
<<<<<<< Updated upstream
        
        bool ataque = Physics2D.OverlapCircle(ataquePosCheck.position, 0.5f, playerMask);
        
        if(ataque == true){
            //acertou
            //corrigir collisao no player para ele saltar
=======

        Collider2D[] cols = Physics2D.OverlapCircleAll(ataquePosCheck.position, 0.5f);

        
        foreach (Collider2D col in cols)
        {
            if (col.gameObject.name == "Player")
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(col.gameObject.transform.up * 300);
                col.gameObject.GetComponent<playerScript>().TakeDamage(ataque);
            }
>>>>>>> Stashed changes
        }
    }

    public void TakeDamage(int dano){
        vida -= dano;
<<<<<<< Updated upstream
=======
        levouDano = true;
>>>>>>> Stashed changes
    }


    void Flip(){
        transform.Rotate(0, 180, 0);
        virado = !virado;
    }
}
