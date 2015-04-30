using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine.UI;

public class MovesAPIRequests : MonoBehaviour {

	//public APIInfo apiInfo;

	public string screenShotURL= "http://www.my-server.com/cgi-bin/screenshot.pl";
		
	private static string movesAuthUrl = "https://api.moves-app.com/oauth/v1/access_token?grant_type=authorization_code";
	private static string movesApiUrl = "https://api.moves-app.com/api/1.1/user/summary/daily/";

	public static string MOVES_ACCESS_TOKEN = "M4gZwNSV6fnxFsMF9tSdJ8B0lylooCxc7ai90OhXtXcrAu6ACls6jfzJnC9E2yCJ";

	//public static string ACCESS_TOKEN = "";
	public static string CLIENT_ID = "81BlGaldSj5KIjUdz374fcMocXbu6AMC";
	public static string CLIENT_SECRET = "uXeALhVX4zefkW7j73tVMtKE35R0777z8XmK14yaOp91sE41XrvcWfx5q9N9evvc";
	public static string CODE="";
	public static string REDIRECT_URI = "/";

	public DateClass dateObj;
	public string dateString = "20151010";

	JSONDataObject jsonDataObj;
	public SimpleJSON.JSONNode JSONData;


	public void Awake(){
		Debug.Log ("MovesAPIRequests Awake called");

		if (PlayerPrefs.GetString("CLIENT_ID")=="")
			PlayerPrefs.SetString("CLIENT_ID",CLIENT_ID);
		
		if (PlayerPrefs.GetString("CLIENT_SECRET")=="")
			PlayerPrefs.SetString("CLIENT_SECRET",CLIENT_SECRET);

		if (MOVES_ACCESS_TOKEN == "") {
			Debug.Log("MOVES_ACCESS_TOKEN is empty, requesting one from playerPrefs.");
			MOVES_ACCESS_TOKEN = PlayerPrefs.GetString ("MOVES_ACCESS_TOKEN");
		}
	}

	public void Start(){
		
		Debug.Log ("MovesAPIRequests Start called");
		
		jsonDataObj = GameObject.Find ("JSONDataObject").GetComponent<JSONDataObject> ();
		JSONData = jsonDataObj.JSONData;

		dateObj = GameObject.Find ("DateObject").GetComponent<DateClass> ();
	}

	public void callGetData(){
		Debug.Log("MovesAPIRequests callGetData is called");
		StartCoroutine (getData ());
	}
	
	public void callGetToken () {
		Debug.Log("callGetToken is Called!");
		StartCoroutine (getToken ());	
	}

	IEnumerator getData(){
		Debug.Log ("APIRequests getData called");
		string api = getAPIString ();

		WWW request = new WWW(api);
		yield return request;
		if (request.error == null || request.error == ""){

			Debug.Log(request.text);

			SimpleJSON.JSONNode N = JSON.Parse(request.text);
			var newJSONObj = N[0];

			storeDataObj(newJSONObj);

			Debug.Log(newJSONObj);
			Debug.Log("^^^^This is the data ^^^^");

		}else{
			Debug.Log("WWW error: " + request.error);
		}
	}

	//store the newly acquired JSONObj into the Gameobject call "JSONDataObject" field "JSONData"
	public void storeDataObj(SimpleJSON.JSONNode JSONObj)
	{
		jsonDataObj.JSONData = JSONObj;
	}

	public string getAPIString(){
		Debug.Log("MovesAPIRequests getAPIString is Called!");

		if (MOVES_ACCESS_TOKEN == "") {
			Debug.Log("MOVES_ACCESS_TOKEN is empty, requesting one from playerPrefs.");
			MOVES_ACCESS_TOKEN = PlayerPrefs.GetString ("MOVES_ACCESS_TOKEN");
		}

		dateString = dateObj.getCurrentDateString ();
		return movesApiUrl + dateString + "?access_token=" + MOVES_ACCESS_TOKEN;
	}

	IEnumerator getToken(){
		
		Debug.Log("MovesAPIRequests getToken is Called!");

		movesAuthUrl = getAuthString ();

		WWWForm form = new WWWForm ();

		form.AddField ("some field","some data");
		WWW w = new WWW (movesAuthUrl, form);
		yield return w;

		if (!string.IsNullOrEmpty(w.error)) {
			Debug.Log("something went wrong with retreiving the token");
			Debug.Log(w.error);
		}
		else {
			Debug.Log("Success getting the Access Token!!");
			Debug.Log(w.text);
			storeToken(w);
		}

	}

	public string getAuthString(){
		CODE = PlayerPrefs.GetString("CODE");
		return movesAuthUrl + "&code=" + CODE + "&client_id=" + CLIENT_ID + "&client_secret=" + CLIENT_SECRET + "&redirect_uri=" + REDIRECT_URI;
	}

	public void storeToken(WWW w){
		Debug.Log("store Token is called!");
		string tokenString = parseToken (w.text);
		
		PlayerPrefs.SetString ("MOVES_ACCESS_TOKEN", tokenString);

		MOVES_ACCESS_TOKEN = tokenString;

		Debug.Log (MOVES_ACCESS_TOKEN);
		Debug.Log ("This is the access token: ^^");
	}

	public string parseToken(string dataText){
		string[] result = dataText.Split('"');
		string t_string = result [3];
		return t_string;
	}

}

