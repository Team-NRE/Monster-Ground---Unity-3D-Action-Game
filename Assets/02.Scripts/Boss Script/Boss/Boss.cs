using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Boss : MonoBehaviour
{
    public enum AnimState 
    {
        IDLE, //현재 상태
        DISCOVERY, //발견
        FlyTRACE, //공중 추적
        Attack, //공격
        Meteor, //메테오
        Takeoff, //날기
        
        DIE  //죽음
    }

    //componenet 초기화
    public AnimState state = AnimState.IDLE;
    
    Animator anim;
    NavMeshAgent NavMesh;
    Transform Player;
    Transform boss;
    
    Coroutine co_StopRoutine;
    public Image gauge; 
    
    public GameObject FireFly;
    public GameObject Meteor;
    public GameObject WinUI;
    public GameObject WinText;
    

    

    
    //행동 초기화
    bool isDie = false;
    public bool check = false;

    float AttackDistance = 80.0f; //공격 탐지 거리
    float FlyTrace = 180.0f; //공중 추적 사정거리
    float DiscoveryDistance = 250.0f; //발견 사정거리
    
    public float nowBossHealth;
    public float nowBossDefensive;
    
    //애니메이터 해시값 추출
    readonly int hashDie = Animator.StringToHash("Die");
    
    readonly int hashFlyDisc = Animator.StringToHash("IsFlyStart");
    readonly int hashFlyMove = Animator.StringToHash("IsFlyMove");
    
    readonly int hashAttack = Animator.StringToHash("IsAttack");
    
    readonly int hashFlame = Animator.StringToHash("IsFlame");
    
    readonly int hashTakeoff = Animator.StringToHash("Takeoff");
    readonly int hashFly = Animator.StringToHash("Fly");
    readonly int hashMeteor = Animator.StringToHash("IsMeteor");

    
    

    void Start()
    {
        nowBossHealth = BossStats.Boss_HP;
        nowBossDefensive = BossStats.Boss_Defensive_Power;
        
        anim = GetComponent<Animator>();
        NavMesh = GetComponent<NavMeshAgent>();
        
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        
        FireFly.SetActive(false);
        Meteor.SetActive(false);

        NavMesh.updateRotation = false;

                

        StartCoroutine(CheckBossState());
        co_StopRoutine = StartCoroutine(PlayBossState());
        
    }

    
    IEnumerator CheckBossState() //state 체크
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);
            

            

            float distance = Vector3.Distance(Player.position, boss.position);

            if(nowBossHealth <= 0)
            {
                state = AnimState.DIE;
                yield break;
                
            }

            
            
            if(distance <= AttackDistance) //공격 거리
            {
                state = AnimState.Attack; //공격 시작
                yield return new WaitForSecondsRealtime(10.0f);
                

                state = AnimState.Meteor;
                yield return new WaitForSecondsRealtime(20.0f);
                
                state = AnimState.Takeoff;
                yield return new WaitForSecondsRealtime(3.0f);
                

            }
            
            else if(distance <= FlyTrace) //공중 추적 거리
            {
                
                state = AnimState.FlyTRACE; //공중 추적 시작
            }
            
            else if(distance <= DiscoveryDistance) //Player 발견
            {
                
                state = AnimState.DISCOVERY;
            }
            
            else if(distance > DiscoveryDistance)
            {
                
                state = AnimState.IDLE;  
            }

            
        }


    }

            
    
    IEnumerator PlayBossState()     
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            switch (state)
            {
                case AnimState.IDLE : 
                    nowBossDefensive = PlayerStats.bulletDamage;
                    NavMesh.isStopped = true;
                    
                    anim.SetBool(hashFlyDisc , false);

                    
                    
                    break;

                case AnimState.DISCOVERY :
                    nowBossDefensive = PlayerStats.bulletDamage;

                    NavMesh.isStopped = true;
                    
                    anim.SetBool(hashFlyDisc, true);
                    
                    anim.SetBool(hashFlyMove, false);
                   
                    
                    
                    break;

                case AnimState.FlyTRACE :
                    nowBossDefensive = PlayerStats.bulletDamage - 10;
                    
                    FireFly.SetActive(false);
                    
                    NavMesh.SetDestination(Player.position);
                    NavMesh.isStopped = false;
                    NavMesh.speed = 30.0f;
                    

                    //Animator.attack 으로 가기
                    anim.SetBool(hashFlyMove,true);
                    
                    anim.SetBool(hashFlyDisc,false);
                    anim.SetBool(hashAttack,false);
                    
                    
                    
                    break;

                    
                case AnimState.Attack :
                    //방어력 원래대로
                    nowBossDefensive = 10;
                    
                    FireFly.SetActive(true);
                    Meteor.SetActive(false);
                    
                    //layer 0
                    anim.SetBool(hashAttack,true);
                    anim.SetBool(hashFlyMove,false);
                    
                    //Animator.attack 초기화
                    anim.SetLayerWeight(1,1.0f);

                    NavMesh.SetDestination(Player.position);
                    NavMesh.isStopped = false;
                    NavMesh.speed = PlayerStats.walkSpeed;
                        
                    anim.SetBool(hashFlame,true);
                    
                    //공격패턴 중 보스 사망 시 (코루틴 빠져나가기)
                    if(nowBossHealth <= 0)
                    {
                        StopCoroutine(co_StopRoutine);
                        
                        anim.SetTrigger(hashDie);
                        
                        GetComponent<CapsuleCollider>().enabled = false;
                    
                        FireFly.SetActive(false);
                        Meteor.SetActive(false);


                        NavMesh.isStopped = true;
                        isDie = true;
                    }
                    
                    break;
                    
                case AnimState.Takeoff :
                {
                    anim.SetTrigger(hashTakeoff);
                    anim.SetBool(hashMeteor,false);

                    yield return new WaitForSeconds(2.0f);
                    anim.SetTrigger(hashFly);

                    break;
                }

                case AnimState.Meteor :
                {
                    //방어력 증가
                    nowBossDefensive = PlayerStats.bulletDamage - 10 ;
                    
                    FireFly.SetActive(false);
                    
                    NavMesh.isStopped = true;

                    anim.SetBool(hashMeteor,true);
                    anim.SetBool(hashFlame,false);
                    
                    yield return new WaitForSeconds(1.0f);
                    Meteor.SetActive(true);
                    
                    break;
                }

                case AnimState.DIE :
                {    
                    anim.SetTrigger(hashDie);
                    
                    
                    GetComponent<CapsuleCollider>().enabled = false;
                    
                    FireFly.SetActive(false);
                    Meteor.SetActive(false);

                    
                    NavMesh.isStopped = true;
                    isDie = true;


                    break;
                }        
                    
            }
            
            yield return new WaitForSeconds(0.3f);
            
        }
    }
    
    

    private void Update() {
        
        //보스 피 달기
        float fillAmount = nowBossHealth / BossStats.Boss_HP;

        if(gauge.fillAmount != fillAmount)
        {
            gauge.fillAmount = Mathf.Lerp(gauge.fillAmount, nowBossHealth / BossStats.Boss_HP, Time.deltaTime*1.0f);
        }

        //보스 회전
        if(NavMesh.remainingDistance > 2.0f)
        {
            Vector3 direction = NavMesh.desiredVelocity;
            Quaternion rot =Quaternion.LookRotation(direction);
            boss.rotation = Quaternion.Slerp(boss.rotation, rot,Time.deltaTime * 12.0f);
        }

        //보스 죽으면 게이트 생성
        if(isDie == true)
        {
            if(check == true)
            {
                WinUI.SetActive(false);
            }
            
            else if (check == false)
            {
                WinUI.SetActive(true);
            }

            StartCoroutine(Win());
        }
    }
    
    
    
    IEnumerator Win()
    {
        yield return new WaitForSeconds(10.0f);

        WinUI.SetActive(false);
        WinText.SetActive(true);

        check = true;
    }

    public void getHealth(float h) 
    {
        h += nowBossDefensive;
        
        if(h > 0)
        {
            Debug.Log("Miss");
        }
        
        else if (h <= 0)
        {    
            nowBossHealth += h;

            Debug.Log("Damage");
        }
    }   
}

