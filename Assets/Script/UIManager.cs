
using UnityEngine;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{
    public GameObject startScreen; 
    public GameObject gameOverScreen; 
    public Button startButton; 
    public Button replayButton; 
    public GameObject[] gameObjects; 

    private void Start()
    {
        
        ShowStartScreen();

        
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }

        if (replayButton != null)
        {
            replayButton.onClick.AddListener(RestartGame);
        }
    }

    public void ShowStartScreen()
    {
        if (startScreen != null)
        {
            startScreen.SetActive(true);
        }
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
        
        SetGameObjectsActive(false);
    }

    public void ShowGameOverScreen()
    {
        if (startScreen != null)
        {
            startScreen.SetActive(false);
        }
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void StartGame()
    {
        ShowGameScreen();
    }

    public void RestartGame()
    {
        
        ShowGameScreen();
        
        
    }

    private void ShowGameScreen()
    {
        if (startScreen != null)
        {
            startScreen.SetActive(false);
        }
        
        SetGameObjectsActive(true);
    }

    private void SetGameObjectsActive(bool isActive)
    {
        foreach (var obj in gameObjects)
        {
            if (obj != null)
            {
                obj.SetActive(isActive);
            }
        }
    }
}

