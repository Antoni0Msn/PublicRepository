using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMagnet : MonoBehaviour
{

    public GameObject Magnet_position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
                Camera.main.GetComponent<CameraBehavior>().TargetObject = Magnet_position;
         
        }
       
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.main.GetComponent<CameraBehavior>().TargetObject = collision.gameObject;
        }


    }

}
