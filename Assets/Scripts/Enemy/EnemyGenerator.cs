using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
              createFunc: () => Instantiate(_prefab,transform.position,Quaternion.identity),
              actionOnGet: (enemy) => SetUp(enemy),
              actionOnRelease: (enemy) => ResetEnemy(enemy),
              defaultCapacity: _poolCapacity,
              maxSize: _poolMaxSize);
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    private IEnumerator GenerateEnemy()
    {
        WaitForSeconds waitForSeconds = new(_delay);

        while (enabled)
        {
            Spawn();
            yield return waitForSeconds;
        }
    }

    public void HandleEnemyDeath(Enemy enemy)
    {
        _scoreCounter.Add();
        Release(enemy);
    }

    public void Release(Enemy enemy)
    {
        _pool.Release(enemy);
    }

    private void Spawn()
    {
        float spawnPostionY = Random.Range(_lowerBound, _upperBound);
        Vector2 spawnPoint = new(transform.position.x, spawnPostionY);

        Enemy enemy = _pool.Get();
        enemy.transform.position = spawnPoint;            
        enemy.Fire();
    }

    private void SetUp(Enemy enemy)
    {
        enemy.Destroyed += HandleEnemyDeath;
        enemy.gameObject.SetActive(true);
    }

    private void ResetEnemy(Enemy enemy)
    {
        enemy.Destroyed -= HandleEnemyDeath;
        enemy.gameObject.SetActive(false);
    }
}