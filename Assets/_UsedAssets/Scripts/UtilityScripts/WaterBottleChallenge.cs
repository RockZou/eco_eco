using UnityEngine;
using System.Collections;

public class WaterBottleChallenge : MonoBehaviour {

	public static int NOT_STARTED=0;
	public static int STARTED=1;
	public static int SUCCESS=2;
	public static int FAILED=3;

	public string[] waterBottleDictionary = new string[] {"bottle","steel","metal","thermos","tumbler", "proof", "spill","sports","adidas"};
	public string[] bottledWaterDictionary = new string[] {"bottled","drinking","al","ain","arwa","aquafina","dasani","evian","nestle","oasis","putrified","volvic","voss"};

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

		for (int i=0; i<wordsList.Length; i++) 
			for (int j=0; j<bottledWaterDictionary.Length; j++) {
				if(wordsList[i]== bottledWaterDictionary[j])
				{
					onFailChallenge();
					return 0;//failed
				}
		}

		for (int i=0; i<wordsList.Length; i++) 
			for (int j=0; j<waterBottleDictionary.Length; j++) {
				if(wordsList[i]==waterBottleDictionary[j])
				{
					onCompleteChallenge();
					return 1;//succeeded
				}
		}

		return -1;//undecided
	}

	public void onStartChallenge(){
		status = STARTED;
		Bridge.ShowCamera ();
	}

	public void onCompleteChallenge(){
		status = SUCCESS;
		Debug.Log ("WaterBottleQuest onCompleteChallenge Called!");

		//sea level drop by 50, everytime this challenge is completed
		Vector3 seaLevel = theOcean.transform.position;

		theOcean.changeSeaLevel (seaLevel.y - 50);

		//Coconuts(currency) change to be added
		/*
		 * Do the money stuff here 
		 */
		Debug.Log ("This is doing the money changing stuff.");
	}

	public void onFailChallenge(){
		status = FAILED;
		Debug.Log ("WaterBottleQuest onFailChallenge called!");
	}
}
