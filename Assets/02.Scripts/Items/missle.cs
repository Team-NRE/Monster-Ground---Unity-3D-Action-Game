using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    private float dis;
    private float speed;
    private float waitTime;
    private float missleDamage = 100.0f;

    public Transform Tr;
    public Transform targetTr1;
    private Enemy _enemy;

    void Start()
    {
        dis = Vector3.Distance(Tr.position, targetTr1.position);
        transform.rotation = Quaternion.LookRotation(this.transform.position - targetTr1.transform.position);
    }

    void Update()
    {
        MissleMove();
        Destroy(this.gameObject, 2.0f);
    }

    private void MissleMove()
    {
        if (targetTr1 == null) return;
        waitTime += Time.deltaTime;
        if (waitTime < 1.5f)
        {
            speed += Time.deltaTime;
            transform.Translate(Tr.forward * speed, Space.World);
        }
        else
        {
            speed += Time.deltaTime;
            float t = speed / dis;

            Tr.position = Vector3.LerpUnclamped(Tr.position, targetTr1.position, t);
        }
        Vector3 directionVec = targetTr1.position - Tr.position;
        Quaternion qua = Quaternion.LookRotation(directionVec);
        Tr.rotation = Quaternion.Slerp(Tr.rotation, qua, Time.deltaTime * 2f);

        Destroy(this.gameObject, 2.0f);
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //몬스터에만 데미지 들어가도록 함
            coll.gameObject.GetComponent<Enemy>().getHealth(-missleDamage);
            Debug.Log(coll.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}