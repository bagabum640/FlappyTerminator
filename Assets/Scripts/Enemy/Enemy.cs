using System;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class Enemy : MonoBehaviour, IObject<Enemy>
{
    [SerializeField] private float _shootDelay = 1f;

    private Weapon _weapon;

    public event Action<Enemy> Destroyed;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
    }

    public void Fire()
    {
        _weapon.StartShooting(-transform.right, _shootDelay);
    }

    public void Die()
    {
        Destroyed?.Invoke(this);
    }
}