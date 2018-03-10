using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	public Text initText;
	public Text endTxt;
	public Text forceTxt;
	public Text swipeCheckTxt;


	public GameObject endPanel;
	public Text scoreTxt;

	// Use this for initialization
	void OnEnable () {
		initText.text = "";
		endTxt.text = "";
		forceTxt.text = "";
		swipeCheckTxt.text = "";

		endPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeStatusText(int option) {
		if (option == 0) {
			swipeCheckTxt.text = "Swiping...";
		} else if (option == 1) {
			swipeCheckTxt.text = "Ball Thrown, moving";
		} else if (option == 2) {
			swipeCheckTxt.text = "Ball stopped";
		} 
	}

	public void changeVectorTxt(int option, Vector3 pos) {
		if (option == 0) {
			initText.text = "Init Position: " + pos.ToString();
		} else if (option == 1) {
			endTxt.text = "End Position: " + pos.ToString();
		} else {
			forceTxt.text = "Force: " + pos.ToString();
		}
	}

	public void DisplayScore(int score, int numPin) {
		endPanel.SetActive(true);
		if (score == numPin) {
			scoreTxt.text = "STRIKE!";
		}
		scoreTxt.text = score + "/" + numPin;

	}

	public void Replay() {
		Scene curScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(curScene.buildIndex);

	}
}
