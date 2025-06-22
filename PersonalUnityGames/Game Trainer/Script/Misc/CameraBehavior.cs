using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraBehavior : MonoBehaviour
{

    public GameObject TargetObject;

    public List<Transform> Boundaries;

    Vector3 target_transform;

    GameObject Player_Object;


    // Start is called before the first frame update
    void Start()
    {
        Player_Object = GameObject.FindGameObjectWithTag("Player");
        TargetObject = Player_Object;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player_Object == null)
        {
            target_transform = new Vector3(0, -10, 0);
        }
        else if (Player_Object != null)
        {
            if ((Player_Object.transform.position.x < Boundaries[0].position.x || Player_Object.transform.position.x > Boundaries[1].position.x) && (Player_Object.transform.position.y < Boundaries[2].position.y || Player_Object.transform.position.y > Boundaries[3].position.y))
            {
                target_transform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
            }

            else if (Player_Object.transform.position.x < Boundaries[0].position.x || Player_Object.transform.position.x > Boundaries[1].position.x)
            {
                target_transform = new Vector3(gameObject.transform.position.x, TargetObject.transform.position.y, -10);
            }

            else if (Player_Object.transform.position.y < Boundaries[2].position.y || Player_Object.transform.position.y > Boundaries[3].position.y)
            {
                target_transform = new Vector3(TargetObject.transform.position.x, gameObject.transform.position.y, -10);
            }



            else
            {
                target_transform = new Vector3(TargetObject.transform.position.x, TargetObject.transform.position.y, -10);
            }

            transform.position = Vector3.Lerp(this.transform.position, new Vector3(target_transform.x, target_transform.y, -10), 1f * Time.fixedDeltaTime);
        }
    }
}
