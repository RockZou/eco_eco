using UnityEngine;
using System.Collections;

public class AnimalRaycast : MonoBehaviour {


	public GameObject theOcean;
	public float speed = 0.5f;
	public float raycast_range = 1f;
	public int underWaterFrameCount = 0;//the number of frames the object is under sea level


	public Vector3 lastFramePosition;

	// Use this for initialization
	public void Start () {
		Debug.Log ("Physics controller called");
		theOcean = GameObject.Find ("Ocean");
		lastFramePosition = new Vector3 (0f, 0f, 0f);
	}
	
	// Dude AI. Creates a ray from the body of the dude. Checks a short distance ( raycast range) to check for colission
	// If there is a colission set a random rotation
	void FixedUpdate () {

		Vector3 waterPositions = theOcean.GetComponent<Transform>().position;
		float seaLevel = waterPositions.y;

//		Debug.Log (transform.position.y);

		GetComponent<Rigidbody>().AddForce(-transform.right * speed, ForceMode.VelocityChange );

		Ray ray = new Ray (transform.position, transform.forward);
		
		if (transform.position.y <= seaLevel) {

			//if this the the 30th continous underwater frame, destroy the game object
			underWaterFrameCount++;
			if (underWaterFrameCount > 30) {
				Object.DestroyObject(this.gameObject);
			}

			GetComponent<Rigidbody> ().velocity = Vector3.zero;

			transform.position = lastFramePosition;

			transform.Rotate (0f, 180, 0f);
			GetComponent<Rigidbody> ().AddForce (transform.forward * speed, ForceMode.VelocityChange);

		} 
		//if the character emerges from the water, reset the frameCount
		else {
			underWaterFrameCount=0;
		}

		if (Physics.Raycast(ray, raycast_range ) ){
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			transform.Rotate(0f, Random.Range(0,120), 0f);
		}
		
		if (transform.position.y > seaLevel) {
			lastFramePosition = transform.position;
		} 

	}
}
