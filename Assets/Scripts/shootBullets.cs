using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullets : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    [SerializeField] float nextFire;

    private void Start()
    {
        fireRate = 3.0f;
        nextFire = Time.time;
    }

    private void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
