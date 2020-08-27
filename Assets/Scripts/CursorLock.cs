using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] bool isShowing = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        //Press the escape bar to apply no locking to the Cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isShowing == false)
            {
                pauseMenu.SetActive(true);
                isShowing = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                isShowing = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                lockingCursorLocking();
                Time.timeScale = 1;
            }
        }
    }

    public void lockingCursorLocking()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void unlockingCursorLocking()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void unfreezeTime()
    {
        Time.timeScale = 1;
    }
}