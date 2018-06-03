using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class LoadLevel : MonoBehaviour {
    [Tooltip("Make sure the levelLoadDelay and the animation duration for the camera match.")]
    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] GameObject sFX;

	void Start () {
        Invoke("GoToGame",(levelLoadDelay));
        sFX.SetActive(false);
    }

    void GoToGame() {SceneManager.LoadScene(2);}

    private void Update() {
        //Skip Splash Screen on user input.
        if (CrossPlatformInputManager.GetButton("Fire")) {
            sFX.SetActive(true);
            GoToGame();
        }
    }

}
