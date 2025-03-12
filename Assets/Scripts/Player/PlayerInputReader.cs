using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    private const KeyCode ForceKey = KeyCode.Space;
    private const KeyCode FireButton = KeyCode.Mouse0;

    private bool _isForce;
    private bool _isFire;

    private void Update()
    {
        if(Input.GetKeyDown(ForceKey))
            _isForce = true;

        if(Input.GetKeyDown(FireButton))
            _isFire = true;
    }

    public bool GetIsForce() =>
        GetBoolAsTrigger(ref _isForce);

    public bool GetIsFire() =>
        GetBoolAsTrigger(ref _isFire);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
