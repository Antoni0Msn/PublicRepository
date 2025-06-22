using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeginScreen : MonoBehaviour
{
    GameObject PlayerObject;
    bool PlayerNext;
    bool InGame = true;

    //Som ambient
    AudioSource AudioSourceAmbient;

    //scene do jogo
    public GameObject NewLoadGame;

    public static BeginScreen Instance { get; private set; }

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
        AudioSourceAmbient = OptionsManager.Instance.GetComponent<OptionsManager>().AudioSources[0];
        
        Time.timeScale = 0;
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerObject.GetComponent<PlayerMovement>().enabled = false;
        PlayerObject.GetComponent<PlayerAttack>().enabled = false;
        NewLoadGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        AudioSourceAmbient.volume = OptionsManager.Instance.GetComponent<OptionsManager>().audioslider.value;

    }


    public void LoadGame()
    {
        //PlayerPositions
        PlayerObject.transform.position = new Vector3(PlayerPrefs.GetFloat("Pos_x"), PlayerPrefs.GetFloat("Pos_y"), 0);

        Camera.main.transform.position = new Vector3(PlayerPrefs.GetFloat("Pos_x"), PlayerPrefs.GetFloat("Pos_y"), -10);


        //PlayerStats
        PlayerObject.GetComponent<EntityStats>().Level = PlayerPrefs.GetInt("Level");
        PlayerObject.GetComponent<EntityStats>().exp = PlayerPrefs.GetInt("EXP");
        PlayerObject.GetComponent<EntityStats>().MaxHp = PlayerPrefs.GetFloat("MaxHp");
        PlayerObject.GetComponent<EntityStats>().Hp = PlayerPrefs.GetFloat("CurrentHP");
        PlayerObject.GetComponent<EntityStats>().base_speed = PlayerPrefs.GetFloat("MoveSpeed");
        PlayerObject.GetComponent<EntityStats>().BonusAttack = PlayerPrefs.GetFloat("AttackDamage");
        PlayerObject.GetComponent<EntityStats>().BonusAttackSpeed = PlayerPrefs.GetFloat("AttackSpeed");
        //PlayerObject.GetComponent<InventoryManager>().gold_coins = PlayerPrefs.SetInt("gold_text");

        //PlayerOptions
        OptionsManager.Instance.audioslider.value = PlayerPrefs.GetFloat("AudioVolume");
        OptionsManager.Instance.resolution_dropdown.value = PlayerPrefs.GetInt("ResolutionSave");
        InGame = true;
        NewLoadGame.SetActive(false);
       
        //Permite jogar
        PlayerObject.GetComponent<PlayerMovement>().enabled = true;
        PlayerObject.GetComponent<PlayerAttack>().enabled = true;
        Time.timeScale = 1f;

        //Dá play no som de fundo
        AudioSourceAmbient.Play();

    }

    public void NewGame()
    {
        NewLoadGame.SetActive(false);
        //Permite jogar
        PlayerObject.GetComponent<PlayerMovement>().enabled = true;
        PlayerObject.GetComponent<PlayerAttack>().enabled = true;
        Time.timeScale = 1f;
        //Dá play no som ambient
        AudioSourceAmbient.Play();
       
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
