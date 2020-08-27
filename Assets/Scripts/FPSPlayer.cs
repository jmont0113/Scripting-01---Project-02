using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    [SerializeField] float rayDistance = 10f;
    [SerializeField] float debugRayDuration = 1f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            DebugRay();
            ShootRay();
        }
    }

    void DebugRay()
    {
        Vector3 endPoint = transform.forward * rayDistance;
        Debug.DrawRay(transform.position, endPoint, Color.green, debugRayDuration);
    }

    void ShootRay()
    {
        if(Physics.Raycast(transform.position, transform.forward, rayDistance))
        {
            Debug.Log("Hit something!");
            //Apply Damage
            //Trigger object's animation
        }
        else
        {
            Debug.Log("MISS");
        }
    }
}
