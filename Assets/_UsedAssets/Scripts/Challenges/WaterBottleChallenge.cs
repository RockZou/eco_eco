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
	public GameObject ImageRecognitionModal_Waiting2;

	public GameObject ImageRecognitionModal_ChallengeComplete;
	public GameObject ImageRecognitionModal_FailedChallenge;
	public GameObject ImageRecognitionModal_IsThisCorrect;
	public GameObject TextBox;

	public AudioSource achievement;

	public GameObject CoconutText;

	public GameObject CamDisplay;

	string[] waterBottleDictionary = new string[] {"adidas","aluminum","glass","metal","proof","purple","reusable","steel", "spill","silver", "sports", "thermos","tumbler"};

	string[] bottledWaterDictionary = new string[] {"bottled","clear","drinking","al","ain","arwa","aquafina","dasani",
															"evian","nestle","oasis","putrified","volvic","voss"};

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

		Debug.Log ("WaterBottleChallenge onVerify is called");
		for (int i=0; i<wordsList.Length; i++) 
			for (int j=0; j<waterBottleDictionary.Length; j++)
			{
				Debug.Log("wordlist No." + i + " is "+wordsList[i] + "waterBottleDictionary No." + j + " is "+waterBottleDictionary[j]);

				if(wordsList[i] == waterBottleDictionary[j])
				{
					Debug.Log("**************************the challenge succeeded because *************************");
					Debug.Log(wordsList[i]);
					onCompleteChallenge();
					return 1;//succeeded
				}
			}

		for (int i=0; i<wordsList.Length; i++) 
			for (int j=0; j<bottledWaterDictionary.Length; j++) {
				if(wordsList[i]== bottledWaterDictionary[j])
				{
					Debug.Log("the challenge is failed because " + wordsList[i]);
					onFailChallenge();
					
					return 0;//failed
				}
		}

		onRetryChallenge ();
		return -1;//undecided
	}

	public void onStartChallenge(){
		status = STARTED;
		CamDisplay.GetComponent<CamDisplay> ().turnCamearOn ();
	}

	public void onRetryChallenge(){
		Debug.Log ("WaterBottleChallege onRetryChallenge is called");
		ImageRecognitionModal_Waiting.SetActive (false);
		TextBox.GetComponent<TextBox> ().setText ("The image isn't very clear... Plase try again!|warning");
		onStartChallenge ();
	}

	public void onRetryChallenge(string ErrorMessage){
		Debug.Log ("WaterBottleChallege onRetryChallenge is called");
		ImageRecognitionModal_Waiting.SetActive (false);
		TextBox.GetComponent<TextBox> ().setText ("Something is wrong...("+ErrorMessage+") Plase try again!|warning");
		onStartChallenge ();
	}

	public void onCompleteChallenge(){
		status = SUCCESS;

		ImageRecognitionModal_Waiting.SetActive (false);
		ImageRecognitionModal_ChallengeComplete.SetActive (true);

		Debug.Log ("WaterBottleChallenge onCompleteChallenge Called!");
		TextBox.GetComponent<TextBox> ().setText ("You completed the challenge! Keep using the plastic bottle to keep the sea level from rising!|reward");

		ImageRecognitionModal_TakePicture.SetActive(false);
	}

	public void giveReward(){
		Debug.Log ("WaterBottleChallenge giveReward is called");

		achievement.Play ();

		//sea level drop by 50, everytime this challenge is completed
		Vector3 seaLevel = theOcean.transform.position;
		theOcean.changeSeaLevel (seaLevel.y - 50);

		//Coconuts(currency) change to be added
		/*
		 * Do the money stuff here 
		 */
		
		CoconutText.GetComponent<CoconutNumber>().add (300);
	}

	public void givePunishment(){

		ImageRecognitionModal_Waiting.SetActive (false);

		CoconutText.GetComponent<CoconutNumber>().sub (20);
		
		Vector3 seaLevel = theOcean.transform.position;
		theOcean.changeSeaLevel (seaLevel.y + 10);
		
		ImageRecognitionModal_TakePicture.SetActive (false);
		ImageRecognitionModal_FailedChallenge.SetActive (true);

	}

	public void onFailChallenge(){
		Debug.Log ("WaterBottleChallenge onFailChallenge is called");
		status = FAILED;

		TextBox.GetComponent<TextBox> ().setText ("You failed the challenge! The picture is not a reusable water bottle!|warning");

		CamDisplay.GetComponent<CamDisplay>().cam.Stop();

		givePunishment ();

		Debug.Log ("WaterBottleChallenge onFailChallenge called!");
	}
}
