using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void PlayButton ()
    {
        Debug.Log("neh");
        StartCoroutine(GameObject.Find("LoadLevel").GetComponent<loadlevel>().loadScene(1));
    }

    public void QuitButton ()
    {
        Debug.Log("This is working");
        Application.Quit();
    }

}
