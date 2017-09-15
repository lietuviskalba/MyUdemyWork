using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingPinDisplay;

	private GameManager gameManager;

	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;

	void Start(){
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

    void Update()
    {
        standingPinDisplay.text = countStanding().ToString();

        if (ballOutOfPlay)
        {
            updateStandingCountAndSettle();
            standingPinDisplay.color = Color.red;
        }
    }

	public void reset(){
		lastSettledCount = 10;
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.name == "Bowling Ball") {
			ballOutOfPlay = true;
		}
	}

	void updateStandingCountAndSettle(){
		int currentStanding = countStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;//how long to wait before settle
		if ((Time.time - lastChangeTime) > settleTime) {//if last change was 3 sex ago
			pinsHaveSettled ();
		}
	}

	void pinsHaveSettled(){
		int standing = countStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManager.bowl (pinFall);

		ballOutOfPlay = false;
		lastStandingCount = -1; // pins have settled
		standingPinDisplay.color = Color.green;

	}

	int countStanding(){

		int numberOfStandingPins = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.isStanding()) {
				numberOfStandingPins++;
			}
		}
		return numberOfStandingPins;
	}

}
