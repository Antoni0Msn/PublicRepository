using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject Porta_;

    public List<GameObject> SpawnPoints;

    public List<GameObject> Enemyes;

    public int EnemyesAlive = 0;
    
    bool Durgeon_active = false;

    GameObject Enemies;

    //Round
    public int RoundActual = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDurgeonEnd();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Porta_.SetActive(true);
            SpawnEnemyes();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Durgeon_active =true;
        }
    }

    void SpawnEnemyes()
    {
        foreach (GameObject SP in SpawnPoints)
        {
            int randomEnemy = Random.Range(0, 2);
            GameObject NewEnemy = Instantiate(Enemyes[randomEnemy], SP.transform.position, Quaternion.identity);
            NewEnemy.GetComponent<EntityStats>().spawnManager = this;
            EnemyesAlive++;
        }
    }


    void CheckDurgeonEnd()
    {
        if (Durgeon_active == true)
        {
            if (EnemyesAlive == 0)
            {
                RoundActual++;
                Porta_.SetActive (false);
                gameObject.GetComponent <BoxCollider2D>().enabled = true;
            }
        }
    }

}
