using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControlPlayer : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^s-1")] [SerializeField] float speed = 6.5f;
    [Tooltip("In ms^s-1")] [SerializeField] float xRange = 6.5f;
    [Tooltip("In ms^s-1")] [SerializeField] float yRange = 3.4f;

    [Header("Projectiles")]
    [Tooltip("Set gun particles")][SerializeField] GameObject[] guns;
    [Tooltip("Set fire SFX")] [SerializeField] GameObject gunSound;

    [Header("Screen Position")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control")]
    [SerializeField] float controlRollFactor = -5f;
    [SerializeField] float controlPitchFactor = -15f;

    float xThrow, yThrow;
    bool controlsEnabled = true;

    void Update()
    {
        if (controlsEnabled)
        {
            ShipTranslation();
            ShipRotation();
            ProcessFiring();
        }
    }

    private void ShipTranslation()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = (yThrow * speed * Time.deltaTime);
        float yRawMove = transform.localPosition.y + yOffset;
        float yMove = Mathf.Clamp(yRawMove, -yRange, yRange);

        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = (xThrow * speed * Time.deltaTime);
        float xRawMove = transform.localPosition.x + xOffset;
        float xMove = Mathf.Clamp(xRawMove, -xRange, xRange);

        transform.localPosition = new Vector3(xMove, yMove, transform.localPosition.z);
    }

    private void ShipRotation()
    {
        // Pitch = X
        float pitchEquationOne = transform.localPosition.y * positionPitchFactor;
        float pitchEquationTwo = yThrow * controlPitchFactor;
        float pitch = pitchEquationOne + pitchEquationTwo;     

        // Yaw = Y
        float yaw= transform.localPosition.x * positionYawFactor;

        // Roll = Z
        float roll  = xThrow * controlRollFactor; ; 

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    //Called by string Collision Handler script.
    void OnPlayerDeath() 
    {
        controlsEnabled = false;
    }

    void ProcessFiring(){
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
            PlayGunSound(true);
        }
        else
        {
            SetGunsActive(false);
            PlayGunSound(false);
        }
    }

    void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {        
           var emissionModule = gun.GetComponent<ParticleSystem>().emission;
           emissionModule.enabled = isActive;
        }
    }

    void PlayGunSound (bool isPlaying)
    {
        //Gets the audio source component set in the inspector
        //and turns it on whenever "Fire" is pressed.
        switch (isPlaying)
        {
            case (true):
                gunSound.SetActive(true);
                break;
            case (false):
                gunSound.SetActive(false);
                break;
        }
    }
  
}
