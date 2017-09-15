using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	private AudioSource audioSource;
	private Rigidbody rb;

	public Vector3 launchVelocity ;
	public Vector3 ballStartPos ;

	public bool inPlay = false;

	void Start () {
		findAllNeededComponents ();
		rb.useGravity = false;
		ballStartPos = transform.position;
	}

	void findAllNeededComponents(){
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}

	public void launchBall (Vector3 velocity)
	{
		inPlay = true;
		rb.useGravity = true;
		rb.velocity = velocity;
		audioSource.Play ();
	}

	public void reset(){
		transform.position = ballStartPos;
		transform.rotation = Quaternion.identity;
		rb.velocity = new Vector3 (0, 0, 0);
		rb.angularVelocity = Vector3.zero;
		inPlay = false;
		rb.useGravity = false;

	}
}
