using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour
{
    public Animator anim;
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
}
