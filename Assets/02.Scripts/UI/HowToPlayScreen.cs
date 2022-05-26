using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScreen : MonoBehaviour
{
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            gameObject.SetActive(false);
        }

        if (Input.anyKeyDown) {
            gameObject.SetActive(false);
        }
    }
}
