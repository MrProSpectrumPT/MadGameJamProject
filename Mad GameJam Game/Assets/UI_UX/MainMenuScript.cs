using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource audioPrincipal;
    public Dropdown resolutionDropdown;
    public GameObject FullscreenToggle;
    public GameObject VSyncToggle; 
    public GameObject ApplyButton;
    public bool fullscreen;
    public bool vsync;
    public int resolution;
    Resolution[] resolutions;
    

    void Start ()
    {
        audioPrincipal.Play();

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if(GameObject.Find("Travel").gameObject != null)
        {
            GameObject.Find("Travel").transform.Find("sons").transform.Find("musicTenso").GetComponent<AudioSource>().Stop();
        }
    }
    public void PlayButton ()
    {
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

    public void newresolution()
    {

        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
