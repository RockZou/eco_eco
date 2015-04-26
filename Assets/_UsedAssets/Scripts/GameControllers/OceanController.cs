using UnityEngine;
using System.Collections;

public class OceanController : MonoBehaviour {
	
	Vector3 currentSeaLevel;
	Vector3 targetSeaLevel;
	
	Vector3 highestSeaLevel;
	public float maxSea;
	public GameObject oceanLayer;
	
	float risingSpeed=0.1f;
	
	// Use this for initialization
	void Start () {
		targetSeaLevel = transform.position;
		targetSeaLevel.y = maxSea;
		
		highestSeaLevel = targetSeaLevel;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (targetSeaLevel.y<highestSeaLevel.y)
			targetSeaLevel += new Vector3 (0, risingSpeed, 0);

		oceanLayer.transform.position = new Vector3(oceanLayer.transform.position.x,
		                                            targetSeaLevel.y + 1f,
		                                            oceanLayer.transform.position.z);
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
