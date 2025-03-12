using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parallax : MonoBehaviour
{
    private const float MaxParallaxStrengthValue = 1;

    [SerializeField] private Camera _camera;
    [SerializeField,Range(0, MaxParallaxStrengthValue)] private float _parallaStrength;

    private float _length;
    private Vector2 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float currentPosition = (_camera.transform.position.x * (MaxParallaxStrengthValue - _parallaStrength));
        float distance = (_camera.transform.position.x * _parallaStrength);

        transform.position = new Vector3(_startPosition.x + distance, transform.position.y, transform.position.z);

        if (currentPosition > _startPosition.x + _length)
            _startPosition.x += _length;
        else if(currentPosition < _startPosition.x - _length)
            _startPosition.x -= _length;
    }

    public void Reset()
    {
        transform.position = _startPosition;
    }
}