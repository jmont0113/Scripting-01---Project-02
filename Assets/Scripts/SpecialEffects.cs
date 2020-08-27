using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour
{

    [SerializeField] public AudioSource hurtSound;
    [SerializeField] public GameObject hurtFlash;

    float moreCountTime = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            StartCoroutine(moreTime());
        }
    }

    IEnumerator moreTime()
    {
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(moreCountTime);
        hurtSound.Play();
        hurtFlash.SetActive(false);
    }
}
