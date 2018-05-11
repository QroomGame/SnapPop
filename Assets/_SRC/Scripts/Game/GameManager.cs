using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	GameplayUI ui;

	void Awake(){
		ui = GameObject.FindObjectOfType<GameplayUI>();
		ui.gameObject.SetActive(false);
	}


	public void GameOver(){
		 ui.GameOver(2f);
	}
}
