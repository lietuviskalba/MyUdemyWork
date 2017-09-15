using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinSetter : MonoBehaviour {

	public GameObject pinsSet;

	private Animator anim;
	private ActionMaster actionMaster = new ActionMaster (); // we need it here for only 1 instance
	private PinCounter pinCounter;

	void Start () {
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
		anim = GetComponent<Animator> ();
	}

	public void raisePins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.raiseIfStanding ();
		}
	}

	public void lowerPins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.lower ();
		}
	}

	public void renewPins(){
		GameObject newPins = Instantiate(pinsSet, new Vector3(0,5,1829), Quaternion.identity);
		newPins.transform.position += new Vector3 (0, 20, 0);
		print (" renew pins ");

	}

	public void performAction(ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy) {
			anim.SetTrigger ("tidyTrigger");
		}else if(action == ActionMaster.Action.EndTurn){
			anim.SetTrigger ("resetTrigger");
			pinCounter.reset ();
		}else if(action == ActionMaster.Action.Reset){
			anim.SetTrigger ("resetTrigger");
			pinCounter.reset ();
		}else if(action == ActionMaster.Action.EndGame){
			throw new UnityException (" I dont know how to handle end game yet" );	
		}
	}

}
