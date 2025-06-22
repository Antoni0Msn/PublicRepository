using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class WarningManager : MonoBehaviour
{
    public GameObject GameWelcome;
    public GameObject SetaDeDireção;
    GameObject PlayerOBJ;
    public GameObject ParticulasTutoras;
    int ReadThis = 0;


    // Start is called before the first frame update
    void Start()
    {
        ParticulasTutoras.SetActive(true);
        GameWelcome.SetActive(false);
        PlayerOBJ = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, PlayerOBJ.transform.position);
        
        if (dist < 1 && ReadThis == 0)
        {
            GameWelcome.SetActive(true);
            ParticulasTutoras.SetActive(false);
            ReadThis++;

        }
        else if (dist > 1 && ReadThis > 0)
        {
            GameWelcome.SetActive(false);
        }

        
        
    }



}
