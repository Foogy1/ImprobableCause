using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterScript : MonoBehaviour {

	public int score;
	private bool levelInProgress = true;
	private float playTime = 0.0f;

	public Text scoreText;

	//Essentially, if the bowling ball is used, then make this true
	public bool audienceBonus = false;

	void Start () {
		score = 0;
		playTime = 0.0f;
	}
	

	void Update () {

		if (levelInProgress == true) 
		{
			playTime += Time.deltaTime;
			if (playTime >= 1) 
			{
				AddScore (100);

				//score += 100;
				playTime = 0;
			}
		}


	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void scoreTimerStart()
	{
		levelInProgress = true;
	}

	public void scoreTimerStop()
	{
		levelInProgress = false;
	}

	public void scoreTimerRestart()
	{
		scoreTimerStop ();
		scoreText.text = "Score: 000";
		score = 0;

	}

	public void scoreEnd()
	{
		scoreTimerStop ();
		if (audienceBonus) {
			score += 5000;
		}
		UpdateScore ();
	}
}
