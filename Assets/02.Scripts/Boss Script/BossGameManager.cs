using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameManager : MonoBehaviour
{
    public GameObject Boss_HP;
    public GameObject Gotiteminfo;
    public GameObject Quest;
    public GameObject player;
    

    void Start()
    {
        Boss_HP.SetActive(true);
        Gotiteminfo.SetActive(false);
        Quest.SetActive(false);

        player.GetComponent<itemAction>().enabled = false;
    }
        

    
}
