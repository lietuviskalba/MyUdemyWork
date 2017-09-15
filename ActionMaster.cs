using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action
	{
		Tidy, Reset, EndTurn, EndGame
	};

	private int[] bowls = new int[21];
	private int bowlBallThrown = 1;

	public void lol(){

	}

	public static Action NextAction(List<int>pinFalls){
		
		ActionMaster am = new ActionMaster ();
		Action currentAction = new Action ();

		foreach (int pinFall in pinFalls) {
			currentAction = am.bowl (pinFall);
		}

		return currentAction;
	}

	private Action bowl(int pins){ //TODO make private

		if (pins < 0 || pins > 10) {throw new UnityException ("Too much or noth enough pins.?.");}

		bowls [bowlBallThrown - 1] = pins;

		if (bowlBallThrown == 21) {
			return Action.EndGame;
		} 

		//Handle last-frame special class
		if (bowlBallThrown >= 19 && pins == 10) {
			bowlBallThrown++;
			return Action.Reset;
		} else if (bowlBallThrown == 20) {
			bowlBallThrown++;
			if (bowls [19 - 1] == 10 && bowls [20 - 1] != 10) {
				return Action.Tidy;

			}else if ((bowls[19-1] + bowls[20-1])  % 10 == 0) {
				return Action.Reset;
			} else if (bowl21Awarded ()) {
				return Action.Tidy;
			} else {
				return Action.EndGame;
			}
		}

		//if first bowl of the frame
		//then we return action.tidy
		if (bowlBallThrown % 2 != 0) {//first bowl of frame
			if (pins == 10) {
				bowlBallThrown += 2;
				return Action.EndTurn;
			} else {
				bowlBallThrown += 1;
				return Action.Tidy;
			}

		} else if (bowlBallThrown % 2 == 0) {//Second bowl of frame
			bowlBallThrown += 1;
			return Action.EndTurn;
		}

		throw new UnityException ("Not sure what action to return.?.");
	}

	private bool bowl21Awarded(){
		return (bowls [19 - 1] + bowls [20 - 1] >= 10);
	}
}
