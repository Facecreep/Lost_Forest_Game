using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Action<float> PlayerMove;
    public static Action PlayerJump;
    public static Action Fire;
    
    public static Action Interact;

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
            Interact?.Invoke();
        
        PlayerMove?.Invoke(Input.GetAxisRaw("Horizontal"));
        PlayerJump?.Invoke();

        if(Input.GetButtonDown("Fire1"))
            Fire?.Invoke();
    }
}
