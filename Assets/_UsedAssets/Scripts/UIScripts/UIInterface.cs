using UnityEngine;
using System.Collections;

public class UIInterface : MonoBehaviour {

	public GameObject CameraRawImage;
	public GameObject APIRequests;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startImageRecognitionApi(){
		CameraRawImage.GetComponent<CamDisplay> ().startImageRecognitionApi ();
	}
}
