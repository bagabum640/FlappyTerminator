using System.Collections;
using UnityEngine;

public class Weapon : Spawner<Bullet>
{
    [SerializeField] private Transform _firePoint;

    private IEnumerator ShootCoroutine(Vector2 direction, float delay)
    {
        WaitForSeconds wait = new(delay);

        while (enabled)
        {
            Shoot(direction);

            yield return wait;
        }
    }

    public void StartShooting(Vector2 direction, float delay)
    {
        StartCoroutine(ShootCoroutine(direction, delay));
    }

    public void Shoot(Vector2 direction)
    {
        Bullet bullet = Pool.Get();

        bullet.SetDirectionToFly(direction);
    }

    protected override void SetUp(Bullet bullet)
    {
        base.SetUp(bullet);
        bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        bullet.StartDestruction();
    }

    protected override void ResetObject(Bullet bullet)
    {
        base.ResetObject(bullet);
        bullet.ResetToDefault();
    }
}