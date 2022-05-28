using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeteor : MonoBehaviour
{
    PlayerHealth playerHealth;
    public float MeteorDamage;
    public Texture[] texture;

    new Renderer renderer;
    void OnEnable()
    {

        MeteorDamage = BossStats.Boss_Meteor_Power;

        Physics.IgnoreLayerCollision(7,7,true);

        
        renderer = GetComponentInChildren<Renderer>();
        int idx = Random.Range(0, texture.Length);
        renderer.material.mainTexture = texture[idx];
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().getHealth(-MeteorDamage); 

            Debug.Log("Meteor Damage");

            
        }

            
    }
    
}
