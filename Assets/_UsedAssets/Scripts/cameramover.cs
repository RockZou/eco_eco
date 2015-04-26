using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// This class controlls the movement for the camera.
public class CameraMover : MonoBehaviour {


	public float speed;
	// Use this for initialization
	void Start () {
	
	}

	public Text Text;

	// Update is called once per frame
	void Update () {
		float boost = 1.0f;
		if (Input.GetKey (KeyCode.LeftShift)){
			boost = 3.0f;
		} else {
			boost = 1.0f;
		}

		// Maps WASD to move the camera.

		if ( Input.GetKey ( KeyCode.A ) ) 	{ // Time.deltaTime is the fraction of a second in between a frame
			// a value that gets bigger with low FPS, smaller with high FPS
			transform.position += Vector3.right * Time.deltaTime * speed * boost ;
		}

		if ( Input.GetKey ( KeyCode.D ) ) { // Time.deltaTime is the fraction of a second in between a frame
			// a value that gets bigger with low FPS, smaller with high FPS
			transform.position -= Vector3.right * Time.deltaTime * speed * boost ;
		}

		if ( Input.GetKey ( KeyCode.W ) ) { // Time.deltaTime is the fraction of a second in between a frame
			// a value that gets bigger with low FPS, smaller with high FPS
			transform.position -= Vector3.forward * Time.deltaTime * speed * boost ;
		}

		if ( Input.GetKey ( KeyCode.S ) ) { // Time.deltaTime is the fraction of a second in between a frame
			// a value that gets bigger with low FPS, smaller with high FPS
			transform.position += Vector3.forward * Time.deltaTime * speed * boost;
		}

		// Zoom functionality
		transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * 100);
	}	

}