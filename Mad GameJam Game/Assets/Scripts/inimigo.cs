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
    public float ataque;
    bool virado;

    //ATAQUE
    public Transform ataquePosCheck;
    public LayerMask playerMask;
    public float tempAtaque;
    float tempo;


    ///
    Animator Animator;
    bool levouDano;


    // Start is called before the first frame update
    void Start()
    {
        playerAtacou = true;
        player = GameObject.Find("Player");

        virado = false;

        tempo = tempAtaque;

        Animator = GetComponent<Animator>();
        levouDano = false;
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
            
            //MOVIMENTO e ATAQUE
            if(levouDano == true){
                Animator.SetInteger("anim", 0); //idle
                levouDano = false;
            }
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

        Collider2D[] cols = Physics2D.OverlapCircleAll(ataquePosCheck.position, 0.5f);
        
        foreach (Collider2D col in cols)
        {
            if (col.gameObject.name == "Player")
            {
               //col.gameObject.GetComponent<playerScript>().TakeDamage(ataque);
            }
        }
    }

    void TakeDamage(int dano){
        vida -= dano;
        levouDano = true;
        Animator.SetInteger("anim", 3); //dano
    }


    void Flip(){
        transform.Rotate(0, 180, 0);
        virado = !virado;
    }
}
