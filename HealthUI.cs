using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {

    [SerializeField] GameObject healthFull;
    [SerializeField] GameObject healthMedium;
    [SerializeField] GameObject healthLow;

    void Start () {
        healthFull.SetActive(true);
        healthMedium.SetActive(false);
        healthLow.SetActive(false);
    }

    // Functions called by CollisionHandler.

    public void PlayerHealthMedium()
    {
        healthFull.SetActive(false);
        healthMedium.SetActive(true);
    }

    public void PlayerHealthLow()
    {
        healthMedium.SetActive(false);
        healthLow.SetActive(true);
    }

    public void HideUI()
    {
        healthLow.SetActive(false);
    }


}
