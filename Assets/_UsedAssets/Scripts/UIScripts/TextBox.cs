using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextBox : MonoBehaviour {
	public Text Info_text;
	bool resettingColor;
	bool fadingText;
	Color targetColor;
	Color originalColor;
	Color t_color;
	Color t_textColor;
	Color targetTextColor;

	public Color warningColor;
	public Color rewardColor;
	public Color infoColor;

	float colorChangingIndex=0.0f;
	float textFadingIndex=0.0f;
	float lerpFrames;
	float textFadingFrames;
	float rate;
	float textFadingRate;

	float	timeToFading=5.0f;
	// Use this for initialization
	void Awake () {
		lerpFrames = 30.0f;
		textFadingFrames=60.0f;
		rate = 1.0f / lerpFrames;
		textFadingRate = 1.0f / textFadingFrames;

		warningColor = new Color (0.8f, 0.2f, 0.2f, 0.5f);
		
		rewardColor = new Color(0.953f,0.97f,0.37f,0.5f);

		infoColor = new Color (0.8f,0.8f,0.8f,0.5f);

		resettingColor = false;
		originalColor = GetComponent<Image> ().color;
		Debug.Log (originalColor);
	}

	void Start(){
		setText ("Welcome to Eco Eco! \nBe Eco-Friendly and Build Your Eco-system!|info");
	}

	void Update(){
		if (resettingColor) {
//			Debug.Log("TextBox Update resettingColor is true");
			resetColor();
		}
		if (fadingText) {
//			Debug.Log("TextBox Update fadingText");
			fadeText();
		}
	}

	// setText with three different blink colors
	// pass in the text with the status string attached after a '|'
	// for example for a warning text "rising sealevel has destroyed a plant!"
	// send
	// 			"rising sealevel has destroyed a plant!|warning" 
	// to the setText function

	public void setText(string theText_status){
		string[] substrings = theText_status.Split('|');
		string theText = substrings [0];
		Debug.Log ("theText is: "+ theText);
		string status = substrings [1];
		Debug.Log ("status is: " + status);

		
		Info_text.color = new Color (1.0f,1.0f,1.0f,1.0f);
		Info_text.text = theText;
		startFadingText ();

		if (status == "warning")
			changeColor (warningColor);
		else if (status == "info")
			changeColor (infoColor);
		else if (status == "reward")
			changeColor (rewardColor);
		else {
			Debug.Log("status is incorrect! use 'warning', 'info',or 'reward'");
		}
	}

	void startFadingText(){
		t_textColor = Info_text.color;
		targetTextColor = new Color (1.0f,1.0f,1.0f,1.0f);
		timeToFading = 5.0f;
		fadingText = true;
	}

	void fadeText(){

		if (timeToFading > 0) {
			Debug.Log(timeToFading);
			timeToFading -= Time.deltaTime;
		} else {
			textFadingIndex += textFadingRate;
			if (textFadingIndex <= 1.1f) {
				t_textColor = Color.Lerp (targetTextColor, new Color (targetTextColor.r, targetTextColor.g, targetTextColor.b, 0),textFadingIndex);
				Info_text.color = t_textColor;
			} else {
				textFadingIndex = 0.0f;
				fadingText = false;
			}
		}
	}

	void resetColor(){
		colorChangingIndex += rate;
		if (colorChangingIndex <= 1.1f) {
			t_color = Color.Lerp (targetColor, originalColor, colorChangingIndex);
			GetComponent<Image> ().color = t_color;
		}
		else {
			colorChangingIndex=0f;
			resettingColor = false;
		}
	}

	public void changeColor(Color targetColor)
	{
		
		Debug.Log ("TextBox changeColor called");
		this.targetColor = targetColor;
		
		Color t_color = GetComponent<Image> ().color;
		t_color = targetColor;
		GetComponent<Image> ().color = t_color;

		resettingColor = true;
	}
}
