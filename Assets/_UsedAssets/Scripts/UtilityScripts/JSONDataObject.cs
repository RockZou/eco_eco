using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;


public class JSONDataObject : MonoBehaviour {

	public SimpleJSON.JSONNode JSONData;

	public void Start(){
	}

	public string getDate(){
		return JSONData ["date"];
	}

	public string getSummary(){
		if (JSONData == null) {
			return "";
		}
		else 
		{
		return JSONData["summary"];
		}
	}

	public string getSteps(){

		Debug.Log ("JSONDataObject getSteps is called");
		return JSONData ["summary"] [0] ["steps"];
	}

	public string getOtherThings(){
		return "";
	}

	public void doSomethingWithData(){
		
		//display full JSONData onto the displayText text field
		
		string dateString = getDate();

		Debug.Log("doing something with Data");
	}
}
