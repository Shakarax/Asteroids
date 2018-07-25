using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Can't find 'GameController' script");
		}
	}


	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{
		//Debug.Log (other.name);

		if (other.tag == "Boundry") {	//Ignore our boundry trigger
			return;
		}

		if (other.tag == "Player") {	//Player death
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore (scoreValue);  //Send our Asteroid score value to the GameController to update the UI.
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy (other.gameObject);  //Destroy the bullet
		Destroy (gameObject);		//Destroy the Asteroid
	}
}
	
