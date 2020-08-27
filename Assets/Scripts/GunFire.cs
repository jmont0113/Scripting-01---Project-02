using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public float targetDistance;
    public int damageAmount = 5;
    public AudioSource gettingShotSound;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(FiringShots());
        }
    }

    IEnumerator FiringShots()
    {
        RaycastHit theShoot;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShoot))
        {
            targetDistance = theShoot.distance;
            theShoot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }

        gettingShotSound.Play();
        yield return new WaitForSeconds(0.25f);
    }
}
