using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loja : MonoBehaviour
{
    public Scene1 scene;

    public GameObject lojaUI;
    public bool haveWeapon = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if(!scene.mission.text.Equals("Ajude a sua filha") && !haveWeapon)
            {
                lojaUI.SetActive(true);
                scene.player.GetComponent<playerScript>().inCutScene = true;
                scene.player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                scene.player.GetComponent<Animator>().SetBool("cutScene", true);
            }
        }
    }

    public void chooseWeapon(int weapon)
    {
        haveWeapon = true;
        scene.player.GetComponent<playerScript>().weapon = weapon;
        scene.player.GetComponent<playerScript>().canAttack = true;

        scene.player.GetComponent<playerScript>().inCutScene = false;
        scene.player.GetComponent<Animator>().SetBool("cutScene", false);

        scene.SpawnEnemy();
        lojaUI.SetActive(false);
    }
}
