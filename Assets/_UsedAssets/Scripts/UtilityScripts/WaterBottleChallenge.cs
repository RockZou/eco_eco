using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaterBottleChallenge : MonoBehaviour {

	public static int NOT_STARTED=0;
	public static int STARTED=1;
	public static int SUCCESS=2;
	public static int FAILED=3;


	public GameObject ImageRecognitionModal_TakePicture;
	public GameObject ImageRecognitionModal_Waiting;
	public GameObject ImageRecognitionModal_ChallengeComplete;

	public GameObject CoconutText;

	public string[] waterBottleDictionary = new string[] {"bottle","steel","metal","thermos","tumbler", "proof", "spill","sports","adidas"};

	public string[] bottledWaterDictionary = new string[] {"bottled","clear","drinking","al","ain","arwa","aquafina","dasani",
															"evian","nestle","oasis","putrified","volvic","voss"};

	public int status;

	OceanController theOcean;

	public void Awake(){
		status = NOT_STARTED;
		theOcean = GameObject.Find ("Ocean").GetComponent<OceanController>();
		//ImageRecognitionModal_TakePicture = GameObject.Find ("ImageRecognitionModal_TakePicture");
		//ImageRecognitionModal_Waiting = GameObject.Find ("ImageRecognitionModal_Waiting");
		//ImageRecognitionModal_ChallengeComplete = GameObject.Find ("ImageRecognitionModal_ChallengeComplete");

	}

	// Use this for initialization
	public void Start () {
		
	}

	public int onVerify(string[] wordsList){

		for (int i=0; i<wordsList.Length; i++) 
			for (int j=0; j<bottledWaterDictionary.Length; j++) {
				if(wordsList[i]== bottledWaterDictionary[j])
				{
					Debug.Log("the challenge is failed because " + wordsList[i]);
					onFailChallenge();
					return 0;//failed
				}
		}

		for (int i=0; i<wordsList.Length; i++) 
			for (int j=0; j<waterBottleDictionary.Length; j++) {
				if(wordsList[i]==waterBottleDictionary[j])
				{
					Debug.Log("the challenge succeeded because " + wordsList[i]);
					onCompleteChallenge();
					return 1;//succeeded
				}
		}

		onRetryChallenge ();
		return -1;//undecided
	}

	public void onStartChallenge(){
		status = STARTED;
	}

	public void onRetryChallenge(){
		ImageRecognitionModal_Waiting.SetActive (false);
	}

	public void onCompleteChallenge(){
		status = SUCCESS;

		ImageRecognitionModal_Waiting.SetActive (false);
		ImageRecognitionModal_ChallengeComplete.SetActive (true);

		Debug.Log ("WaterBottleChallenge onCompleteChallenge Called!");


		ImageRecognitionModal_TakePicture.SetActive(false);
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
		ImageRecognitionModal_Waiting.SetActive (false);

		CoconutText.GetComponent<CoconutNumber>().sub (10);

		ImageRecognitionModal_TakePicture.SetActive (false);
		Debug.Log ("WaterBottleChallenge onFailChallenge called!");
	}
}
