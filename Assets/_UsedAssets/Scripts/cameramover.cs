using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// This class controlls the movement for the camera.
public class cameramover : MonoBehaviour {


	public float speed = 100f;
	// Use this for initialization
	void Start () {
	
	}

	public Text Text;

	// Update is called once per frame
	void Update () {
		float boost = 1.5f;
		if (Input.GetKey (KeyCode.LeftShift)){
			boost = 3.0f;
		} else {
			boost = 1.5f;
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




	/*

	TOUCH MOVE

	// If there are two touches on the device...
	if (Input.touchCount == 2)
	{
		// Store both touches.
		Touch touchZero = Input.GetTouch(0);
		Touch touchOne = Input.GetTouch(1);
		
		// Find the position in the previous frame of each touch.
		Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
		Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
		
		// Find the magnitude of the vector (the distance) between the touches in each frame.
		float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
		float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
		
		// Find the difference in the distances between each frame.
		float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
		
		// If the camera is orthographic...
		if (camera.isOrthoGraphic)
		{
			// ... change the orthographic size based on the change in distance between the touches.
			camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;
			
			// Make sure the orthographic size never drops below zero.
			camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
		}
		else
		{
			// Otherwise change the field of view based on the change in distance between the touches.
			camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
			
			// Clamp the field of view to make sure it's between 0 and 180.
			camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
		}
	}
}
*/


}