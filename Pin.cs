using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pin : MonoBehaviour {

	private Rigidbody rb;

	private float distanceToRaise = 40f;

	public float standingThreshold = 6f;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	public void raiseIfStanding(){
		if (isStanding()) {
			rb.useGravity = false;
			transform.Translate (new Vector3 (0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0f, 0f);
            print (" lifting them up " + distanceToRaise);
		}
	}

	public void lower(){
		transform.Translate (new Vector3 (0, -distanceToRaise, 0), Space.World);
		rb.useGravity = true;
	}

	public bool isStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		if((tiltInX < standingThreshold || (tiltInX <= 360f && tiltInX >= 360f-standingThreshold))
			&& (tiltInZ < standingThreshold) || (tiltInZ <= 360f && tiltInZ >= 360f - standingThreshold))
		{
			return true;
		}
		return false;
	}
}
