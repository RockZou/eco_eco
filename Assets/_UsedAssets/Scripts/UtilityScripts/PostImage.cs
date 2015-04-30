using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using BestHTTP;
using System.Text;
using SimpleJSON;
using UnityEngine.UI;

public class PostImage:MonoBehaviour{

	public string CloudSightApiUrl = "https://api.cloudsightapi.com/image_requests";
	
	public string CloudSightAPIkey = "eDdEhEKOVJznJRlx-qXwiA";
	public string CloudSightResponseUrl = "http://api.cloudsightapi.com/image_responses/";

	JSONImageKeywordsObject theObj;
	
	JSONNode N;
	Text displayText;
	Text DebugText;
	CamDisplay camDisplay;
	JSONImageKeywordsObject jsonImageKeywordsObj;
	
	bool inProgress;

	// Use this for initialization
	void Start () {
		displayText = GameObject.Find ("DisplayText").GetComponent<Text> ();
		DebugText = GameObject.Find ("DebugText").GetComponent<Text>();
		camDisplay = GameObject.Find("CameraRawImage").GetComponent<CamDisplay>();
		jsonImageKeywordsObj = GameObject.Find ("JSONImageKeywordsObject").GetComponent<JSONImageKeywordsObject>();

		inProgress = false;
		//sendImageToCloudSight ();
	}

	public void sendImageToCloudSight(){

		if (!inProgress) {
			Debug.Log("inProgress is false, starting uploadPNG coroutine");
			inProgress = true;
			StartCoroutine (UploadPNG ());
		} else {
			Debug.Log("an image is being processed!");
		}
	}
	
	IEnumerator UploadPNG() {
		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();

		Debug.Log("UploadPNG is called");

		var tex = new Texture2D (1280,720);

		WWW testImage = new WWW("file://"+Application.persistentDataPath+'/'+"test_image.png");

		yield return testImage;

		DebugText.text += " www object testImage is returned!";

		Debug.Log ("the image file info is "+testImage.text);

		
		DebugText.text += " the image file info is" +testImage.text;

		testImage.LoadImageIntoTexture (tex);

		Debug.Log ("sending the image to the server...");
		var request = new HTTPRequest(new System.Uri(CloudSightApiUrl), HTTPMethods.Post, OnRequestFinished);
											request.SetHeader("Authorization", "CloudSight " + CloudSightAPIkey);
											request.AddBinaryData("image_request[image]",tex.EncodeToPNG(),"test_image.png");
											request.AddField ("image_request[locale]", "en_US");
		                                      request.Send();
	}

	public void OnRequestFinished(HTTPRequest request, HTTPResponse response)
	{
		Debug.Log("Request Finished! Text received: " + response.DataAsText);
		
		string responseString = response.DataAsText;

		N = SimpleJSON.JSON.Parse (responseString);

		string CloudSightToken = N["token"];

		StartCoroutine(GetImageInfo(CloudSightToken));
	}

	IEnumerator GetImageInfo(string CloudSightToken) {
		var theImageInfo = new HTTPRequest(new System.Uri(CloudSightResponseUrl+CloudSightToken), HTTPMethods.Get, onGetImageInfo);
		theImageInfo.SetHeader("Authorization", "CloudSight " + CloudSightAPIkey);
		theImageInfo.Send();
		yield return StartCoroutine(theImageInfo);
		
		string responseString = theImageInfo.Response.DataAsText;
		
		N = SimpleJSON.JSON.Parse (responseString);
		
		Debug.Log(N["status"]);
		string statusString = N["status"];
		Debug.Log ("before while");
		while (statusString!="completed") {

			theImageInfo = new HTTPRequest(new System.Uri(CloudSightResponseUrl+CloudSightToken), HTTPMethods.Get, onGetImageInfo);
			theImageInfo.SetHeader("Authorization", "CloudSight " + CloudSightAPIkey);
			theImageInfo.Send();
			yield return StartCoroutine(theImageInfo);

			Debug.Log("inside while ");
			statusString = N["status"];
			Debug.Log("status is "+ statusString);
			
			if (statusString=="skipped")
			{
				Debug.Log("image is skipped because " + N["reason"]);
				return false;
			}
			if (statusString=="timeout")
			{
				Debug.Log("timeout");
				return false;
			}
		}

		onImageRecognitionFinished ();
	}

	public void onImageRecognitionFinished(){

		camDisplay.GetComponent<RawImage>().texture= camDisplay.cam;
		inProgress = false;
		Debug.Log ("PostImage onImageRecognitinFinished is called");

		string statusString = N ["status"];

		Debug.Log ("statusString is "+ statusString);

		if (statusString == "completed") {
			Debug.Log ("N['status'] is completed");
			jsonImageKeywordsObj.onReturnImageKeyword (N ["name"]);
		} else {
			Debug.Log("Image recognition is skipped because it's" + N["reason"]+ "challenge is not verified.");
		}

	}

	void onGetImageInfo(HTTPRequest request, HTTPResponse response){
		Debug.Log("Image Info is back! Text received: " + response.DataAsText);
		
		string responseString = response.DataAsText;
		
		N = SimpleJSON.JSON.Parse (responseString);
	}

}