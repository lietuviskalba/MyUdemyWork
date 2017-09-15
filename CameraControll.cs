using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	public BallMovement ball;

	private Vector3 offset;

	void Start () {
		offset = transform.position - ball.transform.position;
	}
	
	void Update () {

		if (transform.position.z <= 1700) {
			cameraFollowsBall ();
		}

		if(!ball.inPlay){
			cameraFollowsBall ();
		}
	}

	void cameraFollowsBall(){
		transform.position = ball.transform.position + offset;

	}
}
