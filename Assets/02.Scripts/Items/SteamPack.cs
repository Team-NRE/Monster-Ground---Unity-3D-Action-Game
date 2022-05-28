using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPack : MonoBehaviour
{
    private float intervalTime = 10.0f;
    private float terminateTime = 1.0f;
    private itemAction sc;

    void Update()
    {
        intervalTime -= Time.deltaTime;
        PlayerStats.bulletSpeed -= itemAction.steamCount*0.1f;
        //5초 동안 효과 발생, 하나 먹어선 효과 없음
        //아이템 횟수당 효과 증가, 공속 증가용
        if (intervalTime - Time.deltaTime < 0.0f)
        {
            intervalTime = 10.0f;
        }
    }
}
