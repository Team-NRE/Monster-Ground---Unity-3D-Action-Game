using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public Text[] StatusUI;

    void Update()
    {
        StatusUI[0].text = PlayerStats.bulletDamage.ToString();
        StatusUI[1].text = PlayerStats.defensivePower.ToString();
        StatusUI[2].text = PlayerStats.shotSpeed.ToString();
        StatusUI[3].text = PlayerStats.walkSpeed.ToString();
    }
}
