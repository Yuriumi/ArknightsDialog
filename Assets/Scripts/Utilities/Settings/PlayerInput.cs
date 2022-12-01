using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float AxesX => Input.GetAxisRaw("Horizontal");
    public bool IsMove => !Mathf.Approximately(AxesX,0);
    public bool Jump => Input.GetKeyDown(KeyCode.Space);
    public bool StopJump => Input.GetKeyUp(KeyCode.Space);
    public bool Interact => Input.GetKeyDown(KeyCode.F);
    public bool MouseLeftClick => Input.GetMouseButtonDown(0);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
