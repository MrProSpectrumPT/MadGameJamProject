using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour
{
    public string dialogue;
    private dialogueManager dMan;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<dialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.name == "Player"){

            dMan.ShowBox(dialogue);

        }
    }

    void OnTriggerExit2D(Collider2D other){

        if(other.gameObject.name == "Player"){

            dMan.OffBox();

        }
    }
}
