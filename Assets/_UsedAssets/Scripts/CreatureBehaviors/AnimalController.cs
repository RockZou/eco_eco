using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {
	public GameObject theOcean;

    Rigidbody rbody;
	Transform position;
	public float speed = 5f;
	public float smoothTime = 2f;
	public float stopSpeed = 100f;
	public float treshold = 2f;
	public float stopTreshold = 0.5f;

	float boost = 1f;

	Vector3 impactPoint;
	Vector3 currentPosition;
	Vector3 moveDirection;

	Vector3 zeroVelocity = Vector3.zero;

	float initialDistance;
	float slowTreshold;

	bool distanceFlag = true;



	// Use this for initialization
	void Start () {
		Debug.Log ("Physics controller called");
		theOcean = GameObject.Find ("Ocean");
	}

	void Update(){
		Debug.Log (transform);
		
	}

	// FixedUpdate is called one a fixed interval / every physics frame
    // Use this when you are doing with physics

	void FixedUpdate () {
		
//		Vector3 seaPositions = theOcean.GetComponent<Transform>().position;

		Ray cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition);
		RaycastHit cursorRayInfo = new RaycastHit();
		
		if(Physics.Raycast(cursorRay, out cursorRayInfo, 100f)){
			
			if (Input.GetMouseButtonDown(0) ){
				impactPoint = cursorRayInfo.point;
				currentPosition = transform.position;
				distanceFlag = true;
			}
		}
		
		moveDirection = impactPoint - currentPosition;
		
		if (distanceFlag){
			GetComponent<Rigidbody>().velocity = moveDirection.normalized * 5f;
			initialDistance = Vector3.Distance(transform.position, impactPoint);
			distanceFlag = false;
		}

		float distance = Vector3.Distance(transform.position, impactPoint);
		
		slowTreshold = (initialDistance / treshold);
		if ( distance - 1f > slowTreshold){
			GetComponent<Rigidbody>().AddForce( moveDirection.normalized * speed * boost 
			                   , ForceMode.VelocityChange);
		}


		// Ask why overshooting.
		if( distance < slowTreshold && distance > stopTreshold){
			transform.position = Vector3.SmoothDamp(transform.position, 
			                                        impactPoint, 
			                                        ref zeroVelocity, 
			                                        smoothTime);
		
		} else if (distance < stopTreshold){
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}
}
