using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonItemDic : MonoBehaviour
{
    Dictionary<int, Item> itemMap;

    private void Start()
    {
        itemMap = new Dictionary<int, Item>();
        // id는 첨부된 엑셀파일을 참조할 것

        //롱소드
        itemMap.Add(0, new Item(
            //public float MaxHealth;
            //public float DefensivePower;
            //public int DodgeChance;
            //public float WalkSpeed;
            //public float BulletDamage;
            //public float BulletSpeed;
            //public float ShotSpeed;
            //public float CriticalDamage;
            //public float CriticalChance;
            0,
            0,
            0,
            0,
            1,
            0,
            0,
            0,
            0
        ));
        //검투사의 채찍
        itemMap.Add(1, new Item(
            //public float MaxHealth;
            //public float DefensivePower;
            //public int DodgeChance;
            //public float WalkSpeed;
            //public float BulletDamage;
            //public float BulletSpeed;
            //public float ShotSpeed;
            //public float CriticalDamage;
            //public float CriticalChance;
            0,
            0,
            0,
            0,
            1,
            0,
            0,
            0,
            0
        ));
        //아파보이는 쇠붙이
        itemMap.Add(2, new Item(
            //public float MaxHealth;
            //public float DefensivePower;
            //public int DodgeChance;
            //public float WalkSpeed;
            //public float BulletDamage;
            //public float BulletSpeed;
            //public float ShotSpeed;
            //public float CriticalDamage;
            //public float CriticalChance;
            0,
            0,
            0,
            0,
            1,
            0,
            0,
            0,
            0
        ));
        //철갑탄
        itemMap.Add(3, new Item(
            //public float MaxHealth;
            //public float DefensivePower;
            //public int DodgeChance;
            //public float WalkSpeed;
            //public float BulletDamage;
            //public float BulletSpeed;
            //public float ShotSpeed;
            //public float CriticalDamage;
            //public float CriticalChance;
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            1
        ));
        //(소주)병
        itemMap.Add(4, new Item(
            //public float MaxHealth;
            //public float DefensivePower;
            //public int DodgeChance;
            //public float WalkSpeed;
            //public float BulletDamage;
            //public float BulletSpeed;
            //public float ShotSpeed;
            //public float CriticalDamage;
            //public float CriticalChance;
            0,
            0,
            0,
            0,
            1,
            0,
            0,
            0,
            0
        ));
        //여기부터 방어탬
        //판떼기
        itemMap.Add(5, new Item(
            //public float MaxHealth;
            //public float DefensivePower;
            //public int DodgeChance;
            //public float WalkSpeed;
            //public float BulletDamage;
            //public float BulletSpeed;
            //public float ShotSpeed;
            //public float CriticalDamage;
            //public float CriticalChance;
            0,
            1,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        ));
        //방패
        itemMap.Add(6, new Item(
            //public float MaxHealth;
            //public float DefensivePower;
            //public int DodgeChance;
            //public float WalkSpeed;
            //public float BulletDamage;
            //public float BulletSpeed;
            //public float ShotSpeed;
            //public float CriticalDamage;
            //public float CriticalChance;
            0,
            1,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        ));

        //연장
        itemMap.Add(6, new Item(
            //public float MaxHealth;
            //public float DefensivePower;
            //public int DodgeChance;
            //public float WalkSpeed;
            //public float BulletDamage;
            //public float BulletSpeed;
            //public float ShotSpeed;
            //public float CriticalDamage;
            //public float CriticalChance;
            0,
            1,
            0,
            0,
            1,
            0,
            0,
            0,
            0
        ));

        //고기
        itemMap.Add(7, new Item(
    //public float MaxHealth;
    //public float DefensivePower;
    //public int DodgeChance;
    //public float WalkSpeed;
    //public float BulletDamage;
    //public float BulletSpeed;
    //public float ShotSpeed;
    //public float CriticalDamage;
    //public float CriticalChance;
    10,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0
    ));

        //맛있어보이는 고기
        itemMap.Add(8, new Item(
//public float MaxHealth;
//public float DefensivePower;
//public int DodgeChance;
//public float WalkSpeed;
//public float BulletDamage;
//public float BulletSpeed;
//public float ShotSpeed;
//public float CriticalDamage;
//public float CriticalChance;
0,
20,
0,
0,
0,
0,
0,
0,
0
));
        //방탄 헬멧
        itemMap.Add(9, new Item(
//public float MaxHealth;
//public float DefensivePower;
//public int DodgeChance;
//public float WalkSpeed;
//public float BulletDamage;
//public float BulletSpeed;
//public float ShotSpeed;
//public float CriticalDamage;
//public float CriticalChance;
10,
2,
0,
0,
0,
0,
0,
0,
0
));
        //방어핵
        itemMap.Add(10, new Item(
//public float MaxHealth;
//public float DefensivePower;
//public int DodgeChance;
//public float WalkSpeed;
//public float BulletDamage;
//public float BulletSpeed;
//public float ShotSpeed;
//public float CriticalDamage;
//public float CriticalChance;
0,
10,
5,
0,
0,
0,
0,
0,
0
));
        //여기에 없는 아이템
        //폭발성 탄환, 더블배럴, 백팩 캐논, 엄폐박스, 각성제

    }
}
