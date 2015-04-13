using UnityEngine;
using System.Collections;

public class ButtonEvent : MonoBehaviour {

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
