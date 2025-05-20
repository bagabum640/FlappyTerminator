using System.Collections;
using UnityEngine;

public class EnemyGenerator : Spawner<Enemy>
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

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
    }

    private void Spawn()
    {
        float spawnPostionY = Random.Range(_lowerBound, _upperBound);
        Vector2 spawnPoint = new(transform.position.x, spawnPostionY);

        Enemy enemy = Pool.Get();
        enemy.transform.position = spawnPoint;            
        enemy.Fire();
    }

    protected override void SetUp(Enemy enemy)
    {
        base.SetUp(enemy);
        enemy.Destroyed += HandleEnemyDeath;
    }

    protected override void ResetObject(Enemy enemy)
    {
        base.ResetObject(enemy);
        enemy.Destroyed -= HandleEnemyDeath;
    }
}