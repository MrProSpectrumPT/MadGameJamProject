using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3 : MonoBehaviour
{

    public KillStatus status;
    public static int numKills;

    public static bool primeiraSCENE;
    public static bool segundaSCENE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numKills = status.countDeadEnemys;

        //ativado no player trigger se kills > 6
        if(primeiraSCENE == true){
            Debug.Log("morte");
        }

        //ativado no player se primeiraSCENE == true
        if(segundaSCENE == true){

        }

    }
}
