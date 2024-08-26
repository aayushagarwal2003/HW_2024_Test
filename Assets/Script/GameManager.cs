


using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public UIManager uiManager; 
    private int score = 0;

   

    public void UpdateScore()
    {
        score++; 
        UpdateScoreText(); 
    }

    private void UpdateScoreText()
    {
        
        if (scoreText != null)
        {
            scoreText.text = "" + score; 
        }
    }

    public void EndGame()
    {
        
        if (uiManager != null)
        {
            uiManager.ShowGameOverScreen();
        }
        
    }

    public void ResetGame()
    {
        
        score = 0;
        UpdateScoreText();
       
        if (uiManager != null)
        {
            uiManager.ShowStartScreen();
        }
    }
}
