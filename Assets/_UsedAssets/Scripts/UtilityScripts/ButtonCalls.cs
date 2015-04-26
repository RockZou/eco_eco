using UnityEngine;
using System.Collections;

public class ButtonCalls : MonoBehaviour {

	// No setter function for APIInterval yet. Should belong to API class.
	private int APIInterval = 10;// represents how often (in seconds/time) are the API calls made.

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

	public void doRequestMovesAuthInApp()
	{
		Debug.Log("Button is Clicked!");
//		if (APIRequests.ACCESS_TOKEN=="")
		Bridge.doRequestMovesAuthInApp ();
		//Bridge.ShowCamera (12345);
	}

	public void getMovesAPIData(){
		Debug.Log ("getMovesAPIData called");
		movesAPIObj.callGetData ();
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

		//ChallengeFinished = !ChallengeFinished;
	}

	public void startChallenge(WaterBottleChallenge waterBottleChallenge){

		//Bridge.startCloudSight ();

		waterBottleChallenge = GameObject.Find ("WaterBottleChallenge").GetComponent<WaterBottleChallenge>();
		waterBottleChallenge.onStartChallenge ();

	}

	IEnumerator getDataForChallenge(){
		Debug.Log ("Button Event getDataForChallenge called");
		
		string MOVES_ACCESS_TOKEN = PlayerPrefs.GetString ("MOVES_ACCESS_TOKEN");
		if (MOVES_ACCESS_TOKEN == "") {
			Debug.Log("Button Event getDataForChallenge No Access Token in PlayerPrefs");
			doRequestMovesAuthInApp();
			
			yield return new WaitForSeconds(2);
			
			while (PlayerPrefs.GetString("MOVES_ACCESS_TOKEN")==""){}// IMPERFECT WAY TO YIELD
			
			getMovesAPIData();
		} else {
			getMovesAPIData();
			yield return new WaitForSeconds(1);
		}
	}
	
	IEnumerator timedAPICalls(){
		Debug.Log("ButtonCalls timedAPICalls called");
		
		while (true) {
			Debug.Log("inside while");
			getMovesAPIData ();
			yield return new WaitForSeconds (APIInterval);
		}
		
		// need to design a flag mechanism to turn off the calls and exit the function.
	}


}
