using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    // 오브젝트와 이 스크립트에서 사용하는 함수
    private GameObject playTimeBackgroundUI;
    private GameObject playTimesUI;
    public Sprite[] clockLevel;
    private Image clockFill;
    private Image clockBack;
    private float timeLevelInterval;

    void Start()
    {
        // 기본 값 설정
        playTimeBackgroundUI = GameObject.FindWithTag("PlayerTime").transform.Find("Background").gameObject;
        playTimesUI = GameObject.FindWithTag("PlayerTime").transform.Find("Gauge").gameObject;
        clockFill = playTimesUI.GetComponent<Image>();
        clockBack = playTimeBackgroundUI.GetComponent<Image>();
        timeLevelInterval = 180.0f;

        clockBack.sprite = clockLevel[PlayerStats.timeLevel - 1];
        clockFill.sprite = clockLevel[PlayerStats.timeLevel];
    }

    void Update()
    {
        // 플레이타임 증가
        PlayerStats.playTimes += Time.deltaTime;

        clockFill.fillAmount = (PlayerStats.playTimes % timeLevelInterval) / timeLevelInterval;


        if (PlayerStats.playTimes >= PlayerStats.timeLevel * timeLevelInterval && PlayerStats.timeLevel < 11)
        {
            clockBack.sprite = clockLevel[PlayerStats.timeLevel++];

            if (PlayerStats.timeLevel <= 10)
                clockFill.sprite = clockLevel[PlayerStats.timeLevel];
        }
    }
}
