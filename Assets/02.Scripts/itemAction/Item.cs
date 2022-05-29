using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New item")]
public class Item : ScriptableObject
{

    public enum ItemType
    {
        Passive,
        Equip,
        Consume
    }

    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    
    //Health Type
    public float MaxHealth;
    public float DefensivePower;
    public int DodgeChance;
    
    //Move Type
    public float WalkSpeed;

    //Attack Type
    public float BulletDamage;
    public float BulletSpeed;
    public float ShotSpeed;
    public float CriticalDamage;
    public int CriticalChance;

    public Item(float _MaxHeath, float _DefenseivPower, int _DodgeChance, float _WalkSpeed, float _BulletDamage, float _BulletSpeed, float _ShotSpeed, float _CriticalDamage, int _CriticalChance)
    {
        this.MaxHealth = _MaxHeath;
        this.DefensivePower = _DefenseivPower;
        this.DodgeChance = _DodgeChance;
        this.WalkSpeed = _WalkSpeed;
        this.BulletDamage = _BulletDamage;
        this.BulletSpeed = _BulletSpeed;
        this.ShotSpeed = _ShotSpeed;
        this.CriticalDamage = _CriticalDamage;
        this.CriticalChance = _CriticalChance;
    }

    
}
