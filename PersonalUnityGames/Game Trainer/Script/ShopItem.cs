using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Weapon w_;

    public Text ItemNameHolder;
    public Text ItemValueHolder;
    public Image ItemIconHolder;
    public Text ItemInfoHolder;
    public Button ShopButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Setup(w_);
    }

    public void Setup(Weapon w)
    {
        ItemNameHolder.text = w.WeaponName;
        ItemValueHolder.text = w.WeaponValue.ToString();
        ItemIconHolder.sprite = w.Weapon_Icon;
        ItemInfoHolder.text = "Attack Damage: " + w.Weapon_Damage.ToString() + "\nAttack Speed: " + w.Weapon_Speed.ToString() + "\nRange: " + w.Weapon_Range.ToString();

        if (InventoryManager.Instance.gold_coins < w.WeaponValue)
        {
            ShopButton.interactable = false;

        }
        else
        {
            ShopButton.interactable = true;
        }
    }


    public void BuyWeapon()
    {
        if (InventoryManager.Instance.Inventory_[4] != null)
        {

        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (InventoryManager.Instance.Inventory_[i] == null)
                {
                    InventoryManager.Instance.Inventory_[i] = w_;
                    break;
                }
            }
            
            InventoryManager.Instance.AddGold(w_.WeaponValue * -1);
            refreshShop();
            Destroy(this.gameObject);
        }


    }



    void refreshShop()
    {
        GameObject[] shopButtons = GameObject.FindGameObjectsWithTag("ShopItem");
        foreach (GameObject go in shopButtons)
        {
            go.GetComponent<ShopItem>().Setup(go.GetComponent<ShopItem>().w_);
        }
    }


 


}
