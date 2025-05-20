using System;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    private const KeyCode ForceKey = KeyCode.Space;
    private const KeyCode FireButton = KeyCode.Mouse0;

    public event Action OnForce;
    public event Action OnFire;

    private void Update()
    {
        if (Input.GetKeyDown(ForceKey))        
            OnForce?.Invoke();        

        if (Input.GetKeyDown(FireButton))        
            OnFire?.Invoke();        
    }
}
