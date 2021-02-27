using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1 : MonoBehaviour
{
    public Animator anim;
    public Transform player;

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
    private bool send;
    public bool canSpeak;

    public GameObject enemy;

    public Animator TextIntroduction;
    public loadlevel level;
    public GameObject introduction;
    void Start()
    {
        StartCoroutine(IntroductionMovie());
    }

    private void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        if (enemy == null) return;
        if (enemy.GetComponent<inimigo>().morreu && player.GetComponent<playerScript>().canAttack)
        {
            if (!send)
            {
                send = true;
                sendMissionSearch();
            }
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

        player.GetComponent<playerScript>().inCutScene = false;
        player.GetComponent<Animator>().SetTrigger("idle");

        Roubo.SetActive(false);
        Blood.SetActive(true);
    }

    private IEnumerator StartCinematicScene()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("grito!");
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<SpriteRenderer>().transform.Rotate(0, 180f, 0);
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("cut");
    }

    public IEnumerator StartCutScene3()
    {
        BlackBars.SetActive(true);
        gameUi.SetActive(false);
        player.GetComponent<playerScript>().inCutScene = true;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.GetComponent<Animator>().SetBool("cutScene", true);
        yield return new WaitForSeconds(3f);

        BlackBars.SetActive(false);
        gameUi.SetActive(true);
        missionText.SetTrigger("fadeOut");
        yield return new WaitForSeconds(0.2f);
        mission.text = "Compre uma arma";
        missionText.SetTrigger("fadeIn");
        player.GetComponent<Animator>().SetBool("cutScene", false);

        player.GetComponent<playerScript>().inCutScene = false;
    }

    public void SpawnEnemy()
    {
        missionText.SetTrigger("fadeOut");
        mission.text = "Abata o vilão";
        missionText.SetTrigger("fadeIn");
        Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
    }

    public void sendMissionSearch()
    {
        missionText.SetTrigger("fadeOut");
        mission.text = "Procure informações sobre os vilões";
        missionText.SetTrigger("fadeIn");
        canSpeak = true;
    }

    public IEnumerator IntroductionMovie()
    {
        introduction.SetActive(true);
        player.GetComponent<playerScript>().inCutScene = true;
        BlackBars.SetActive(false);
        Blood.SetActive(false);
        gameUi.SetActive(false);
        TextIntroduction.SetTrigger("open");
        yield return new WaitForSeconds(5f);
        StartCoroutine(level.loadStartGame());
    }

    public void startGame()
    {
        player.GetComponent<playerScript>().inCutScene = true;
        BlackBars.SetActive(true);
        Blood.SetActive(false);
        gameUi.SetActive(false);
        introduction.SetActive(false);
        StartCoroutine(StartCinematicScene());
    }
}
