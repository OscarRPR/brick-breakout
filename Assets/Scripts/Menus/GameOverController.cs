﻿using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	private GameObject[] buttonsGO;
	private GameObject[] buttonsPlayerNameGO;
	private string[] leaderboard;
	private int score;
	private int position;

	void Start() {
		tk2dTextMesh scoreTitle =(tk2dTextMesh) GameObject.Find(NameUtils.NAME_SCORE_TITLE).GetComponent<tk2dTextMesh>();
		scoreTitle.text = PlayerPrefs.GetInt (ScoreUtils.TOTAL_SCORE).ToString ();
		scoreTitle.Commit ();
		buttonsGO = GameObject.FindGameObjectsWithTag (TagUtils.TAG_BUTTONS);
		buttonsPlayerNameGO = GameObject.FindGameObjectsWithTag (TagUtils.TAG_SCORE_LEADERBOARD);

		string startedLevel = PlayerPrefs.GetString (ScoreUtils.LEVEL_USER_INIT);
		bool canBeAddedToLeaderboard = ScoreUtils.canBeAddedToLeaderboard (startedLevel);

		leaderboard = ScoreUtils.getLeaderboard ();
		score = PlayerPrefs.GetInt (ScoreUtils.TOTAL_SCORE);
		position = ScoreUtils.checkUserEnterLeaderboard (leaderboard, score);
		Debug.Log (canBeAddedToLeaderboard);
		Debug.Log (position);

		if (canBeAddedToLeaderboard && isOnLeaderboard(position)) {
			foreach(GameObject buttonGO in buttonsGO) {
				buttonGO.SetActive(false);
			}
		} else {
			foreach(GameObject buttonGO in buttonsPlayerNameGO) {
				buttonGO.SetActive(false);
			}
		}
	}

	void mainMenuClicked() {
		Application.LoadLevel ("MainMenu");
	}
	
	void leaderboardsClicked() {
		Application.LoadLevel ("Leaderboards");
	}
	
	void levelSelectionClicked() {
		Application.LoadLevel ("LevelSelection");
	}

	void saveButtonClicked() {

		string nameUser = ScoreUtils.DEFAULT_STR_PLAYER_NAME;

		foreach(GameObject buttonGO in buttonsPlayerNameGO) {
			if (buttonGO.name.Equals (NameUtils.NAME_INPUT_LEADERBOARD)) {
				tk2dUITextInput textInput = buttonGO.GetComponent<tk2dUITextInput>();
				nameUser = textInput.Text;

				if (nameUser.Length < ScoreUtils.TOTAL_CHARACTERS_NAME) {
					Debug.Log (nameUser);
					return;
				}

				nameUser = nameUser.ToUpper();
			}
		}

		foreach(GameObject buttonGO in buttonsGO) {
			buttonGO.SetActive(true);
		}

		foreach(GameObject buttonGO in buttonsPlayerNameGO) {
			buttonGO.SetActive(false);
		}

		ScoreUtils.addUserLeaderboard(nameUser, score, position, leaderboard);
	}

	private bool isOnLeaderboard(int position) {
		return position >= 0 && position < 10 ? true : false ;
	}
}