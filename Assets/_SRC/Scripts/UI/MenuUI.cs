using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

	// Use this for initialization
	public void GoToGameplay(){
		SceneManager.LoadScene("Main");
	}
	
}
