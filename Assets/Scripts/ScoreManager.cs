using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoreDisplay;

    void Update()
    {
        scoreDisplay.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            score++;
        }
    }
}
