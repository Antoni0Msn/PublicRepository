using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileDamage : MonoBehaviour
{
    public float Projectile_Damage;
    public float projectile_lifespan = 1;
    public bool IsPlayer;


    void Start()
    {
        Destroy(this.gameObject, projectile_lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" && IsPlayer == false) || (collision.gameObject.tag == "Player" && IsPlayer == true))
        {
            collision.gameObject.GetComponent<EntityStats>().RemoveHP(Projectile_Damage);
            Destroy(this.gameObject); 
        }
        else if ((collision.gameObject.tag == "Wall")) {  Destroy(this.gameObject); }
    }
}
