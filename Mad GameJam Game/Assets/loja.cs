using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loja : MonoBehaviour
{
    public cameraControl control;

    public GameObject lojaUI;
    public bool haveWeapon = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if(!control.mission.text.Equals("Ajude a sua filha") && !haveWeapon)
            {
                lojaUI.SetActive(true);
                control.target.GetComponent<playerScript>().inCutScene = true;
                control.target.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                control.target.GetComponent<Animator>().SetBool("cutScene", true);
            }
        }
    }

    public void chooseWeapon(int weapon)
    {
        haveWeapon = true;
        control.target.GetComponent<playerScript>().weapon = weapon;
        control.target.GetComponent<playerScript>().canAttack = true;

        control.target.GetComponent<playerScript>().inCutScene = false;
        control.target.GetComponent<Animator>().SetBool("cutScene", false);

        control.SpawnEnemy();
        lojaUI.SetActive(false);
    }
}
