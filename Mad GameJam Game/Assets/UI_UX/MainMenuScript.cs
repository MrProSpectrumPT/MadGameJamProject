using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void PlayButton ()
    {
        SceneManager.LoadScene("RealLevel01");
    }

    public void QuitButton ()
    {
        Debug.Log("This is working");
        Application.Quit();
    }

}
