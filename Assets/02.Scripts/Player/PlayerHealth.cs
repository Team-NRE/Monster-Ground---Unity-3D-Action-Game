using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // 오브젝트와 이 스크립트에서 사용하는 함수
    private GameObject healthGaugeUI;   // 체력 게이지 UI
    private Image gauge;    // 체력 게이지 UI의 이미지 컴포넌트
    public float nowHealth;  // 현재 체력

    public GameObject LoseUI;
    
    

    void Start()
    {
        // 기본 값 설정
        healthGaugeUI = GameObject.FindWithTag("PlayerHealth").transform.Find("Gauge").gameObject;
        gauge = healthGaugeUI.GetComponent<Image>();
        nowHealth = PlayerStats.maxHealth;
    }

    void Update()
    {
        // 게이지 UI 체력 채워진 정도 설정
        float fillAmount = nowHealth / PlayerStats.maxHealth;

        if (gauge.fillAmount != fillAmount)
            gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, nowHealth / PlayerStats.maxHealth, Time.deltaTime * 1.0f);

        // 최대 체력 못 넘어가도록 설정
        if (nowHealth > PlayerStats.maxHealth)
            nowHealth = PlayerStats.maxHealth;

        // 만약 죽으면
        if (gauge.fillAmount <= 0)
        {
            Debug.Log("Die");
            LoseUI.SetActive(true);
            
            GetComponent<CharacterController>().enabled = false;
            GetComponent<PlayerShooting>().enabled = false;
        }
    }

    

    public string getHealth(float h)
    {
        /*
            체력에 변화가 갈 시, 함수를 호출하여 변화 실행
            
            인자
            int h : 체력 변화량 / 양수 : 체력 회복, 음수 : 체력 감소

            리턴값
            string "dodge"  : 체력 감소를 회피함
            string "damage" : 체력이 감소됨
            string "heal"   : 체력이 증가함
        */

        if (h < 0) {
            // 회피 확률 실행
            int dodgeRandomNumber = Random.Range(1, 100);

            // 만약 회피 확률 보다 작은 값이 나오면 회피
            if (PlayerStats.dodgeChance >= dodgeRandomNumber) 
                return "dodge";
            else {
                // 큰 값일 경우 방어력을 뺀 데미지가 체력에서 감소
                h += PlayerStats.defensivePower;
                
                nowHealth += (h >= 0) ? 0 : h;
                return "damage";
            }
        }

        // 체력 회복
        nowHealth += h;
        return "heal";
    }
}
