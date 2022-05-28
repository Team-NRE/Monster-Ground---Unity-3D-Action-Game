using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    
    PlayerHealth playerHealth;
    public float damage;
    
    void OnEnable()
    {
        damage = BossStats.Boss_Attack_Power;    
    }

    void OnTriggerStay(Collider other) 
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().getHealth(-damage); 
            
            Debug.Log("boss attack");
        }
    }

    
}
