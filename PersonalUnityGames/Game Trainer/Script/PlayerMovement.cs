using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;

    EntityStats entity_stats;

    Animator animator_;

    public AudioSource FootStepsSound;

    // Ideia de fazer um Score por kill - public int ScoreInt;




    void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStats>();
        MoveSpeed = entity_stats.base_speed;
        animator_ = GetComponent<Animator>();
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WASDmove();
    }



    void WASDmove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal*MoveSpeed * Time.deltaTime, vertical*MoveSpeed * Time.deltaTime));


        //movimento diagonal
        if ((horizontal > 0 || horizontal < 0) && (vertical > 0 || vertical < 0 ))
        {
            MoveSpeed =  entity_stats.base_speed * 0.66f;
        }

        else 
        {
            MoveSpeed = entity_stats.base_speed;          
        }


        //Animação
        if (horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0)
        {
            if (horizontal > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            else if (horizontal < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            animator_.Play("Move");
            FootStepsSound.volume = 1 * OptionsManager.Instance.audioslider.value; 
            
        }

        else
        {
            animator_.Play("Idle");
            FootStepsSound.volume = 0;
        }


    }

}
