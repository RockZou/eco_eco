using UnityEngine;
using System.Collections;

public class MovesApiChallenge : MonoBehaviour {
		
	private int APIInterval = 10;// represents how often (in seconds/time) are the API calls made.
	
	public static int NOT_STARTED=0;
	public static int STARTED=1;
	public static int SUCCESS=2;
	public static int FAILED=3;
	public int rewardCoconut = 500;
	public int rewardSealevelDrop = 50;

	public int targetSteps = 5000;
	public int initialStepCount;
	public int currentStepsCount;
	public int stepsWalked=0;


	public DateClass dateObj;
	public string startDate;
	

	public GameObject MovesChallengeModal_Main;
	public GameObject MovesChallengeModal_Complete;
	
	public GameObject CoconutText;
	public AudioSource achievement;


	public int status;

	OceanController theOcean;
	
	public PostImage postImage;
	public MovesAPIRequests movesAPIObj;
	public JSONDataObject jsonDataObj;

	public void Awake(){
		status = NOT_STARTED;
		theOcean = GameObject.Find ("Ocean").GetComponent<OceanController>();
		movesAPIObj = GameObject.Find ("MovesAPIRequests").GetComponent<MovesAPIRequests> ();
		jsonDataObj = GameObject.Find ("JSONDataObject").GetComponent<JSONDataObject> ();
		dateObj = GameObject.Find ("DateObject").GetComponent<DateClass> ();
		startDate = dateObj.getCurrentDateString ();
	}
	public void Start(){
		callGetDataForChallenge ();
	}


	public void onStartChallenge(){
		Debug.Log ("MovesApiChallenge onStartChallenge is called");

		status = STARTED;
		stepsWalked = 0;

		string theSummary = jsonDataObj.getSummary ();
		Debug.Log ("the Summary is " + theSummary);

		string theSteps = jsonDataObj.getSteps ();

		theSteps = jsonDataObj.getSteps ();

		initialStepCount = int.Parse(theSteps);

		Debug.Log ("the initialStepCount is "+ initialStepCount);
	}

	public void onCompleteChallenge(){

		if (status == STARTED) {
			status = SUCCESS;
			MovesChallengeModal_Complete.SetActive (true);
			giveReward ();
		}
	}
	
	public void giveReward(){
		achievement.Play ();

		Vector3 seaLevel = theOcean.transform.position;
		theOcean.changeSeaLevel (seaLevel.y - rewardSealevelDrop);
		
		CoconutText.GetComponent<CoconutNumber>().add (rewardCoconut);
	}
	
	public void onFailChallenge(){
		Debug.Log ("MovesApiChallenge onFailChallenge is called");
		status = FAILED;
	}
	
	public void onRetryChallenge(){
		Debug.Log ("MovesApiChallenge onRetryChallenge is called");
		onStartChallenge ();
	}
	
	public void callGetDataForChallenge(){		
		Debug.Log("MovesApiChallenge callGetDataForChallenge called");
		StartCoroutine (getDataForChallenge());
	}
	
	public void callTimedAPICalls(){
		Debug.Log("MovesApiChallenge callTimedAPICalls called");
		StartCoroutine (timedAPICalls());
	}
	
	IEnumerator getDataForChallenge(){
		Debug.Log ("MovesApiChallenge getDataForChallenge called");

		string MOVES_ACCESS_TOKEN = "";
		
		if (MovesAPIRequests.MOVES_ACCESS_TOKEN == "") {
			MOVES_ACCESS_TOKEN = PlayerPrefs.GetString ("MOVES_ACCESS_TOKEN");
		}
		else {
			MOVES_ACCESS_TOKEN = MovesAPIRequests.MOVES_ACCESS_TOKEN;
		}

		if (MOVES_ACCESS_TOKEN == "") {
			Debug.Log("MovesApisChallenge getDataForChallenge No Access Token in PlayerPrefs");
			//doRequestMovesAuthInApp();
			
			yield return new WaitForSeconds(2);
			
			while (PlayerPrefs.GetString("MOVES_ACCESS_TOKEN")==""){
				Debug.Log("inside While");
				yield return new WaitForSeconds(0.25f);
			}// IMPERFECT WAY TO YIELD
			
			getMovesAPIData();

		} else {

			getMovesAPIData();

			yield return new WaitForSeconds(1);
		}
	}

	public void doRequestMovesAuthInApp()
	{
		Debug.Log("MovesApiChallenge doRequestMovesAuthInApp is called");
		
		if (MovesAPIRequests.MOVES_ACCESS_TOKEN == "") {
			Debug.Log("MovesApiChallenge MOVES_ACCESS_TOKEN == \"\" ");
			Bridge.doRequestMovesAuthInApp ();
		}

	}


	public void getMovesAPIData(){
		
		Debug.Log ("getMovesAPIData called");
		
		movesAPIObj.callGetData ();
	}
	
	IEnumerator timedAPICalls(){
		Debug.Log("MovesApiChallenge timedAPICalls is called");

		string currentDate = dateObj.getCurrentDateString ();

		while (stepsWalked<targetSteps && currentDate==startDate) {

			Debug.Log("inside while");

			string theSummary = jsonDataObj.getSummary();
			Debug.Log("theSummary is " + theSummary);

			getMovesAPIData ();
			yield return new WaitForSeconds (APIInterval);
		}
		// need to design a flag mechanism to turn off the calls and exit the function.
	}
	
	public void setAPIInterval(int newInterval)
	{
		APIInterval = newInterval;
	}

	
}
