using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStats : MonoBehaviour
{
    public void Awake() 
    {
        PlayerStats.maxHealth = 300f;
        PlayerStats.defensivePower = 5f;
        PlayerStats.dodgeChance = 10;

        PlayerStats.walkSpeed = 12f;

        PlayerStats.bulletDamage = 15f;
        PlayerStats.bulletSpeed = 3000f;
        PlayerStats.shotSpeed = 1.5f;
        PlayerStats.criticalChance = 10;
        PlayerStats.criticalDamage = 55f;

        PlayerStats.level = 1;
        PlayerStats.haveExperience = 0f;
        PlayerStats.timeLevel = 1;
        PlayerStats.playTimes = 0f;
    }

    
}
