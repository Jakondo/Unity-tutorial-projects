using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float timer = 0;
    private float thisTime = 0.5f;

    public GameObject dogPrefab;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetKey(KeyCode.Space) && timer > thisTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timer = 0;
        }
    }
}
