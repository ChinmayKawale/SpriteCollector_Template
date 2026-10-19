using UnityEngine;
using TMPro;

// Put this on an empty GameObject called "GameManager".
// Drag your score text into the Score Text slot in the Inspector.
public class ScoreKeeper : MonoBehaviour
{
    // Lets any other script find this one. Set up before anything else runs.
    public static ScoreKeeper instance;

    [Header("Drag the score text here")]
    public TextMeshProUGUI scoreText;

    [Header("Shown when everything is collected (optional)")]
    public GameObject wellDoneMessage;

    private int score = 0;
    private int totalToCollect = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (wellDoneMessage != null)
        {
            wellDoneMessage.SetActive(false);
        }

        UpdateText();
    }

    // Each collectible calls this when the game starts, so we know how many there are.
    public void Register()
    {
        totalToCollect = totalToCollect + 1;
        UpdateText();
    }

    public void AddPoints(int amount)
    {
        score = score + amount;
        UpdateText();

        // Have we got them all?
        if (score >= totalToCollect && wellDoneMessage != null)
        {
            wellDoneMessage.SetActive(true);
        }
    }

    void UpdateText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score + " / " + totalToCollect;
        }
    }
}
