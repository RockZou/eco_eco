using UnityEngine;
using System.Collections;

public class MobileCameraMover : MonoBehaviour {
	public float minDist = 2.0f;
	public float maxDist = 5.0f;
	public Transform projectile;
	private Vector3 moveVec;
	private float startZ;
	private float actualDist;
	private Vector2 dragStartPos;

	float westBound = 1137.783f;
	float eastBound = -46.1283f;
	float northBound = 149.6171f;
	float southBound = 1391.943f;
	float inZoomBound= 185.0933f;
	float outZoomBound = 437.8882f;
	
	
	public float movesensitivityX = 20.0f;
	public float movesensitivityY = 20.0f;
	
	void Start () 
	{        
	}
	
	void Update () 
	{

		Touch[] touches = Input.touches;
		//This section for move the camera position only limited values . 
		// You can Change the values for your requirements.
		//Here the camera will move with in your required portion on the screen.

		// This sets the bounderies.
		if ( projectile.position.x > westBound){
			projectile.position = new Vector3( westBound, projectile.position.y, projectile.position.z);
		}

		if ( projectile.position.x < eastBound){
			projectile.position = new Vector3( eastBound, projectile.position.y, projectile.position.z);
		}

		if ( projectile.position.z < northBound){
			projectile.position = new Vector3( projectile.position.x, projectile.position.y, northBound);
		}

		if ( projectile.position.z > southBound){
			projectile.position = new Vector3( projectile.position.x, projectile.position.y, southBound);
		}

		if ( projectile.position.y < inZoomBound){
			projectile.position = new Vector3( projectile.position.x, inZoomBound, projectile.position.z);
		}

		if ( projectile.position.y > outZoomBound){
			projectile.position = new Vector3( projectile.position.x, outZoomBound, projectile.position.z);
		}

		// camera movement with touch gestures. 3 fingers
		if ( Input.touchCount == 1){
			if (touches[0].phase == TouchPhase.Moved){
				Vector2 delta = touches[0].deltaPosition;

				float position_x = delta.x * movesensitivityX * Time.deltaTime;
				float position_y = delta.y * movesensitivityY * Time.deltaTime;

				projectile.position = new Vector3(projectile.position.x + position_x, projectile.position.y , projectile.position.z + position_y);
			}

		}


		//This section for pinch Zooming on screen.        
		if (Input.touchCount == 2) 
		{
			Touch touch = Input.GetTouch(0);
			Touch touch1 = Input.GetTouch(1);
			if (touch.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved) 
			{
				Vector2 curDist = touch.position - touch1.position;
				Vector2 prevDist = (touch.position - touch.deltaPosition) - (touch1.position - touch1.deltaPosition);
				float delta = curDist.magnitude - prevDist.magnitude;
				Camera.main.transform.Translate(0,0,delta * .5f);
			}
		}
	}
}