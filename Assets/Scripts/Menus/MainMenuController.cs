﻿using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	void Start() {
		ScoreUtils.initializeLeaderboards ();
	}

	void startGameClicked() {
		Application.LoadLevel ("LevelSelection");
	}

	void leaderboardsClicked() {
		Application.LoadLevel ("Leaderboards");
	}

	void optionsClicked() {
		Application.LoadLevel ("Options");
	}

	void creditsClicked() {
		Application.LoadLevel ("Credits");
	}

	void exitGameClicked() {
		Application.Quit ();
	}
}