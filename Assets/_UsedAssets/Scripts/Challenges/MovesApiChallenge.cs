using UnityEngine;
using System.Collections;

public class MovesApiChallenge : MonoBehaviour {
		
		public static int NOT_STARTED=0;
		public static int STARTED=1;
		public static int SUCCESS=2;
		public static int FAILED=3;
		
		
		public GameObject MovesChallengeModal_Main;
		public GameObject MovesChallengeModal_Complete;
		
		public GameObject CoconutText;
		
		public int status;
		
		OceanController theOcean;
		
		public void Awake(){
			status = NOT_STARTED;
			theOcean = GameObject.Find ("Ocean").GetComponent<OceanController>();
			
		}
		
		// Use this for initialization
		public void Start () {
			
		}
		
		public int onVerify(string[] wordsList){			
			
			onRetryChallenge ();
			return -1;//undecided
		}
		
		public void onStartChallenge(){
			status = STARTED;
		}
		
		public void onRetryChallenge(){

		}
		
		public void onCompleteChallenge(){
			status = SUCCESS;
		}
		
		public void giveReward(){
			
			//sea level drop by 50, everytime this challenge is completed
			Vector3 seaLevel = theOcean.transform.position;
			theOcean.changeSeaLevel (seaLevel.y - 50);
			
			//Coconuts(currency) change to be added
			/*
		 * Do the money stuff here 
		 */
			
			CoconutText.GetComponent<CoconutNumber>().add (300);
			Debug.Log ("This is doing the money changing stuff.");
		}
		
		public void onFailChallenge(){
			Debug.Log ("WaterBottleChallenge onFailChallenge is called");
			status = FAILED;
			Debug.Log ("MovesApiChallenge onFailChallenge called!");
		}
	
}
