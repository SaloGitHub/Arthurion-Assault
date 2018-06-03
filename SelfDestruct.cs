using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    [Tooltip("How long before ExplosionFX instance destroys itself")]
    [SerializeField] float destroyDelay = 1f;

	void Start () {
        Destroy(gameObject, destroyDelay);
	}

}
