using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStatue : MonoBehaviour
{
    GameObject PlayerObject;
    bool PlayerNext;
    public GameObject SaveBG;
   
    

    public static SaveStatue Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerNext = false;
        SaveBG.SetActive(false);

    }


    // Update is called once per frame

    void Update()
    {

        float dist = Vector3.Distance(transform.position, PlayerObject.transform.position);
        if (dist < 1.5f)
        {
            PlayerNext = true;
            SaveBG.SetActive(true);
            if ((Input.GetKeyUp(KeyCode.E)))
            {
                SaveGame();
            }
        }
        else if (dist > 1.5f)
        {
            PlayerNext = false;
            SaveBG.SetActive(false);
        }

    }


    public void SaveGame()
    {

        //PlayerPosition
        PlayerPrefs.SetFloat("Pos_x", PlayerObject.transform.position.x);
        PlayerPrefs.SetFloat("Pos_y", PlayerObject.transform.position.y);
        //PlayerStats
        PlayerPrefs.SetInt("Level", PlayerObject.GetComponent<EntityStats>().Level);
        PlayerPrefs.SetInt("EXP", PlayerObject.GetComponent<EntityStats>().exp);
        PlayerPrefs.SetFloat("MaxHp", PlayerObject.GetComponent<EntityStats>().MaxHp);
        PlayerPrefs.SetFloat("CurrentHP", PlayerObject.GetComponent<EntityStats>().Hp);
        PlayerPrefs.SetFloat("MoveSpeed", PlayerObject.GetComponent<EntityStats>().base_speed);
        PlayerPrefs.SetFloat("AttackDamage", PlayerObject.GetComponent<EntityStats>().BonusAttack);
        PlayerPrefs.SetFloat("AttackSpeed", PlayerObject.GetComponent<EntityStats>().BonusAttackSpeed);
        //PlayerPrefs.SetInt("gold_text", PlayerObject.GetComponent<InventoryManager>().gold_coins);

        //PlayerOptions

        PlayerPrefs.SetFloat("AudioVolume", OptionsManager.Instance.audioslider.value);
        PlayerPrefs.SetInt("ResolutionSave", OptionsManager.Instance.resolution_dropdown.value);


    }
}
