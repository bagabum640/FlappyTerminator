using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _lifetime = 0.7f;

    private Rigidbody2D _rigidbody;
    private WaitForSeconds _wait;

    public event Action<Bullet> Destroyed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();       

        _wait = new(_lifetime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            Destroyed?.Invoke(this);
        }
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return _wait;

        Destroyed?.Invoke(this);
    }

    public void StartDestruction()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    public void SetDirectionToFly(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _speed,ForceMode2D.Impulse);
    }

    public void ResetToDefault()
    {
        _rigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}