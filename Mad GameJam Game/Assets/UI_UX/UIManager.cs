using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public GameObject OptionsMenu;
    public GameObject PauseMenu;
    public GameObject VideoMenu;
    public GameObject AudioMenu;
    public GameObject CreditsMenu;

    public AudioSource audio;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Este script ja existe!");
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Resume()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        AudioManager.instance.ClickSound();
    }
    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(GameObject.Find("LoadLevel").GetComponent<loadlevel>().loadScene(0));
        AudioManager.instance.QuitSound();
    }
    public void disablePanel()
    {
        PauseMenu.SetActive (false);
        OptionsMenu.SetActive (false);
        VideoMenu.SetActive (false);
        AudioMenu.SetActive (false);
    }


    public void QuitButton()
    {
        Debug.Log("This is working");
        AudioManager.instance.ClickSound();
        Application.Quit();

    }

    public void OptionsButton()
    {
        disablePanel();
        OptionsMenu.SetActive (true);
        AudioManager.instance.ClickSound();
    }
    public void VideoButton()
    {
        disablePanel();
        VideoMenu.SetActive (true);
        AudioManager.instance.ClickSound();
    }
    public void AudioButton()
    {
        disablePanel();
        AudioMenu.SetActive (true);
        AudioManager.instance.ClickSound();
    }
    public void BackButton(string Index)
    {
        disablePanel();
        if (Index.Equals("Pause"))
        {
            PauseMenu.SetActive (true);
        }
        else if (Index.Equals("Options"))
        {
            OptionsMenu.SetActive (true);
        }
        AudioManager.instance.ClickSound();
    }
}
