using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region Enemy state
    [Header ("--Health Type")]
    public float Max_HP;
    public float Defensive_Power;

    [Header ("--speed")]
    public float speed_in_NavMeshAgent; 

    [Header ("--Attack Type")]
    public float Attack_Power;
    public float Attack_Speed;

    [Header ("--.etc")]
    public float Experiance;
    #endregion
    
    // component 
    private NavMeshAgent nvAgent;
    private GameObject player;
    private Animation anim;

    // Variable
    private float Now_HP;
    private float Now_Attack_Cooling_Time;
    private bool isDead;

    void Start()
    {
        player  = GameObject.FindGameObjectWithTag("Player");
        nvAgent = GetComponent<NavMeshAgent>();
        anim    = GetComponent<Animation>();

        nvAgent.speed = speed_in_NavMeshAgent;
        Now_HP  = Max_HP;
        Now_Attack_Cooling_Time = Attack_Speed;
        isDead = false;
    }

    void Update()
    {
        if (!isDead) {
            float distance = Vector3.Distance(player.transform.position , transform.position);
            nvAgent.destination = player.transform.position;

            if (Attack_Speed - anim["attack"].length >= Now_Attack_Cooling_Time)
                anim.CrossFade("move");
                nvAgent.isStopped = false;

            if (Now_Attack_Cooling_Time > 0f)
                Now_Attack_Cooling_Time -= Time.deltaTime;
            
            else if(distance <= 5f)
            {
                nvAgent.isStopped = true;
                string result = player.GetComponent<PlayerHealth>().getHealth(-Attack_Power);
                Debug.Log(result);
                
                anim.CrossFade("attack");
                Now_Attack_Cooling_Time = Attack_Speed;
            }

            if (Now_HP <= 0)
            {
                if(QuestControl.IsPortalOpen == true)
                {
                    player.GetComponent<PlayerLevel>().getExperience(0);
                }
                    
                else    
                {
                    player.GetComponent<PlayerLevel>().getExperience(Experiance);
                }

                anim.CrossFade("death");
                nvAgent.destination = transform.position;
                Destroy(gameObject.GetComponent<Collider>());
                Destroy(gameObject, 2);
                isDead = true;
            }
        }
    }
    
    public string getHealth(float h) {
        if (h >= 0) {
            Now_HP += h;
            return "Heal";
        } else {
            h += Defensive_Power;

            Now_HP += (h >= 0) ? 0 : h;
            return "Damage";
        }
    }
}