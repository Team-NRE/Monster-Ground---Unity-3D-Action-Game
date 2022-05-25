using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackCannon : MonoBehaviour
{
    public GameObject missle;
    public Transform playerTr;

    private float launchTime = 5.0f;
    private float launchPower = 50.0f;

    void Start()
    {
        //rot = Quaternion.LookRotation(dirVec.normalized);
    }


    void Update()
    {
        MissleLaunch();
    }
    
    void MissleLaunch()
    {
        launchTime -= Time.deltaTime;
        if (launchTime < 0.0f)
        {
            launchTime = 5.0f;
            Instantiate(missle, new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z), this.transform.rotation);
        }
    }
}
