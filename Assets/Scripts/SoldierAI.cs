using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    [SerializeField] public string hitTag;
    [SerializeField] public bool lookingAtPlayer = false;
    [SerializeField] public GameObject theSoldier;
    [SerializeField] public AudioSource fireSound;
    [SerializeField] public bool isFiring = false;
    [SerializeField] public float fireRate = 2.5f;
    [SerializeField] RaycastHit Hit;
    [SerializeField] public ParticleSystem visualFeedbackObject;
    [SerializeField] public Transform endBarrel;

    private void Update()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag;
        }

        if (hitTag == "Player" && isFiring == false)
        {
            StartCoroutine(EnemyFire());
        }

        if (hitTag != "Player")
        {
            theSoldier.GetComponent<Animator>().Play("Idle");

            lookingAtPlayer = false;
        }
    }
    
    IEnumerator EnemyFire()
    {
        isFiring = true;
        theSoldier.GetComponent<Animator>().Play("FirePistol", -1, 0);
        theSoldier.GetComponent<Animator>().Play("FirePistol");

        visualFeedbackObject.transform.position = endBarrel.transform.position;

        visualFeedbackObject.Emit(10);
        fireSound.Play();
        lookingAtPlayer = true;
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}
