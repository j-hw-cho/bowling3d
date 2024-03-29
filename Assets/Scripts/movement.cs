﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	public scoreCalc sc;
	public GameObject cam;
	public GameObject ball;
	public Rigidbody ballRb;

	public float baseForce = 1000f;
	public Vector3 force;

	public bool hasThrown;
	public bool isMoving;
	public bool inTouch;

	private Vector3 initPos;
	private Vector3 endPos;
	private Vector3 curPos;
	private float time;

	public UIController ui;

	private float camBallZDist;
	private float camBallYDist;
	private float camPosX;
	private float camPosY;

	private float accelFactor;

	// Use this for initialization
	void OnEnable () {
		ballRb = ballRb == null ?  ball.GetComponent<Rigidbody>() : ballRb;

		hasThrown = false;
		isMoving = false;
		inTouch = false;

		force = Vector3.zero;
		initPos = Vector3.zero;
		endPos = Vector3.zero;
		curPos = Vector3.zero;
		time = 0.0f;

		ui = GameObject.Find("Canvas").GetComponent<UIController>();
		camPosX = cam.transform.position.x;
		camPosY = cam.transform.position.y;
		camBallYDist = cam.transform.position.y - ball.transform.position.y;
		camBallZDist = cam.transform.position.z - ball.transform.position.z;

		accelFactor = 1.5f;

		sc = GameObject.Find("Plane").GetComponent<scoreCalc>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasThrown) {
			if (Input.GetMouseButtonDown(0)) {
				if (inTouch) {
					// ignore 
				} else {
					// begin swiping
					// TODO:
					if (GameObject.Find("initPanel") != null) {
						GameObject.Find("initPanel").SetActive(false);
					}
					time = 0;
					initPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
					endPos = Vector3.zero;
					inTouch = true;
					ui.changeStatusText(0);
					ui.changeVectorTxt(0, initPos);


				}

			} else if (Input.GetMouseButtonUp(0)) {
				time = time + Time.deltaTime;
				endPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
				ui.changeStatusText(1);
				ui.changeVectorTxt(1, endPos);
				FinishTouch();
			} else if (inTouch) {
				time = time + Time.deltaTime;

			}
		} else if (isMoving) {
		
			float newCamPosZ = ball.transform.position.z + camBallZDist;
			if (newCamPosZ >= 95f) { // near boundary, stop camera
				isMoving = false;
			} else {
				
				cam.transform.position = new Vector3(camPosX, camPosY, newCamPosZ);
			}

			if (ballRb.velocity.magnitude == 0) {	// ball stopped
				ui.changeStatusText(2);
				isMoving = false;

				ui.DisplayScore(0,sc.numPins);
			} 
		
		}
		
	}


	void FinishTouch() {
		inTouch = false;
		hasThrown = true;

		// Add force to ball
		float distX = endPos.x - initPos.x;
		float distZ = endPos.y - initPos.y;		// Ball's z pos == ui y pos


		float forceX = baseForce * (distX / time);
		float forceZ = baseForce * (distZ / time);
		if (forceZ >= 1f) {
			forceZ = forceZ >= 2000f ? forceZ + accelFactor: forceZ * accelFactor; 
		}
		//forceZ = forceZ < 1f ? forceZ : forceZ * accelFactor;

		force = new Vector3 (forceX, 0f, forceZ);

		ballRb.useGravity = true;
		ballRb.AddForce(force);
		ui.changeVectorTxt(2, force);

		isMoving = true;

	}
		
}
