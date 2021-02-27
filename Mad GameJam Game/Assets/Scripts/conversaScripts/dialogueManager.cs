using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dTex;

    public bool dialogActive;

    // Start is called before the first frame update
    void Start()
    {
        dBox.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogActive && Input.GetMouseButtonDown(0)){

            dBox.SetActive(false); 
            dialogActive = false;
        }
    }


    public void ShowBox(string dialogue){

        dialogActive = true;
        dBox.SetActive(true);
        dTex.text = dialogue;
    }

    public void OffBox(){

        dialogActive = false;
        dBox.SetActive(false);
    }
}
