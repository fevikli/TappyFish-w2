using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //variables
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public static bool gameStarted;
    public static int gameScore;
    //end  of variables

    //game objects
    public GameObject gameOverPanel;
    public GameObject getReady;
    public GameObject score;
    //end of game objects

    //calesse
    public Score scoreScript;
    //end of classes

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }

    public void GameHasStarted()
    {
        gameStarted = true;
        getReady.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = scoreScript.GetScore();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
