using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sons : MonoBehaviour
{
    public static sons instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
