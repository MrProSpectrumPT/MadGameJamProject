using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scene3 : MonoBehaviour
{

    public KillStatus status;
    public static int numKills;

    public static bool primeiraSCENE;
    float tempoPrim;

    public static bool segundaSCENE;
    public static bool podeSegunda;

    private GameObject ui;
    GameObject barras;

    public AudioSource musicTensa;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("UI");
        barras = GameObject.Find("UI").transform.Find("BB").gameObject;

        tempoPrim = 0;

        primeiraSCENE = false;
        segundaSCENE = false;
        podeSegunda = false;
    }

    // Update is called once per frame
    void Update()
    {
        numKills = status.countDeadEnemys;

        //ativado no player trigger se kills > 6
        if(primeiraSCENE == true && podeSegunda == false){

            barras.SetActive(true);
            tempoPrim += Time.deltaTime;
            
            GameObject.Find("Player").GetComponent<playerScript>().speed = 0f;

            //sons
            if(musicTensa.isPlaying == false){
                musicTensa.Play();
            }

            //CAMERA
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 3.5f;
            GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<cameraControl>().offset = new Vector3(0.2f,GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<cameraControl>().offset.y,GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<cameraControl>().offset.z);

            GameObject.Find("UI").transform.Find("UI-GAME").gameObject.SetActive(false);
            //GameObject.Find("Enemys").gameObject.SetActive(false);


            if(tempoPrim > 5){
                musicTensa.Stop();
                barras.SetActive(false);
                GameObject.Find("Enemys").gameObject.SetActive(true);
                GameObject.Find("UI").transform.Find("UI-GAME").gameObject.SetActive(true);
                GameObject.Find("UI").transform.Find("UI-GAME").gameObject.transform.Find("MyMission").GetComponent<UnityEngine.UI.Text>().text = "...vai para casa...";

                //CAMERA
                GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 5f;
                GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<cameraControl>().offset = new Vector3(0,GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<cameraControl>().offset.y,GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<cameraControl>().offset.z);
                
                GameObject.Find("Player").GetComponent<playerScript>().speed = 9f;
                podeSegunda = true;

            }
        }

        //ativado no player se podeSegunda == true
        if(segundaSCENE == true){
            StartCoroutine(GameObject.Find("LoadLevel").GetComponent<loadlevel>().loadScene(4));
        }
    }
}
