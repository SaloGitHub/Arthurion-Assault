using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject enemyExplode;
    [SerializeField] Transform parent;
    [SerializeField] int pointsPerHit = 1;
    [SerializeField] int pointsPerKill = 10;
    [SerializeField] int hitPoints = 6;

    ScoreBoard scoreBoard;

	void Start () {
        AddNonTriggerBoxCollider();
        FindScoreBoard();
	}

    void AddNonTriggerBoxCollider() {
        Collider boxCol = gameObject.AddComponent<BoxCollider>();
        boxCol.isTrigger = false;
    }

    void FindScoreBoard() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision (GameObject other)
    {
        ProcessHits();
        if (hitPoints <= 0) { KillEnemy(); }
    }

    private void ProcessHits()
    {
        //Adds points when you SHOOT enemies.
        scoreBoard.ScoreHit(pointsPerHit); 
        hitPoints--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(enemyExplode, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        //Adds points when you KILL enemies.
        scoreBoard.ScoreKill(pointsPerKill); 
    }

}
