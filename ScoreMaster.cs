using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	public static List<int> ScoreCumulative (List<int> rolls){
		
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames(rolls)){
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}
	}

	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frameList = new List<int>();

		//Code here

		return frameList;
	}
}
