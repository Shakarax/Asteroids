using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	void Start () {  //Apply a random rotation to our Asteroids.

		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
}
