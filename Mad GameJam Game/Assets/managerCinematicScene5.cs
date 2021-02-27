using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerCinematicScene5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Travel").transform.Find("UI").transform.Find("BB").gameObject.SetActive(true);
        GameObject.Find("Travel").transform.Find("UI").transform.Find("UI-GAME").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
