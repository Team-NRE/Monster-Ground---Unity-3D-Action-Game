using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestControl : MonoBehaviour
{
    public GameObject itemspawner;
    public GameObject[] QuestList;
    public int QuestNumber;

    private int[] QuestCount;

    public static bool IsPortalOpen = false;

    void Start() {
        QuestCount = new int[QuestList.Length];

        questTextChanger();

        IsPortalOpen = false;
    }

    void questTextChanger() {
        for (int i=0; i<QuestList.Length; i++)
            QuestList[i].SetActive((i == QuestNumber) ? true : false);
    }

    void questProcessing() {
        switch (QuestNumber) {
            case 0: //Destroy the Spawner
                if (QuestCount[0] == 4) {
                    QuestNumber = 1;
                    QuestCount[0] = 0;
                    questProcessing();
                }
                else 
                    QuestList[0].transform.Find("Count").GetComponent<Text>().text = QuestCount[0] + " / 4";
                break;
            case 1: //Enter the Center Portal
                if (QuestCount[1] == 1) {
                    QuestNumber = 0;
                    QuestCount[1] = 0;
                } 
                else
                    itemspawner.SetActive(false);
                    GameObject.Find("Portal").transform.GetChild(0).gameObject.SetActive(true);
                    IsPortalOpen = true;
                break;
        }
    }

    public void questConditionCounter(int Count = 0) {
        QuestCount[QuestNumber] += Count;

        questProcessing();
        questTextChanger();
    }
}
