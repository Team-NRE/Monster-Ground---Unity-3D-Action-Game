using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//실질적으로 인벤토리와 아이템이 연결되는 유일한 코드
[System.Serializable]//주의사항 이건 그냥 인스펙터에 표시하기 위함임
public class ItemEffect
{
    public string itemName; //아이템의 이름
    public string[] part;   //효과에 대한 내용
    public int[] num;       //포션 하나당 미치는 효과가 여러개일 경우 사용
}

public class effectItem : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;

    private const string HP = "HP", CriticalChance = "CriticalChance", DodgeChance = "DodgeChance", ShootSpeed = "ShootSpeed";

#region EffectTimeField
    private float effectTimeHP = 30.0f;
    private float effectTimeSS = 30.0f;
    private float effectTimeDC = 30.0f;
    private float effectTimeCC = 30.0f;
#endregion
    public void UseItem(Item _item)
    {
        //if (_item.itemType == Item.ItemType.Equip)
        //{
            //로켓런처, 더블 배럴 등을 여기서 취급해야한다.
        //}

        if (_item.itemType == Item.ItemType.Consume)
        {
            for(int i = 0; i < itemEffects.Length; i++)
            {
                if (itemEffects[i].itemName == _item.itemName)
                {
                    for (int j = 0; j < itemEffects[i].part.Length; j++)
                    {
                        if (itemEffects[i].part[j] == HP)
                        {
                            gameObject.GetComponent<PlayerHealth>().getHealth(10);
                        }
                        else if (itemEffects[i].part[j] == CriticalChance)
                        {
                            effectTimeCC -= Time.deltaTime;
                            PlayerStats.criticalChance += 5;
                            Debug.Log(PlayerStats.criticalChance);
                            if (effectTimeCC < 0)
                            {
                                effectTimeCC = 0;
                                PlayerStats.criticalChance -= 5;
                                Debug.Log(effectTimeCC + "\n" +PlayerStats.criticalChance);
                            }
                        }
                        else if (itemEffects[i].itemName == DodgeChance)
                        {
                            effectTimeDC -= Time.deltaTime;
                            PlayerStats.dodgeChance += 5;
                            if (effectTimeDC < 0)
                            {
                                effectTimeDC = 0;
                                PlayerStats.dodgeChance -= 5;
                            }
                        }
                        else if (itemEffects[i].itemName == ShootSpeed)
                        {
                            effectTimeSS -= Time.deltaTime;
                            PlayerStats.shotSpeed += 5;
                            if (effectTimeSS < 0)
                            {
                                effectTimeSS = 0;
                                PlayerStats.shotSpeed -= 5;
                            }
                        }
                    }
                    Debug.Log(_item.itemName + "을 사용했습니다");
                    break;
                }
            }
        } 
        else
            Debug.Log("itemEffect목록에 일치하는 itemName이 없습니다.");
    }
}
