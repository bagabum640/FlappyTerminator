using UnityEngine;

[RequireComponent(typeof(Mover),
                  typeof(PlayerInputReader))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private Mover _mover;
    private PlayerInputReader _input;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _input = GetComponent<PlayerInputReader>();
    }

    private void FixedUpdate()
    {
        if (_input.GetIsForce())
            _mover.Fly();

        if(_input.GetIsFire())
            _weapon.Shoot(transform.right);
    }
}