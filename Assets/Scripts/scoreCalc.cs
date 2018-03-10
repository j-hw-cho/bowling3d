using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCalc : MonoBehaviour {
	public GameObject ball;
	public GameObject[] pins;

	public int numPins;

	bool isHit;
	public int score;
	public int checkedPins;

	void OnEnable() {
		pins = GameObject.FindGameObjectsWithTag("pin");
		numPins = pins.Length;
		isHit = false;
		score = numPins;
		checkedPins = 0;
	}



	void OnTriggerEnter(Collider col) {
		if (col.gameObject == ball) {
			Debug.Log("Ball Hits Floor!");
			isHit = true;
			foreach (GameObject pin in pins) {
				pin.GetComponent<pinScript>().WatchStop();
			}
		} else if (col.gameObject.tag == "pin") {
			col.gameObject.GetComponent<pinScript>().floorHit();

		}
	}

	public void listenStop(bool notFallen) {
		if (notFallen) {
			score --;
		}

		checkedPins ++;
		Debug.Log("numStoped == " + checkedPins);

		if (checkedPins == numPins) {
			// All pins checked
			DisplayScore();
		}
	}

	void DisplayScore() {
		Debug.Log("Display Score: " + score + "/" + numPins);

	}
}
