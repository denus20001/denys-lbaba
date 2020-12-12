using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

	public static Scores instance;

	private const string BEST_SCORE = "bestScore";

	private const string BEST_COIN_SCORE = "bestCoinScore";

	// Use this for initialization
	void Awake () {
		GameStartedFirstTime ();
		MakeSingleton ();
	}
	
	// Update is called once per frame
	void Update () {		

	}

	void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void GameStartedFirstTime() {
		if(!PlayerPrefs.HasKey ("isGameStartedFirstTime")) {
			PlayerPrefs.SetInt (BEST_SCORE, 0);
			PlayerPrefs.SetInt (BEST_COIN_SCORE, 0);
			PlayerPrefs.SetInt ("isGameStartedFirstTime", 0);

		}
	}

	public void SetHighScore (int score) {
		PlayerPrefs.SetInt (BEST_SCORE, score);
	}

	public int GetHighScore () {
		return PlayerPrefs.GetInt (BEST_SCORE);
	}

	public void SetHighCoinScore (int highCoinScore) {
		PlayerPrefs.SetInt (BEST_COIN_SCORE, highCoinScore);
	}

	public int GetHighCoinScore () {
		return PlayerPrefs.GetInt (BEST_COIN_SCORE);
	}
}
