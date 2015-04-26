using UnityEngine;
using System.Collections;
using SimpleJSON;

public class JSONImageKeywordsObject : MonoBehaviour {

	public JSONNode JSONData;
	public string[] wordsListForName;

	public WaterBottleChallenge waterBottleChallenge;

	// Use this for initialization
	void Start () {
		waterBottleChallenge = GameObject.Find ("WaterBottleChallenge").GetComponent<WaterBottleChallenge>();
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	public void onReturnImageKeyword(string nameString){
		
		wordsListForName = getWordsList (nameString);
		
		wordsListForName = this.wordsListForName;
		verifyChallenges ();
	}
	
	public string[] getWordsList(string nameString){
		string[] theWordsList = nameString.Split (' ');
		
		Debug.Log ("This is nameString: " + nameString);
		for (int i =0;i<theWordsList.Length; i++)
			Debug.Log ("This is the wordsList: " + theWordsList[0]+ " "+ theWordsList[1]);
		
		return theWordsList;
	}

	public void verifyChallenges(){

		
		Debug.Log ("JSONImageKeywordsObject verifyChallenges is called");

		int verifyStatus=-1;

		if (waterBottleChallenge.status == WaterBottleChallenge.STARTED) {
			verifyStatus = waterBottleChallenge.onVerify (wordsListForName);
		}

		/*
		if (airConditionerChallenge.status = airConditionerChallenge.STARTED) {
			verifyStatus = waterBottleChallenge.onVerify (wordsListForName);
		}
		*/
		
		Debug.Log ("JSONImageKeywordsObject verifyChallenges challenge status:" + verifyStatus);
	}
}


