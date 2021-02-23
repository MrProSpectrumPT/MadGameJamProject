using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolumeEffects : MonoBehaviour
{

    public AudioMixer mixer;

    public void SetLevel (float sliderValue)

    {
        mixer.SetFloat ("EffectsVolume", Mathf.Log10 (sliderValue) * 20);
        AudioManager.instance.EffectsVolume = Mathf.Log10 (sliderValue) * 20;
    }

}