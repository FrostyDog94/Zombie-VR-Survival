using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliders : MonoBehaviour
{
    public Collider col1;
    public Collider col2;
    public Collider playerCol;

    void Start()
    {
        Physics.IgnoreCollision(col1, playerCol);
        Physics.IgnoreCollision(col2, playerCol);
    }
}
