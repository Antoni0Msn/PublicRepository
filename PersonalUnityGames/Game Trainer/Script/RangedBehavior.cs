using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class RangedBehavior : MonoBehaviour

{

    public GameObject Projectile_;
    EntityStats entity_stats;

    bool can_attack = true;
    float cooldown_;

    GameObject Player_obj;
    float Cooldown_AutoDestroy;


    void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStats>();
        Player_obj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (can_attack == true && Player_obj != null)
        {
            GameObject projectile_instance = Instantiate(Projectile_, transform.position, Quaternion.identity);

            projectile_instance.GetComponent<ProjectileDamage>().Projectile_Damage = entity_stats.attackDamage;
            projectile_instance.GetComponent<ProjectileDamage>().projectile_lifespan = entity_stats.attack_life;

            Vector2 projectile_diretion = Player_obj.transform.position - transform.position;
            projectile_diretion.Normalize();


            projectile_instance.GetComponent<Rigidbody2D>().AddForce(projectile_diretion * entity_stats.atackRange, ForceMode2D.Impulse);

            can_attack = false;
            cooldown_ = 0;
        }
        else if (Player_obj == null) 
        {
            Cooldown_AutoDestroy += Time.deltaTime;
            if (Cooldown_AutoDestroy >= 2)
            {
                Destroy(this.gameObject);
            }
        }

        cooldown();

       

    }



    void cooldown()
    {
        if (cooldown_ > entity_stats.attackSpeed && can_attack == false)
        {
            can_attack = true;
        }

        else
        {
            cooldown_ += Time.deltaTime;
        }


    }
}
