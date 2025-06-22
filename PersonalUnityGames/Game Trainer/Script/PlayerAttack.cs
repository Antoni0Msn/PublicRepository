using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    public GameObject Projectile_;
    EntityStats BulletStats;
    float cooldown_;
    bool can_attack = true;

    public AudioClip Weapon_sound_clip;

    public AudioSource WeaponSound;

    public float AudioPitch;


    void Start()
    {
        BulletStats = GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButton(0) && can_attack == true)
        {
            GameObject projectile_instance = Instantiate(Projectile_,transform.position, Quaternion.identity);

            projectile_instance.GetComponent<ProjectileDamage>().Projectile_Damage = BulletStats.attackDamage * ((BulletStats.BonusAttack + 100)/100);
            projectile_instance.GetComponent<ProjectileDamage>().projectile_lifespan = BulletStats.attack_life;


            Vector2 projectile_diretion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            projectile_diretion.Normalize();


            float rot_z = Mathf.Atan2(projectile_diretion.y, projectile_diretion.x)*Mathf.Rad2Deg;
            projectile_instance.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            projectile_instance.GetComponent<Rigidbody2D>().AddForce(projectile_diretion* BulletStats.atackRange, ForceMode2D.Impulse);

            WeaponSound.pitch = AudioPitch;
            WeaponSound.volume = OptionsManager.Instance.audioslider.value;

            WeaponSound.PlayOneShot(Weapon_sound_clip);

            can_attack = false;
            cooldown_ = 0;
        }
        cooldown();

        if (Input.GetKeyDown(KeyCode.G))
        {
            InventoryManager.Instance.DiscardWeapon();
        }

    }

    void cooldown()
    {
        if (cooldown_ > (BulletStats.attackSpeed * ((100 - BulletStats.BonusAttackSpeed ))/100) && can_attack == false)
        {
            can_attack = true;
        }

        else
        {
            cooldown_ += Time.deltaTime;
        }


    }
}
