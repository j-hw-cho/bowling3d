using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	public GameObject ball;
	public Rigidbody ballRb;

	public float minForce = 10f;
	public float force;

	public bool hasThrown;
	public bool isMoving;
	public bool inTouch;

	Vector3 initPos;


	// Use this for initialization
	void OnEnable () {
		ballRb = ballRb == null ?  ball.GetComponent<Rigidbody>() : ballRb;

		hasThrown = false;
		isMoving = false;
		inTouch = false;

		initPos = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasThrown) {
			if (Input.GetMouseButtonDown(0)) {
				if (inTouch) {


				} else {
					// begin swiping
					// TODO:
					inTouch = true;

				}

			} else if (Input.GetMouseButtonUp(0)) {
				FinishTouch();
			} else if (inTouch) {
				

			}
		} else if (isMoving) {
			// TODO:

		}
		
	}


	void FinishTouch() {
		inTouch = false;
		hasThrown = true;

		ballRb.useGravity = true;
		// Add force to ball

	}
}
