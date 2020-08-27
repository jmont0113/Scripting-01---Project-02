using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    int health = 100;

    public void TakeDamage(int _damageToTake)
    {
        health -= _damageToTake;
        Debug.Log(health + " health remaining");

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
