using UnityEngine;
using System.Collections;

public class AnimalMovement : MonoBehaviour {
	
	public float speed = 0.5f;
	public float raycast_range = 1f;
	public GameObject oceanLayer;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Dude AI. Creates a ray from the body of the dude. Checks a short distance ( raycast range) to check for colission
	// If there is a colission set a random rotation
	bool turned = false;
	void FixedUpdate () {
		
		GetComponent<Rigidbody>().AddForce(-transform.right * speed, ForceMode.VelocityChange );
		
		Ray ray = new Ray (transform.position, transform.forward);
		
		if (Physics.Raycast(ray, raycast_range ) ){
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			
			transform.Rotate(0f, Random.Range(0,359), 0f);
			
		}


	
		RaycastHit waterRayHit ;
		if(Physics.Raycast(transform.position, Vector3.down + Vector3.forward, out waterRayHit, 10f)) {

			//Debug.Log (waterRayHit.collider.gameObject.name);
			if(waterRayHit.collider.gameObject == oceanLayer && !turned){
				Debug.Log("Ocean layer is hit.");
				transform.Rotate(0f, 180f, 0f);
				transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
				turned = true;
			}
			if(waterRayHit.collider.gameObject.name == "Terrain" && turned){
				//turned = false;
			}
		}
	}
}
