using System;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    
    private void Awake()
    {
        PlayerBehaviour.OnScoreChanged += ChangeScore;

    }

    private void OnDestroy()
    {
        PlayerBehaviour.OnScoreChanged -= ChangeScore;
    }

    private void ChangeScore(int score)
    {
        scoreText.text = $"{score}";
    }
}
