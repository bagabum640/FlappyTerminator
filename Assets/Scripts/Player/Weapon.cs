using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(
              createFunc: () => Instantiate(_bullet),
              actionOnGet: (bullet) => SetUp(bullet),
              actionOnRelease: (bullet) => ResetBullet(bullet),
              defaultCapacity: _poolCapacity,
              maxSize: _poolMaxSize);
    }

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
        Bullet bullet = _pool.Get();

        bullet.SetDirectionToFly(direction);
    }

    private void SetUp(Bullet bullet)
    {
        bullet.Destroyed += Release;
        bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        bullet.gameObject.SetActive(true);
        bullet.StartDestruction();
    }

    private void ResetBullet(Bullet bullet)
    {
        bullet.Destroyed -= Release;
        bullet.gameObject.SetActive(false);
        bullet.ResetToDefault();
    }

    private void Release(Bullet bullet) =>
        _pool.Release(bullet);
}