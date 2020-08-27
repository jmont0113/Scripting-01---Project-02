using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody rb;

    PlayerController target;

    Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth.healthValue -= 5;
            Destroy(gameObject);
        }
    }

}