using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

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


    public GameObject InvBackground;
    public GameObject InvSlot;

    public List<Weapon> Inventory_;

    int selected_slot = 0;

    EntityStats PlayerStats;
    public int ActiveSlot;



    //Gold Manager

    public int gold_coins;
    public Text gold_text;



    // Start is called before the first frame update
    void Start()
    {
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        SelectWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        InventorySelection();
    }

    public void refreashInventory()
    {
        //refreash Gold

        gold_text.text = gold_coins.ToString();


        //destroi todos os slots antes de continuar
        GameObject[] destroy_slots = GameObject.FindGameObjectsWithTag("Slot"); 
        foreach (GameObject go in destroy_slots)
        {
            Destroy(go);
        }


        int Hotkey_ = 1;

        foreach (Weapon w in Inventory_)
        {
            GameObject slot_instance = Instantiate(InvSlot, InvBackground.transform);
            Image[] slot_icons = slot_instance.GetComponentsInChildren<Image>();


            if (w == null)
            {
                slot_icons[1].GetComponentInChildren<Image>().enabled = false;

            }
            else
            {
                slot_instance.GetComponentInChildren<Image>().enabled = true;

                slot_icons[1].GetComponentInChildren<Image>().sprite = w.Weapon_Icon;

                //Desabilita Outline e habilita caso selecionado
                slot_icons[0].GetComponent<Image>().color = Color.white;

                if (selected_slot == Hotkey_) { slot_icons[0].GetComponent<Image>().color = Color.yellow; }
              
            }
            slot_instance.GetComponentInChildren<Text>().text = Hotkey_.ToString();
            Hotkey_++;


        }

    }

    void SelectWeapon(int Hotkey_)
    {
        Weapon selected_weapon = Inventory_[Hotkey_ - 1];
        ActiveSlot = Hotkey_ - 1;


        PlayerStats.attackDamage = selected_weapon.Weapon_Damage;
        PlayerStats.attackSpeed = selected_weapon.Weapon_Speed;
        PlayerStats.atackRange = selected_weapon.Weapon_Range;
        PlayerStats.attack_life = selected_weapon.Weapon_Life;
        PlayerStats.gameObject.GetComponent<PlayerAttack>().Projectile_ = selected_weapon.weapon_projectile;
        PlayerStats.gameObject.GetComponent<PlayerAttack>().Weapon_sound_clip = selected_weapon.weapon_sound;
        PlayerStats.gameObject.GetComponent<PlayerAttack>().AudioPitch = selected_weapon.weapon_sound_pitch;

        selected_slot = Hotkey_;
        refreashInventory();
    }

    void InventorySelection()
    {
        if (Input.GetKeyDown((KeyCode.Alpha1)))
        {
            SelectWeapon(1);
        }

        if (Input.GetKeyDown((KeyCode.Alpha2)))
        {
            SelectWeapon(2);
        }

        if (Input.GetKeyDown((KeyCode.Alpha3)))
        {
            SelectWeapon(3);
        }

        if (Input.GetKeyDown((KeyCode.Alpha4)))
        {
            SelectWeapon(4);
        }

        if (Input.GetKeyDown((KeyCode.Alpha5)))
        {
            SelectWeapon(5);
        }


    }

    public void AddGold(int g)
    {
        gold_coins += g;
        refreashInventory();
    }


    public void DiscardWeapon()
    {

        if (ActiveSlot != 0)
        {
            Inventory_[ActiveSlot] = null;
            SelectWeapon(1);
            refreashInventory();
        }

    }

}
