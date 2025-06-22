using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHP : MonoBehaviour
{
    Slider hp_slider;
    EntityStats entitystats;


    // Start is called before the first frame update
    void Start()
    {
        
        hp_slider = gameObject.GetComponentInChildren<Slider>();
        entitystats = gameObject.GetComponentInParent<EntityStats>();


    }

    // Update is called once per frame
    void Update()
    {
        hp_slider.maxValue = entitystats.MaxHp;
        hp_slider.value = entitystats.Hp;


    }
}
