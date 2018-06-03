using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
    int finalScore;
    Text finalScoreText;
    ScorePersistance scorePersistance;

    void Start ()
    {
        GetFinalScore();
        DisplayFinalScore();
    }

    void GetFinalScore()
    {
        //Obtain the score from Score recording object.
        scorePersistance = FindObjectOfType<ScorePersistance>();
        finalScore = scorePersistance.storedScore;
    }

    private void DisplayFinalScore()
    {
        //Display the obtained score in the UI.
        finalScoreText = GetComponent<Text>();
        finalScoreText.text = finalScore.ToString();
    }
}
