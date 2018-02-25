using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public Text initText;
	public Text endTxt;
	public Text forceTxt;
	public Text swipeCheckTxt;
	// Use this for initialization
	void OnEnable () {
		initText.text = "";
		endTxt.text = "";
		forceTxt.text = "";
		swipeCheckTxt.text = "";

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
}
