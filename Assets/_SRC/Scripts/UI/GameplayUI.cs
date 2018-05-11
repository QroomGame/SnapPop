using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour {



	public void GameOver(float time = 0f){

		Invoke("ActivateUI",time);
		
	}
	private void ActivateUI(){

		gameObject.SetActive(true);		

	}

	public void OnClickRestart(){

		SceneManager.LoadScene(Const.SCENES.Main.ToString());

	}

}
