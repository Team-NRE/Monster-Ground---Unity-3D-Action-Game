using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string tagOfShooting;    // 발사한 사람의 태그
    public float Damage;            // 총알 공격력
    public float Speed;             // 총알 속도
    public int criticalChance;      // 크리티컬 확률
    public float criticalDamage;      // 크리티컬 데미지

    public GameObject effect;

    
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed);
        Destroy(gameObject, 5.0f);
    }

    void OnCollisionEnter(Collision other) {
        var contact = other.GetContact(0);

        var obj = Instantiate(effect,
                            contact.point,
                            Quaternion.LookRotation(-contact.normal));

        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag != tagOfShooting) {
            int criticalRandomNumber = Random.Range(1, 100);
            float damageResult = -Damage * ((criticalChance >= criticalRandomNumber) ? (criticalDamage / 100f) : 1f);
            
            switch (other.gameObject.tag) {
                case "Enemy":
                    other.gameObject.GetComponent<Enemy>().getHealth(damageResult);
                    break;
                case "Spawner":
                    other.gameObject.GetComponent<EnemySpPoint>().getHealth(damageResult);
                    break;
                case "Wall":
                    
                    break;

                case "Boss":
                    other.gameObject.GetComponent<Boss>().getHealth(damageResult);
                    break;
                
                default:
                    break;
            }
        }

        Destroy(gameObject);
    }
}
