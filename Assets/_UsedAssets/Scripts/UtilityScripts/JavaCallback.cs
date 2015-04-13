using UnityEngine;
using System.Collections;
using SimpleJSON;


public class JavaCallback : MonoBehaviour {

/*
 * Data Format:
 * 
 	{
    "status": "completed",
    "name": "white digital ac monitor"
	}
 */

	//Water Bottle Testing String -- Fail
	string temp_string_water_fail = "{\"status\": \"completed\",\"name\": \"arwa bottled water\"}";
	
	//Water Bottle Testing String -- Success
	string temp_string_water_success = "{\"status\": \"completed\",\"name\": \"gray and black adidas sports bottle\"}";

	//AC testing string
	string temp_string = "{\"status\": \"completed\",\"name\": \"white digital ac monitor\"}";

	string[] wordsListForName;

	JSONImageKeywordsObject theObj;

	public void Start(){

		theObj = GameObject.Find("JSONImageKeywordsObject").GetComponent<JSONImageKeywordsObject>();

		Debug.Log ("JavaCallback Start is Called");
//		onReturnImageKeyword (temp_string);
	}

	void onActivityResult(string theString){
		Debug.Log ("onActivityResult in Unity is Called: "+theString);

		///?code=h4MjiL7u785Ysp_Z0_9aYGrXwHmJEIP0hI5n1rBAbdMwi2p1M3zvISp96z_99ToG&state=88725247

		string[] result = theString.Split('=');
		string t_string = result [1];
		result = t_string.Split ('&');
		t_string = result [0];
		
		Debug.Log ("the Code is: "+t_string);
		PlayerPrefs.SetString ("CODE", t_string);
		GameObject APIObj = GameObject.Find ("APIRequests");
		APIObj.GetComponent<APIRequests> ().callGetToken ();

		//GameObject APIButtonObj = GameObject.Find("APIButton");
		//api.GetComponent<APIRequests>().callGetToken ();
	}

	void onImageResult(){
		Debug.Log ("JavaCallback onImageResult called");
	}

	void onGettingImageKeyword(){
		//do loading stuff while waiting for image keywords.
	}

	public void onReturnImageKeyword(string theData){

		SimpleJSON.JSONNode theJsonNode = JSON.Parse(theData);
		theObj.JSONData = theJsonNode;

		wordsListForName = getWordsList (theJsonNode);

		theObj.wordsListForName = this.wordsListForName;
		theObj.verifyChallenges ();
	}

	public string[] getWordsList(JSONNode theJsonNode){
		string nameString = theJsonNode["name"];
		string[] theWordsList = nameString.Split (' ');
		
		Debug.Log ("This is nameString: " + nameString);
		for (int i =0;i<theWordsList.Length; i++)
		Debug.Log ("This is the wordsList: " + theWordsList[0]+ " "+ theWordsList[1]);

		return theWordsList;
	}
}