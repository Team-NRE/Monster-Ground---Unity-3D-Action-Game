using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemAction : MonoBehaviour
{
    [SerializeField]
    private Text actionText;
    [SerializeField]
    public Inventory theInventory;
    //[SerializeField]
    //public LayerMask layerMask;
    
    private CommonItemDic dic;
    private float textTimer = 5.0f;

    //스플뎀 탬 구현 위한 변수
    public GameObject player;

    //중첩 아이템 구현용
    public static int steamCount = 0;

     

    private void Start()
    {
        actionText.gameObject.SetActive(false);
        //gameObject.GetComponent<DefenceCore>().enabled = false;
        //gameObject.GetComponent<BackPackCannon>().enabled = false;
    }

    private void OnTriggerEnter(Collider coll)
    {
        //패시브 아이템
        if (coll.gameObject.CompareTag("Item"))
        {
            Item nowItem = coll.GetComponent<itemPickUp>().item;

            Debug.Log(coll.gameObject.name);
            //theInventory.AddItem(nowItem);
            PlayerStats.maxHealth += nowItem.MaxHealth;
            PlayerStats.defensivePower += nowItem.DefensivePower;
            PlayerStats.dodgeChance += nowItem.DodgeChance;
            PlayerStats.walkSpeed += nowItem.WalkSpeed;
            PlayerStats.bulletDamage += nowItem.BulletDamage;
            PlayerStats.bulletSpeed += nowItem.BulletSpeed;
            PlayerStats.shotSpeed += nowItem.ShotSpeed;
            PlayerStats.criticalChance += nowItem.CriticalChance;
            PlayerStats.criticalDamage += nowItem.CriticalDamage;
            Destroy(coll.gameObject);
            //ItemInfoAppear();
            Debug.Log("item collision finish");
            //actionText.gameObject.SetActive(false);
            //ItemInfoDisappear();

            if(PlayerStats.defensivePower > 29.9f)
            {
                PlayerStats.defensivePower = 29.9f;
            }

            // 공속 2.7f 최대치 
            if(PlayerStats.shotSpeed > 2.7f)
            {
                PlayerStats.shotSpeed = 2.7f;
            }

            //ExpBullet, SteamPack, DeliMeat 효과 스크립트 발현
            if (coll.gameObject.name == "06. ExplosiveBullet")
            {
                gameObject.GetComponent<PlayerShooting>().isSplash = true;
            }
            else if(coll.gameObject.name == "08. SteamPack")
            {
                gameObject.GetComponent<SteamPack>().enabled = true;
            }
            else if(coll.gameObject.name == "15. DeliMeat")
            {
                gameObject.GetComponent<DeliMeat>().enabled = true;
                DeliMeat.recoverCount++;
            }

            //item info 출력
            int index = coll.gameObject.name.IndexOf("(Clone)");
            //(clone)을 제외하고 출력하기 위한 코드
            if (index > 0)
                actionText.text = coll.gameObject.name.Substring(0, index) + " 을/를 획득!";
            
            //actionText.text = coll.gameObject.name;
            actionText.gameObject.SetActive(true);
        }
        /*
        //액티브 아이템, 스팀팩, 각성제 등등
        else if (coll.gameObject.CompareTag("ActiveItem"))
        {
            Item nowItem = coll.GetComponent<itemPickUp>().item;
            Debug.Log("Active Item Collision");
            theInventory.AddItem(nowItem);

            if (coll.gameObject.name == "06. AdditionalBullet")
                gameObject.GetComponent<AdditionalBullet>().enabled = true;

            else if(coll.gameObject.name=="08. SteamPack")
            {
                steamCount += 1;
                if (gameObject.GetComponent<SteamPack>().enabled == false)
                    gameObject.GetComponent<SteamPack>().enabled = true;
                Debug.Log(steamCount);
            }

            if (coll.gameObject.name == "06. ExplosiceBullet")
                _bullet.GetComponent<ExplosiveBullet>().enabled = true;

            if (coll.gameObject.name == "15. DeliMeat")
            {
                //추가 획득시 중첩 가능하도록 함
                gameObject.GetComponent<DeliMeat>().enabled = true;
                DeliMeat.recoverHealth *= 1;
            }
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag("RocketLauncher"))
        {   
            Item nowItem = coll.GetComponent<itemPickUp>().item;
            theInventory.AddItem(nowItem);
            gameObject.GetComponent<BackPackCannon>().enabled = true;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag("DefenceCore"))
        {
            Item nowItem = coll.GetComponent<itemPickUp>().item;
            theInventory.AddItem(nowItem);
            gameObject.GetComponent<DefenceCore>().enabled = true;
            Destroy(coll.gameObject);
        }*/
    }
    private void Update()
    {
        textTimer -= Time.deltaTime;

        if (textTimer < 0.0f)
        {
            actionText.gameObject.SetActive(false);
            textTimer = 5.0f;
        }
    }
}
