using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Stats
    [Header("- Health Type")]
    public static float maxHealth = 300f;
    public static float defensivePower = 10f;
    public static int dodgeChance = 10;

    [Header("- Move Type")]
    public static float walkSpeed = 15f;

    [Header("- Attack Type")]
    public static float bulletDamage = 100f;
    public static float bulletSpeed = 3000f;
    public static float shotSpeed = 1f;
    public static int criticalChance = 10;
    public static float criticalDamage = 100f;

    [Header("- etc. Type")]
    public static int level = 1;
    public static float haveExperience = 0f;
    public static int timeLevel = 1;
    public static float playTimes = 0f;
    #endregion
}
