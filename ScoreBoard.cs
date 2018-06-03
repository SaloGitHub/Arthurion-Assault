using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    int score; //string reference
    Text scoreText;
    ScorePersistance scorePersistance;

	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        scorePersistance = FindObjectOfType<ScorePersistance>();
    }

    public void ScoreHit(int pointsPerHit)
    {
        score = score + pointsPerHit;
        scoreText.text = score.ToString();
        scorePersistance.StoreScore(score);
    }

    public void ScoreKill(int pointsPerKill)
    {
        score = score + pointsPerKill;
        scoreText.text = score.ToString();
        scorePersistance.StoreScore(score);
    }

}
