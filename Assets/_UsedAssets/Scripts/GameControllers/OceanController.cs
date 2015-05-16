using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OceanController : MonoBehaviour {
	
	Vector3 currentSeaLevel;
	Vector3 targetSeaLevel;
	
	Vector3 highestSeaLevel;
	public float risingSpeed=0.01f;

	public float startingSeaLevel=150;

	float sealevel_percentage;
	int p_percentageNumber;

	public Image sealevel_Bar;

	public Text SealevelPercentageText;
	public Text SealevelPercentageText_main;
	public GameObject TextBox;

	public GameObject RTSCamera;

	// Use this for initialization
	void Start () {
		p_percentageNumber=0;
		targetSeaLevel = transform.position;
		targetSeaLevel.y = startingSeaLevel;
//		highestSeaLevel = targetSeaLevel;
		highestSeaLevel = new Vector3 (0f,200f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (targetSeaLevel.y<highestSeaLevel.y)
			targetSeaLevel += new Vector3 (0, risingSpeed, 0);
		
		seaLevelUpdate (); 
	}
	
	public void changeSeaLevel(float targetLevel)
	{
		targetSeaLevel.y = targetLevel;
	}

	public void setRisingSpeed(float theSpeed){
		Debug.Log ("the rising speeding is changed to " + theSpeed);
		risingSpeed = theSpeed;
	}

	public void seaLevelUpdate()
	{
		transform.position = Vector3.Lerp (transform.position, targetSeaLevel, Time.deltaTime);

		sealevel_percentage = targetSeaLevel.y / highestSeaLevel.y;

		int percentage_number = (int) (sealevel_percentage * 100);

		if (percentage_number >= 80&&p_percentageNumber<80) {
			Color t_color = new Color (0.8f, 0.1f, 0.1f, 1.0f);
			SealevelPercentageText.color = t_color;
			SealevelPercentageText_main.color = t_color;
			TextBox.GetComponent<TextBox>().setText("The Sealevel is dangerous for your ecosystem! Complete the challenges to save your island!|warning");
		} else if (percentage_number < 80&&p_percentageNumber>=80)		
		{ // percentage_number<80)
			Color t_color = new Color(0f, 0.533f,0.333f,1.0f);
			SealevelPercentageText.color = t_color;
			SealevelPercentageText_main.color = t_color;
		}

		SealevelPercentageText.text = percentage_number.ToString ()+ "%";
		SealevelPercentageText_main.text = percentage_number.ToString () + "%";
		sealevel_Bar.rectTransform.sizeDelta = new Vector2 (100, percentage_number);
		
		p_percentageNumber = percentage_number;
	}
}
