using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scenFinal : MonoBehaviour
{

    float tempo;
    public AudioSource musicTensa;

    public Text FrutaTextTalk;
    public Text MeTextTalk;

    public Text me, HomemFruta;
    public string fullText;
    private string currentText;
    public float delay = 0.1f;

    public bool canGo;

    private void Start()
    {
        HomemFruta.enabled = false;
        me.enabled = false;
    }
    void Update()
    {
        if (canGo)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize -= 0.01f;
            if (GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize <= 1)
            {
                GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 1;

                StartCoroutine(GameObject.Find("LoadLevel").GetComponent<loadlevel>().loadScene(0));

            }
            GameObject.Find("Main Camera").GetComponent<cameraControl>().offset = new Vector3(0, -10, -20);

            GameObject.Find("UI").transform.Find("BB").gameObject.SetActive(true);
            GameObject.Find("UI").transform.Find("UI-GAME").gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<playerScript>().speed = 0f;

            //sons
            if (musicTensa.isPlaying == false)
            {
                musicTensa.Play();
            }
        }
    }

    public IEnumerator startFinalCinematic()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("final");
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(startWriting());
    }

    IEnumerator startWriting()
    {
        HomemFruta.enabled = true;
        fullText = "BOM DIA... ANTES DE MAIS SINTO MUITO PELO SEU DIVORCIO...";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            FrutaTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.7f);

        me.enabled = true;
        fullText = "POIS..."; 
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            MeTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.7f);

        HomemFruta.enabled = true;
        fullText = "ENFIM.. O QUE DESEJA?...";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            FrutaTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.7f);

        me.enabled = true;
        fullText = "ESPERA!? ONDE ESTA A MINHA FILHA?!...";
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            MeTextTalk.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.3f);

        HomemFruta.enabled = false;
        me.enabled = false;
        FrutaTextTalk.text = "";
        MeTextTalk.text = "";
        StartCoroutine(GameObject.Find("Main Camera").transform.Find("GameControl").GetComponent<Scene1>().StartCinematicScene());
    }
}
