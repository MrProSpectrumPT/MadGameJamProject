using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector3 relSmooth;
    private Animator anim;

    public Transform boundInicio, boundFim;

    public Animator rouboNPC1;
    public Animator rouboNPC2;
    public GameObject Blood;
    public GameObject Roubo;

    public Transform move1, move2;
    private bool movePlayer;
    public GameObject BlackBars;
    public GameObject gameUi;

    public Animator missionText;
    public Text mission;
    private Vector3 relvel;

    public GameObject enemyPrefab;
    public Transform spawnPos;
    private void Start()
    {
        anim = GetComponent<Animator>();
        target.GetComponent<playerScript>().inCutScene = true;
        BlackBars.SetActive(true);

        Blood.SetActive(false);
        gameUi.SetActive(false);
        StartCoroutine(StartCinematicScene());
    }
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, 0f, 0f), new Vector3(target.position.x, 0f, 0f), ref relSmooth, 0.1f) + offset;
        
        if(transform.position.x == boundInicio.position.x)
        {
            Debug.Log("dead");
            transform.position = new Vector3(boundInicio.position.x, transform.position.y, transform.position.z);
        }
    }

    public IEnumerator startAnimationRoubo()
    {
        yield return new WaitForSeconds(0.4f);
        rouboNPC1.SetTrigger("attack");

        yield return new WaitForSeconds(0.5f);
        rouboNPC2.SetTrigger("attack2");

        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("cut2");

        yield return new WaitForSeconds(2.5f);

        //START GAME
        gameUi.SetActive(true);

        mission.text = "Ajude a sua filha";

        missionText.SetTrigger("fadeIn");

        anim.enabled = false;
        BlackBars.SetActive(false);

        target.GetComponent<playerScript>().inCutScene = false;
        target.GetComponent<Animator>().SetTrigger("idle");

        Roubo.SetActive(false);
        Blood.SetActive(true);
    }

    private IEnumerator StartCinematicScene()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("grito!");
        yield return new WaitForSeconds(0.5f);
        target.GetComponent<SpriteRenderer>().transform.Rotate(0, 180f, 0);
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("cut");
    }

    public IEnumerator StartCutScene3()
    {
        BlackBars.SetActive(true);
        gameUi.SetActive(false);
        target.GetComponent<playerScript>().inCutScene = true;
        target.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        target.GetComponent<Animator>().SetBool("cutScene", true);
        yield return new WaitForSeconds(3f);

        BlackBars.SetActive(false);
        gameUi.SetActive(true);
        missionText.SetTrigger("fadeOut");
        yield return new WaitForSeconds(0.2f);
        mission.text = "Compre uma arma";
        missionText.SetTrigger("fadeIn");
        target.GetComponent<Animator>().SetBool("cutScene", false);

        target.GetComponent<playerScript>().inCutScene = false;
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
    }
}


