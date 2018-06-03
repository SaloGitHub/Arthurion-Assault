using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    [Tooltip ("How fast the cube rotates")][SerializeField] float rotationSpeed = 5f;

	void Update () {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
