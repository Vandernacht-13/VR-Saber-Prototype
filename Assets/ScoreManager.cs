
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Text displayed in the VR environment
    public TextMeshProUGUI scoreText;

    // Total number of successful hits
    private int hits = 0;

    void Start()
    {
        UpdateHitDisplay();
    }

    // Called when the saber hits a cube
    public void AddPoints(int points)
    {
        hits += points;
        UpdateHitDisplay();
    }

    // Update the world-space hit counter
    void UpdateHitDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Hits: " + hits;
        }
    }
}
