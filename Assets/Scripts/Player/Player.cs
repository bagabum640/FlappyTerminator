using System;
using UnityEngine;

[RequireComponent(typeof(Mover),
                  typeof(PlayerInputReader))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private Mover _mover;
    private PlayerInputReader _input;

    public event Action GameOver;

    private void OnEnable()
    {
        _input.OnForce += HandleForce;
        _input.OnFire += HandleFire;
    }

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _input = GetComponent<PlayerInputReader>();
    }

    public void Die()
    {
        GameOver?.Invoke();
    }

    private void HandleForce()
    {
        _mover.Fly();
    }

    private void HandleFire()
    {
        _weapon.Shoot(transform.right);
    }
}