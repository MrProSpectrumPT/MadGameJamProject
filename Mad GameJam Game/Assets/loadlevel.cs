using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        anim.SetTrigger("next");
    }
    public IEnumerator loadStartGame()
    {
        anim.SetTrigger("load");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("loadnext");
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Main Camera").transform.Find("GameControl").GetComponent<Scene1>().startGame();
    }

    public IEnumerator loadScene(int index)
    {
        anim.SetTrigger("load");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }

    public IEnumerator loadSceneSlow(int index)
    {
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("load");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }

    public IEnumerator goToHome(GameObject player)
    {
        anim.SetTrigger("load");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("loadnext");

        GameObject.Find("Main Camera").GetComponent<cameraControl>().enabled = true;
        player.transform.position = GameObject.Find("spawnPlayer").transform.position;
        GameObject.Find("Main Camera").GetComponent<cameraControl>().offset = new Vector3(0, 1.5f, -10);
        GameObject.Find("Cenario").transform.Find("sky").gameObject.transform.position = new Vector3(
            GameObject.Find("Cenario").transform.Find("sky").gameObject.transform.position.x,
            GameObject.Find("Cenario").transform.Find("sky").gameObject.transform.position.y + 3.2f,
            GameObject.Find("Cenario").transform.Find("sky").gameObject.transform.position.z);
    }
}
