using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStore : MonoBehaviour
{

    public GameObject StoreObject;
    public GameObject StoreWarning;

    

    GameObject Player_Object;

    public List<Weapon> Weapons_Sold;

    public GameObject shop_bg;
    public GameObject shop_item;

    // Start is called before the first frame update
    void Start()
    {
        RandomItens();
        StoreObject.SetActive(false);
        Player_Object = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            return;
        }
        else
        {


            float dist = Vector2.Distance(transform.position, Player_Object.transform.position);

            if (dist < 2)
            {
                StoreWarning.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    StoreObject.SetActive(true);

                }
            }

            else
            {
                StoreObject.SetActive(false);
                StoreWarning.SetActive(false);
            }
        }


    }


    void RandomItens()
    {

        for (int i = 0; i < 3; i++)
        {

            int RandomNumber = Random.Range(0, Weapons_Sold.Count);

            GameObject NewShopItem = Instantiate(shop_item, shop_bg.transform);
            NewShopItem.GetComponent<ShopItem>().w_ = Weapons_Sold[RandomNumber];
            NewShopItem.GetComponent<ShopItem>().Setup(Weapons_Sold[RandomNumber]);


        }

    }


    //Botão função de fechar loja
    public void closeStore()
    {
        StoreObject.SetActive(false);
        
    }



}
