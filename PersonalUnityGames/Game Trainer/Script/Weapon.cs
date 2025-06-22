using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon")]

public class Weapon : ScriptableObject
{

    public float Weapon_Damage;
    public float Weapon_Speed;
    public float Weapon_Life;
    public float Weapon_Range;
    public Sprite Weapon_Icon;
    public string WeaponName;
    public int WeaponValue;
    public GameObject weapon_projectile;
    public AudioClip weapon_sound;
    public float weapon_sound_pitch;


 
}
