using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List <int> bowls = new List<int>();

	private PinSetter pinSetter;
	private BallMovement ballMove;

	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		ballMove = GameObject.FindObjectOfType<BallMovement> ();
	}

	public void bowl(int pinFall){
		bowls.Add (pinFall);
		ActionMaster.Action nextAction =  ActionMaster.NextAction (bowls);
		pinSetter.performAction (nextAction);
		ballMove.reset ();
	}
}
