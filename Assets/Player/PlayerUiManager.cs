using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUiManager : MonoBehaviour
{
    public GameObject CMCamera;
    private void Awake()
    {
        CursorLockState(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            CursorLockState(false);
        }

        if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical"))) > 0.1)
        {
            CursorLockState(true);
        }
    }

    public void CursorLockState(bool state)
    {
        switch (state)
        {
            case true:
                Cursor.lockState = CursorLockMode.Locked;
                CMCamera.SetActive(true);
                break;
            case false:
                Cursor.lockState = CursorLockMode.None;
                CMCamera.SetActive(false);
                break;
        }
    }
}
