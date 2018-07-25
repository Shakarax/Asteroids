using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazzardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	//UI
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
		gameOver = false;
		gameOverText.text = "";

		restart = false;
		restartText.text = "";

		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update () {
		if (restart)
		{
			if(Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{  //Spawn hazards.
		yield return new WaitForSeconds (startWait);  //delays the first hazard

		while (true) 
		{
			for (int i = 0; i < hazzardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' to Restart.";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)  //This public will be called by the Asteroid when it dies.
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}


}
