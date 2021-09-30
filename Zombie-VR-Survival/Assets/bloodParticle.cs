using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodParticle : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 2);
    }
}
