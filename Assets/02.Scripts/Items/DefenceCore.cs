using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceCore : MonoBehaviour
{
    public GameObject coreShield;
    private float rotSpeed = 100.0f;

    void Start()
    {
        Instantiate(coreShield, this.transform.position, this.transform.rotation);
    }

    void Update()
    {
        coreShield.transform.Rotate(new Vector3(2, rotSpeed * Time.deltaTime, 2));
    }
}
