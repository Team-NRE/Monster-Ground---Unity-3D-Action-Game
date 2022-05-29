using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    // 오브젝트와 이 스크립트에서 사용하는 함수
    private GameObject levelTextUI; // 레벨 텍스트 UI
    private GameObject levelGaugeUI;    // 경험치 게이지 UI
    private Text levelText; // 레벨 텍스트 UI의 텍스트 컴포넌트
    private Image gauge;    // 경험치 게이지 UI의 이미지 컴포넌트
    private float maxExperienceValue; // 최대 경험치량

    public itemSpawner itemspawner;
    
    void Start()
    {
        // 기본 값 설정
        levelTextUI = GameObject.FindWithTag("PlayerLevel").transform.Find("Lv Text").gameObject;
        levelGaugeUI = GameObject.FindWithTag("PlayerLevel").transform.Find("Gauge").gameObject;
        levelText = levelTextUI.GetComponent<Text>();
        gauge = levelGaugeUI.GetComponent<Image>();
        maxExperienceValue = experienceFormula(PlayerStats.level);

        itemspawner = GameObject.FindWithTag("itemSpawner").GetComponent<itemSpawner>();
    }

    void Update()
    {
        // UI 레벨 텍스트 및 경험치 채워진 정도 설정
        levelText.text = "Lv. " + PlayerStats.level;
        float fillAmount = PlayerStats.haveExperience / maxExperienceValue;

        if (gauge.fillAmount != fillAmount)
            gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, PlayerStats.haveExperience / maxExperienceValue, Time.deltaTime * 3.0f);

        // 만약 레벨업을 할 시
        if (gauge.fillAmount >= 0.999f)
        {
            // 레벨 상승
            PlayerStats.level++;
            PlayerStats.haveExperience -= maxExperienceValue;   // 최대 경험치만큼 현재 경험치 감소

            maxExperienceValue = experienceFormula(PlayerStats.level);  // 최대 경험치 재조정

            itemspawner.ItemSpawners();
        }
    }

    float experienceFormula(int level)
    {
        /*
            레벨의 최대 경험치 량 계산 함수
            
            인자
            int level : 계산하고자 하는 경험치 량의 레벨

            리턴값
            int 30 * level + 20 : 레벨의 30배의 20을 더한 값이 그 레벨의 최대 경험치량
        */

        return 40 * level + 20;
    }

    public void getExperience(float e)
    {
        /*
            레벨에 변화가 갈 시, 함수를 호출하여 변화 실행
            
            인자
            int e : 경험치 변화량

            리턴값
            none
        */

        PlayerStats.haveExperience += e;
    }
}
