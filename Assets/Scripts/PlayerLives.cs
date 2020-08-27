using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public GameObject lifeDisplay;
    public static int lifeValue = 3;
    public int internalLife;

    void Update()
    {
        internalLife = lifeValue;
        lifeDisplay.GetComponent<Text>().text = "" + lifeValue;
    }
}
