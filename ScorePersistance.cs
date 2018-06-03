using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePersistance : MonoBehaviour {
    public int storedScore;

	void Awake () {
        int scoreObjs = FindObjectsOfType<ScorePersistance>().Length;
        if (scoreObjs > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    }

    //Receives and stores the score from ScoreBoard script
    public void StoreScore (int score)
    {
        storedScore = score;
    }
	
}
