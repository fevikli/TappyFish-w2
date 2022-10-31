using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //variables
    private int score;
    private int highScore;
    //end of variables
   
    //components
    private Text scoreText;
    public Text panelScore;
    public Text panelHighScore;
    //end of components

    //game objects
    public GameObject New;
    //end of game objects

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore");
        panelHighScore.text = highScore.ToString();
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            panelHighScore.text = score.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
            New.SetActive(true);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
