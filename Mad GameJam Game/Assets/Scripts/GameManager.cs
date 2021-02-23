using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject instance;

    [SerializeField]
    public GameObject groundPrefabParticle;
    void Awake()
    {
        if(instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Debug.Log("Este script ja existe!");
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        GameObject[] tmp_obj = GameObject.FindGameObjectsWithTag("particles");

        if (tmp_obj.Length > 0)
        {
            foreach (GameObject ps in tmp_obj)
            {
                if (ps.GetComponent<ParticleSystem>().isStopped)
                {
                    Destroy(ps);
                }
            }
        }   

    }

    public void instanceGroundColision(Transform pos)
    {
        Instantiate(groundPrefabParticle, pos.position, Quaternion.identity);
    }
}
