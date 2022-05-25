using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpPoint : MonoBehaviour
{
    public float SP_Health = 300;
    public float SP_CoolingTime = 3.0f;
    private float nowHealth;
    
    public GameObject Enemy_prefab;
    public Image HealthGauge;
    GameObject sp1;
    QuestControl questControl;
    
    void Start()
    {
        nowHealth = SP_Health;
        questControl = GameObject.Find("UserUI").GetComponent<QuestControl>();
        StartCoroutine("StartCor");
    }

    void FixedUpdate() {
        if(HealthGauge.fillAmount <= 0.01f)
        {
            questControl.questConditionCounter(1);
            Destroy(gameObject);
        }

        float fillAmount = nowHealth / SP_Health;

        if (HealthGauge.fillAmount != fillAmount)
            HealthGauge.fillAmount = Mathf.Lerp(HealthGauge.fillAmount, nowHealth / SP_Health, Time.deltaTime * 1.0f);
    }

    IEnumerator StartCor()
    {
        while(true){
            Prefab_Spon();
            
            yield return new WaitForSecondsRealtime(SP_CoolingTime); 
        }
             
    }

    void Prefab_Spon()
    {
        GameObject sp1 =  Instantiate(Enemy_prefab);
        sp1.transform.position = transform.position;
        sp1.transform.rotation = transform.rotation;
    }

    public void getHealth(float h) {
        nowHealth += h;
    }
}
