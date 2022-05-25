using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // 오브젝트와 이 스크립트에서 사용하는 함수
    public GameObject Bullet;   // 총알 프리펩
    private GameObject FirePosition;    // 총알 발사 위치 오브젝트
    private Transform FirePoint;    // 총알 발사 위치 컴포넌트
    private float coolingTime;  // 발사 쿨타임 체크용

    void Start()
    {
        // 기본 값 설정
        FirePosition = GameObject.Find("FirePos").gameObject;
        FirePoint = FirePosition.GetComponent<Transform>();
        coolingTime = PlayerStats.shotSpeed;
    }

    void Update()
    {
        // 쿨타임이 발사 속도보다 작을 시 시간을 더해줌
        if (coolingTime < PlayerStats.shotSpeed)
            coolingTime += Time.deltaTime;

        if (Input.GetMouseButton(0))    // 마우스 좌클릭
        {
            if (coolingTime >= PlayerStats.shotSpeed)   // 총알 발사 가능 상태
            {
                // 총알 오브젝트 소환
                GameObject bullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation) as GameObject;
                
                // 총알 기본 스텟 오브젝트로 옮김
                Bullet bulletStats = bullet.GetComponent<Bullet>();
                bulletStats.Damage = PlayerStats.bulletDamage;  // 총알 공격력
                bulletStats.Speed = PlayerStats.bulletSpeed;    // 총알 속도
                bulletStats.criticalChance = PlayerStats.criticalChance;    // 크리티컬 확률
                bulletStats.criticalDamage = PlayerStats.criticalDamage;    // 크리티컬 데미지

                // 쿨타임 초기화
                coolingTime = 0;
            }
        }
    }
}
