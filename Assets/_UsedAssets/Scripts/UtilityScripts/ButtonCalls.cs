using UnityEngine;
using System.Collections;

public class ButtonCalls : MonoBehaviour {

	// No setter function for APIInterval yet. Should belong to API class.
	private int APIInterval = 10;// represents how often (in seconds/time) are the API calls made.

	/*
	 *This field should be a reference to a Challenge Object
	 */
	public bool ChallengeFinished = true;

	APIRequests APIObj;
	JSONDataObject jsonDataObj;
	public void Start(){
		APIObj = GameObject.Find ("APIRequests").GetComponent<APIRequests> ();
		jsonDataObj = GameObject.Find ("JSONDataObject").GetComponent<JSONDataObject> ();
	}

	public void doRequestMovesAuthInApp()
	{
		Debug.Log("Button is Clicked!");

		//Bridge.ShowCamera (12345);
		Bridge.doRequestMovesAuthInApp ();
	}

	public void getMovesAPIData(){
		Debug.Log ("getMovesAPIData called");
		APIObj.callGetData ();
	}


	
	public void callGetDataForChallenge(){
		Debug.Log("ButtonEvent callGetDataForQuest called");
		StartCoroutine (getDataForChallenge());
	}
	
	public void callTimedAPICalls(){
		Debug.Log("ButtonEvent callTimedAPICalls called");
		StartCoroutine (timedAPICalls());
	}
	
	public void changeChallengeStatus(){

		/*
		 * This is a place holder for changing the ChallengeFinshied Variable for Challenge Objects
		 */ 

		ChallengeFinished = !ChallengeFinished;
	}

	public void startWaterBottleChallenge(){

		//Bridge.startCloudSight ();

		WaterBottleChallenge waterBottleChallenge = GameObject.Find ("WaterBottleChallenge").GetComponent<WaterBottleChallenge>();
		waterBottleChallenge.onStartChallenge ();

		/*
		 * This "short-circuit" the Java lib to directly call JavaCallback
		 * In production version, this JavaCallback function should only be called from java lib
		 */
		JavaCallback javaCallback = GameObject.Find("JavaCallback").GetComponent<JavaCallback>();
		
		string temp_string = "{\"status\": \"completed\",\"name\": \"white digital ac monitor\"}";
		//Water Bottle Testing String -- Fail
		string temp_string_water_fail = "{\"status\": \"completed\",\"name\": \"arwa bottled water\"}";

		string temp_string_water_success = "{\"status\": \"completed\",\"name\": \"gray and black adidas sports bottle\"}";
	

		javaCallback.onReturnImageKeyword (temp_string_water_success);
	}


	
	IEnumerator getDataForChallenge(){
		Debug.Log ("Button Event getDataForChallenge called");
		
		string ACCESS_TOKEN = PlayerPrefs.GetString ("ACCESS_TOKEN");
		if (ACCESS_TOKEN == "") {
			Debug.Log("Button Event getDataForChallenge No Access Token in PlayerPrefs");
			doRequestMovesAuthInApp();
			
			yield return new WaitForSeconds(2);
			
			while (PlayerPrefs.GetString("ACCESS_TOKEN")==""){}// IMPERFECT WAY TO YIELD
			
			getMovesAPIData();
		} else {
			getMovesAPIData();
			yield return new WaitForSeconds(1);
		}
	}
	
	IEnumerator timedAPICalls(){
		Debug.Log("ButtonCalls timedAPICalls called");
		
		while (!ChallengeFinished) {
			getMovesAPIData ();
			yield return new WaitForSeconds (APIInterval);
		}
		
		// need to design a flag mechanism to turn off the calls and exit the function.
	}


	public void completeWaterBottleChallenge(){

		JavaCallback javaCallback = GameObject.Find("JavaCallback").GetComponent<JavaCallback>();
		//Water Bottle Testing String -- Success
		string temp_string_water_success = "{\"status\": \"completed\",\"name\": \"gray and black adidas sports bottle\"}";

		javaCallback.onReturnImageKeyword (temp_string_water_success);
	}

	public void doSomethingWithData(){
		jsonDataObj.doSomethingWithData ();
	}

}
