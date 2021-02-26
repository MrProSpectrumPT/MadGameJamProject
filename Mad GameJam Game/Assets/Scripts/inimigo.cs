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
    public float speed;
    public float ataque;
    bool virado;

    // Start is called before the first frame update
    void Start()
    {
        playerAtacou = true;
        player = GameObject.Find("Player");

        virado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAtacou == true){   


            //CENA DE FICAR VIRADO PARA O PLAYER 
            if(virado == false){
                if(transform.position.x > player.transform.position.x){
                    virado = true;
                    Flip();
                }
            }
            else{
                if(transform.position.x < player.transform.position.x){
                    virado = false;
                    Flip();
                }
            }
            
            //MOVIMENTO e ATAQUE
            if(Vector3.Distance(player.transform.position, transform.position) > distParaAtacar){ //falta meter e se não tiver na animacao de ataque

                posPlayer = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector2.Lerp(transform.position, posPlayer, 1.0f * Time.fixedDeltaTime);
            }
            else{
                atacar();
            }
        }
    }

    void atacar(){
        //FALTA SO FAZER O ATAQUE
    }

    void Flip(){
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
}
