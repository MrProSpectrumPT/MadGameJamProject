using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public float EffectsVolume;
    public float MusicVolume;

  void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Este script ja existe!");
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void ClickSound()

    {
        transform.Find("ClickSound").GetComponent<AudioSource>().Play();
    }
    public void QuitSound()

    {
        transform.Find("QuitSound").GetComponent<AudioSource>().Play();
    }

}
