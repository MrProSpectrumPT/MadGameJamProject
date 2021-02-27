using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaControl : MonoBehaviour
{
    private int vidaPlayer;
    Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vidaPlayer = playerScript.vidaAtual;

        Animator.SetInteger("vida", vidaPlayer);
    }
}
