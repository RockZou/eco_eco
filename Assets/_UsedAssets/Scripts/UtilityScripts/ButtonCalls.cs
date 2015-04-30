using UnityEngine;
using System.Collections;

public class ButtonCalls : MonoBehaviour {
	/*
	 *This field should be a reference to a Challenge Object
	 */
	public bool ChallengeFinished = false;

	public PostImage postImage;
	MovesAPIRequests movesAPIObj;
	JSONDataObject jsonDataObj;

	public void Awake(){
		movesAPIObj = GameObject.Find ("MovesAPIRequests").GetComponent<MovesAPIRequests> ();
		jsonDataObj = GameObject.Find ("JSONDataObject").GetComponent<JSONDataObject> ();
	}

	public void startChallenge(WaterBottleChallenge waterBottleChallenge){

		//Bridge.startCloudSight ();

		waterBottleChallenge = GameObject.Find ("WaterBottleChallenge").GetComponent<WaterBottleChallenge>();
		waterBottleChallenge.onStartChallenge ();

	}
	
}
