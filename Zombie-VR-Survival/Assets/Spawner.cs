using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float timer;
    float time;


    // Update is called once per frame
    void Update()
    {
        if (time <= 0){
            Instantiate(enemy, transform.position, Quaternion.identity);
            time = timer;
        }

        time -= Time.deltaTime;

        
    }
}
