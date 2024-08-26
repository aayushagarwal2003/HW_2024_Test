using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        
            scoreText.text =  ""+score;
            Debug.Log(score);
        
    }
}
