using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    #region itemField
    public GameObject[] itemEpic;
    public GameObject[] itemRare;
    public GameObject[] itemCommon;
    public GameObject blueLight;
    #endregion

    private float maxTime = 30.0f;
    private float nowTime = 0;

    private void Start()
    {
        nowTime = maxTime;
    }

    private void Update()
    {
        //1분에 한번씩 아이템을 출력
        nowTime -= Time.deltaTime;        

        //Debug.Log(maxTime);
        if (nowTime < 0.0f)
        {
            Debug.Log("item Spawned");
            nowTime = maxTime;
            ItemSpawners();
        }


    }

    //특정 아이템들은 한번 생성되면 다시는 생성되지 않도록 해야함
    public void ItemSpawners()
    {
        //Transform[] itemSpawnPoint = GameObject.Find("itemSpawnPoints").GetComponentsInChildren<Transform>();
        Vector3 RandomPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
        Quaternion prepQuat = new Quaternion(0, 0, 0, 0);
        GameObject item;

        int itemProb = Random.Range(0, 100);

        //Prob 5, 25, 70

        if (itemProb < 5) {
            // Epic
            int itemIdx = Random.Range(0, itemEpic.Length);
            item = Instantiate(itemEpic[itemIdx], RandomPosition, prepQuat);
        } else if (itemProb < 25) {
            // Rare
            int itemIdx = Random.Range(0, itemRare.Length);
            item = Instantiate(itemRare[itemIdx], RandomPosition, prepQuat);
        } else {
            // Common
            int itemIdx = Random.Range(0, itemCommon.Length);
            item = Instantiate(itemCommon[itemIdx], RandomPosition, prepQuat);
        }

        GameObject itemLight =  Instantiate(blueLight, new Vector3(0, 2f, 0), prepQuat);

        itemLight.transform.SetParent(item.transform, false);
    }
}
