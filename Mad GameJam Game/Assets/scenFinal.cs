using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenFinal : MonoBehaviour
{

    float tempo;
    public AudioSource musicTensa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

        if(tempo >= 17){

            //CAMERA
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize -= 0.02f;
            if(GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize <= 1){
                GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 1;
                StartCoroutine(GameObject.Find("LoadLevel").GetComponent<loadlevel>().loadScene(0));
            }
            GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<cameraControl>().offset = new Vector3(0,-1.2f,-20);

            GameObject.Find("UI").transform.Find("BB").gameObject.SetActive(true);
            GameObject.Find("UI").transform.Find("UI-GAME").gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<playerScript>().speed = 0f;

            //sons
            if(musicTensa.isPlaying == false){
                musicTensa.Play();
            }
        }   
    }
}
