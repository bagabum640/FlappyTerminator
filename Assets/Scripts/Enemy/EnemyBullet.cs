using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {}
    }
}