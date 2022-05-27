using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    //시간을 재서 일정 시간이 지나면 탄이 차는 방식
    //우클릭하면 발사시켜야지
    //설계 방향
    //1. 착탄점 주변의 적을 배열에 저장(overlap sphere)
    //2. 일관되게 데미지만 적용

    private Vector3 pos;
    private float radius = 10.0f;
    public LayerMask layerMask;
    private float ExpDamage=100.0f;
    public bool isSplash;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (isSplash == true)
        {
            Collider[] colls = Physics.OverlapSphere(transform.position, radius, layerMask);
            for (int i = 0; i < colls.Length; i++)
            {
                colls[i].GetComponent<Enemy>().getHealth(-ExpDamage);
            }
        }
    }
}
