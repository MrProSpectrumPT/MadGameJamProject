using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class managerCinematicScene5 : MonoBehaviour
{
    private GameObject player;
    public Text WifeTextTalk;
    public Text MeTextTalk;

    public Text me, wife;

    public Volume volume;
    private Vignette vignette;
    private ChromaticAberration chromatic;
    private Tonemapping tone;
    private FilmGrain film;
    private ChannelMixer mixer;

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    void Start()
    {
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out chromatic);
        volume.profile.TryGet(out tone);
        volume.profile.TryGet(out film);
        volume.profile.TryGet(out mixer);

        vignette.active = false;
        chromatic.active = false;
        tone.active = false;
        film.active = false;
        mixer.active = false;

        wife.enabled = false;
        me.enabled = false;
        player = GameObject.Find("Player").gameObject;
        GameObject.Find("Travel").transform.Find("UI").transform.Find("BB").gameObject.SetActive(true);
        GameObject.Find("Travel").transform.Find("UI").transform.Find("UI-GAME").gameObject.SetActive(false);
        StartCoroutine(startCinematic());
    }

    public IEnumerator startCinematic()
    {
        yield return new WaitForSeconds(1f);
        player.GetComponent<Animator>().SetTrigger("run");
        yield return new WaitForSeconds(1f);
        StartCoroutine(startWriting());
    }

    IEnumerator startWriting()
    {
        wife.enabled = true;
        fullText = "BOM DIA AMOR...";
        for (int i= 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            WifeTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.7f);

        me.enabled = true;
        fullText = "BOM DIA QUERIDA... TIVE UM SONHO ESTRANHO...";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            MeTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.7f);

        wife.enabled = true;
        fullText = "NAO TE PREOCUPES AMOR... TENHO UMA SURPRESA...";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            WifeTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.7f);

        me.enabled = true;
        fullText = "QUE SURPRESA?";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            MeTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.7f);

        wife.enabled = true;
        fullText = "VAMOS TER UM BÉBÉ...";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            WifeTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.7f);

        me.enabled = true;
        fullText = "ASSERIO?! MEU DEUS!... ESPERO QUE SEJA UMA MENINA!";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            MeTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.4f);

        wife.enabled = false;
        me.enabled = false;
        WifeTextTalk.text = "";
        MeTextTalk.text = "";

        StartCoroutine(GameObject.Find("LoadLevel").GetComponent<loadlevel>().loadScene(6));
    }


}
