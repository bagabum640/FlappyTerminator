using UnityEngine;

public class ReleaseDetector : MonoBehaviour
{
    [SerializeField] private EnemyGenerator _enemyGenerator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            _enemyGenerator.Release(enemy);
        }
    }
}