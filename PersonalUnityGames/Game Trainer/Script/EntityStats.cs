using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EntityStats : MonoBehaviour
{
    public float MaxHp;
    public float Hp;
    public float base_speed;
    public float attackDamage;
    public float attackSpeed;
    public float attack_life;
    public float atackRange;
    public int gold_carry;

    AudioSource HitSound;

    AudioSource FootStepSoundStop;


    

    //Inimigo
    public SpawnManager spawnManager;

    //apenas jogador

    public int Level = 1;
    public int exp = 0;
    public float BonusAttack;
    public float BonusAttackSpeed;

    //particles
    public GameObject Death_particles;



    private void Start()
    {
        FootStepSoundStop = GameObject.Find("FootSteps Sound").GetComponent<AudioSource>();

        Hp = MaxHp;

        HitSound = GameObject.Find("Hit Sound").GetComponent<AudioSource>();
    }

    private void Update()
    {
        DamageBlink();

    }


    public void Death()
    {
        if (Hp <= 0)
        {
            //Dá ouro para o jogador

            if (this.gameObject.tag != "Player")
            {
                InventoryManager.Instance.AddGold(gold_carry);
                GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>().AddExp(exp);
            }

            if (this.gameObject.tag == "Player")
            {
                OptionsManager.Instance.GetComponent<OptionsManager>().audioslider.value = 0;
                
            }

            //computa a morte do inimigo

            if (this.gameObject.tag == "Enemy")
            {
                spawnManager.EnemyesAlive--;
            }

            HitSound.volume = 1 * OptionsManager.Instance.audioslider.value;

            FootStepSoundStop.Stop();


            Instantiate(Death_particles, gameObject.transform.position, Quaternion.identity);

            
            

            Destroy(this.gameObject);
        }
    }



    public void RemoveHP(float HP_Toremove)
    {

        GameObject NewPopUp = Instantiate(HudScript.Instance.damagePopUP, this.gameObject.transform.position, Quaternion.identity);
        NewPopUp.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), 5), ForceMode2D.Impulse);
        NewPopUp.GetComponentInChildren<Text>().text = (Mathf.RoundToInt(HP_Toremove*10)).ToString();
        Destroy(NewPopUp,1 );

        //change color

        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        HitSound.volume = 0.4f * OptionsManager.Instance.audioslider.value; ;
        

        Hp -= HP_Toremove;
        Death();
        HitSound.Play();
    }


    void AddExp(int exp_)
    {
        exp += exp_;

        if (exp >= Level*100)
        {
            Level++;
            exp = 0;
            HudScript.Instance.setupLevelUP();
        }


    }

    void DamageBlink()
    {

        if (gameObject.GetComponent<SpriteRenderer>().color == Color.white)
        {

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, Color.white, 10 * Time.deltaTime);
        }

    }


}
