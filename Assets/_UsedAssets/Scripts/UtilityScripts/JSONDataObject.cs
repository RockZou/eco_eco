using UnityEngine;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;


public class JSONDataObject : MonoBehaviour {

	public SimpleJSON.JSONNode JSONData;
	
	//UI Elements
	public Button authButton;
	public Button apiButton;
	public Text displayText;

	public void Start(){
//		authButton = GameObject.Find ("AuthButton").GetComponent<Button>();
//		apiButton = GameObject.Find ("APIButton").GetComponent<Button>();
		displayText = GameObject.Find("DisplayText").GetComponent<Text>();
//		displayText.text = "This is the Original Text";
	}

	public string getDate(){
		return JSONData ["date"];
	}

	public string getSummary(){
		return JSONData["summary"];
	}

	public string getOtherThings(){
		return "";
	}

	public void doSomethingWithData(){
		
		//display full JSONData onto the displayText text field
		
		string dateString = getDate();

		displayText.text = dateString;

		Debug.Log("doing something with Data");
	}
}
