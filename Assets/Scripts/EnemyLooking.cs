using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLooking : MonoBehaviour
{
    public Transform thePlayer;

    void Update()
    {
        transform.LookAt(thePlayer);
    }
}
