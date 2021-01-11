using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    int score;

    public void IncrementScore()
    {
        score=score+10;
        scoreText.text = "Score - "+score;
    }
}
