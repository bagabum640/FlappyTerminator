using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) || collision.TryGetComponent(out Bound _) || collision.TryGetComponent(out EnemyBullet _))
        {
            GameOver?.Invoke();
        }
    }
}