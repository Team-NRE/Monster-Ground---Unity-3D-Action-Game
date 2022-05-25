using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNextFloor : MonoBehaviour
{
    public Transform PlayerTransform;

    void Start() {
        PlayerTransform = GameObject.Find("Player").transform;
    }

    void FixedUpdate() {
        float distance = Vector3.Distance(PlayerTransform.position, transform.position);

        if (distance <= 7.5f && distance != 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
