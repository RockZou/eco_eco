using UnityEngine;
using System.Collections;

public class OceanController : MonoBehaviour {

	Vector3 currentSeaLevel;
	Vector3 targetSeaLevel;

	float risingSpeed=0.1f;

	// Use this for initialization
	void Start () {
		targetSeaLevel = transform.position;
		targetSeaLevel.y = 170;
	}
	
	// Update is called once per frame
	void Update () {		
		targetSeaLevel += new Vector3 (0, risingSpeed, 0);
		seaLevelUpdate (); 
	}

	public void changeSeaLevel(float targetLevel)
	{
		targetSeaLevel.y = targetLevel;
	}

	public void seaLevelUpdate()
	{
		transform.position = Vector3.Lerp (transform.position, targetSeaLevel, Time.deltaTime);
	}
}
