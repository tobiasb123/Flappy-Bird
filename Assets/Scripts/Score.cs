using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int alloverScore;

    void Start()
    {
        score = 0;
        alloverScore = 0;
    }

    public void ScoreUp()
    {
        score++;
        alloverScore++;
        GetComponent<Text>().text = score.ToString();
        GetComponent<Text>().text = alloverScore.ToString();
    }
}
