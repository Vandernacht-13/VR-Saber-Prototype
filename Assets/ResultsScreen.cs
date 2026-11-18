
using UnityEngine;
using TMPro;

public class ResultsScreen : MonoBehaviour
{
    public GameObject resultsPanel;

    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highestComboText;

    public ScoreManager scoreManager;
    public AudioSource musicSource;

    public float levelDuration = 90f;

    private bool levelFinished = false;

    void Update()
    {
        // Don't run if the level has already finished
        if (levelFinished)
            return;

        // Make sure the music is assigned
        if (musicSource == null)
            return;

        // Check whether 90 seconds have passed
        if (musicSource.time >= levelDuration)
        {
            ShowResults();
        }
    }

    void ShowResults()
    {
        levelFinished = true;

        // Display the final score and highest combo
        finalScoreText.text =
            "Final Score: " + scoreManager.FinalScore;

        highestComboText.text =
            "Highest Combo: " + scoreManager.HighestCombo;

        // Display the results panel
        scoreManager.scoreText.gameObject.SetActive(false);
        scoreManager.comboText.gameObject.SetActive(false);
        
        resultsPanel.SetActive(true);

        // Stop the music
        musicSource.Stop();
    }
}
