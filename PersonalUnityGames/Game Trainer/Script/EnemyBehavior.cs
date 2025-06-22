using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class EnemyBehavior : MonoBehaviour
{
    GameObject PlayerObject;
    public float MoveSpeed;
    EntityStats EntityStats;
    float Cooldown_AutoDestroy;




    void Start()
    {
        
        
        EntityStats = gameObject.GetComponent<EntityStats>();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }


    public void FollowPlayer()
    {
        if (PlayerObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerObject.transform.position, MoveSpeed * Time.deltaTime);
        }
        else if (PlayerObject == null)
        {
            Cooldown_AutoDestroy += Time.deltaTime;
            if (Cooldown_AutoDestroy >= 2)
            {
                
                Destroy(this.gameObject);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EntityStats>().Hp -= EntityStats.attackDamage;
            gameObject.GetComponent<EntityStats>().RemoveHP(EntityStats.MaxHp + 1);
            EntityStats.Hp -= EntityStats.MaxHp + 1;    
        }
    }

}
