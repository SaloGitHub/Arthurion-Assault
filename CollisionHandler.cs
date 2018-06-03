using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
   
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitOneFX;
    [SerializeField] GameObject hitTwoFX;
    private int playerHealth = 3;
    [Tooltip("How long is the player immune after getting hit.")] [SerializeField]float temporalImmunity = 1.5f;
    BoxCollider boxCollider;
    HealthUI healthUI;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        healthUI = FindObjectOfType<HealthUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        switch (playerHealth)
        {           
            case (3):
                PlayerHitOne();
                break;
            case (2):
                PlayerHitTwo();
                break;
            case (1):
                StartDeathSequence();
                break;
        }
    }

    void PlayerHitOne()
    {
        playerHealth--;
        hitTwoFX.SetActive(true);
        boxCollider.enabled = false;
        Invoke("EnableCollider", temporalImmunity);
        healthUI.PlayerHealthMedium();
    }

    void PlayerHitTwo()
    {
        playerHealth--;
        hitOneFX.SetActive(true);
        boxCollider.enabled = false;
        Invoke("EnableCollider", temporalImmunity);
        healthUI.PlayerHealthLow();
    }

    void EnableCollider()
    {
        boxCollider.enabled = true;
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("LevelRestart",(levelLoadDelay));
        healthUI.HideUI();
    }

    private void LevelRestart() //String reference.
    {
        SceneManager.LoadScene(2);
    }
}
