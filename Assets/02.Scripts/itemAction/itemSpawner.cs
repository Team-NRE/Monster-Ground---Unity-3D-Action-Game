using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    #region itemField
    public GameObject item0;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    public GameObject item7;
    public GameObject item8;
    public GameObject item9;
    public GameObject item10;
    public GameObject item11;
    public GameObject item12;
    public GameObject item13;
    public GameObject item14;
    public GameObject item15;
    public GameObject item16;
    public GameObject item17;
    #endregion

    private float maxTime = 10.0f;

    private void Start()
    {
        ItemSpawners();
    }

    private void Update()
    {
        //1분에 한번씩 아이템을 출력
        maxTime -= Time.deltaTime;        

        //Debug.Log(maxTime);
        if (maxTime < 0.0f)
        {
            Debug.Log("item Spawned");
            maxTime = 5.0f;
            ItemSpawners();
        }
    }

    //특정 아이템들은 한번 생성되면 다시는 생성되지 않도록 해야함
    private void ItemSpawners()
    {
        //Transform[] itemSpawnPoint = GameObject.Find("itemSpawnPoints").GetComponentsInChildren<Transform>();
        float rangex = Random.Range(0, 15);
        float rangey = 0.0f;
        float rangez = Random.Range(0, 15);
        Vector3 RandomPosition = new Vector3(rangex, rangey, rangez);
        Quaternion prepQuat = new Quaternion(0, 0, 0, 0);
        Vector3 sptr = RandomPosition;

        //int idTrans = Random.Range(1, itemSpawnPoint.Length);
        int itemId = Random.Range(0, 19);
        int itemProb = Random.Range(0, 100);

        //에픽급 스폰
        if (itemProb < 2)
        {
            if (itemProb == 0)//백팩캐논
                Instantiate(item9, RandomPosition, prepQuat);
            else if (itemProb == 1)//방어핵
                Instantiate(item17, RandomPosition, prepQuat);
        }

            //레어급 스폰
        if (itemProb < 8 && itemProb >= 2)
        {
            if (itemProb == 2)
                Instantiate(item6, RandomPosition, prepQuat);
            else if (itemProb == 3)
                Instantiate(item7, RandomPosition, prepQuat);
            else if (itemProb == 4)
                Instantiate(item8, RandomPosition, prepQuat);
            else if (itemProb == 5)
                Instantiate(item15, RandomPosition, prepQuat);
            else if (itemProb == 6)
                Instantiate(item16, RandomPosition, prepQuat);
            else if (itemProb == 7)
                Instantiate(item17, RandomPosition, prepQuat);
        }

        //일반급 스폰
        if(itemProb >=8 && itemProb < 100)
        {
            if (itemProb == 8)
                Instantiate(item0, RandomPosition, prepQuat);
            else if (itemProb == 9)
                Instantiate(item1, RandomPosition, prepQuat);
            else if (itemProb == 10)
                Instantiate(item2, RandomPosition, prepQuat);
            else if (itemProb == 11)
                Instantiate(item3, RandomPosition, prepQuat);
            else if (itemProb == 12)
                Instantiate(item4, RandomPosition, prepQuat);
            else if (itemProb == 13)
                Instantiate(item5, RandomPosition, prepQuat);
            else if (itemProb == 14)
                Instantiate(item10, RandomPosition, prepQuat);
            else if (itemProb == 15)
                Instantiate(item11, RandomPosition, prepQuat);
            else if (itemProb == 16)
                Instantiate(item12, RandomPosition, prepQuat);
            else if (itemProb == 17)
                Instantiate(item13, RandomPosition, prepQuat);
            else if (itemProb == 18)
                Instantiate(item14, RandomPosition, prepQuat);
        }

        /*
        if (itemId == 0)
        {
            Instantiate(item0, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 1)
        {
            Instantiate(item1, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 2)
        {
            Instantiate(item2, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 3)
        {
            Instantiate(item3, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 4)
        {
            Instantiate(item4, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 5)
        {
            Instantiate(item5, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 6)
        {
            Instantiate(item6, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 7)
        {
            Instantiate(item7, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 8)
        {
            Instantiate(item8, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 9)
        {
            Instantiate(item9, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 10)
        {
            Instantiate(item10, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 11)
        {
            Instantiate(item11, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 12)
        {
            Instantiate(item12, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 13)
        {
            Instantiate(item13, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 14)//레어
        {
            Instantiate(item14, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 15)//레어
        {
            Instantiate(item15, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 16)//레어
        {
            Instantiate(item16, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        else if (itemId == 17)// 방어핵 아이템
        {
            Instantiate(item17, itemSpawnPoint[idTrans].position, itemSpawnPoint[idTrans].rotation);
        }
        */
    }
}
