using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{   
    
    public GameObject FullscreenToggle;
    public GameObject VSyncToggle; 
    public GameObject ApplyButton;
    public bool fullscreen;
    public bool vsync;
    public int resolution;

    private void Start()
    {
        if (GameObject.Find("Travel").gameObject != null)
        {
            GameObject.Find("Travel").transform.Find("UI").transform.Find("BB").gameObject.SetActive(false);
        }
    }
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
    public void toggleFullscreen()
    {
        if(FullscreenToggle.GetComponent<Toggle>().isOn)
        {
            Screen.fullScreen = true;
        }
        else Screen.fullScreen = false;
    }
    public void toggleVSync()
    {
        if(VSyncToggle.GetComponent<Toggle>().isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else QualitySettings.vSyncCount = 0;
    }

}
