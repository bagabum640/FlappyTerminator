using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private Text _score;

    private void Awake()
    {
        _score = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += ScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= ScoreChanged;
    }

    private void ScoreChanged(int value)
    {
        _score.text = value.ToString();
    }
}