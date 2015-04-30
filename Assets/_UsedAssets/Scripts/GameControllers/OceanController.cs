using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OceanController : MonoBehaviour {
	
	Vector3 currentSeaLevel;
	Vector3 targetSeaLevel;
	
	Vector3 highestSeaLevel;
	float risingSpeed=0.01f;

	public float startingSeaLevel=150;

	float sealevel_percentage;

	public Image sealevel_Bar;

	public Text SealevelPercentageText;

	// Use this for initialization
	void Start () {
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

		SealevelPercentageText.text = percentage_number.ToString ()+ "%";

		sealevel_Bar.rectTransform.sizeDelta = new Vector2 (100, percentage_number);
	}
}
