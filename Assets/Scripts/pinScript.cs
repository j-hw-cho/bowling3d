using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinScript : MonoBehaviour {
	public scoreCalc sc;

	bool isHit;
	bool stop;

	bool watch;

	Vector3 prevPos;
	Vector3 prevRot;


	// Use this for initialization
	void OnEnable () {
		sc = GameObject.Find("Plane").GetComponent<scoreCalc>();

		isHit = false;
		stop = false;

		prevPos = this.transform.position;
		prevRot = this.transform.rotation.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {
		if (isHit) {
			if (!stop) {
				Vector3 curPos = this.transform.position;
				Vector3 curRot = this.transform.rotation.eulerAngles;

				if (curPos == prevPos && curRot == prevRot) {
					stop = true;
					//Debug.Log(this.name + " stopped");
				}
			}
		}

		if (watch) {
			if (isHit && stop) {
				sc.listenStop(false);
				watch = false;
			} else if (!isHit) {
				sc.listenStop(true);
				watch = false;
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "pin" || col.gameObject.name == "ball") {
			if (!isHit) {
				//Debug.Log (this.name + " hit!!");
				isHit = true;
			}
		}
	}

	public void floorHit() {
		isHit = true;
		stop = true;
		//Debug.Log(this.name + " fall down");
	}

	public void WatchStop() {
		watch = true;


	}

}
