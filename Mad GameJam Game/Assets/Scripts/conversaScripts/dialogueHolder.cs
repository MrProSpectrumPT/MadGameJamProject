using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour
{
    public string dialogue;
    private dialogueManager dMan;
    private bool seen;

    public Scene1 scene;

    // Start is called before the first frame update
    void Start()
    {
        dMan = GameObject.Find("UI").transform.Find("UI-GAME").transform.Find("dialogueManager").GetComponent<dialogueManager>();
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.name == "Player"){

            if (scene.canSpeak)
            {
                dMan.ShowBox(dialogue);
                if (!seen)
                {
                    seen = true;
                    other.gameObject.GetComponent<playerScript>().dialogCount += 1;
                }
            }

        }
    }

    void OnTriggerExit2D(Collider2D other){

        if(other.gameObject.name == "Player"){

            if (scene.canSpeak)
            {
                dMan.OffBox();
            }
        }
    }
}
