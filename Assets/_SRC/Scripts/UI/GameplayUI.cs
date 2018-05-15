using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour {

    GameObject restartPanel;
    GameObject pausePanel;
    Transform t;
    Text points;
    float currentMts;

    private void Awake() {
        t = transform;
        restartPanel = t.Find("RestartPanel").gameObject; ;
        pausePanel = t.Find("PausePanel").gameObject;
        points = t.Find("hud/points").GetComponent<Text>();

    }

    private void Start() {
        GameData.instance.ui = this;
        StarCount();
    }

    public void GameOver(float time = 0f){

		//Invoke("ActivateGameOverUI",time);
        restartPanel.transform.Find("points").GetComponent<Text>().text= Mathf.Round(currentMts).ToString() + " m.";
        restartPanel.SetActive(true);

    }
	private void ActivateUI(){

        restartPanel.SetActive(true);		

	}
    public void StarCount() {
        currentMts = 0;
        points.text = "0 mts.";
    }

    public void AddPoints(float poin) {
        if(poin> currentMts) {
            currentMts = poin;
        }
       
        points.text = Mathf.Round(currentMts).ToString() + " m.";
    }

    public void OnClickPauseGame() {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

	public void OnClickRestart(){

		SceneManager.LoadScene(Const.SCENES.Main.ToString());

	}

    public void OnClickResume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
