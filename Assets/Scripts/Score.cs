using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //variables
    private int score;
    //end of variables
   
    //components
    Text scoreText;
    //end of components

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
