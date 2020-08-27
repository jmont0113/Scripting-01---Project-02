using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] GameObject visualFeedbackObject;
    [SerializeField] int weaponDamage = 20;
    [SerializeField] LayerMask hitLayers;

    RaycastHit objectHit;  // Store info about our raycast hit

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    // fire the weapon using a raycast 
    void Shoot()
    {
        // calculate direction to shoot the ray 
        Vector3 rayDirection = cameraController.transform.forward;
        // cast a debug ray 
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.cyan, 1f);
        // do the raycast
        if (Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance, hitLayers))
        {
            // Hit thing DoStuff() code
            Debug.Log("You HIT the " + objectHit.transform.name);

            if (objectHit.transform.tag == "Enemy")
            {
                Debug.Log("DEAL DAMAGE");
                // Visual Feedback
                visualFeedbackObject.transform.position = objectHit.point;
                // Apply damage if it's enemy 
                EnemyShooter enemyShooter = objectHit.transform.gameObject.GetComponent<EnemyShooter>();
                if (enemyShooter != null)
                {
                    enemyShooter.TakeDamage(weaponDamage);
                }
            }
        }
        else
        {
            Debug.Log("Miss.");
        }
    }
}
