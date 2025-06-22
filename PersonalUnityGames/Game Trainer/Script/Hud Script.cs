using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    public static HudScript Instance { get; private set; }



    public Slider hp_bar;
    EntityStats Player_stats;

    public Slider EXPBar;

    public GameObject LevelUpScreen;
    public Text[] stats_info;

    public GameObject damagePopUP;


    //HUD de status
    bool StatsOpen = false;
    public Text HPLevel;
    public Text MovePLevel;
    public Text DamageLevel;
    public Text AtkSpeedLevel;
    public Text LevelText;
    public GameObject StatsUI;

    //Objeto do player
    GameObject PlayerObj;


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
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        Player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        StatsUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        player_hud();
        OpenUIStats();
        LevelText.text = "Level: " + PlayerObj.GetComponent<EntityStats>().Level.ToString();

    }

    void player_hud()
    {
        //hp
        hp_bar.maxValue = Player_stats.MaxHp;
        hp_bar.value = Player_stats.Hp;

        //EXP
        EXPBar.maxValue = Player_stats.Level * 100;
        EXPBar.value = Player_stats.exp; 

    }


   public void SelectStats(string stat)
    {
        if (stat == "hp")
        {
            Player_stats.MaxHp += 5;
            Player_stats.Hp += 5;
        } 
        if (stat == "attack")
        {
            Player_stats.BonusAttack += 5;
        }
        if (stat == "atkspeed")
        {
            Player_stats.BonusAttackSpeed += 2.5f;
            
        }
        if (stat == "move")
        {
            Player_stats.base_speed += 200;

        }

        LevelUpScreen.SetActive(false);
    }

    public void setupLevelUP()
    {
        LevelUpScreen.SetActive(true);
        stats_info[0].text = Player_stats.MaxHp.ToString();
        stats_info[1].text = Player_stats.BonusAttack.ToString() + 5;
        stats_info[2].text = (Mathf.RoundToInt(Player_stats.BonusAttackSpeed)).ToString();
        stats_info[3].text = ((Player_stats.base_speed / 1000)).ToString();
        //stats_info[3].text = (Mathf.CeilToInt(Player_stats.base_speed / 1000)).ToString(); 

    }

    //abrir statis caso aperte TAB
    public void OpenUIStats()
    {
        if (Input.GetKey(KeyCode.Tab) && StatsOpen == false)
        {
            StatsOpen = true;
            StatsInfo();
            StatsUI.SetActive(true);
            PlayerObj.GetComponent<PlayerAttack>().enabled = false;
        }
       
       
    }

    //Fecha a tela de status
    public void CloseUIStats()
    {
        StatsUI.SetActive(false);
        StatsOpen = false;
        PlayerObj.GetComponent<PlayerAttack>().enabled = true;
    }

    public void StatsInfo()
    {
        //StatsUI;
        HPLevel.text = PlayerObj.GetComponent<EntityStats>().MaxHp.ToString();
        MovePLevel.text = PlayerObj.GetComponent<PlayerMovement>().MoveSpeed.ToString();
        DamageLevel.text = PlayerObj.GetComponent<EntityStats>().attackDamage.ToString();
        AtkSpeedLevel.text = PlayerObj.GetComponent<EntityStats>().BonusAttackSpeed.ToString();


    }

}


