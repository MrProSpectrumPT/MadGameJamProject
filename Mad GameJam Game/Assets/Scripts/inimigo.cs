using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{

    //JOGADOR
    GameObject player;
    bool playerAtacou;

    //dist para inimigo n ficar cima player
    Vector3 diferencaDist;
    public float distParaAtacar; //distancia max para realizar o ataque 
    

    //CARACTERISTICAS
    public float speed;
    public float ataque;
    bool virado;

    // Start is called before the first frame update
    void Start()
    {
        playerAtacou = false;
        player = GameObject.Find("jogador");

        virado = false;
        diferencaDist = new Vector3(-2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAtacou == true){   


            //CENA DE FICAR VIRADO PARA O PLAYER 
            if(virado == false){
                if(transform.position.x > player.transform.position.x){
                    diferencaDist = new Vector3(2, 0, 0);
                    virado = true;
                    Flip();
                }
            }
            else{
                if(transform.position.x < player.transform.position.x){
                    diferencaDist = new Vector3(-2, 0, 0);
                    virado = false;
                    Flip();
                }
            }
            
            

            transform.position = Vector2.Lerp(transform.position, player.transform.position + diferencaDist, 1.0f * Time.fixedDeltaTime);


            if(distParaAtacar < Vector3.Distance(player.transform.position, transform.position)){
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
