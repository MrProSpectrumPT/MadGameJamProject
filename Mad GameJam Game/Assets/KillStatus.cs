using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillStatus : MonoBehaviour
{
    public bool canSwitch = false;
    public Text enemysText;
    private GameObject[] enemys;
    public int countDeadEnemys = 0;
    void Start()
    {
        enemys = GameObject.FindGameObjectsWithTag("enemy");
        enemysText.text = countDeadEnemys + " / " + enemys.Length / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDeadEnemys >= enemys.Length / 2)
        {
            canSwitch = true;
            enabled = false;
            enemysText.text = countDeadEnemys + " / " + enemys.Length / 2;
        }
        else
        {
            enemysText.text = countDeadEnemys + " / " + enemys.Length / 2;
        }
    }
}
