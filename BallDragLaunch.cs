using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BallMovement))]
public class BallDragLaunch : MonoBehaviour {

	private BallMovement ballMovement;

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;

	void Start () {
		ballMovement = GetComponent<BallMovement> ();
	}
		
	public void moveStart(float amount){
		if (!	ballMovement.inPlay) {
			ballMovement.transform.Translate (new Vector3(amount,0,0));
		}
	}

	// Making swipe controlls for mobile
	public void dragStartMethod(){
		if(!ballMovement.inPlay){
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void dragEndMethod(){
		if (!ballMovement.inPlay) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;
			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0f, launchSpeedZ);
			ballMovement.launchBall (launchVelocity);
		}
	}
}
